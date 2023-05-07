using System.Text.RegularExpressions;

namespace Assignment.Services
{
    public interface IApiInputValidationService
    {
        int[] ParseNumbers(string numbers);
        string SanitizeNumbers(string numbers);
    }


    public class ApiInputValidationService : IApiInputValidationService
    {
        private readonly Regex numberValidation = new Regex("-?\\d+");
        public int[] ParseNumbers(string numbers)
        {
            return numbers.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
        }
        public string SanitizeNumbers(string numbers)
        {
            MatchCollection matches = numberValidation.Matches(numbers);
            if (matches.Count == 0) throw new ArgumentException("Invalid numbers supplied");
            return string.Join(" ", matches.Select(m => m.Value));
        }



    }
}
