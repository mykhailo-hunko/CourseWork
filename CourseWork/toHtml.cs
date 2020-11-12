using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class toHtml
    {
        List<fileInformation> fileInformation;
        int Lec1;
        int Lec2;
        int Pr1;
        int Pr2;
        int Lab1;
        int Lab2;
        bool isSecond;
        StreamWriter sw;

        public toHtml(List<fileInformation> fileInformation, int lec1, int lec2, int pr1, int pr2, int lab1, int lab2, bool isSecond)
        {
            this.fileInformation = fileInformation;
            Lec1 = lec1;
            Lec2 = lec2;
            Pr1 = pr1;
            Pr2 = pr2;
            Lab1 = lab1;
            Lab2 = lab2;
            this.isSecond = isSecond;
            mainWork();
            FileStream fs = new FileStream("D:\\courseWork\\index.html", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fs.Close();
        }

        private void mainWork()
        {
             
            sw = new StreamWriter("D:\\courseWork\\index.html");
            sw.WriteLine("<!DOCTYPE html>");
            sw.WriteLine(" < html lang = \"en\" >");
            sw.WriteLine("< head >");
            sw.WriteLine(" < meta charset = \"utf -8\" >");
            sw.WriteLine("< title > CourseWork </ title >");
            sw.WriteLine("     </ head >");
            sw.WriteLine("< body >");
            sw.WriteLine("   Hello world!");
            sw.WriteLine(" </ body > ");
            sw.Close();
        }
    }
}
