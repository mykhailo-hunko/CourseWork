using System.Collections.Generic;
using System.IO;

namespace CourseWork
{
    class toHtml
    {
        public enum MyColor
        {
            White,
            Red,
            Yellow,
            Aqua,
            Lime
        }
        List<fileInformation> fileInformation;
        int Lec1;
        int Lec2;
        int Pr1;
        int Pr2;
        int Lab1;
        int Lab2;
        bool isSecond;
        int fontSizeText;
        MyColor backGround;
        MyColor lk;
        MyColor lb; 
        MyColor pr;
        StreamWriter sw;
        string[] dir = { "D:\\courseWork\\index.html",  "D:\\courseWork\\sem1.html", "D:\\courseWork\\sem2.html", "D:\\courseWork\\style.css" };

        public toHtml(List<fileInformation> fileInformation, int lec1, int lec2, int pr1, int pr2, int lab1, int lab2, bool isSecond, int fontSizeText, MyColor backGround, MyColor lk, MyColor lb, MyColor pr)
        {
            this.fileInformation = fileInformation;
            Lec1 = lec1;
            Lec2 = lec2;
            Pr1 = pr1;
            Pr2 = pr2;
            Lab1 = lab1;
            Lab2 = lab2;
            this.lb = lb;
            this.lk = lk;
            this.pr = pr;
            this.backGround = backGround;                                                                                                                                                                                                                                                                                                                                                                                
            this.fontSizeText = fontSizeText;
            this.isSecond = isSecond;
           // mainWork();
            FileStream fs = new FileStream(dir[0], FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fs.Close();
            fs = new FileStream(dir[3], FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fs.Close();
            mainWork();
        }

        private void mainWork()
        {
             
            sw = new StreamWriter(dir[0]);
            sw.WriteLine("<!DOCTYPE html>");
            sw.WriteLine(" <html lang = \"en\">");
            sw.WriteLine("<head>");
            sw.WriteLine(" <meta charset = \"utf -8\">");
            sw.WriteLine("<title> CourseWork </title>");
            sw.WriteLine("<link rel = \"stylesheet\" href = \"style.css\" >");
            sw.WriteLine("<style>");
            sw.WriteLine(" body {");
            sw.WriteLine(" background: " + chooseColor(backGround) + ";}");
            sw.WriteLine(" </style>");
            sw.WriteLine("</head>");
            sw.WriteLine("<body>");
            writeIndex();
            //createSem();
            sw.WriteLine(" </body> ");
            sw.Close();

            writeSem(1);
            writeCSS();
            if (isSecond)
            {
                writeSem(2);  
            }

            
        }

        private void writeCSS()
        {
            sw = new StreamWriter(dir[3]);
            sw.WriteLine(".lk{ color: " + chooseColor(lk) + ";}");
            sw.WriteLine(".lab{ color: " + chooseColor(lb) + ";}");
            sw.WriteLine(".pr{ color: " + chooseColor(pr) + ";}");
            sw.WriteLine("body{ font-size: " + fontSizeText + "px;}");
            sw.Close();
        }

        private string chooseColor(MyColor backGround)
        {
            switch (backGround)
            {
                case MyColor.White: return "white";
                case MyColor.Red: return "red";
                case MyColor.Yellow: return "yellow";
                case MyColor.Aqua: return "aqua";
                case MyColor.Lime: return "lime";
                default: return "white";
            }
           
        }

        private void writeSem(byte sem)
        {
            sw = new StreamWriter(dir[sem]);
            sw.WriteLine("<!DOCTYPE html>");
            sw.WriteLine(" <html lang = \"en\">");
            sw.WriteLine("<head>");
            sw.WriteLine(" <meta charset = \"utf -8\">");
            if(sem == 1)
            { 
                sw.WriteLine("<title> Первый семестр </title>");
            } else
            {
                sw.WriteLine("<title> Второй семестр </title>");
            }
            sw.WriteLine("<link rel = \"stylesheet\" href = \"style.css\" >");
            sw.WriteLine("<style>");
            sw.WriteLine(" body {");
            sw.WriteLine(" background: " + chooseColor(backGround) + ";} </style>");
            sw.WriteLine("</head>");
            sw.WriteLine("<body>");
            sw.WriteLine("<div class = \"lk\">");
            sw.WriteLine("Леции(" + (sem == 1 ? Lec1 : Lec2) + " часов):<br>");
            foreach(fileInformation file in fileInformation)
            {
                if(file.number == 10 + sem)
                {
                    if (file.isAcceess)
                    {
                        sw.WriteLine("<a href=\"" + file.path + "\" target = \"blank\" > " + file.name + "</a><br>");
                        sw.WriteLine("Описание: " + file.description + "<br><br>");
                    }
                    else
                    {
                        sw.WriteLine("<a href=\"" + file.path + "\" target = \"blank\" onclick=\"return false; \" > " + file.name + "</a><br>");
                        sw.WriteLine("(Недоступен)<br>");
                        sw.WriteLine("Описание: " + file.description + "<br><br>");
                    }
                }
            }
            sw.WriteLine("</div>");
            sw.WriteLine("<div class = \"pr\">");
            sw.WriteLine("<br><br>Практические занятия(" + (sem == 1 ? Pr1 : Pr2) + " часов):<br>");
            foreach (fileInformation file in fileInformation)
            {
                if (file.number == 20 + sem)
                {
                    if (file.isAcceess)
                    {
                        sw.WriteLine("<a href=\"" + file.path + "\" target = \"blank\"> " + file.name + "</a><br>");
                        sw.WriteLine("Описание: " + file.description + "<br><br>");
                    }
                    else
                    {
                        sw.WriteLine("<a href=\"" + file.path + "\" target = \"blank\"  onclick=\"return false; \" > " + file.name + "</a><br>");
                        sw.WriteLine("(Недоступен)<br>");
                        sw.WriteLine("Описание: " + file.description + "<br><br>");
                    }
                }
            }
            sw.WriteLine("</div>");
            sw.WriteLine("<div class = \"lab\">");
            sw.WriteLine("<br><br>Лабораторные работы(" + (sem == 1 ? Lab1 : Lab2) + " часов):<br>");
            foreach (fileInformation file in fileInformation)
            {

                if (file.number == 30 + sem)
                {
                    if (file.isAcceess)
                    {
                        sw.WriteLine("<a href=\"" + file.path + "\" target = \"blank\"> " + file.name + "</a><br>");
                        sw.WriteLine("Описание: " + file.description + "<br><br>");
                    } 
                    else
                    {

                    }
                }
            }

            sw.WriteLine("</div>");
            sw.WriteLine("</body>");
            sw.Close();

        }

        private void writeIndex()
        {
            sw.WriteLine("<a href=\"sem1.html\" target = \"blank\">Материалы первого семестра!</a><br>");
            if (isSecond)
            {
                sw.WriteLine("<a href = \"sem2.html\" target = \"blank\"> Материалы второго семестра!</a>");
            }
        }



        //private void createSem()
        //{
        //    FileStream fs = new FileStream(dir[1], FileMode.OpenOrCreate, FileAccess.ReadWrite);
        //    if (isSecond)
        //    {
        //        fs.Close();
        //        fs = new FileStream(dir[2], FileMode.OpenOrCreate, FileAccess.ReadWrite);
                
        //    }
        //    fs.Close();
        //}

        
    }
}
