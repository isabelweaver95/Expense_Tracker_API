CREATE DATABASE IF NOT EXISTS expense_tracker_db;
USE expense_tracker_db;

CREATE TABLE IF NOT EXISTS User (
        -- public int Id {get; set;}
        -- public string Username {get; set;}
        -- public string PasswordHash {get; set;}
        -- public string Name {get; set;}
        -- public string Email {get; set;}
        -- public string Salt {get; set;}
        -- public List<Expense> Expenses {get; set;} = new List<Expense>();
        
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(100) NOT NULL,
    Name VARCHAR(100),
    Email VARCHAR(100) UNIQUE,
    PasswordHash VARCHAR(500) NOT NULL,
    Salt VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS Catagory(
    -- public int Id {get; set;}
    -- public string Name {get; set;}
    -- public List<Expense> Expenses {get; set;} = new List<Expense>();

    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100)
);

CREATE TABLE IF NOT EXISTS Expense(
        -- public int Id {get; set;}
        -- public decimal Amount {get; set;}
        -- public DateTime Date {get; set;}
        -- public string Description {get; set;}

        -- //This is the forign keys for the database.
        -- public int CatagoryId {get; set;}
        -- public Catagory Category {get; set;}
        -- public int UserID {get; set;}

    Id INT AUTO_INCREMENT PRIMARY KEY,
    Amount DECIMAL(10,2) NOT NULL,
    Date DateTime DEFAULT CURRENT_TIMESTAMP,
    Description VARCHAR(100) NOT NULL,

    FOREIGN KEY (UserId) REFERENCES User(Id),
    FOREIGN KEY (CategoryId) REFERENCES Category(Id)

);