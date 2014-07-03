
namespace Typen
{
    public class Student
    {
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string SNummer { get; set; }
        public string Mail { get; set; }
        public string Rolle { get; set; }

        public Student(string name, string vorname, string sNummer, string mail, string rolle)
        {
            Name = name;
            Vorname = vorname;
            SNummer = sNummer;
            Mail = mail;
            Rolle = rolle;
        }

    }
}
