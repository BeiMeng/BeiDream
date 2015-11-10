using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeiDream.Core.Validations
{
    public class ValidationException : Exception
    {
        public List<ValidationResult> ValidationErrors { get; set; }

        public ValidationException(string message, List<ValidationResult> validationErrors)
            : base(message)
        {
            ValidationErrors = validationErrors;
        }
    }
}