using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.wasWrire = true;
            Form1.tempDesc = text_desc.Text;
            if (checkBox1.Checked)
            {
                Form1.tempIsAccess = false;
            }
            else
            {
                Form1.tempIsAccess = true;
            }
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Form1.wasWrire = false;
            this.Close();
            
        }

        private void addFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = true;
            // openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if(openFileDialog.FileNames.Length > 1)
                {
                    MessageBox.Show("Выберите только один файл","Error");
                }
                else
                {

                
                foreach (string fileName in openFileDialog.FileNames)
                {
                    //Process.Start(fileName);
                    Form1.tempName = Path.GetFileName(fileName);
                    Form1.tempPath = fileName;
                }
                }
            }
        }
    }
}
