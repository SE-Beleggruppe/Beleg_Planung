create table Student (
	sNummer char(6) NOT NULL,
	Vorname char(15),
	Nachname char(15),
	Mail char(50),
	Rolle char(25),
	primary key (sNummer)
)

create table Zuordnung_GruppeStudent (
	Gruppenkennung char(6) NOT NULL,
	sNummer char(6) NOT NULL,
	primary key (Gruppenkennung, sNummer)
)

create table Gruppe (
	Gruppenkennung char(6) NOT NULL,
	Themennummer int NOT NULL,
	Passwort char(25),
	primary key(Gruppenkennung)
)

create table Zuordnung_GruppeBeleg (
	Gruppenkennung char(6) NOT NULL,
	Belegkennung char(20) NOT NULL,
	primary key (Gruppenkennung, Belegkennung)
)

create table Beleg (
	Belegkennung char(20) NOT NULL,
	Semester char(10),
	StartDatum Date,
	EndDatum Date,
	MinAnzMitglieder int,
	MaxAnzMitglieder int,
	Passwort char(10),
	primary key (Belegkennung)
)

create table Zuordnung_BelegThema (
	Belegkennung char(20) NOT NULL,
	Themennummer int NOT NULL,
	primary key (Belegkennung, Themennummer)
)


create table Thema (
	Themennummer int NOT NULL,
	Aufgabe char(80),
	primary key (Themennummer)
)

create table Zuordnung_BelegCases (
	Belegkennung char(20) NOT NULL,
	Casekennung char(6) NOT NULL,
	primary key (Belegkennung, Casekennung)
)

create table Case (
	Casekennung char(6) NOT NULL,
	primary key (Casekennung)
)

create table Zuordnung_BelegRolle (
	Belegkennung char(20) NOT NULL,
	Rolle char(25) NOT NULL,
	primary key (Belegkennung, Rolle)
)

create table Rolle (
	Rolle char(25) NOT NULL,
	primary key (Rolle)
)












ausgeführt:

insert into Cases values ("caseXX") // case01-case25

insert into Rolle values("Leitung")
insert into Rolle values("Entwurf")
insert into Rolle values("Datenbankentwurf")
insert into Rolle values("Implementation")
insert into Rolle values("Analyse")
insert into Rolle values("Test")
insert into Rolle values("Dokumentation")