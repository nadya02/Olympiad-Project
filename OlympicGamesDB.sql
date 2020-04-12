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