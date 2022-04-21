using System;
using BusinessLogic.Sorting;
using Microsoft.Extensions.Logging;

namespace PreliminaryAssessment
{
    internal class SortArray
    {
        private static ILogger _logger;

        private static Random _rnd;

        private static ISortingService _sortingService;

        /// <summary>
        /// Entry point of the Application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            init();

            double[] arr = createRandomArray(10);

            _sortingService.BubbleSort(arr, true);

            _sortingService.BubbleSort(arr, false);

            _logger.LogInformation($"The {nameof(SortArray)} application is ended");

            Console.ReadKey();
        }

        private static double[] createRandomArray(int size)
        {
            double[] array = new double[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = Math.Round(_rnd.NextDouble() * size, 2);
            }

            return array;
        }

        private static void init()
        {
            _logger = ServiceProviderFactory
                .GetService<ILoggerFactory>()
                .CreateLogger<SortArray>();

            _sortingService = ServiceProviderFactory.GetService<ISortingService>();

            _rnd = new Random();

            _logger.LogInformation($"The {nameof(SortArray)} application is Initialized and Started");
        }
    }
}
