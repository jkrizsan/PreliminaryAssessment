namespace BusinessLogic.Sorting
{
    /// <summary>
    /// Interface of the Sorting Service
    /// </summary>
    public interface ISortingService
    {
        /// <summary>
        /// Method for Bubble sorting, Complexity: O(n^2)
        /// </summary>
        /// <param name="arr">Unsorted Array</param>
        /// <param name="isAsc">Control Ascending(true) or Descending(false) sorting</param>
        /// <returns></returns>
        void BubbleSort(double[] arr, bool isAsc);
    }
}
