using System;
using BusinessLogic.Statistics;
using System.ComponentModel.DataAnnotations;

namespace GiveMeSomeStats
{
    internal class GiveMeSomeStats
    {
        private static IStatisticsService _statisticsService = new StatisticsService();

        // <summary>
        /// Entry point of the Application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine($"My input: {args[0]}");

            StatResponse statResp = new StatResponse();

            try
            {
                var numbers = _statisticsService.ParseAndValidateInput(args[0]);

                statResp = _statisticsService.CalcStatistics(numbers);
            }
            catch (ValidationException ex)
            {
                Console.WriteLine($"Validation error happened: {ex.Message}");
                Console.WriteLine("Please provide comma-separated integers as input arguments, for ex: 1,2,3");

                return;
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected error happened!");
                
                return;
            }

            Console.WriteLine($"Max number is: {statResp.Max}");
            Console.WriteLine($"Min number is: {statResp.Min}");
            Console.WriteLine($"Average is: {Math.Round(statResp.Average, 2)}");
            Console.WriteLine($"Std Deviation is: {Math.Round(statResp.StandardDeviation, 2)}");

            Console.ReadLine();
        }
    }
}
