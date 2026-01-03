-- Script tạo cơ sở dữ liệu QuanLySinhVien
-- SQL Server 2022

-- Tạo database
USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'QuanLySinhVien')
BEGIN
    ALTER DATABASE QuanLySinhVien SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLySinhVien;
END
GO

CREATE DATABASE QuanLySinhVien;
GO

USE QuanLySinhVien;
GO

-- Tạo bảng Faculty (Khoa)
CREATE TABLE Faculty (
    FacultyID INT PRIMARY KEY,
    FacultyName NVARCHAR(200) NOT NULL
);
GO

-- Tạo bảng Student (Sinh viên)
CREATE TABLE Student (
    StudentID NVARCHAR(20) PRIMARY KEY,
    FullName NVARCHAR(200) NOT NULL,
    AverageScore FLOAT,
    FacultyID INT,
    CONSTRAINT FK_Student_Faculty FOREIGN KEY (FacultyID) REFERENCES Faculty(FacultyID)
);
GO

-- Nhập dữ liệu mẫu cho bảng Faculty
INSERT INTO Faculty (FacultyID, FacultyName) VALUES
(1, N'Công Nghệ Thông Tin'),
(2, N'Ngôn Ngữ Anh'),
(3, N'Quản trị kinh doanh');
GO

-- Nhập dữ liệu mẫu cho bảng Student
INSERT INTO Student (StudentID, FullName, AverageScore, FacultyID) VALUES
(N'1611061916', N'Nguyễn Trần Hoàng Lan', 4.5, 1),
(N'1711060596', N'Đàm Minh Đức', 2.5, 1),
(N'1711061004', N'Nguyễn Quốc An', 10, 2);
GO

ALTER TABLE Faculty
ADD TotalProfessor INT NULL;
GO

-- Kiểm tra dữ liệu
SELECT * FROM Faculty;
SELECT * FROM Student;
GO
