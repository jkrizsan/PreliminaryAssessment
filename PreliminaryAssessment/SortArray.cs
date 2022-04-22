using System;
using BusinessLogic.Sorting;
using Microsoft.Extensions.Logging;

namespace PreliminaryAssessment
{
    internal class SortArray
    {
        private static ILogger _logger;

        private static ISortingService _sortingService;

        /// <summary>
        /// Entry point of the Application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            init();

            double[] arr = _sortingService.CreateArrayWithRandomNumbers(11);

            _sortingService.BubbleSort(arr, true);

            _sortingService.BubbleSort(arr, false);

            _sortingService.MergeSort(arr, true);

            _sortingService.MergeSort(arr, false);


            _logger.LogInformation($"The {nameof(SortArray)} application is ended");

            Console.ReadKey();
        }

        private static void init()
        {
            _logger = ServiceProviderFactory
                .GetService<ILoggerFactory>()
                .CreateLogger<SortArray>();

            _sortingService = ServiceProviderFactory.GetService<ISortingService>();

            _logger.LogInformation($"The {nameof(SortArray)} application is Initialized and Started");
        }
    }
}
