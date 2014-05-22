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

insert into Zuordnung_BelegThema values ("beleg1", 10)
insert into Zuordnung_BelegThema values ("beleg1", 11)
insert into Zuordnung_BelegThema values ("beleg1", 12)

insert into Gruppe values ("case01", 10, "pw")

insert into Student values ("s68311", "Benjamin", "Herzog", "s68311@htw-dresden.de", "Implementation")
insert into Student values ("s68398", "Markus", "Noack", "s68398@htw-dresden.de", "Datenbankentwurf")
insert into Student values ("s12345", "TestV", "TestN", "s12345@htw-dresden.de", "Test")

insert into Zuordnung_GruppeStudent values ("case01", "s68311")
insert into Zuordnung_GruppeStudent values ("case01", "s68398")
insert into Zuordnung_GruppeStudent values ("case01", "s12345")