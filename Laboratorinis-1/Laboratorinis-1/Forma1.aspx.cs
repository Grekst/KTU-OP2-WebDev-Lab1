using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorinis_1
{
    public partial class Forma1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FileUploadErrorLabel.Visible = false;
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            FileUploadErrorLabel.Visible = false;

            var check = TaskUtils.ValidateFile(FileUpload1.PostedFile);

            if (check.validity)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(FileUpload1.PostedFile.InputStream))
                    {
                        string content = reader.ReadToEnd();

                        DataTextBox.Text = content;

                        FileUploadErrorLabel.Visible = true;
                        FileUploadErrorLabel.Text = "Failas sėkmingai įkeltas.";
                        FileUploadErrorLabel.ForeColor = System.Drawing.Color.Green;
                    }
                }
                catch (Exception ex)
                {
                    FileUploadErrorLabel.Visible = true;
                    FileUploadErrorLabel.Text = "Klaida skaitant failą: " + ex.Message;
                    FileUploadErrorLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                FileUploadErrorLabel.Visible = true;

                FileUploadErrorLabel.Text = check.message;
                FileUploadErrorLabel.ForeColor = System.Drawing.Color.Red;

                DataTextBox.Text = "";
            }
        }

        protected void CalculationButton_Click(object sender, EventArgs e)
        {
            ResultTextBox.Text = "";


            if (!string.IsNullOrEmpty(DataTextBox.Text))
            {
                Scorpion sk = TaskUtils.ReadFromText(DataTextBox.Text);
                if (sk != null)
                {
                    ResultTextBox.Text = sk.Analize();
                }
                else
                {
                    ResultTextBox.Text = "Klaida: Netinkamas duomenų formatas tekstiniame lauke.";
                }
            }
        }
    }
}