using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Square
{
    /// <summary>
    /// Class of the Square Service
    /// </summary>
    public class SquareService: ISquareService
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="loggerFactory"></param>
        public SquareService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SquareService>();
        }

        public int FindLargestSquare(byte[,] matrix)
        {
            _logger.LogInformation($"The {nameof(FindLargestSquare)} process is started!");

            int rowsCount = matrix.GetLength(0);
            int columnsCount = matrix.GetLength(1);

            int[,] newMatrix = new int[rowsCount, columnsCount];
            Array.Copy(matrix, 0, newMatrix, 0, matrix.Length);

            for (int i = 1; i < rowsCount; i++)
            {
                for (int j = 1; j < columnsCount; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        newMatrix[i, j] = estimateItem(newMatrix, i, j);
                    }
                    else
                    {
                        newMatrix[i, j] = 0;
                    }
                }
            }

            _logger.LogInformation($"The {nameof(FindLargestSquare)} process is ended!");

            return newMatrix.Cast<int>().Max();
        }

        private int estimateItem(int[,] newMatrix, int i, int j)
            => 1 + 
            Math.Min(newMatrix[i, j - 1], Math.Min(newMatrix[i - 1, j], newMatrix[i - 1, j - 1]));
    }
}
