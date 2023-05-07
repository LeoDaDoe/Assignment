using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace Assignment.Services.Tests
{
    [TestClass()]
    public class SortingServiceTest
    {
        ISortingService _sortingService;
        public SortingServiceTest() {
            _sortingService = new SortingService();
        }

        [DataTestMethod]
        [DataRow(new int[] { 615, 984, 1, 1, 0, -10, 15, 1, -10, 50, 10, 10, 10, 1 })]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { })]

        public void Test_CorrectSortedSequence_InsertionSort(int[] inputNumbers)
        {
            int[] internallySortedNumbers = new int[inputNumbers.Length];
            int[] validationSort = new int[inputNumbers.Length];
            inputNumbers.CopyTo(internallySortedNumbers,0);
            inputNumbers.CopyTo(validationSort,0);

            validationSort = _sortingService.InsertionSort(validationSort);
            Array.Sort(internallySortedNumbers);

            CollectionAssert.AreEqual(internallySortedNumbers, validationSort);

        }

        [DataTestMethod]
        [DataRow(new int[] { 615, 984, 1, 1, 0, -10, 15, 1, -10, 50, 10, 10, 10, 1 })]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { })]
        public void Test_CorrectSortedSequence_CountingSort(int[] inputNumbers)
        {
            int[] internallySortedNumbers = new int[inputNumbers.Length];
            int[] validationSort = new int[inputNumbers.Length];
            inputNumbers.CopyTo(internallySortedNumbers, 0);
            inputNumbers.CopyTo(validationSort, 0);

            validationSort = _sortingService.CountingSort(validationSort);
            Array.Sort(internallySortedNumbers);

            CollectionAssert.AreEqual(internallySortedNumbers, validationSort);
        }

        [DataTestMethod]
        [DataRow(new int[] { 615, 984, 1, 1, 0, -10, 15, 1, -10, 50, 10, 10, 10, 1 })]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { })]
        public void Test_CorrectSortedSequence_BubbleSort(int[] inputNumbers)
        {
            int[] internallySortedNumbers = new int[inputNumbers.Length];
            int[] validationSort = new int[inputNumbers.Length];
            inputNumbers.CopyTo(internallySortedNumbers, 0);
            inputNumbers.CopyTo(validationSort, 0);

            validationSort = _sortingService.BubbleSort(validationSort);
            Array.Sort(internallySortedNumbers);

            CollectionAssert.AreEqual(internallySortedNumbers, validationSort);
        }
    }
}