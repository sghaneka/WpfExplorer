using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Explorer.Utils.Attributes;

namespace Explorer.Utils.Extensions
{

    public static class EnumExtensions
    {
        public static T ParseEnumWithAttribute<T, A>(string value, Func<A, string> expression)
            where T : struct
            where A : Attribute
        {
            if (!typeof(T).IsEnum) throw new InvalidOperationException("Generic type argument is not System.Enum");
            Type enumType = typeof(T);
            foreach (Enum val in Enum.GetValues(enumType))
            {
                FieldInfo fi = enumType.GetField(val.ToString());
                A[] attributes = (A[])fi.GetCustomAttributes(
                    typeof(A), false);
                if (attributes.Length == 1)
                {
                    A attr = attributes[0];
                    string tempVal = expression(attr);
                    if (tempVal == value)
                    {
                        return (T)Enum.Parse(enumType, val.ToString());
                    }
                }
            }
            // at this point we will try to enum parse the hook
            return (T)Enum.Parse(enumType, value);
        }


        public static TExpected GetAttributeValue<T, TExpected>
            (this Enum enumeration, Func<T, TExpected> expression)
                where T : Attribute
        {
            T attribute = enumeration.GetType().GetMember(enumeration.ToString())[0].GetCustomAttributes(typeof(T), false).Cast<T>().SingleOrDefault();

            if (attribute == null)
                return default(TExpected);

            return expression(attribute);
        }

    }

    public static class Enum<T>
    {
        public static T Parse(string value)
        {
            var enumType = typeof (T);

           // var member = enumType.GetFields()[0].GetValue(T);

            //var tempType = typeof (T);
            //var memInfo = tempType.GetMembers()//
            /*foreach (MemberInfo mi in tempType.GetMembers())
            {
                var attrib = mi.GetCustomAttributes(typeof (ValueMap), false).FirstOrDefault();
                if (attrib != null)
                {
                    var valueMapAttrib = ((ValueMap) attrib);
                    if (valueMapAttrib.ActualValue == value)
                        return Parse(mi.MemberType)
                }
            }*/
            return Parse(value, true);
        }

        

        public static T Parse(string value, bool ignoreCase)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }

        public static bool TryParse(string value, out T returnedValue)
        {
            return Enum<T>.TryParse(value, true, out returnedValue);
        }

        public static bool TryParse(string value, bool ignoreCase, out T returnedValue)
        {
            try
            {
                returnedValue = (T)Enum.Parse(typeof(T), value, ignoreCase);
                return true;
            }
            catch
            {
                returnedValue = default(T);
                return false;
            }
        }
    }
}
