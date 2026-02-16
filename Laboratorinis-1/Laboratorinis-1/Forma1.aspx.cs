using System;
using System.IO;

namespace Laboratorinis_1
{
    public partial class Forma1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FileUploadErrorLabel.Visible = false;
            FileWriteErrorLabel.Visible = false;
        }

        /// <summary>
        /// Runs the uploaded file validation and translation logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            FileUploadErrorLabel.Visible = false;

            var check = TaskUtils.ValidateFile(FileUpload1.PostedFile);

            // Only runs if a file has been uploaded
            if (check.validity)
            {
                try
                {
                    DataTextBox.Text = InOutUtils.ReadFileData(FileUpload1.PostedFile);

                    FileUploadErrorLabel.Visible = true;
                    FileUploadErrorLabel.Text = "Failas sėkmingai nuskaitytas.";
                    FileUploadErrorLabel.ForeColor = System.Drawing.Color.Green;
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

        /// <summary>
        /// Runs the analizer script
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CalculationButton_Click(object sender, EventArgs e)
        {
            ResultTextBox.Text = "";


            if (!string.IsNullOrEmpty(DataTextBox.Text))
            {
                Scorpion sk = InOutUtils.ReadFromText(DataTextBox.Text);
                if (sk != null)
                {
                    ResultTextBox.Text = TaskUtils.Analize(sk);
                }
                else
                {
                    ResultTextBox.Text = "Klaida: Netinkamas duomenų formatas tekstiniame lauke.";
                }
            }
        }

        /// <summary>
        /// Writes data from ResultTextBox to internal result file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void WriteToAppData_Button_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == null) return;

            string path = Server.MapPath("~/Data/Rezultatai.txt");
            InOutUtils.PrintResultToFile(path, ResultTextBox.Text);

            string contents = InOutUtils.ReadFileDataFromInternal(path);

            FileWriteErrorLabel.Visible = true;
            FileWriteErrorLabel.Text = String.Format("{0} \n {1}", "Failas sėkmingai įrašytas.", contents);
            FileWriteErrorLabel.ForeColor = System.Drawing.Color.Green;
        }

        /// <summary>
        /// Reads data to DataTextBox from internal data file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UploadInternalButton_Click(object sender, EventArgs e)
        {
            FileUploadErrorLabel.Visible = false;

            string path = Server.MapPath("~/Data/PradiniaiDuomenys.txt");
            string data = InOutUtils.ReadFileDataFromInternal(path);

            DataTextBox.Text = data;

            FileUploadErrorLabel.Visible = true;
            FileUploadErrorLabel.Text = "Failas sėkmingai nuskaitytas.";
            FileUploadErrorLabel.ForeColor = System.Drawing.Color.Green;
        }
    }
}