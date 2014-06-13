insert into Beleg values ("beleg1", "SS14", "15-05-2014", "01-07-2014", 6, 7, "passwort")

insert into Zuordnung_BelegCases values ("beleg1", "case01")
insert into Zuordnung_BelegCases values ("beleg1", "case02")
insert into Zuordnung_BelegCases values ("beleg1", "case03")
insert into Zuordnung_BelegCases values ("beleg1", "case04")

insert into Zuordnung_BelegRolle values ("beleg1", "Leitung")
insert into Zuordnung_BelegRolle values ("beleg1", "Entwurf")
insert into Zuordnung_BelegRolle values ("beleg1", "Datenbankentwurf")
insert into Zuordnung_BelegRolle values ("beleg1", "Implementation")
insert into Zuordnung_BelegRolle values ("beleg1", "Analyse")
insert into Zuordnung_BelegRolle values ("beleg1", "Test")
insert into Zuordnung_BelegRolle values ("beleg1", "Dokumentation")

insert into Zuordnung_BelegThema values ("beleg1", 16)
insert into Zuordnung_BelegThema values ("beleg1", 17)
insert into Zuordnung_BelegThema values ("beleg1", 18)

insert into Gruppe values ("case01", 16, "pw")

insert into Student values ("s68311", "Benjamin", "Herzog", "s68311@htw-dresden.de", "Implementation")
insert into Student values ("s68398", "Markus", "Noack", "s68398@htw-dresden.de", "Datenbankentwurf")
insert into Student values ("s12345", "TestV", "TestN", "s12345@htw-dresden.de", "Leitung")

insert into Zuordnung_GruppeStudent values ("case01", "s68311")
insert into Zuordnung_GruppeStudent values ("case01", "s68398")
insert into Zuordnung_GruppeStudent values ("case01", "s12345")

insert into Zuordnung_GruppeBeleg values ("case01","beleg1")

insert into Rolle values ("Leitung")
insert into Rolle values ("Entwurf")
insert into Rolle values ("Datenbankentwurf")
insert into Rolle values ("Implementation")
insert into Rolle values ("Analyse")
insert into Rolle values ("Test")
insert into Rolle values ("Dokumentation")