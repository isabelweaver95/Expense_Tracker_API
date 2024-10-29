CREATE DATABASE IF NOT EXSISTS expense_tracker_db;
USE expense_tracker_db;

CREATE TABLE User (
        -- public int Id {get; set;}
        -- public string Username {get; set;}
        -- public string PasswordHash {get; set;}
        -- public string Name {get; set;}
        -- public string Email {get; set;}
        -- public string Salt {get; set;}
        -- public List<Expense> Expenses {get; set;} = new List<Expense>();
        
    Id INT KEY AUTO_INCRAMENT,
    Username VARCHAR(100) NOT NULL UNIQUE,
    Name VARCHAR(100),
    Email VARCHAR(100) UNIQUE,
    PasswordHash VARCHAR(500) NOT NULL,
    Salt VARCHAR(50) NOT NULL
);

CREATE TABLE Catagory(
    -- public int Id {get; set;}
    -- public string Name {get; set;}
    -- public List<Expense> Expenses {get; set;} = new List<Expense>();

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

    Id INT KEY AUTO_INCRAMENT,
    Amount DECIMAL(10,2) NOT NULL,
    Date DateTime DEFAULT CURRENT_TIMESTAMP,
    Description VARCHAR(100) NOT NULL,

    FOREIGN KEY (UserId) REFERENCES User(Id),
    FOREIGN KEY (CategoryId) REFERENCES Category(Id)

);