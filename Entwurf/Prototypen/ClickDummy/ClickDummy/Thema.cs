using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickDummy
{
    public class Thema
    {
        public List<Beleg> beleg { get; set; }
        public string aufgabenName { get; set; }

        public Thema(string aufgabe)
        {
            this.aufgabenName = aufgabe;
        }
    }
}
