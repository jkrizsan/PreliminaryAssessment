using System;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Sorting
{
    /// <summary>
    /// Class of the Sorting Service
    /// </summary>
    public class SortingService: ISortingService
    {
        private readonly Random _rnd;

        private readonly ILogger _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="loggerFactory"></param>
        public SortingService(ILoggerFactory loggerFactory)
        {
            _rnd = new Random();
            _logger = loggerFactory.CreateLogger<SortingService>();
        }

        /// <inheritdoc />
        public void BubbleSort(double[] arr, bool isAscending)
        {
            _logger.LogInformation("Bubble sorting is started!");

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (isAsc(arr[i], arr[j], isAscending))
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            _logger.LogInformation("Bubble sorting is ended!");
        }

        /// <inheritdoc />
        public double[] CreateArrayWithRandomNumbers(int size)
        {
            double[] array = new double[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = Math.Round(_rnd.NextDouble() * size, 2);
            }

            return array;
        }

        /// <inheritdoc />
        public void MergeSort(double[] arr, bool isAsc, int left = 0, int right = -1)
        {
            _logger.LogInformation("Merge sorting is started!");

            mergeSortRecursively(arr, isAsc, left, right);

            _logger.LogInformation("Merge sorting is ended!");
        }

        private void mergeSortRecursively(double[] arr, bool isAsc, int left, int right)
        {
            if (right == -1)
            {
                right = arr.Length - 1;
            }

            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;

                mergeSortRecursively(arr, isAsc, left, mid);
                mergeSortRecursively(arr, isAsc, (mid + 1), right);

                doMerge(arr, left, (mid + 1), right, isAsc);
            }
        }

        private void doMerge(double[] numbers, int left, int mid, int right, bool isAsc)
        {
            double[] temp = new double[numbers.Length];
            int i, leftEnd, numOfElements, index;

            leftEnd = (mid - 1);
            index = left;
            numOfElements = (right - left + 1);

            while ((left <= leftEnd) && (mid <= right))
            {
                if (isLeft(numbers[left], numbers[mid], isAsc))
                {
                    temp[index++] = numbers[left++];
                }
                else
                {
                    temp[index++] = numbers[mid++];
                }
            }

            while (left <= leftEnd)
            {
                temp[index++] = numbers[left++];
            }

            while (mid <= right)
            {
                temp[index++] = numbers[mid++];
            }

            for (i = 0; i < numOfElements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        private bool isAsc(double first, double second, bool isAsc)
            => isAsc ? first > second : first < second;

        private bool isLeft(double first, double second, bool isAsc)
            => isAsc ? first <= second : first >= second;
    }
}
