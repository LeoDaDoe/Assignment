using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Services.Tests
{
    [TestClass()]
    public class LoggingServiceTests
    {
        ILoggingService _loggingService;
        public LoggingServiceTests() {
            _loggingService = new LoggingService();
        }

        [DataTestMethod]
        [DataRow(new long[] {1,1,1})]
        [DataRow(new long[] {})]
        public void Test_DataSavedToFile_LogPerformance(long[] times)
        {
            string? insertionSortTime, countingSortTime, bubbleSortTime;


            _loggingService.LogPerformance(times);
            using (StreamReader perfFile = new StreamReader("results/performance.txt"))
            {
                insertionSortTime = perfFile.ReadLine()?.Split(" ")[2];           
                countingSortTime = perfFile.ReadLine()?.Split(" ")[2];          
                bubbleSortTime = perfFile.ReadLine()?.Split(" ")[2];              
            }

            Assert.AreEqual(insertionSortTime, times[0].ToString());
            Assert.AreEqual(countingSortTime, times[1].ToString());
            Assert.AreEqual(bubbleSortTime, times[2].ToString());

        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 1, 1 })]
        [DataRow(new int[] { })]
        public void Test_DataSavedToFile_LogSortResultTest(int[] numbers)
        {
            string? sortedNumbers, validationSortedNumbers;
            validationSortedNumbers = string.Join(' ', numbers.Select(n => n.ToString()).ToArray());

            _loggingService.LogSortResult(numbers);
            using (StreamReader perfFile = new StreamReader("results/sort.txt"))
            {
                sortedNumbers = perfFile.ReadLine();
            }

            Assert.AreEqual(validationSortedNumbers, sortedNumbers);

        }
    }
}