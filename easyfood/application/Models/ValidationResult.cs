namespace Easyfood.Application.Models
{
    public class ValidationResult
    {
        public bool HasErrors => _errors.Count > 0;

        public IReadOnlyList<string> Errors => _errors;
        private readonly List<string> _errors;

        public string ConcatenatedErrors() => string.Join(';', _errors);

        public ValidationResult()
        {
            _errors = new List<string>();
        }

        public void AddError(string error)
        {
            _errors.Add(error);
        }
    }
}