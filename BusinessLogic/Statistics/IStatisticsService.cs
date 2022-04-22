using System.Collections.Generic;

namespace BusinessLogic.Statistics
{
    /// <summary>
    ///  Statistics Service Interface
    /// </summary>
    public interface IStatisticsService
    {
        /// <summary>
        /// Calculate statistics data
        /// </summary>
        /// <param name="numbers">Collection of Integers</param>
        /// <returns>StatResponse</returns>
        StatResponse CalcStatistics(List<int> numbers);

        /// <summary>
        /// Parse and validate the received input data
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Collection of Integers</returns>
        List<int> ParseAndValidateInput(string input);
    }
}
