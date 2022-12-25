using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Validation
{
    public static class ValidationMessages
    {

        public static string  InvalidModelStateMessage(string fieldName) => $"Invalid model state for the {fieldName} object.";

        public static string  RequiredMessage(string fieldName) => $"{fieldName} is a required field.";

        public static string MaxLengthMessage(string fieldName, int minSize) => $"Maximum length for the {fieldName} is {minSize} characters.";
        public static string RangeMessage(string fieldName, int minSize) => $"{fieldName} is required and it can't be lower than {minSize}";
    }
}
