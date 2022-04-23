using System;
using BusinessLogic.Square;
using PreliminaryAssessment;
using Microsoft.Extensions.Logging;

namespace FindLargestSquare
{
    internal class FindLargestSquare
    {
        private static ILogger _logger;

        private static ISquareService _squareService;

        /// <summary>
        /// Entry point of the Application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            init();

            byte[,] bytes = new byte[5,5]
            {
                { 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1},
                { 0, 1, 1, 1, 1},
                { 0, 0, 1, 1, 0}
            };

            var maxSize = _squareService.FindLargestSquare(bytes);

            _logger.LogInformation($"The {nameof(FindLargestSquare)} application is Ended");

            Console.ReadLine();
        }

        private static void init()
        {
            _logger = ServiceProviderFactory
                .GetService<ILoggerFactory>()
                .CreateLogger<FindLargestSquare>();

            _squareService = ServiceProviderFactory.GetService<ISquareService>();

            _logger.LogInformation($"The {nameof(FindLargestSquare)} application is Initialized and Started");
        }
    }
}
