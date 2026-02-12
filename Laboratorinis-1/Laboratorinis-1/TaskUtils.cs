using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Laboratorinis_1
{
    public class TaskUtils
    {
        public static void ReadFile(HttpPostedFile file)
        {
            if (!ValidateFile(file).validity) return;
        }

        protected static (bool validity, string message) ValidateFile(HttpPostedFile file)
        {
            if (file == null || file.ContentLength == 0)
                return (false, "No file found");
            if (System.IO.Path.GetExtension(file.FileName).ToLower() != ".txt")
                return (false, "Invalid file type. Should be .txt");

            return (true, "All checks passed. Proceed");
        }
    }
}