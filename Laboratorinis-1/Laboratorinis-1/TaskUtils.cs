using System.IO;
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

                if (elementCount < 5 || elementCount > 50) return null;

                //Create matrix
                char[,] matrix = new char[elementCount, elementCount];
                for (int i = 0; i < elementCount; i++)
                {
                    string line = reader.ReadLine();
                    if (line == null) return null; //Stop everything if too little lines than required by elementCount

                    string realSymbols = line.Replace(" ", "").Trim(); //Delete spaces
                    for (int j = 0; j < elementCount; j++)
                    {
                        if (j < realSymbols.Length)
                            matrix[i, j] = realSymbols[j];
                        else
                            matrix[i, j] = '-';
                    }
                }

                //Create a new animal from read data
                return new Scorpion(elementCount, matrix);
            }
        }

        /// <summary>
        /// Runs a basic validation of the uploaded file. (Is it a .txt file, and is it filled)
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static (bool validity, string message) ValidateFile(HttpPostedFile file)
        {
            if (System.IO.Path.GetExtension(file.FileName).ToLower() != ".txt") //Is it a .txt file?
                return (false, string.Format("Failo tipas ( {0} ) yra netinkamas. Reikalinga: .txt", System.IO.Path.GetExtension(file.FileName).ToLower()));

            if (file == null || file.ContentLength == 0) //Does file exist?
                return (false, "Failas nerastas");

            return (true, "Viskas gerai");
        }
    }
}