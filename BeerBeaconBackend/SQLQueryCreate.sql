DROP TABLE Buddy
DROP TABLE Beacon
DROP TABLE [User]


CREATE TABLE [User]
(
UserId int PRIMARY KEY IDENTITY(1,1) not null,
FaceBookId varchar(255),
InstagramId varchar(255),
UserName varchar(20),
Email varchar(255)
)

CREATE TABLE Beacon
(
BeaconId int PRIMARY KEY IDENTITY(1,1) not null,
UserId int not null,
BeaconType int not null,
Latitude decimal(9,6) not null,
Longitude decimal(9,6) not null,
LocationName varchar(50),
LocationLink varchar(255),
[Private] bit not null,
StartTime datetime not null,
DrinkCounter int not null,
[Image] bit,
FOREIGN KEY (UserId) REFERENCES [User](UserId)
)

CREATE TABLE Buddy
(
BuddyId int IDENTITY(1,1) PRIMARY KEY not null,
UserId int not null,
BeaconId int not null,
BuddyStatus int,
ETADrinks int,
FOREIGN KEY (UserId) REFERENCES [User](UserId),
FOREIGN KEY (BeaconId) REFERENCES Beacon(BeaconId)
)