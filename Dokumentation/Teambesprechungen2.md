Treffen am 30.04.2014 13.30-15.00 Bibliothek B302a
==================================================

Treffen mit Frau Prof. Hauptmann

Tagesordnung
============
	- Diskussion über Aufbau und Einsatz des Systems
	- Analayse

Martin Tzschoppe's Idee wird vorgestellt(bisheriger Stand):
============================================================
Client-Server-Architektur
Studenten können Themen einsehen die zur Verfügung steht
Dozent verwaltet Gruppen selbst
Mitglieder können sich eigene Gruppe anzeigen lassen und Note
Gruppenleiter kann Mitglieder hinzufügen/entfernen
Filtermöcglichketen, da sich über 10 Jahre mit vielen Gruppen und Mitgliedern ansammelt ???

---------------------------------------------------------------------------------------------------------------------------



Frau Hauptmann:

Automatisierung der ANMELDUNG DER BELEGGRUPPEN, keine Noten!!!


Prozess des Entstehens von Beleg-Arbeitsgruppen
=================================================

Was ist interessant?
====================
Welche Gruppe gibt es?
Wer gehört zu der Gruppe?
(für alle Gruppen)
Wer ist Projektleiter?
Wer verantwortet was?

Gruppe benötigt Identifiation (z.B. Gruppennummer)

Gruppe trägt selbst ihre Mitglieder ein, nachdem sie sich gefunden hat

Gruppe findet sich
trägt sich ein und legt Passwort fest (entweder kennt nur GruppenleiterPasswort oder alle Mitglieder) --> Sicherheitsfunktion
--> wenn 7 gefunden und 8 sollen es sein, kann keine beliebige Person sich als 8. Mitglied eintragen

Informationen:
==============
Name, Vorname, sxxxxx, Email, [Verantwortlichkeit], new festgelegtes Passwort (geänderter "Erstlogin"... EINE Person wird Gruppenleiter --> Ansprechpartner für Dozent
caseXX --> Rahmenbedingungen festlegen damit kein case99 mölgich ist

Vorlesung: "ab sofort können Sie sich anmelden, bitte möglichst schnell, nicht erst in 7 Wochen"
zu dem Zeitpunkt müssen noch keine Verantwortlchkeiten festgelegt sein --> kommen später dazu
"Erstlogin" wird an die Tafel geschrieben


nach gewisser Zeit ist Liste mit Gruppen gefüllt
ein Admin (Dozent oder Zirkelbach) muss Beleggruppe anlegen mit Thema ... Textfeld soll von Admin ausgefüllt werden können "Sommersemester 2014 4. Semester Wirtschaftsinformatik"


ID in Textfeld(Sommersemester 2014 Allgemeine Informatik)
Startdaten
Enddatum
für die soll eingegeben werden können von Admin

minimale Anzahl... wenn minimale Anzahl an Mitgliedern noch nicht erreicht, dann soll Gruppe sich trotzdem schon anmelden und für die anderen Mitglieder "N" oder so eingeben
maximale Anzahl an Grzppenteilnehmern

Themen-Pool (der ganzen Gruppe zugeordenet) auswählen --> flexibel!! muss nur innerhalb startdatum und enddatum festgelegt werden, kann innerhalb der Zeit geändert werden
Rolle auswählen

nach Bekanntgabe "sie können sich anmelden" wird jeder Gruppe ein "Erstlogin" (Benutzername, Passwort) vergeben
über dieses Login wird Gruppe angemeldet


------------------------------------

Ziel: kleine, schlanke, lokale Anwendung, möglichst unter Windows

1 Thema kann von mehreren Gruppen gewählt werden

Accounts caseXX werden nach jedem Jahr zurückgesetzt um im nächsten Jahr wieder neu verwendet werden zu können
--> müssen archiviert werden

caseXX wird automatisch generiert... am Anfang wird festgelegt wie viele cases es gibt z.B. 12
dann bekommt zuerst angemeldete Gruppe case01, zweite case02,.... case 12... 13te Gruppe bekommt Meldung: "geht nicht mehr"

Admin (Dozent) soll Email verschicken können an z.B, "Alle Gruppenleiter", "alle Analytiker", "Gruppe case04 und Gruppe 07"
Email-Programm soll nur Verweis sein... nicht neu Implementiert werden.. "senden via Thunderbird"