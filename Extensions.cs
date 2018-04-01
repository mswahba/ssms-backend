using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Remotion.Linq.Parsing.Structure;
using SSMS.EntityModels;
using SSMS.Users;

namespace SSMS
{
    public static class Extensions
    {
        //Get the generated SQL statement from the linq query 
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

        public static User Map(SignUp signup)
        {
            return new User()
            {
                UserId = signup.UserId,
                UserPassword = signup.UserPassword,
                UserType = signup.UserType,
                SubscribeDate = DateTime.UtcNow.AddHours(3),
                IsActive = false
            };
        }
        //an extension function that takes type that it will be attached to 
        // and the property name which we want to get its value  
        //Normaly we use item.[propName] if we know it exactly 
        //but here we dont know it as it comes as a parameter,
        //so we use reflection to get the property based on its name at runtime  
        //'this' keyword means this function becomes an extension function on the type given after it 
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
            TypeCode typeCode = System.Type.GetTypeCode(propertyType);
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
        //function to get the property to use it later 
        public static PropertyInfo GetProperty(this object obj, string propName)
        {
            return obj.GetType()
                    .GetProperty(propName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        }
        //a func that takes a comma separated string, 
        // removes any empty elements (white spaces or empty strings)
        public static string RemoveEmptyElements(this string str)
        {
            // convert comma separated list to array so that we can remove empty items 
            string[] strArr = str.Split(',', StringSplitOptions.RemoveEmptyEntries);
            //Remove empty items from array using where() 
            //and trim each element using select()
            strArr = strArr.Where(item => !string.IsNullOrWhiteSpace(item))
                            .Select(item => item.Trim())
                            .ToArray();
            //convert fieldsArr array to a string with ',' separator 
            return string.Join(',', strArr);
        }
        public static string[] RemoveEmptyElementsArr(this string str)
        {
            // convert comma separated list to array so that we can remove empty items 
            string[] strArr = str.Split(',', StringSplitOptions.RemoveEmptyEntries);
            //Remove empty items from array using where() 
            //and trim each element using select(), then return it 
            return strArr.Where(item => !string.IsNullOrWhiteSpace(item))
                            .Select(item => item.Trim())
                            .ToArray();
        }
    }
}