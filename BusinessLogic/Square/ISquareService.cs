namespace BusinessLogic.Square
{
    /// <summary>
    /// Interface of the Square Service
    /// </summary>
    public interface ISquareService
    {
        /// <summary>
        /// Find the Largest sub square size in the given array
        /// Complexity: O(MxN)
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>Size of the Square</returns>
        int FindLargestSquare(byte[,] bytes);
    }
}
