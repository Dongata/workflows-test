namespace workflows.Models
{
    public class ValidationResult
    {
        private ValidationResult(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }

        public bool IsValid { get; set; }

        public string Message { get; set; }

        public static ValidationResult AsValid() => new ValidationResult(true, string.Empty);
        public static ValidationResult AsInvalid(string message) => new ValidationResult(false, message);
    }
}
