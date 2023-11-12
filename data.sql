CREATE DATABASE Retail;
USE Retail;
CREATE TABLE Users
(	

	Displayname nvarchar(255) NOT NULL DEFAULT N'Hãy đặt tên User',
    username NVARCHAR(255) PRIMARY KEY NOT NULL,
    password NVARCHAR(255) NOT NULL DEFAULT 0,
	TYPE INT NOT NULL DEFAULT 0,
);
drop table Users
INSERT INTO Users (Username,Displayname, Password) VALUES ('admin','Huy', '88888888');
INSERT INTO Users (Username,Displayname, Password) VALUES ('user1','Toan', '88888888');
CREATE TABLE TableCoffee
(
	ID INT IDENTITY PRIMARY KEY,
	name nvarchar(100) NOT NULL DEFAULT N'Bàn chưa đặt tên',
	status nvarchar(100) NOT NULL DEFAULT N'Trống',
)
CREATE TABLE HUMAN
(
id INT PRIMARY KEY  NOT NULL,
Name nvarchar(100) NOT NULL,
age int ,
country nvarchar(100),
status INT NOT NULL,
salary int,
)
drop table HUMAN

INSERT INTO HUMAN(id,Name,age,country,status,salary)VALUES (1,N'Nguyễn Thuý Hằng','20',N'Hải Phòng',1,'5200000')
INSERT INTO HUMAN(id,Name,age,country,status,salary)VALUES (2,N'Nguyễn Văn Huy ','22',N'Bình Định',1,'5200000')
INSERT INTO HUMAN(id,Name,age,country,status,salary)VALUES (3,N'Lê Thị Kim Loan ','24',N'Long An',1,'8300000')
INSERT INTO HUMAN(id,Name,age,country,status,salary)VALUES (4,N'Nguyễn Phúc Hậu ','23',N'Hậu Giang',1,'4200000')
INSERT INTO HUMAN(id,Name,age,country,status,salary)VALUES (5,N'Huỳnh Minh Sáng' ,'24',N'Tiền Giang',0,'0')


CREATE TABLE BILL
(
ID INT IDENTITY PRIMARY KEY,
DateCheckIn DATE,
DateCheckOut DATE,
IdTable INT NOT NULL,
status INT NOT NULL,
FOREIGN KEY(IdTable) REFERENCES TableCoffee(id)
);	
CREATE TABLE BillInfo(
id INT IDENTITY PRIMARY KEY,
idBill INT NOT NULL,
idCoffee INT NOT NULL,
 count INT NOT NULL DEFAULT 0

  FOREIGN KEY(idBill) REFERENCES BILL(id),
	FOREIGN KEY(idCoffee) REFERENCES Coffee(id)
);

CREATE TABLE CATEGORY
(
ID INT IDENTITY PRIMARY KEY,
NAME NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên' ,
);
CREATE TABLE Coffee(
	ID INT IDENTITY PRIMARY KEY,
	NAME NVARCHAR(100) DEFAULT N'Chưa đặt tên',
	IdCategory INT NOT NULL ,
	price INT NOT NULL,
	FOREIGN KEY(IdCategory) REFERENCES CATEGORY(id)
	);

INSERT INTO USERS
(
Displayname,
 Username,
 Password,
TYPE
)
VALUES (
N'NVHUY',
'ngvanhuy2003',
'123',
1)

INSERT INTO USERS(Displayname,Username,Password,TYPE)VALUES (N'Tai','Tai1','234',1)

INSERT INTO USERS
(
Displayname,
 Username,
 Password,
TYPE
)
VALUES (
N'Toan',
'Toan1',
'222',
1)

