﻿namespace Assignment.Services
{
    public interface ILoggingService
    {
        void LogPerformance(long[] times);
        void LogSortResult(int[] sortedNumbers);

    }

    public class LoggingService : ILoggingService
    {
        public LoggingService() {
            Directory.CreateDirectory("results");
        }

        public void LogPerformance(long[] times)
        {
            using (StreamWriter resultFile = new StreamWriter("results/performance.txt", false))
            {
                resultFile.WriteLine("Insertion sort: " + times[0].ToString()+ " ms");
                resultFile.WriteLine("Counting sort: " + times[1].ToString() + " ms");
                resultFile.WriteLine("Bubble sort: " + times[2].ToString() + " ms");
            }
        }

        public void LogSortResult(int[] sortedNumbers)
        {
            using (StreamWriter resultFile = new StreamWriter("results/sort.txt", false))
            {
                resultFile.WriteLine(string.Join(' ', sortedNumbers.Select(n => n.ToString()).ToArray()));
            }
        }


    }
}
