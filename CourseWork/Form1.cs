using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{

     
    public partial class Form1 : Form
    {
        public static string tempDesc;
        public static string tempName;
        public static string tempPath;
        public static bool tempIsAccess;
        public static bool wasWrire;

       List<fileInformation> fileInformation;
        toHtml html;
        bool isSecond;
        public Form1()
        {
            InitializeComponent();
            isSecond = false;
            fileInformation = new List<fileInformation>();
            updateDrop();


        }
    

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ableSecond();
          
        }

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            enableSecond();
            
        }
        
        
       
        private void ableSecond()
        {
            isSecond = true;
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
            isSecond = false;
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

        private void addLec1_Click(object sender, EventArgs e)
        {
            addFiles(11);
        }

        private void addLec2_Click(object sender, EventArgs e)
        {
            addFiles(12);
        }

        private void addPr1_Click(object sender, EventArgs e)
        {
            addFiles(21);
        }

        private void addPr2_Click(object sender, EventArgs e)
        {
            addFiles(22);
        }

        private void addLab1_Click(object sender, EventArgs e)
        {
            addFiles(31);
        }

        private void addLab2_Click(object sender, EventArgs e)
        {
            addFiles(32);
        }
        private void addFiles(byte number)
        {
            
            Form2 form2 = new Form2();
            form2.ShowDialog();
            if (wasWrire)
            {
                fileInformation.Add(new fileInformation(number, tempName, tempPath, tempDesc, tempIsAccess));
            }
            updateDrop();

        }

        private void delFiles(string name)
        {
            
            foreach( fileInformation fileOne in fileInformation)
            {
                if (fileOne.name.Equals(name))
                {
                   
                   fileInformation.Remove(fileOne);
                    break;
                }
            }
            

            MessageBox.Show("Файл был удален из локального репозитория программы", "Уведомление");
        }

        private void updateDrop()
        {
            dropLec1.Items.Clear();
            dropLec1.Items.Clear();
            dropLab1.Items.Clear();
            dropLab1.Items.Clear();
            dropPr1.Items.Clear();
            dropPr1.Items.Clear();
            for (int i = 0; i < fileInformation.Count; i++)
            {
                switch (fileInformation[i].number)
                {
                    case 11:
                        dropLec1.Items.Add(fileInformation[i].name);
                    break;
                    case 12:
                        dropLec2.Items.Add(fileInformation[i].name);
                        break;
                    case 21:
                        dropPr1.Items.Add(fileInformation[i].name);
                        break;
                    case 22:
                        dropPr2.Items.Add(fileInformation[i].name);
                        break;
                    case 31:
                        dropLab1.Items.Add(fileInformation[i].name);
                        break;
                    case 32:
                        dropLab2.Items.Add(fileInformation[i].name);
                        break;
                    default: break;

                }
                   
            }
        }

        private void delLec1_Click(object sender, EventArgs e)
        {
            string name = dropLec1.SelectedItem.ToString();
            dropLec1.Items.RemoveAt(dropLec1.SelectedIndex);
            delFiles(name);
           
        }

        private void delLec2_Click(object sender, EventArgs e)
        {
            string name = dropLec2.SelectedItem.ToString();
            dropLec2.Items.RemoveAt(dropLec2.SelectedIndex);
            delFiles(name);
        }

        private void delPr1_Click(object sender, EventArgs e)
        {
            string name = dropPr1.SelectedItem.ToString();
            dropPr1.Items.RemoveAt(dropPr1.SelectedIndex);
            delFiles(name);
        }

        private void delPr2_Click(object sender, EventArgs e)
        {
            string name = dropPr1.SelectedItem.ToString();
            dropPr2.Items.RemoveAt(dropPr2.SelectedIndex);
            delFiles(name);
        }

        private void dellab1_Click(object sender, EventArgs e)
        {
            string name = dropLab1.SelectedItem.ToString();
            dropLab1.Items.RemoveAt(dropLab1.SelectedIndex);
            delFiles(name);
        }

        private void delLab2_Click(object sender, EventArgs e)
        {
            string name = dropLab2.SelectedItem.ToString();
            dropLab2.Items.RemoveAt(dropLab2.SelectedIndex);
            delFiles(name);
        }

        private void htmlFile_Click(object sender, EventArgs e)
        {
            clearDirectory();
            
            foreach (fileInformation file in fileInformation)
            {
                switch (file.number)
                {
                    case 11:
                       File.Copy(file.path, @"D:\courseWork\Lec1\" + file.name);
                        break;
                    case 12:
                        if (isSecond)
                        {
                            File.Copy(file.path, @"D:\courseWork\Lec2\" + file.name);
                        }
                        break;
                    case 21:
                        File.Copy(file.path, @"D:\courseWork\Pr1\" + file.name);
                        break;
                    case 22:
                        if (isSecond)
                        {
                            File.Copy(file.path, @"D:\courseWork\Pr2\" + file.name);
                        }
                        break;
                    case 31:
                        File.Copy(file.path, @"D:\courseWork\Lab1\" + file.name);
                        break;
                    case 32:
                        if (isSecond)
                        {
                            File.Copy(file.path, @"D:\courseWork\Lab2\" + file.name);
                        }
                        break;
                    default: break;

                }
                
            }
            int Lec1;
            int Lec2;
            int Pr1;
            int Pr2;
            int Lab1;
            int Lab2;
            int.TryParse(text_lec1.Text, out Lec1);
            int.TryParse(text_lec2.Text, out Lec2);
            int.TryParse(text_pr1.Text, out Pr1);
            int.TryParse(text_pr2.Text, out Pr2);
            int.TryParse(text_lab1.Text, out Lab1);
            int.TryParse(text_lab2.Text, out Lab2);

            html = new toHtml(fileInformation, Lec1, Lec2,Pr1 ,Pr2,Lab1 ,Lab2, isSecond);
            // toHtml.mainWork();
        }

        private void clearDirectory()
        {
            string[] dir = { @"D:\courseWork", @"D:\courseWork\Lec1", @"D:\courseWork\Lec2", @"D:\courseWork\Pr1", @"D:\courseWork\Pr2", @"D:\courseWork\Lab1", @"D:\courseWork\Lab1" };
            foreach(string directoryFor in dir)
            {
                if (Directory.Exists(directoryFor))
                {
                    string[] fileNames = Directory.GetFiles(directoryFor);
                foreach (string fileName in fileNames)
                    {
                        File.Delete(fileName);

                    }
                
                }
                

            }
            
            Directory.CreateDirectory(@"D:\courseWork");
             Directory.CreateDirectory(@"D:\courseWork\Lab1");
            Directory.CreateDirectory(@"D:\courseWork\Lec1");
            Directory.CreateDirectory(@"D:\courseWork\Pr1");
            if (isSecond)
            {
                Directory.CreateDirectory(@"D:\courseWork\Lab2");
                Directory.CreateDirectory(@"D:\courseWork\Lec2");
                Directory.CreateDirectory(@"D:\courseWork\Pr2");

            }
        }
    }
}
