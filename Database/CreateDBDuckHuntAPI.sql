CREATE DATABASE DuckHuntAPI;

USE DuckHuntAPI;

CREATE TABLE Character(
	Id int NOT NULL PRIMARY KEY,
	Name varchar(255)
);

CREATE TABLE Image(
	Id int NOT NULL PRIMARY KEY,
	Data varbinary(max),
	CharacterId int FOREIGN KEY REFERENCES Character(Id)
);

CREATE TABLE ImageSequence(
	Id int NOT NULL,
	AnimationId int NOT NULL,
	ImageIndex int NOT NULL,
	ImageId int FOREIGN KEY REFERENCES Image(Id) NOT NULL
);

CREATE TABLE Animation(
	Id int NOT NULL PRIMARY KEY,
	CharacterId int FOREIGN KEY REFERENCES Character(Id),
	Name varchar(255),
);

ALTER TABLE ImageSequence
ADD PRIMARY KEY(Id, AnimationId, ImageIndex);

ALTER TABLE ImageSequence
ADD FOREIGN KEY (AnimationId) REFERENCES Animation(Id);