CREATE DATABASE IF NOT EXSISTS expense_tracker_db;
USE expense_tracker_db;

CREATE TABLE User (
    Id INT KEY AUTO_INCRAMENT,
    Username VARCHAR(100) NOT NULL UNIQUE,
    Name VARCHAR(100),
    Email VARCHAR(100) UNIQUE,
    PasswordHash VARCHAR(500) NOT NULL,
    Salt VARCHAR(50) NOT NULL
);

CREATE TABLE Catagory(
    Id INT KEY AUTO_INCRAMENT,
    Name VARCHAR(100)
);

CREATE TABLE Expense(
        -- public int Id {get; set;}
        -- public decimal Amount {get; set;}
        -- public DateTime Date {get; set;}
        -- public string Description {get; set;}

        -- //This is the forign keys for the database.
        -- public int CatagoryId {get; set;}
        -- public Catagory Category {get; set;}
        -- public int UserID {get; set;}

    Id INT KEY AUTO_INCRAMENT
);