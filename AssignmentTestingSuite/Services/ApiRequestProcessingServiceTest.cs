namespace Assignment.Tests.Services
{
    [TestClass]
    public class ApiInputValidationService
    {
        //The idea of the naming convention for the methods is
        //Test_(What Are we Checking e.g. output or other internal behaviour like exception handling)_(Name of the function)

        private IApiRequestProcessingService _apiRequestProcessingService;

        public ApiInputValidationService()
        {
            _apiRequestProcessingService = new ApiRequestProcessingService(new LoggingService(),
                new SortingService(), new InputValidationService());

        }


        [DataTestMethod]
        [DataRow("1 2 3 4 5", "1 2 3 4 5")]
        [DataRow("1 A A24 5", "1 5 24")]
        [DataRow("afew984 feaw98 s994s  22     -1", "-1 22 98 984 994")]
        [DataRow("A", "")]
        [DataRow("11111111111111111111111111111111111", "11111111111111111111111111111111111")]

        public void Test_CorrectPipelineResult_ProcessNumbers(string inputNumbers, string expectedNumbers)
        {
            string? sortedNumbers;

            _apiRequestProcessingService.ProcessNumbers(inputNumbers);
            using (StreamReader sortResult = new StreamReader("results/sort.txt"))
            {
                sortedNumbers = sortResult.ReadLine();
            }

            Assert.AreEqual(expectedNumbers, sortedNumbers, "The sorted numbers do not match the expected sequence");
        }

        [DataTestMethod]
        [DataRow("1 2 3 4 5", "1 2 3 4 5")]
        [DataRow("1 A A24 5", "1 5 24")]
        [DataRow("afew984 feaw98 s994s  22     -1", "-1 22 98 984 994")]
        [DataRow("A", "")]
        [DataRow("11111111111111111111111111111111111", "11111111111111111111111111111111111")]

        public void Test_CorrectOutput_FetchSortResult(string inputNumbers, string expectedNumbers)
        {
            string? sortedNumbers;

            _apiRequestProcessingService.ProcessNumbers(inputNumbers);
            sortedNumbers = _apiRequestProcessingService.FetchLastSortResult();

            Assert.AreEqual(expectedNumbers, sortedNumbers, "The sorted numbers do not match the expected sequence");
        }

    }
}