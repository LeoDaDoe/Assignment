using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Assignment.Services.Tests
{
    [TestClass()]
    public class InputValidationServiceTests
    {
        IInputValidationService _inputValidationService;
        private readonly Regex numberValidation = new Regex("-?\\d+");
        public InputValidationServiceTests()
        {
            _inputValidationService = new InputValidationService();
        }

        [DataTestMethod]
        [DataRow("1 32 98 169 61 1686 A", new int[] { 1, 32, 98, 169, 61, 1686, 65 })]
        [DataRow(null, new int[] { })]
        [DataRow("1 2 3", new int[] {1,2,3 })]
        [DataRow("", new int[] { })]
        public void Test_CorrectOutput_ConvertToIntArray(string inputNumbers, int[] expectedNumbers)
        {
            int[] validationArray = new int[expectedNumbers.Length];

            validationArray = _inputValidationService.ConvertToIntArray(inputNumbers);

            CollectionAssert.AreEqual(validationArray, expectedNumbers);

        }

        [DataTestMethod]
        [DataRow("1 32 98 169 61 1686 A", "1 32 98 169 61 1686")]
        [DataRow(null, "")]
        [DataRow("1 2 3", "1 2 3")]
        [DataRow("", "")]
        public void SanitizeNumbersTest(string inputNumbers, string expectedNumbers)
        {
            string validationString;

            validationString = _inputValidationService.SanitizeNumbers(inputNumbers);

            Assert.AreEqual(expectedNumbers, validationString);   
        }
    }
}