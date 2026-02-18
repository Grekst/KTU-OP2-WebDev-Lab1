namespace Laboratorinis_1
{
    public class Scorpion
    {
        public int ElementCount { get; private set; } //How many body parts are there

        private char[,] Matrix;                       //A matrix displaying the linke between body parts.
                                                      // '*' - current element
                                                      // '+' - connection to element at index
                                                      // '-' - no connection to element at index

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="elCnt"></param>
        /// <param name="mat"></param>
        public Scorpion(int elCnt, char[,] mat)
        {
            ElementCount = elCnt;
            Matrix = mat;
        }

        /// <summary>
        /// Gets a body part type from a specific index of a 2D array
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>A body part type ( - / + / * )</returns>
        public char GetMatrixValue(int i, int j)
        {
            return Matrix[i, j];
        }
    }
}