using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

namespace SSMS
{
  public static class SqlTableWatcher
  {
    // get the db connectionString from the appsettings.json
    private static string conStr = Helpers.GetService<IConfiguration>().GetValue<string>("ConStr");
    // do the needed action on every [Insert - Update - Delete] operation
    private static void OnChange<T>(object sender, RecordChangedEventArgs<T> e)
      where T : class, new()
    {
      switch (e.ChangeType)
      {
        case ChangeType.Insert:
          Console.WriteLine($"{e.Entity} has been inserted");
          break;
        case ChangeType.Update:
          Console.WriteLine($"{e.Entity} has been updated");
          break;
        case ChangeType.Delete:
          Console.WriteLine($"{e.Entity} has been deleted");
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
    // finally start the table listners
    // [new()] in Type Constrain means it must be a non abstract class with parameterless constructor
    public static void Watch<T>(string tableName)
      where T : class, new()
    {
      var tableDependency = new SqlTableDependency<T>(conStr, tableName);
      tableDependency.OnError += OnError;
      tableDependency.OnChanged += OnChange;
      tableDependency.Start();
      Console.WriteLine($"SqlTableWatcher Started on: {tableName} table.");
    }    
    // loop through all Table Entities and register SqlTableWatcher
    public static void RegisterAllTableWatchers()
    {
      Helpers.GetAllClasses("SSMS.EntityModels")
              .Where(c => c.Name != "SSMSContext")
              .ToList()
              .ForEach(type => {
                typeof(SqlTableWatcher)
                  .GetMethod("Watch")
                  .MakeGenericMethod(type)
                  .Invoke(Activator.CreateInstance(type), new object[] { type.Name });
              });
    }    
  }
}