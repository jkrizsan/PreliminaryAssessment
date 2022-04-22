namespace BusinessLogic.Statistics
{
    /// <summary>
    /// Dto class for statistics data
    /// </summary>
    public class StatResponse
    {
        /// <summary>
        /// Maximum
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// Minimum
        /// </summary>
        public int Min { get; set; }

        /// <summary>
        /// Average
        /// </summary>
        public double Average { get; set; }

        /// <summary>
        /// Standard deviation
        /// </summary>
        public double StandardDeviation { get; set; }
    }
}
