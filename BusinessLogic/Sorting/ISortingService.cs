namespace BusinessLogic.Sorting
{
    /// <summary>
    /// Interface of the Sorting Service
    /// </summary>
    public interface ISortingService
    {
        /// <summary>
        /// Bubble sorting, Complexity: O(N^2)
        /// </summary>
        /// <param name="arr">Unsorted Array</param>
        /// <param name="isAsc">Control Ascending(true) or Descending(false) sorting</param>
        /// <returns></returns>
        void BubbleSort(double[] arr, bool isAsc);

        /// <summary>
        /// Merge sorting, Complexity: O(NLogN)
        /// </summary>
        /// <param name="arr">Unsorted Array</param>
        /// <param name="left">Lower Index</param>
        /// <param name="right">Upper Index</param>
        /// <param name="isAsc">Control Ascending(true) or Descending(false) sorting</param>
        /// <returns></returns>
        void MergeSort(double[] arr, bool isAsc, int left = 0, int right = -1);

        /// <summary>
        /// Generate Array with Random Numbers
        /// </summary>
        /// <param name="size">Size of the array</param>
        /// <returns>Array with random numbers</returns>
        double[] CreateArrayWithRandomNumbers(int size);
    }
}
