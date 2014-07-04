using System;
using System.Collections.Generic;

namespace Typen
{
    public class Beleg
    {
        public string Semester { get; set; }
        public string Passwort { get; set; }
        public string BelegKennung { get; set; }
        public string Dozent { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EndDatum { get; set; }
        public int MinMitglieder { get; set; }
        public int MaxMitglieder { get; set; }
        public List<Thema> Themen;
        public List<string> Cases;

        public List<Gruppe>  Gruppen = new List<Gruppe>(); 

        //Konstruktor
        public Beleg(string kennung, string semester, DateTime startDatum, DateTime endDatum, int minM, int maxM, string passwort)
        {
            BelegKennung = kennung; // Automatisch generieren
            Passwort = passwort;
            Semester = semester;
            Dozent = Dozent;
            StartDatum = startDatum;
            EndDatum = endDatum;
            MinMitglieder = minM;
            MaxMitglieder = maxM;

            //Themen = new List<Thema> {new Thema(1, "Dies ist eine tolle Aufgabe")};
        }


        //Gruppe hinzufühen
        public void AddGruppe(Gruppe gruppe)
        {
            Gruppen.Add(gruppe);
        }
    }
}
