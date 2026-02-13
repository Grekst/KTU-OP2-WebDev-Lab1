using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorinis_1
{
    public class Scorpion
    {
        public int N { get; private set; }
        public char[,] Matrica { get; private set; }

        public Scorpion(int n, char[,] matrica)
        {
            this.N = n;
            this.Matrica = matrica;
        }

        // Rekursinis metodas patikrinti, ar Liemuo sujungtas su visomis kojomis
        public bool ArSujungtaSuVisaisRekursiskai(int liemuo, int dabartinis, int geluonis)
        {
            if (dabartinis == N) return true; // Bazinė sąlyga

            // Praleidžiame patį liemenį ir geluonį (su juo liemuo tiesiogiai nesijungia)
            if (dabartinis != liemuo && dabartinis != geluonis)
            {
                // Liemuo PRIVALO būti sujungtas su visomis kojomis ir uodega
                if (Matrica[liemuo, dabartinis] != '+') return false;
            }

            return ArSujungtaSuVisaisRekursiskai(liemuo, dabartinis + 1, geluonis);
        }

        // Metodas rasti kaimynų skaičių konkrečiai viršūnei
        public List<int> GautiKaimynus(int v)
        {
            List<int> kaimynai = new List<int>();
            for (int j = 0; j < N; j++)
            {
                if (Matrica[v, j] == '+') kaimynai.Add(j);
            }
            return kaimynai;
        }
    }
}