using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickDummy
{
    public class Student
    {
        public string name { get; set; }
        public string vorname { get; set; }
        public string sNummer { get; set; }
        public string mail { get; set; }
        public string rolle { get; set; }

        public Student(string name, string vorname, string sNummer, string mail, string rolle)
        {
            this.name = name;
            this.vorname = vorname;
            this.sNummer = sNummer;
            this.mail = mail;
            this.rolle = rolle;
        }

    }
}
