using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Remotion.Linq.Parsing.Structure;
using UAParser;

namespace SSMS
{
  public static class Extensions
  {
    // Get the generated SQL statement from the linq query
    #region toSQL
    private static readonly TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();
    private static readonly FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");
    private static readonly PropertyInfo NodeTypeProviderField = QueryCompilerTypeInfo.DeclaredProperties.Single(x => x.Name == "NodeTypeProvider");
    private static readonly MethodInfo CreateQueryParserMethod = QueryCompilerTypeInfo.DeclaredMethods.First(x => x.Name == "CreateQueryParser");
    private static readonly FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");
    private static readonly PropertyInfo DatabaseDependenciesField = typeof(Database).GetTypeInfo().DeclaredProperties.Single(x => x.Name == "Dependencies");
    public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
    {
      if (!(query is EntityQueryable<TEntity>) && !(query is InternalDbSet<TEntity>))
        throw new ArgumentException("Invalid query");
      var queryCompiler = (QueryCompiler)QueryCompilerField.GetValue(query.Provider);
      var nodeTypeProvider = (INodeTypeProvider)NodeTypeProviderField.GetValue(queryCompiler);
      var parser = (IQueryParser)CreateQueryParserMethod.Invoke(queryCompiler, new object[] { nodeTypeProvider });
      var queryModel = parser.GetParsedQuery(query.Expression);
      var database = DataBaseField.GetValue(queryCompiler);
      var databaseDependencies = (DatabaseDependencies)DatabaseDependenciesField.GetValue(database);
      var queryCompilationContext = databaseDependencies.QueryCompilationContextFactory.Create(false);
      var modelVisitor = (RelationalQueryModelVisitor)queryCompilationContext.CreateQueryModelVisitor();
      modelVisitor.CreateQueryExecutor<TEntity>(queryModel);
      return modelVisitor.Queries.First().ToString();
    }
    public static string ToSql(this IQueryable query)
    {
      var queryCompiler = (QueryCompiler)QueryCompilerField.GetValue(query.Provider);
      var nodeTypeProvider = (INodeTypeProvider)NodeTypeProviderField.GetValue(queryCompiler);
      var parser = (IQueryParser)CreateQueryParserMethod.Invoke(queryCompiler, new object[] { nodeTypeProvider });
      var queryModel = parser.GetParsedQuery(query.Expression);
      var database = DataBaseField.GetValue(queryCompiler);
      var databaseDependencies = (DatabaseDependencies)DatabaseDependenciesField.GetValue(database);
      var queryCompilationContext = databaseDependencies.QueryCompilationContextFactory.Create(false);
      var modelVisitor = (RelationalQueryModelVisitor)queryCompilationContext.CreateQueryModelVisitor();
      modelVisitor.CreateQueryExecutor<dynamic>(queryModel);
      return modelVisitor.Queries.First().ToString();
    }

    #endregion

