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

        public Scorpion(int n, char[,] matrix)
        {
            ElementCount = n;
            Matrix = matrix;
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
                var neighbors = GetNeighbors(i);
                if (neighbors.Count == 1)
                {
                    int stinger = i;
                    int tail = neighbors[0];
                    var tailNeighbors = GetNeighbors(tail);

                    if (tailNeighbors.Count == 2)
                    {
                        int body = tailNeighbors[0] == stinger ? tailNeighbors[1] : tailNeighbors[0];

                        if (GetNeighbors(body).Count == ElementCount - 2)
                        {
                            if (CheckIfConnected(body, 0, stinger))
                            {
                                return GenerateAnswer(stinger, tail, body);
                            }
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