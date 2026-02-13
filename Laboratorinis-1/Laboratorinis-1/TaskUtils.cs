using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Laboratorinis_1
{
    public class TaskUtils
    {
        public static Scorpion ReadFromText(string text)
        {
            using (StringReader reader = new StringReader(text))
            {
                //First line validity check
                string firstLine = reader.ReadLine();
                if (string.IsNullOrEmpty(firstLine) || !int.TryParse(firstLine.Trim(), out int elementCount)) return null;

                //Create matrix
                char[,] matrix = new char[elementCount, elementCount];
                for (int i = 0; i < elementCount; i++)
                {
                    string line = reader.ReadLine();
                    if (line == null) break;

                    string tikriSimboliai = line.Replace(" ", "").Trim();
                    for (int j = 0; j < elementCount; j++)
                    {
                        if (j < tikriSimboliai.Length)
                            matrix[i, j] = tikriSimboliai[j];
                        else
                            matrix[i, j] = '-';
                    }
                }

                //Create a new animal from read data
                return new Scorpion(elementCount, matrix);
            }
        }


        //public static Scorpion ReadFile(HttpPostedFile file)
        //{
        //    using (StreamReader reader = new StreamReader(file.InputStream))
        //    {
        //        string line = reader.ReadLine();
        //        if (string.IsNullOrEmpty(line) || !int.TryParse(line.Trim(), out int n)) return null;

        //        char[,] matrix = new char[n, n];
        //        for (int i = 0; i < n; i++)
        //        {
        //            string line = reader.ReadLine();
        //            if (line == null) break;

        //            string tikriSimboliai = eilute.Replace(" ", "").Trim();

        //            for (int j = 0; j < n; j++)
        //            {
        //                if (j < tikriSimboliai.Length)
        //                    matrix[i, j] = tikriSimboliai[j];
        //                else
        //                    matrix[i, j] = '-';
        //            }
        //        }
        //        return new Scorpion(n, matrix);
        //    }
        //}

        public static (bool validity, string message) ValidateFile(HttpPostedFile file)
        {
            if (file == null || file.ContentLength == 0)
                return (false, "Failas nerastas");
            if (System.IO.Path.GetExtension(file.FileName).ToLower() != ".txt")
                return (false, string.Format("Failo tipas ( {0} ) yra netinkamas. Reikalinga: .txt", System.IO.Path.GetExtension(file.FileName).ToLower()));

            return (true, "Viskas gerai");
        }
    }
}