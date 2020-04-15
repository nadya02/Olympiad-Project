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
create table Sports
(
	id int not null unique identity, primary key(id),
	Name varchar(30) not null
);
GO
create table Coaches
(
	id int not null identity, primary key(id),
	Name varchar not null,
);
GO
create table Competitors
(
	id int not null unique identity, primary key(id),
	FullName varchar(30) not null,
	BirthDate date not null,
	Age int not null, 
	Gender enum ('man','women')not null;//?
	Weight int not null,
	Town_id int , foreign key(Town_id) references Towns(id),
	Coach_id int , foreign key(Coach_id) references Coaches(id),	
	Sport_id int not null, foreign key(Sport_id) references Sports(id),
);
GO





