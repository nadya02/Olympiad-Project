<<<<<<< HEAD
create database OlympicGamesDB; 
GO
use OlympicGamesDB;
GO
create table Sports
(
	id int not null unique identity, primary key(id),
	Name varchar(30) not null
);
GO
create table Competitors
(
	id int not null unique identity, primary key(id),
	FullName varchar(30) not null,
	BirthDate date not null,
	Age int not null, 
	town_id int not null, foreign key(town_id) references Towns(id),
	sport_id not null, foreign key(sport_id) references Sports(id),
	coach_id not null, foreign key(coach_id) references Coaches(id)
);
GO
=======
create database OlympicGamesDB;
GO
use OlympicGamesDB;
GO
create table Countries
(
	id int not null unique identity, primary key(id),
	Name varchar not null
);
GO
create table Towns
(
	id int not null unique identity, primary key(id),
	Name varchar not null, 
	CountryId int not null, foreign key(id) references Countries(id)
);
GO
create table Coaches
(
	id int not null identity, primary key(id),
	Name varchar not null,
);
>>>>>>> 7ff1b7eea1b0c7a62a4f357fdd0801678e410970




