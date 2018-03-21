using System;
using System.Reflection;
using SSMS.EntityModels;
using SSMS.Users;

namespace SSMS
{
    public static class Extensions
    {
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
        public static object GetValue(this object obj, string propName)
        {
            //Get property info  
            var prop = obj.GetProperty(propName);
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

    }
}