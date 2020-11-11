using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class fileInformation
    {
         public byte number;
        public string name;
        public string path;
        public string description;
        public bool isAcceess;

        public fileInformation(byte number, string name, string path, string description, bool isAcceess)
        {
            this.isAcceess = isAcceess;
            this.number = number;
            this.name = name;
            this.path = path;
            this.description = description;
        }
    }
}
