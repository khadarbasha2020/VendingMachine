using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Enums
{
    public static class EnumExtension
    {
        /// <summary>
        /// Returns value of custom code attribute type code
        /// </summary>
        /// <param name="enumVal"></param>
        /// <returns></returns>
        public static string GetEnumCode(this Enum enumVal)
        {
            return enumVal.GetType().GetMember(enumVal.ToString()).FirstOrDefault().GetCustomAttribute<CodeAttribute>().Name;
        }
        /// <summary>
        /// Returns value of custom valid attribute type code
        /// </summary>
        /// <param name="enumVal"></param>
        /// <returns></returns>
        public static bool GetEnumIsValid(this Enum enumVal)
        {
            return enumVal.GetType().GetMember(enumVal.ToString()).FirstOrDefault().GetCustomAttribute<ValidAttribute>().Name == "Valid";
        }
    }
}
