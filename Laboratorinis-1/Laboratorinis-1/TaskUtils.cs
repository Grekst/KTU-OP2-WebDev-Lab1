using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis_1
{
    public class TaskUtils
    {
        /// <summary>
        /// Runs a basic validation of the uploaded file. (Is it a .txt file, and is it filled)
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static (bool validity, string message) ValidateFile(HttpPostedFile file)
        {
            if (System.IO.Path.GetExtension(file.FileName).ToLower() != ".txt")
            {
                return (false, string.Format("Failo tipas ( {0} ) yra netinkamas. Reikalinga: .txt", System.IO.Path.GetExtension(file.FileName).ToLower()));
            }


            if (file == null || file.ContentLength == 0)
            {
                return (false, "Failas nerastas");
            }

            return (true, "Viskas gerai");
        }

        /// <summary>
        /// Checks if the element is conn
        /// </summary>
        /// <param name="body"></param>
        /// <param name="current"></param>
        /// <param name="stinger"></param>
        /// <returns></returns>
        public static bool CheckIfConnected(Scorpion graph, int body, int current, int stinger)
        {
            if (current == graph.ElementCount) return true;

            if (current != body && current != stinger)
            {
                if (graph.GetMatrixValue(body, current) != '+') return false;
            }
            if (current == stinger)
            {
                if (graph.GetMatrixValue(body, current) == '+') return false;
            }

            return CheckIfConnected(graph, body, current + 1, stinger);
        }

        /// <summary>
        /// Gets the list of elements neighboring the current one. (Marked with '+')
        /// </summary>
        /// <param name="index">Current element index</param>
        /// <returns></returns>
        private static List<int> GetNeighbors(Scorpion graph, int index)
        {
            List<int> neighbor = new List<int>();
            for (int j = 0; j < graph.ElementCount; j++)
            {
                if (graph.GetMatrixValue(index, j) == '+') neighbor.Add(j);
            }
            return neighbor;
        }

        /// <summary>
        /// Analizes if the provided body part matrix fits the requirements to be a scorpion
        /// </summary>
        /// <returns></returns>
        public static string Analize(Scorpion graph)
        {
            for (int i = 0; i < graph.ElementCount; i++)
            {
                var gNeighbors = GetNeighbors(graph, i);

                if (gNeighbors.Count == 1) // Checks if body part element is the stringer. (May only have 1 neighbor)
                {
                    int stinger = i;
                    int tail = gNeighbors[0];
                    var uNeighbors = GetNeighbors(graph, tail);

                    if (uNeighbors.Count == 2) // Checks if the body part is a tail. (Has to be connected to stinger and body)
                    {
                        int body = uNeighbors[0] == stinger ? uNeighbors[1] : uNeighbors[0];
                        var bNeighbors = GetNeighbors(graph, body);


                        if (CheckIfConnected(graph, body, 0, stinger)) // Body has to be connected to everything
                        {
                            return GenerateAnswer(graph, stinger, tail, body);
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
        public static string GenerateAnswer(Scorpion graph, int stringer, int tail, int body)
        {
            string res = new string('=', 27) +
                "\n" +
                graph.ToString() +
                new string('=', 27) + "\n" +
                string.Format("| {0, -10} | {1, 10} |\n", "Geluonis", stringer + 1) +
                new string('-', 27) + "\n" +
                string.Format("| {0, -10} | {1, 10} |\n", "Uodega", tail + 1) +
                new string('-', 27) + "\n" +
                string.Format("| {0, -10} | {1, 10} |\n", "Liemuo", body + 1) +
                new string('-', 27) + "\n";
            int legNr = 1;

            // Returns a list of legs and their index
            for (int i = 0; i < graph.ElementCount; i++)
            {
                if (i != stringer && i != tail && i != body)
                {
                    res += string.Format("| {0, -10} | {1, 10} |{2}{3}", legNr + " koja", i + 1, '\n', new string('-', 27));
                    res += '\n';
                    legNr++;
                }
            }
            res += "\nGrafas yra 'skorpionas'\n";
            return res;
        }
    }
}