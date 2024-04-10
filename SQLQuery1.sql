CREATE TABLE Employee (
    SrNo BIGINT Primary Key,
    Prefix NVARCHAR(7),
    FirstName NVARCHAR(50),
    MiddleName NVARCHAR(25),
    LastName NVARCHAR(50),
    DOB DATE,
    Qualification NVARCHAR(40),
    CurrentAddress NVARCHAR(255),
    CurrentCompany NVARCHAR(400),
    DOJ DATE
);
drop Table Employee;