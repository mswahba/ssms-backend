using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using AutoMapper;
using SSMS.Hubs;
using SSMS.EntityModels;
using SSMS.ViewModels;

namespace SSMS
{
  public static class SqlTableWatcher
  {
    // hold the db connection string key
    private static string key = "ConnectionStrings:server:assadara_ssms";
    // hold the signalR clientMethod name
    private static readonly string _clientMethod = "onChange";
    // hold the tableName string
    private static string _tableName;
    // hold all SqlTablesWatchers
    private static Dictionary<string,dynamic> tablesWatchers = new Dictionary<string,dynamic>();
    // hold the types list
    private static List<Type> types = new List<Type>();
    // get the db connectionString from the appsettings.json
    private static string conStr = Helpers.GetService<IConfiguration>().GetValue<string>(key);
    // get the ef db context from the DI
    private static SSMSContext _db = Helpers.GetService<SSMSContext>();
    // get the IMapper from the DI
    private static IMapper _mapper = Helpers.GetService<IMapper>();
    // get the DbHub Context from the DI
    public static IHubContext<DbHub> _dbHub;
    // fill the types List to be used in both [WatchAll - StopAll] Methods
    private static void GetTypes(string[] typeNames)
    {
      // if there are no types then filter out the SSMSContext
      if (typeNames == null)
        types = Helpers.GetAllClasses("SSMS.EntityModels")
                  .Where(c => c.Name != "SSMSContext")
                  .ToList();
      // else only get the listed types
      else
        types = typeNames
                  .Select(tName => Type.GetType($"SSMS.EntityModels.{tName}"))
                  .ToList();
    }
    // map the changed entity to the corresponding view entity
    private static dynamic DoMap<T>(T entity)
    {
      // getting the view model name from the entity name
      string vEName = $"SSMS.ViewModels._V{entity.GetType().Name}";
      // get the view model type from the view model name
      Type vEType = Type.GetType(vEName);
      // must Initialize the Mapper with mapping profile before using _mapper object
      // when using _mapper in a time earlier than its AutoInitialize operation
      Mapper.Initialize(x => x.AddProfile<Mappings>());
      // dynamically call _mapper.map generic method to map entity to view model
      // get all methods then get all map generic methods finally get the first one
      // [because _mapper has many overloaded map methods]
      // finally return the resulted mapped view entity
      return _mapper.GetType()
        .GetMethods()
        .Where(m => m.IsGenericMethod && m.Name == "Map" )
        .ToArray()[0]
        .MakeGenericMethod(vEType)
        .Invoke(_mapper, new object[] { entity });
    }
    // perform realtime db changes: on every [Insert - Update - Delete] db operation
    // SqlTableDependency will send [actionType (insert-update-delete) - entity]
    // then we deliver them to DbHub clients
    // which in turn send them to clients who have joined the group
    // whose name is the same as the (affected) table name
    private async static void OnChange<T>(object sender, RecordChangedEventArgs<T> e)
      where T : class, new()
    {
      _tableName = _db.Model.FindEntityType(e.Entity.GetType()).Relational().TableName;
      switch (e.ChangeType)
      {
        case ChangeType.Insert:
          Console.WriteLine($"{e.Entity} has been inserted");
          // await _dbHub.Clients.All.SendAsync(_clientMethod, new { Table = _tableName, Action = "Insert", Entity = e.Entity });
          await _dbHub.Clients.Group(_tableName).SendAsync(_clientMethod, new { Table = _tableName, Action = "Insert", Entity = DoMap<T>(e.Entity) });
          break;
        case ChangeType.Update:
          Console.WriteLine($"{e.Entity} has been updated");
          // await _dbHub.Clients.All.SendAsync(_clientMethod, new { Table = _tableName, Action = "Update", Entity = e.Entity });
          await _dbHub.Clients.Group(_tableName).SendAsync(_clientMethod, new { Table = _tableName, Action = "Update", Entity = DoMap<T>(e.Entity) });
          break;
        case ChangeType.Delete:
          Console.WriteLine($"{e.Entity} has been deleted");
          // await _dbHub.Clients.All.SendAsync(_clientMethod, new { Table = _tableName, Action = "Delete", Entity = e.Entity });
          await _dbHub.Clients.Group(_tableName).SendAsync(_clientMethod, new { Table = _tableName, Action = "Delete", Entity = DoMap<T>(e.Entity) });
          break;
      }
    }
    // Log the SqlTableDependency Error Message
    private static void OnError(object sender, ErrorEventArgs e)
    {
      Console.WriteLine($"SqlTableDependency error: {e.Error.Message}");
    }
    // get the tableDependency for a the given SQL Table
    // and Add event Handler [Method] to [OnChanged - OnError] to handle
    // finally start the table listeners
    // [new()] in Type Constrain means it must be a non abstract class with parameterless constructor
    public static void Watch<T>(string tableName)
      where T : class, new()
    {
      // hold the current table watcher
      var tableWatcher = new SqlTableDependency<T>(conStr, tableName);
      // bind tableDependency events
      tableWatcher.OnError += OnError;
      tableWatcher.OnChanged += OnChange;
      // start the tableDependency service
      tableWatcher.Start();
      // add the current tableDependency to the tablesWatchers dictionary
      tablesWatchers.Add(tableName,tableWatcher);
      // log to the console
      Console.WriteLine($"SqlTableWatcher Started on: {tableName} table.");
    }
    public static void Stop(string tableName)
    {
      // stop the tableDependency service
      tablesWatchers[tableName].Stop();
      // log to the console
      Console.WriteLine($"SqlTableWatcher Stopped on: {tableName} table.");
    }
    // loop through Entities [all - given types] and register [start] SqlTableWatcher
    public static void WatchAll(string[] typeNames = null)
    {
      // fill the TypeList [types]
      GetTypes(typeNames);
      // register sqltablewatchers
      types.ForEach(type =>
      {
        typeof(SqlTableWatcher)
          .GetMethod("Watch")
          .MakeGenericMethod(type)
          .Invoke(Activator.CreateInstance(type), new object[] { _db.Model.FindEntityType(type).Relational().TableName });
      });
    }
    // loop through Entities [all - given types] and stop SqlTableWatcher
    public static void StopAll(string[] typeNames)
    {
      // fill the TypeList [types]
      GetTypes(typeNames);
      // stop sqltablewatchers
      types.ForEach(type => Stop(_db.Model.FindEntityType(type).Relational().TableName));
    }
  }
}