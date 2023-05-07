using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Assignment.Services
{

    public interface IApiRequestProcessingService
    {
        void ProcessNumbers(string numbers);
        string? FetchLastSortResult();
    }


    public class ApiRequestProcessingService : IApiRequestProcessingService
    {
        ILoggingService loggingService;
        ISortingService sortingService;
        IInputValidationService inputValidationService;
        public ApiRequestProcessingService(ILoggingService loggingService, ISortingService sortingService, IInputValidationService inputValidationService)
        {
            this.loggingService = loggingService;
            this.sortingService = sortingService;
            this.inputValidationService = inputValidationService;
        }

        private readonly Stopwatch _stopwatch = new Stopwatch();

        private void MeasurePerformance(string numbers)
        {
            long[] elapsedTime = new long[3];

            _stopwatch.Start();
            _ = sortingService.InsertionSort(inputValidationService.ConvertToIntArray(numbers));
            _stopwatch.Stop();
            elapsedTime[0] = _stopwatch.ElapsedMilliseconds;
            _stopwatch.Restart();

            _stopwatch.Start();
            _ = sortingService.CountingSort(inputValidationService.ConvertToIntArray(numbers));
            _stopwatch.Stop();
            elapsedTime[1] = _stopwatch.ElapsedMilliseconds;
            _stopwatch.Restart();

            _stopwatch.Start();
            _ = sortingService.BubbleSort(inputValidationService.ConvertToIntArray(numbers));
            _stopwatch.Stop();
            elapsedTime[2] = _stopwatch.ElapsedMilliseconds;
            _stopwatch.Restart();

            loggingService.LogPerformance(elapsedTime);

        }

        public void ProcessNumbers(string numbers)
        {
            int[] sortedNumbers;
            string sanitizedNumbers;

            try
            {
                sanitizedNumbers = inputValidationService.SanitizeNumbers(numbers);

            }
            catch (ArgumentException)
            {
                throw;
            }
            sortedNumbers = sortingService.InsertionSort(inputValidationService.ConvertToIntArray(sanitizedNumbers));

            MeasurePerformance(sanitizedNumbers);
            loggingService.LogSortResult(sortedNumbers);

        }

        public string? FetchLastSortResult()
        {
            string? lastSort;
            if (System.IO.File.Exists("results/sort.txt"))
            {
                using (StreamReader resultFile = new StreamReader("results/sort.txt"))
                {
                    lastSort = resultFile.ReadLine();
                }
                return lastSort;
            }
            return string.Empty;
        }
    }
}
