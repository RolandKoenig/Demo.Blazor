using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Shared.DataAnnotations
{
    // Implementation based on https://gist.github.com/nicocrm/496f1d9b4a137ab3cb36

    /// <summary>
    /// Validation attribute ensuring a date property is greater or smaller than another one specified.
    /// </summary>
    public class IsDateAfterOrBeforeAttribute : ValidationAttribute
    {
        private readonly string _compareTo;
        private readonly DateCompareMode _compareMode;
        private readonly bool _allowEqualDates;

        public IsDateAfterOrBeforeAttribute(string compareTo, DateCompareMode compareMode, bool allowEqualDates = false)
        {
            _compareTo = compareTo;
            _compareMode = compareMode;
            _allowEqualDates = allowEqualDates;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyTestedInfo = validationContext.ObjectType.GetProperty(_compareTo);
            if (propertyTestedInfo == null)
            {
                return new ValidationResult($"Unknown property {_compareTo}");
            }

            var propertyTestedValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);
            if (!(value is DateTimeOffset))
            {
                return new ValidationResult($"Given value is not a DateTimeOffset!");
            }
            if (!(propertyTestedValue is DateTimeOffset))
            {
                return new ValidationResult($"Property {_compareTo} is not a DateTimeOffset!");
            }

            switch(_compareMode)
            {
                case DateCompareMode.After:
                    if ((DateTimeOffset)value < (DateTimeOffset)propertyTestedValue ||
                        (!_allowEqualDates && value == propertyTestedValue))
                    {
                        return new ValidationResult($"Timestamp {validationContext.DisplayName} must be after {_compareTo}");
                    }
                    break;

                case DateCompareMode.Before:
                    if ((DateTimeOffset)value > (DateTimeOffset)propertyTestedValue ||
                        (!_allowEqualDates && value == propertyTestedValue))
                    {
                        return new ValidationResult($"Timestamp {validationContext.DisplayName} must be after {_compareTo}");
                    }
                    break;
            }

            return ValidationResult.Success;
        }
    }
}
