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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ableSecond();
            Directory.CreateDirectory("C:\\courseWork");
          //  FileInfo.CopyTo("C:\\Users\\Mikhail\\Desktop\\n.txthr_main.log", "C:\\courseWork");
        }

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            enableSecond();
            
        }

        
        private void result2_Click(object sender, EventArgs e)
        {
            
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.CheckFileExists = true;
                openFileDialog.AddExtension = true;
                openFileDialog.Multiselect = true;
               // openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        //Process.Start(fileName);
                    }
                }
         }
        private void ableSecond()
        {
            text_lec2.Enabled = true;
            text_pr2.Enabled = true;
            text_lab2.Enabled = true;
            text_kons2.Enabled = true;
            addLab2.Enabled = true;
            addLec2.Enabled = true;
            addPr2.Enabled = true;
            delLab2.Enabled = true;
            delLec2.Enabled = true;
            delPr2.Enabled = true;
            dropLab2.Enabled = true;
            dropLec2.Enabled = true;
            dropPr2.Enabled = true;
        }
        private void enableSecond()
        {
            text_lec2.Enabled = false;
            text_pr2.Enabled = false;
            text_lab2.Enabled = false;
            text_kons2.Enabled = false;
            addLab2.Enabled = false;
            addLec2.Enabled = false;
            addPr2.Enabled = false;
            delLab2.Enabled = false;
            delLec2.Enabled = false;
            delPr2.Enabled = false;
            dropLab2.Enabled = false;
            dropLec2.Enabled = false;
            dropPr2.Enabled = false;
        }

    }
}
