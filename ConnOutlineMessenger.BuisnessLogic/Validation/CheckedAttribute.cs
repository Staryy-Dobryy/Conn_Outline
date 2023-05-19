using System.ComponentModel.DataAnnotations;

namespace ConnOutlineMessenger.Validation
{
    public class CheckedAttribute : ValidationAttribute
    {
        public CheckedAttribute()
        {
            ErrorMessage = "Сhecked value must be True";
        }
        public override bool IsValid(object? obj)
        {
            if (obj is bool value && value is true) return true;
            return false;
        }
    }
}
