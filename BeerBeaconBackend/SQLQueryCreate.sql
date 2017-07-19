DROP TABLE Buddy
DROP TABLE Beacon
DROP TABLE [User]


CREATE TABLE [User]
(
UserId int PRIMARY KEY not null,
FaceBookId varchar(255),
InstagramId varchar(255),
UserName varchar(20),
Email varchar(255)
)

CREATE TABLE Beacon
(
BeaconId int PRIMARY KEY not null,
UserId int not null,
BeaconType smallint not null,
Latitude float(24) not null,
Longitude float(24) not null,
LocationName varchar(50),
LocationLink varchar(255),
[Private] bit not null,
StartTime datetime not null,
DrinkCounter smallint not null,
[Image] bit,
FOREIGN KEY (UserId) REFERENCES [User](UserId)
)

CREATE TABLE Buddy
(
UserId int not null,
BeaconId int not null,
BuddyStatus smallint,
ETADrinks smallint,
FOREIGN KEY (UserId) REFERENCES [User](UserId),
FOREIGN KEY (BeaconId) REFERENCES Beacon(BeaconId)
)