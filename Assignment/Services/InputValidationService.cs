using System.Text.RegularExpressions;

namespace Assignment.Services
{
    public interface IInputValidationService
    {
        int[] ConvertToIntArray(string numbers);
        string SanitizeNumbers(string numbers);
    }


    public class InputValidationService : IInputValidationService
    {
        private readonly Regex numberValidation = new Regex("-?\\d+");
        public int[] ConvertToIntArray(string numbers)
        {
            return numbers.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
        }
        public string SanitizeNumbers(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return string.Empty;
            MatchCollection matches = numberValidation.Matches(numbers);
            if (matches.Count == 0) throw new ArgumentException("Invalid numbers supplied");
            return string.Join(" ", matches.Select(m => m.Value));
        }



    }
}
