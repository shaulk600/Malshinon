
-- create the Data Base for the System Malshinon

CREATE DATABASE
IF NOT EXISTS Malshinon;

-- enter to dataBase
USE Malshinon;

-- if exist - drop of the table's and create new table
DROP TABLE IF EXISTS Pepole ;
DROP TABLE IF EXISTS IntelReports  ;

CREATE TABLE Pepole
(
    Id_pepole INT PRIMARY KEY AUTO_INCREMENT ,
    first_name VARCHAR(100) ,
    last_name VARCHAR(100) , 
    secret_code VARCHAR (20) UNIQUE ,
    type_pepole ENUM ("reporter", "target", "both", "potential_agent") ,
    num_reports INT DEFAULT 0 ,
    num_mentions INT DEFAULT 0 
);

CREATE TABLE IntelReports
(
    Id_intelReports INT PRIMARY KEY AUTO_INCREMENT ,
    reporter_Id INT, 
    target_Id INT, 
    text_free VARCHAR(250),
    time_stamp DATETIME DEFAULT NOW(),

    FOREIGN KEY(reporter_Id) REFERENCES Pepole(Id_pepole) ,
    FOREIGN KEY(target_Id) REFERENCES Pepole(Id_pepole) 
);