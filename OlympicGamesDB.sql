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