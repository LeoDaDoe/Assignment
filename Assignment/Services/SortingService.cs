using System.Diagnostics;

namespace Assignment.Services
{
    public interface ISortingService
    {
        int[] InsertionSort(int[] numbers);
        int[] CountingSort(int[] numbers);
        int[] BubbleSort(int[] numbers);

    }

    public class SortingService : ISortingService
    {
        public int[] InsertionSort(int[] numbers)
        {
            Debug.WriteLine("Insertion sort");
            foreach (int number in numbers)
            {
                System.Diagnostics.Debug.WriteLine(number);
            }
            int currentElement, iterationIndex;

            for (int i = 1; i < numbers.Length; ++i)
            {
                currentElement = numbers[i];
                iterationIndex = i - 1;

                while (iterationIndex >= 0 && currentElement < numbers[iterationIndex])
                {
                    numbers[iterationIndex + 1] = numbers[iterationIndex];
                    iterationIndex--;

                }
                numbers[iterationIndex + 1] = currentElement;
            }
            return numbers;

        }
        public int[] CountingSort(int[] numbers)
        {

            Dictionary<int, int> occurrences;
            int maxValue, minValue;

            maxValue = numbers.Max();
            minValue = numbers.Min();
            occurrences = new Dictionary<int, int>(Enumerable.Range(minValue, maxValue - minValue + 1).Select(occurrence => new KeyValuePair<int, int>(occurrence, 0)));

            //Count how many occurrences of a numbe are in the sequence
            foreach (int number in numbers)
            {
                occurrences[number] += 1;
            }

            //n'th element is the sum of all the previous ones
            occurrences.Aggregate(0, (acc, occurrence) => { acc += occurrence.Value; occurrences[occurrence.Key] = acc; return acc; });

            return numbers.Aggregate(new int[numbers.Length], (acc, number) =>
            {
                acc[occurrences[number] - 1] = number;
                occurrences[number] -= 1;
                return acc;
            }
            );
        }
        //I've tried to implement it in my own way, bit wonky
        public int[] BubbleSort(int[] numbers)
        {
            bool sorting;
            int index;

            sorting = true;
            index = 0;

            if (numbers.Length <= 1) return numbers;
            else if (numbers.Length == 2 && numbers[0] > numbers[1])
                (numbers[0], numbers[1]) = (numbers[1], numbers[0]);
            else
                while (true)
                {
                    if (numbers[index] > numbers[index + 1])
                    {
                        (numbers[index], numbers[index + 1]) = (numbers[index + 1], numbers[index]);
                        sorting = true;
                    }
                    if (index + 1 == numbers.Length - 1)
                    {
                        if (sorting == true)
                        {
                            index = 0;
                            sorting = false;
                        }
                        else break;
                    }
                    else
                        index++;

                }
            return numbers;
        }
    }
}
