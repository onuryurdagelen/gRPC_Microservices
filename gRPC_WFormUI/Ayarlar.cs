using gRPC_Helper;
using gRPC_Helper.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gRPC_WFormUI
{
    public partial class Ayarlar : Form
    {
        SqlHelper sqlHelper;
        public Ayarlar()
        {
            InitializeComponent();
            sqlHelper = new SqlHelper();
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {

            string txtFilePath = DirectoryExtension.GetTxtFilePath();

            if (txtFilePath != null)
            {
                string txtFile = Path.GetFileName(txtFilePath);

                if (!File.Exists(txtFile))
                {
                    // Create a new file     
                    using (StreamWriter sw = File.CreateText(txtFile))
                    {
                        sw.WriteLine("[Server]=DESKTOP-OKIVNDG");
                        sw.WriteLine("[Database]=ETA");
                        sw.WriteLine("[User_Id]= sa");
                        sw.WriteLine("[Password]=eta");

                        sw.Close();
                    }
                }
                else
                {
                    GetAllFields(txtFile);
                }
            }
        }
        private void GetAllFields(string txtFile)
        {
            using (StreamReader file = new StreamReader(txtFile))
            {
                int counter = 0;
                string line;

                List<string> values = new List<string>();

                while ((line = file.ReadLine()) != null)
                {
                    //MessageBox.Show(ln);
                    string value = line.Split("=")[1];
                    values.Add(value);
                    counter++;
                }
                file.Close();
                
                txtServer.Text = values.ToArray()[0];
                txtDatabase.Text = values.ToArray()[1];
                txtUserId.Text = values.ToArray()[2];
                txtPassword.Text = values.ToArray()[3];
            }
        }
        private void SetAllFields(string filePath)
        {

            int counter = 0;

            List<string> values = new List<string>()
                {
                txtServer.Text,
                txtDatabase.Text,
                txtUserId.Text,
                txtPassword.Text,
                };
            string[] lines = File.ReadAllLines(filePath);

            while (counter < lines.Length)
            {
                lines[counter] = lines[counter].Replace(lines[counter].Split("=")[1], values.ToArray()[counter]);
                File.WriteAllLines(filePath, lines);
                counter++;
            }
        }

      
      

        private void btnSaveSettings_Click_1(object sender, EventArgs e)
        {
            string txtFilePath = DirectoryExtension.GetTxtFilePath();

            if (txtFilePath != null)
                SetAllFields(txtFilePath);
            SqlHelper.SqlBaglantisiniGetir();
            IList<string> dbTableList = sqlHelper.ListTables();
            Form1.instance.ComboBoxDbTable.Items.Clear();
            dbTableList.ToList().ForEach(dbTable =>
            {
                Form1.instance.ComboBoxDbTable.Items.Add(dbTable);
            });
            Thread.Sleep(1000);
            this.Close();
        }

        private void btnPassShow_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            btnPassShow.Text = txtPassword.UseSystemPasswordChar ? "Show" : "Hide";
        }
    }
}
