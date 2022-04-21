using Microsoft.Extensions.Logging;

namespace BusinessLogic.Sorting
{
    /// <summary>
    /// Class of the Sorting Service
    /// </summary>
    public class SortingService: ISortingService
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="loggerFactory"></param>
        public SortingService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SortingService>();
        }

        /// <inheritdoc />
        public void BubbleSort(double[] arr, bool isAsc)
        {
            _logger.LogInformation("Sorting is started!");

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (ascOrDesc(arr[i], arr[j], isAsc))
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            _logger.LogInformation("Sorting is ended!");
        }

        private bool ascOrDesc(double first, double second, bool isAsc)
            => isAsc ? first > second : first < second;
    }
}
