SET FOREIGN_KEY_CHECKS = 0;
drop table if exists gym; 
drop table if exists equipment;
drop table if exists trainers;
drop table if exists staff;
drop table if exists customers;
drop table if exists trainingSession;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE gym(
gymID INT,
street varchar(25),
city varchar(25),
prov varchar(25),
postalCode VARCHAR(6),
PRIMARY KEY (gymID)
);

create table equipment(
equipID INT,
gymID INT,
equipType varchar(25),
weightInLBS TINYINT UNSIGNED,
FOREIGN KEY (gymID) REFERENCES gym(gymID)
);

CREATE TABLE trainers(
trainerID INT,
firstName VARCHAR(25),
lastName VARCHAR(25),
phoneNumber CHAR(10),
email VARCHAR(50),
baseSalary INT,
hourlyFee INT,
certification VARCHAR(50),
employmentStatus BOOLEAN,
PRIMARY KEY (trainerID)
);

CREATE TABLE staff(
staffID INT,
gymID INT,
firstName VARCHAR(25),
lastName VARCHAR(25),
phoneNumber CHAR(10),
email VARCHAR(50),
salary INT,
position VARCHAR(50),
employmentStatus BOOLEAN,
PRIMARY KEY (staffID),
FOREIGN KEY (gymID) REFERENCES gym(gymID)
);

CREATE TABLE customers(
custID INT,
firstName VARCHAR(25),
lastName VARCHAR(25),
phoneNumber CHAR(10),
email VARCHAR(50),
dateOfBirth date,
membershipType VARCHAR(10),
accountStatus BOOLEAN,
PRIMARY KEY (custID)
);

CREATE TABLE trainingSession(
sessionID INT,
trainerID INT,
custID INT,
gymID INT,
sessionDate TIMESTAMP,
PRIMARY KEY (sessionID),
FOREIGN KEY (trainerID) references trainers(trainerID),
FOREIGN KEY (gymID) REFERENCES gym(gymID),
FOREIGN KEY (custID) REFERENCES customers(custID)
);
