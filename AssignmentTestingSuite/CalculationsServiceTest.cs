namespace AssignmentTestingSuite
{
    [TestClass]
    public class CalculationsServiceTest
    {
        //The idea of the naming convention for the methods is
        //Test_(What Are we Checking e.g. output or other internal behaviour like exception handling)_(Name of the function)

        private IApiRequestProcessingService _apiRequestProcessingService;

        public CalculationsServiceTest()
        {
            _apiRequestProcessingService = new ApiRequestProcessingService(new LoggingService(),
                new SortingService(),new ApiInputValidationService());

        }


        //I'd use this but we dont really have any stateful attributes to setup
        //[TestInitialize]
        //public void Setup()
        //{

        //}


    }
}