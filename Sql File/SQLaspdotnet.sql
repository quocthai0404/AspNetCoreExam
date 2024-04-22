use master
drop database if exists baithiaspdotnet
create database baithiaspdotnet
go
use baithiaspdotnet

CREATE TABLE DoUuTien (
    madouutien INT PRIMARY KEY IDENTITY(1,1),
    tendouuTien NVARCHAR(100) NOT NULL
);

CREATE TABLE NhanVien (
    username VARCHAR(30) PRIMARY KEY,
    password VARCHAR(200) NOT NULL,
    hoten NVARCHAR(50) NOT NULL,
    ngaysinh DATE NOT NULL,
    kichhoat BIT NOT NULL,
    hinhanh VARCHAR(100),
    quyen INT NOT NULL
);

CREATE TABLE YeuCau (
    mayeucau INT PRIMARY KEY IDENTITY(1,1),
    tieude NVARCHAR(150),
    noidung NVARCHAR(1000),
    ngaygui DATE,
    madouutien INT FOREIGN KEY REFERENCES DoUuTien(madouutien),
    manv_gui VARCHAR(30) FOREIGN KEY REFERENCES NhanVien(username),
    manv_xuly VARCHAR(30) FOREIGN KEY REFERENCES NhanVien(username)
);

