using System;

namespace BeiDream.Core.Validations
{
    /// <summary>
    /// Can be added to a method to disable auto validation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class DisableValidationAttribute : Attribute
    {
        
    }
}