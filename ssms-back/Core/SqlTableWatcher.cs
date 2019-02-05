using System;
using System.Linq;
using System.Collections.Generic;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using SSMS.EntityModels;
using SSMS.Hubs;
using AutoMapper;

namespace SSMS
{
  public static class SqlTableWatcher
  {
    // hold the db connection string key
    private static string key = "ConnectionStrings:server:assadara_ssms";
    // hold the signalR clientMethod name
    private static readonly string _clientMethod = "onChange";
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
    // do the needed action on every [Insert - Update - Delete] operation
    private async static void OnChange<T>(object sender, RecordChangedEventArgs<T> e)
      where T : class, new()
    {
      switch (e.ChangeType)
      {
        case ChangeType.Insert:
          Console.WriteLine($"{e.Entity} has been inserted");
          // await _dbHub.Clients.All.SendAsync(_clientMethod, new { Action = "Insert", Record = e.Entity });
          await _dbHub.Clients.Group(_db.Model.FindEntityType(e.Entity.GetType()).Relational().TableName).SendAsync(_clientMethod, new { Action = "Insert", Record = e.Entity });
          break;
        case ChangeType.Update:
          Console.WriteLine($"{e.Entity} has been updated");
          // await _dbHub.Clients.All.SendAsync(_clientMethod, new { Action = "Update", Record = e.Entity });
          await _dbHub.Clients.Group(_db.Model.FindEntityType(e.Entity.GetType()).Relational().TableName).SendAsync(_clientMethod, new { Action = "Update", Record = e.Entity });
          break;
        case ChangeType.Delete:
          Console.WriteLine($"{e.Entity} has been deleted");
          // await _dbHub.Clients.All.SendAsync(_clientMethod, new { Action = "Delete", Record = e.Entity });
          await _dbHub.Clients.Group(_db.Model.FindEntityType(e.Entity.GetType()).Relational().TableName).SendAsync(_clientMethod, new { Action = "Delete", Record = e.Entity });
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