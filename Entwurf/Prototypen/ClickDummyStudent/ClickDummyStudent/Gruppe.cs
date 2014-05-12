using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickDummyStudent
{
    public class Gruppe
    {
        public string gruppenKennung { get; set; }
        public Student leiter { get; set; }
        public List<Student> studenten { get; set; }
        public string thema { get; set; }

        public Gruppe(string gruppenKennung, Student leiter, List<Student> mitglieder, string thema, string passwort)
        {
            this.gruppenKennung = gruppenKennung;
            this.leiter = leiter;
            this.studenten = mitglieder;
            this.thema = thema;
        }
    }
}
