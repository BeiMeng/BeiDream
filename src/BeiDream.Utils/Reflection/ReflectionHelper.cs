using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BeiDream.Utils.Reflection
{
    /// <summary>
    /// Defines helper methods for reflection.
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// Gets a list of attributes defined for a class member and it's declaring type including inherited attributes.
        /// </summary>
        /// <typeparam name="TAttribute">Type of the attribute</typeparam>
        /// <param name="memberInfo">MemberInfo</param>
        public static List<TAttribute> GetAttributesOfMemberAndDeclaringType<TAttribute>(MemberInfo memberInfo) 
            where TAttribute : Attribute
        {
            var attributeList = new List<TAttribute>();

            //Add attributes on the member
            if (memberInfo.IsDefined(typeof(TAttribute), true))
            {
                attributeList.AddRange(memberInfo.GetCustomAttributes(typeof(TAttribute), true).Cast<TAttribute>());
            }

            //Add attributes on the class
            if (memberInfo.DeclaringType != null && memberInfo.DeclaringType.IsDefined(typeof(TAttribute), true))
            {
                attributeList.AddRange(memberInfo.DeclaringType.GetCustomAttributes(typeof(TAttribute), true).Cast<TAttribute>());
            }

            return attributeList;
        }
    }
}