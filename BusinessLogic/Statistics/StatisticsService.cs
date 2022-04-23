using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Statistics
{
    /// <summary>
    /// Class of the Statistics Service
    /// </summary>
    public class StatisticsService : IStatisticsService
    {
        /// <inheritdoc />
        public StatResponse CalcStatistics(List<int> numbers)
        {
            StatResponse response = new StatResponse()
            {
                Max = getMax(numbers),
                Min = getMin(numbers),
                Average = getAverage(numbers),
                StandardDeviation = getStandardDeviation(numbers)
            };

            return response;
        }

        /// <inheritdoc />
        public List<int> ParseAndValidateInput(string input)
        {
            List<int> validNumbers = new List<int>();

            var rawData = input.Split(',').ToList();

            foreach (var raw in rawData)
            {
                if(Int32.TryParse(raw, out int number))
                {
                    validNumbers.Add(number);
                }
                else
                {
                    throw new ValidationException($"The '{raw}' value is invalid!");
                }
            }

            return validNumbers;
        }

        private double getAverage(List<int> numbers)
            => numbers.Average();

        private int getMax(List<int> numbers)
            => numbers.Max();

        private int getMin(List<int> numbers)
            => numbers.Min();

        private double getStandardDeviation(List<int> numbers)
        {
            double stdDev = 0;
            int count = numbers.Count();

            if (count > 1)
            {
                double avg = numbers.Average();

                double sum = numbers.Sum(d => (d - avg) * (d - avg));

                stdDev = Math.Sqrt(sum / count);
            }

            return stdDev;
        }
    }
}
