using System.Collections.Generic;

namespace Laboratorinis_1
{
    public class Scorpion
    {
        public int ElementCount { get; private set; } //How many body parts are there
        public char[,] Matrix { get; private set; } //A matrix displaying the linke between body parts.
                                                    // '*' - current element
                                                    // '+' - connection to element at index
                                                    // '-' - no connection to element at index


        public Scorpion(int elCnt, char[,] mat)
        {
            ElementCount = elCnt;
            Matrix = mat;
        }

        /// <summary>
        /// Checks if the element is conn
        /// </summary>
        /// <param name="body"></param>
        /// <param name="current"></param>
        /// <param name="stinger"></param>
        /// <returns></returns>
        public bool CheckIfConnected(int body, int current, int stinger)
        {
            if (current == ElementCount) return true;

            if (current != body && current != stinger)
            {
                if (Matrix[body, current] != '+') return false;
            }
            if (current == stinger)
            {
                if (Matrix[body, current] == '+') return false;
            }

            return CheckIfConnected(body, current + 1, stinger);
        }

        /// <summary>
        /// Gets the list of elements neighboring the current one. (Marked with '+')
        /// </summary>
        /// <param name="index">Current element index</param>
        /// <returns></returns>
        private List<int> GetNeighbors(int index)
        {
            List<int> neighbor = new List<int>();
            for (int j = 0; j < ElementCount; j++)
            {
                if (Matrix[index, j] == '+') neighbor.Add(j);
            }
            return neighbor;
        }

        /// <summary>
        /// Analizes if the provided body part matrix fits the requirements to be a scorpion
        /// </summary>
        /// <returns></returns>
        public string Analize()
        {
            for (int i = 0; i < ElementCount; i++)
            {
                var gNeighbors = GetNeighbors(i);
                // Checks if body part element is the stringer. (May only have 1 neighbor)
                if (gNeighbors.Count == 1)
                {
                    int stinger = i;
                    int tail = gNeighbors[0];
                    var uNeighbors = GetNeighbors(tail);

                    // Checks if the body part is a tail. (Has to be connected to stinger and body)
                    if (uNeighbors.Count == 2)
                    {
                        int body = uNeighbors[0] == stinger ? uNeighbors[1] : uNeighbors[0];
                        var bNeighbors = GetNeighbors(body);

                        // Body has to be connected to everything
                        if (CheckIfConnected(body, 0, stinger))
                        {
                            return GenerateAnswer(stinger, tail, body);
                        }
                    }
                }
            }
            return "Grafas nėra skorpionas.";
        }

        /// <summary>
        /// Generates a formatted answer if the object is a scorpion
        /// </summary>
        /// <param name="stringer"></param>
        /// <param name="tail"></param>
        /// <param name="body"></param>
        /// <returns>A formatted result string</returns>
        private string GenerateAnswer(int stringer, int tail, int body)
        {
            string res = "Grafas yra 'skorpionas'\n" +
                         $"Geluonis: {stringer + 1} virsune\n" +
                         $"Uodega: {tail + 1} virsune\n" +
                         $"Liemuo: {body + 1} virsune\n";
            int legNr = 1;

            // Returns a list of legs and their index
            for (int i = 0; i < ElementCount; i++)
            {
                if (i != stringer && i != tail && i != body)
                {
                    res += $"{legNr} koja: {i + 1} virsune\n";
                    legNr++;
                }
            }
            return res;
        }
    }
}