    // an extension function that takes type that it will be attached to
    // and the property name which we want to get its value
    // Normally, we use item.[propName] if we know it exactly
    // but here we don't know it as it comes as a parameter,
    // so we use reflection to get the property based on its name at runtime
    // 'this' keyword means this function becomes an extension function on the type given after it
    public static object GetValue(this object obj, string propName)
    {
      //Get property info
      var prop = obj.GetProperty(propName.Trim());
      if (prop == null)
        return null;
      return prop.GetValue(obj);
    }
    public static void SetValue(this object obj, string propName, object value)
    {
      var prop = obj.GetProperty(propName);
      if (prop == null)
        return;
      //check if type is nullable, if so return its underlying type , if not, return type
      var propertyType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
      TypeCode typeCode = Type.GetTypeCode(propertyType);
      switch (typeCode)
      {
        case TypeCode.Boolean:
          prop.SetValue(obj, Convert.ToBoolean(value), null);
          break;
        case TypeCode.String:
          prop.SetValue(obj, Convert.ToString(value), null);
          break;
        case TypeCode.Byte:
          prop.SetValue(obj, Convert.ToByte(value), null);
          break;
        case TypeCode.SByte:
          prop.SetValue(obj, Convert.ToSByte(value), null);
          break;
        case TypeCode.UInt16:
          prop.SetValue(obj, Convert.ToUInt16(value), null);
          break;
        case TypeCode.UInt32:
          prop.SetValue(obj, Convert.ToUInt32(value), null);
          break;
        case TypeCode.UInt64:
          prop.SetValue(obj, Convert.ToUInt64(value), null);
          break;
        case TypeCode.Int16:
          prop.SetValue(obj, Convert.ToInt16(value), null);
          break;
        case TypeCode.Int32:
          prop.SetValue(obj, Convert.ToInt32(value), null);
          break;
        case TypeCode.Int64:
          prop.SetValue(obj, Convert.ToInt64(value), null);
          break;
        case TypeCode.Single:
          prop.SetValue(obj, Convert.ToSingle(value), null);
          break;
        case TypeCode.Double:
          prop.SetValue(obj, Convert.ToDouble(value), null);
          break;
        case TypeCode.Decimal:
          prop.SetValue(obj, Convert.ToDecimal(value), null);
          break;
        case TypeCode.DateTime:
          prop.SetValue(obj, Convert.ToDateTime(value), null);
          break;
        case TypeCode.Object:
          if (prop.PropertyType == typeof(Guid) || prop.PropertyType == typeof(Guid?))
          {
            prop.SetValue(obj, Guid.Parse(value.ToString()), null);
            return;
          }
          prop.SetValue(obj, value, null);
          break;
        default:
          prop.SetValue(obj, value, null);
          break;
      }
    }
    // function to return the PropertyInfo of the given propName
    public static PropertyInfo GetProperty(this object obj, string propName)
    {
      return obj.GetType()
                .GetProperty(propName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
    }
    // function to return Array of All PropertiesInfo of the given Object
    public static PropertyInfo[] GetProperties(this object obj)
    {
      return obj.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);
    }
    // Prepending the Root Directory Path To the given filePath
    public static string ToFullPath(this string filePath)
    {
      var exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
      Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
      var appRoot = appPathMatcher.Match(exePath).Value;
      return Path.Combine(appRoot, filePath);
    }
    // A Generic function that takes A JSON filePath and a propName
    // and reads the json file, convert it to T type object
    // finally returns the value of specific prop (propName)
    public static string GetJsonValue<T>(this string filePath, string propName)
    {
      // getting the full filePath then reads the json file
      string json = File.ReadAllText(filePath.ToFullPath());
      // Takes JSON string and converts it to an instance of (T) class
      // by setting Values from JSON file to Matching properties in (T) class
      var obj = JsonConvert.DeserializeObject<T>(json);
      // Return the value of specific prop (propName)
      return obj.GetValue(propName).ToString();
    }
    // A Function that takes string and split it by the givin separator
    // then removes any empty elements (white spaces or empty strings)
    // and return the resulted string
    public static string RemoveEmptyElements(this string str, Char separator)
    {
      // convert comma separated list to array so that we can remove empty items
      string[] strArr = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
      //Remove empty items from array using where()
      //and trim each element using select()
      strArr = strArr.Where(item => !string.IsNullOrWhiteSpace(item))
                      .Select(item => item.Trim())
                      .ToArray();
      //convert fieldsArr array to a string with ',' separator
      return string.Join(separator, strArr);
    }
    // A Function that takes string and split it by the givin separator
    // then removes any empty elements (white spaces or empty strings)
    // and return the resulted Array
    public static string[] SplitAndRemoveEmpty(this string str, Char separator)
    {
      // convert comma separated list to array so that we can remove empty items
      string[] strArr = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
      //Remove empty items from array using where()
      //and trim each element using select(), then return it
      return strArr.Where(item => !string.IsNullOrWhiteSpace(item))
                      .Select(item => item.Trim())
                      .ToArray();
    }
    // get comma separated string of all props [that represent table fields i.e without navigation props]
    public static string GetPrimitivePropsNames(this object obj)
    {
      return string.Join(",",
        obj.GetProperties()
          .Where(prop => Type.GetTypeCode(Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType) != TypeCode.Object)
          .Select(prop => $"[{prop.Name}]")
      );
    }
    // get comma separated string of all props [that represent table fields i.e without navigation props] values
    // in case of [first prop i.e PK] => "@newId"
    // in case of propType is [string - date] => surround with one quote [needed for sql]
    // in case of propType is [boolean] => convert it to "1" Or "0"
    // otherwise => value
    public static string GetPrimitivePropsValues(this object obj)
    {
      return string.Join(",",
        obj.GetProperties()
          .Where(prop => Type.GetTypeCode(Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType) != TypeCode.Object)
          .Select( (prop,i) => {
            if(i == 0)
              return "@newId";
            if(Type.GetTypeCode(Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType) == TypeCode.String || Type.GetTypeCode(Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType) == TypeCode.DateTime)
              return $"'{prop.GetValue(obj).ToString()}'";
            if(Type.GetTypeCode(Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType) == TypeCode.Boolean )
              return Convert.ToBoolean(prop.GetValue(obj)) == true ? "1" : "0";
            return prop.GetValue(obj).ToString();
          })
      );
    }
    // get the client device info from User-Agent Request Header using UAParser
    public static string GetDeviceInfo(this HttpRequest req)
    {
      var dInfo = Parser.GetDefault().Parse(req.Headers["User-Agent"].ToString());
      return $"{dInfo.Device.Family}|{dInfo.OS.Family}|{dInfo.UA.Family}";
    }
    // get the full user [person] name based on lang [Ar-En]
    public static string GetFullName(this Person person, string lang)
    {
      string fName = "FName"+lang;
      string mName = "MName"+lang;
      string gName = "GName"+lang;
      string lName = "LName"+lang;
      return $"{person.GetValue(fName)} {person.GetValue(mName)} {person.GetValue(gName)} {person.GetValue(lName)}";
    }

  }
}