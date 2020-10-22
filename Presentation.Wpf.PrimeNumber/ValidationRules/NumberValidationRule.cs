using System.Globalization;

namespace Presentation.Wpf.PrimeNumber.ValidationRules
{
    public class NumberValidationRule : INumberValidationRule
    {
        public bool validate(object value)
        {
            return int.TryParse(value.ToString(), NumberStyles.Integer, null, out _);
        }
    }
}
