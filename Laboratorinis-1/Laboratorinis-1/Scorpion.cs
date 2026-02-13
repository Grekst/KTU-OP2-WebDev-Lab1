using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis_1
{
    public class Scorpion
    {
        public int ElementCount { get; private set; }
        public char[,] Matrix { get; private set; }

        public Scorpion(int elCnt, char[,] mat)
        {
            ElementCount = elCnt;
            Matrix = mat;
        }

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

        private List<int> GetNeighbors(int v)
        {
            List<int> neighbor = new List<int>();
            for (int j = 0; j < ElementCount; j++)
            {
                if (Matrix[v, j] == '+') neighbor.Add(j);
            }
            return neighbor;
        }

        public string Analize()
        {
            for (int i = 0; i < ElementCount; i++)
            {
                var gNeighbors = GetNeighbors(i);
                // 1. Geluonis turi turėti tik 1 kaimyną (uodegą)
                if (gNeighbors.Count == 1)
                {
                    int stinger = i;
                    int tail = gNeighbors[0];
                    var uNeighbors = GetNeighbors(tail);

                    // 2. Uodega turi būti sujungta su geluonimi ir liemeniu (dažniausiai laipsnis 2)
                    if (uNeighbors.Count == 2)
                    {
                        int body = uNeighbors[0] == stinger ? uNeighbors[1] : uNeighbors[0];
                        var bNeighbors = GetNeighbors(body);

                        // 3. Liemuo turi būti sujungtas su visais, išskyrus geluonį (ir save)
                        // Tad laipsnis turi būti n - 2
                        if (bNeighbors.Count == ElementCount - 2 && !bNeighbors.Contains(stinger))
                        {
                            return GenerateAnswer(stinger, tail, body);
                        }
                    }
                }
            }
            return "Grafas nėra skorpionas.";
        }

        private string GenerateAnswer(int g, int u, int l)
        {
            string res = "Grafas yra 'skorpionas'\n" +
                         $"Geluonis: {g + 1} virsune\n" +
                         $"Uodega: {u + 1} virsune\n" +
                         $"Liemuo: {l + 1} virsune\n";
            int legNr = 1;
            for (int i = 0; i < ElementCount; i++)
            {
                if (i != g && i != u && i != l)
                {
                    res += $"{legNr} koja: {i + 1} virsune\n";
                    legNr++;
                }
            }
            return res;
        }
    }
}