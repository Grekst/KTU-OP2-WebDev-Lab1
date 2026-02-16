using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI.WebControls;

namespace Laboratorinis_1
{
    public class InOutUtils
    {

        /// <summary>
        /// Reads all data from textbox
        /// </summary>
        /// <param name="text"></param>
        /// <returns>A scorpion graph object</returns>
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
        /// Reads text from file
        /// </summary>
        /// <param name="file">Posted file</param>
        /// <returns></returns>
        public static string ReadFileData(HttpPostedFile file)
        {
            string content;

            using (StreamReader reader = new StreamReader(file.InputStream))
            {
                content = reader.ReadToEnd();
            }

            return content;
        }

        public static string ReadFileDataFromInternal(string filePath)
        {
            string[] content = File.ReadAllLines(filePath);

            //string[] lines = File.ReadAllLines(filePath);
            //return ParseLinesToGraph(lines);

            return String.Join("\n", content);
        }

        /// <summary>
        /// Writes a string result to .txt file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="result"></param>
        public static void PrintResultToFile(string filePath, string result)
        {
            File.WriteAllText(filePath, result);
        }


    }
}