	/*	creating databse	*/

CREATE DATABASE LIBRARY;

	/*	creating tables in the databse	*/
				/*MAIN TABLES*/

USE LIBRARY;

CREATE TABLE BOOK(
	ISBN BIGINT CHECK (ISBN > 1000000000 AND ISBN <10000000000000),
	Title varchar(75) NOT NULL ,
	Publisher varchar(40) NOT NULL ,
	Genre varchar(30) NOT NULL,
	PRIMARY KEY (ISBN)
);

CREATE TABLE COPY(
	CopyID VARCHAR(12) CHECK (CopyID LIKE 'CID_________' ),
	Price FLOAT(2) NOT NULL ,
	LibraryName varchar(50) NOT NULL,
	PRIMARY KEY(CopyID)             
);

CREATE TABLE MAINLIBRARY(
    MLName varchar(50),
    MLAdLine1 varchar(30) NOT NULL,
    MLAdLine2 varchar(30) NOT NULL,
    MLAdLine3 varchar(20) DEFAULT('_'),
    Telephone bigint NOT NULL CHECK (Telephone between 100000000 and 999999999),
	PRIMARY KEY(MLName)
);

CREATE TABLE BRANCHLIBRARY(
    BLName varchar(50) ,
    BLAdLine1 varchar(30) NOT NULL ,
    BLAdLine2 varchar(30) NOT NULL ,
    BLAdLine3 varchar(20) DEFAULT('_'),
	Telephone bigint NOT NULL CHECK (Telephone between 100000000 and 999999999),
    PRIMARY KEY(BLName)
);

CREATE TABLE BORROWER(
    BorrowerID varchar(8) CHECK (BorrowerID LIKE 'BID_____'), 
    FName varchar(20) NOT NULL ,	
    MName varchar(20) NULL,
    LName varchar(20) NOT NULL ,
    NICNo varchar(10) NOT NULL CHECK (NICNo LIKE '_________v'), 
	Dob date NOT NULL,
    BADLine1 varchar(30) NOT NULL ,
	BADLine2 varchar(30) NOT NULL ,
	BADLine3 varchar(20) DEFAULT('_'),
	Gender varchar(6) NULL,
    PRIMARY KEY(BorrowerID)
);

CREATE TABLE STAFF(
    StaffID varchar(6) CHECK (StaffID LIKE 'SID___'),
    FName varchar(20)NOT NULL ,
    MName varchar(20) NULL,
    LName varchar(20)NOT NULL ,
    SADLine1 varchar(30) NOT NULL ,                      
    SADLine2 varchar(30) NOT NULL ,						
    SADLine3 varchar(20) DEFAULT('_') ,
    Username varchar(20) NOT NULL ,
    Password varchar(20) NOT NULL ,
    Gender varchar(6) NOT NULL ,
    Status varchar(8) not null default 'Active',
	Telephone bigint NOT NULL CHECK (Telephone between 100000000 and 999999999),
	Position varchar(20) not null,
	PRIMARY KEY(StaffID)
);


CREATE TABLE OVERDUE(
    OverdueID INT IDENTITY(1,1),
    BorrowerID varchar(8) NOT NULL ,
    CopyID VARCHAR (12) NOT NULL ,
    Duedate date NOT NULL,
	PRIMARY KEY(OverdueID)
);

CREATE TABLE BORROWER_HISTORY(
    BorrowerID varchar(8) CHECK (BorrowerID LIKE 'BID_____'), 
    FName varchar(20) NOT NULL ,    
    LName varchar(20) NOT NULL ,
    NICNo varchar(10) NOT NULL CHECK (NICNo LIKE '_________v'), 
    Dob date NOT NULL,
    BADLine1 varchar(30) NOT NULL ,
    BADLine2 varchar(30) NOT NULL ,
    BADLine3 varchar(20) DEFAULT('_'),
    Gender varchar(6) NULL,
    MLName VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES MAINLIBRARY(MLName),
    PRIMARY KEY (BorrowerID,MLName)
);

/* FOREIGN KEYS AND ALTER KEYWORD*/

ALTER TABLE COPY 
ADD ISBN BIGINT NOT NULL FOREIGN KEY REFERENCES BOOK(ISBN);

ALTER TABLE BRANCHLIBRARY
ADD  MLName varchar(50) NOT NULL FOREIGN KEY REFERENCES MAINLIBRARY(MLName);

ALTER TABLE BORROWER
ADD MLName VARCHAR (50) NOT NULL FOREIGN KEY REFERENCES MAINLIBRARY(MLName);

ALTER TABLE STAFF
ADD MLName VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES MAINLIBRARY(MLName);

ALTER TABLE STAFF
ADD ManagerID varchar(6) DEFAULT('_') FOREIGN KEY REFERENCES STAFF(StaffID);

/*TABLES AFTER NORMALIZATION*/

CREATE TABLE CONTAIN(
	MLName varchar(50) FOREIGN KEY REFERENCES MAINLIBRARY (MLName),
    ISBN BIGINT FOREIGN KEY REFERENCES BOOK(ISBN),
	PRIMARY KEY(MLName,ISBN)			
);

CREATE TABLE managesBORROWER(
	StaffID varchar(6) FOREIGN KEY REFERENCES STAFF(StaffID) ,
	BorrowerID varchar(8) FOREIGN KEY REFERENCES BORROWER(BorrowerID),
	Process varchar(10),
	LogTime varchar(25),
	PRIMARY KEY (StaffID,BorrowerID,Process,LogTime)
);

CREATE TABLE managesCOPY(
	StaffID varchar(6) FOREIGN KEY REFERENCES STAFF(StaffID) ,
	CopyID VARCHAR (12) FOREIGN KEY REFERENCES COPY(CopyID),
	Process varchar(10),
	LogTime varchar(25),
	PRIMARY KEY (StaffID,CopyID,Process,LogTime)
);

CREATE TABLE ManagesOVERDUE(
	StaffID varchar(6) FOREIGN KEY REFERENCES STAFF(StaffID),
	OverdueID int FOREIGN KEY REFERENCES OVERDUE(OverdueID),
	PRIMARY KEY (StaffID,OverdueID)
);

CREATE TABLE Loans(
	BorrowedDate date NOT NULL,
	StaffID varchar(6) FOREIGN KEY REFERENCES STAFF(StaffID),
	BorrowerID varchar(8) FOREIGN KEY REFERENCES BORROWER(BorrowerID),
	CopyID VARCHAR (12) FOREIGN KEY REFERENCES COPY(CopyID),
	PRIMARY KEY (StaffID,BorrowerID,CopyID)
);

CREATE TABLE AUTHOR(
	Author varchar (50) ,
	ISBN BIGINT FOREIGN KEY REFERENCES BOOK(ISBN),
	PRIMARY KEY(Author,ISBN)
);

CREATE TABLE BorrowerTELEPHONE(
	Telephone bigint CHECK (Telephone between 100000000 and 999999999),
	BorrowerID varchar(8) FOREIGN KEY REFERENCES BORROWER(BorrowerID),
	PRIMARY KEY(BorrowerID,Telephone)
);

CREATE TABLE RETURNS(
	ReturnDate date NOT NULL,
	BorrowerID varchar(8) FOREIGN KEY REFERENCES BORROWER(BorrowerID),
	CopyID varchar(12) FOREIGN KEY REFERENCES COPY(CopyID),
	PRIMARY KEY(BorrowerID,CopyID)
);

CREATE TABLE ACTIVITYLOG(
	LoginTime VARCHAR(25) NOT NULL,
	LogoutTime VARCHAR(25),
	StaffID varchar(6) FOREIGN KEY REFERENCES STAFF(StaffID),
	PRIMARY KEY(LoginTime,StaffID)
);

CREATE TABLE TempACTIVITYLOG(
	LoginTime VARCHAR(25) NOT NULL,
	LogoutTime VARCHAR(25),
	StaffID varchar(6) ,
	PRIMARY KEY(StaffID)
);

insert into Book values
(90123456789,'Harry Potter and the Philosophers Stone ','Bloomsbury','Fantasy Fiction'),
(91234567890,'Beautiful Creatures','Penguin Random House','Young Adult'),
(92345678901,'Nightshade','Penguin Random House','Fantasy Fiction'),
(93456789012,'The Hunger Games','Penguin Random House','Young Adult'),
(94567890123,'Divergent','HarperCollins','Science Fiction'),
(95678901234,'The Maze Runner','Dell Publishing','Science Fiction'),
(96789012345,'The Novice','Hachette Childrens Group','Fantasy Fiction'),
(97890123456,'Tiny Pretty Things','HarperCollins Publishers','Young Adult'),
(98901234567,'The Other Side of the Sky','HarperCollins Publishers','Romance novel'),
(99012345678,'Aurora Rising','Random House Childrens Books','Adventure fiction');


insert into AUTHOR values
('J. K. Rowling',90123456789),
('Kami Garcia',91234567890),
('Margaret Stohl',91234567890),
('Andrea Cremer',92345678901),
('Suzanne Collins',93456789012),
('Veronica Roth',94567890123),
('James Dashner',95678901234),
('Taran Matharu',96789012345),
('Sona Charaipotra',97890123456),
('Dhonielle Clayton',97890123456),
('Amie Kaufman',98901234567),
('Meagan Spooner',98901234567),
('Amie Kaufman',99012345678),
('Jay Kristoff',99012345678);

insert into MAINLIBRARY values
('Colombo Public Library','No 15','Sir Marcus Fernando Rd','Colombo 007',0112367365),
('Kurunegala Public Library','No.124','Kurunegala','Kaluthara',0376565865),
('Rathnapura Public Library','AB35','Ratnapura',null,0232367365),
('Anurapura Public Library','Maithripala Senanayake Mawatha','Anuradhapura',null,0252222629),
('Jafna Public Library','AB20','Jaffna',null,0212226028),
('Kandy Public Library','Ahalepola Kumarihami Mawatha','Kandy',null,0812223716),
('Gampaha Public Library','St Marybiso Road','Gampaha',null, 0333349423),
('Puttalam Public Library','No.165','Puttalam',null,0324395865),
('Vauniya Public Library','Off Park Rd','Vavuniya',null,0246567365);

 INSERT INTO BRANCHLIBRARY VALUES
 ('Kirulapone Branch library','High level road','Kirulapone','Colombo 06',0114235672,'Colombo Public Library'),
('Mihindu Mawatha branch library','Mihindu Mawatha','Colombo 12','',0118764679,'Colombo Public Library'),
('Elliot Place branch library','Elliot Place','Colombo 12',null,0115672498,'Colombo Public Library'),
('Kuliyapitiya library','Main road','Kuliyapitiya',null,0372281345,'Kurunegala Public Library'),
('Mahaweli Uyana Library','Jaya Mawatha','Kandy',NULL,0812281261,'Kandy Public Library'),
('Eppawala Library','Talawa Rd','Eppawala',null,0252249175,'Anurapura Public Library'),
('Gunasinghe Park Reading Room','Gunasinghe Park','Colombo 11',null,0115678902,'Colombo Public Library'),
('Samalankulam library','No 32','Samalankulam','Vauniya',0247635778,'Vauniya Public Library'),
('Gurunagar Library','Beach Rd','Jaffna',null,0213456789,'Jafna Public Library'),
('Rambewa Public Library','Anuradhapura-Rambewa Hwy','Rambewa',NULL,0252266606,'Anurapura Public Library');

INSERT INTO COPY VALUES
('CID000000001',700,'Rambewa Public Library',90123456789),
('CID000000002',800,'Elliot Place branch library',90123456789),
('CID000000003',234,'Kurunegala Public Library',90123456789),
('CID000000004',678,'Samalankulam library',90123456789),
('CID000000005',9876,'Gampaha Public Library',90123456789),
('CID000000006',3400,'Rathnapura Public Library',90123456789),
('CID000000007',265,'Eppawala Library',90123456789);


insert into STAFF values
('SID001','Nimal',null,'Munasingha','No.213','Pasala Para','Gulawita','asd852','Gtr21rE','male','active',0346628319,'Head Librarian','Colombo Public Library',NULL),
('SID002','Kamal',null,'Addararachchi','No.23','Pilla Mawatha','Mathugama','bnm963','Hfd62jU','male','active',0248564328,'Librarian','Kurunegala Public Library','SID008'),
('SID003','Nayana','Kumari','Hewathanna','No.345','New Town','Anuradhapura','ghj741','Deg32jT','female','active',0713486259,'Librarian','Colombo Public library','SID010'),
('SID004','Amara','Kalani','Gulawita','No.213','Parana Town','Anuradhapura','lkj258','Vng45vH','male','active',0258762349,'Head Librarian','Rathnapura Public Library',null),
('SID005','Kasun','Deshan','Karawita','No.02','Kaluthara Road','Wadduwa','poi369','Kjy25mG','male','active',0774381629,'Head Librarian','Jafna Public Library',null),
('SID006','Sadali','Nilesha','Samaranayaka','No.42','Aluthgama Road','Katukurunda','qwe654','Jyr34hF','female','active',0702486237,'Head Librarian','Jafna Public Library',null),
('SID007','Dilka',null,'Munasingha','Hatharaman Handiya','Parana Sohona',null,'tre321','Lkc19lT','female','active',0115274625,'Head Librarian','Kandy Public Library',null),
('SID008','Nipuna','Dilshan','Kannangara','No.23','Haras Para','Boralla Kanaththa','vcx357','Pmi67lY','male','active',0317531224,'Head Librarian','Kurunegala Public Library',null),
('SID009','Danushka',null,'Samaraweera','No.52','Parana Handiya','Kadawatha','fds951','Chr76kF','male','active',0751432198,'Head Librarian','Gampaha Public Library',null),
('SID010','Disala','Nisansali','Kankangara','No.04','Aluth Para','Kahawaththa','hgf842','Xhy63yR','female','active',0712543026,'Head Librarian','Vauniya Public Library',null);

insert into CONTAIN values
('Jafna Public Library',90123456789),
('Kurunegala Public Library',91234567890),
('Rathnapura Public Library',91234567890),
('Anurapura Public Library',92345678901),
('Colombo Public Library',93456789012),
('Jafna Public Library',94567890123),
('Kandy Public Library',95678901234),
('Puttalam Public Library',96789012345),
('Vauniya Public Library',97890123456);

insert into BORROWER values
('BID00001','Nimal',null,'Silva','945677834v','1994-06-12','Dehiwala Road','Boralesgamuwa',null,'Male','Colombo Public Library'),
('BID00002','Sarath',null,'Herath','836454567v','1983-03-20','No 566','Kumara Mw','Padukka','Male','Kurunegala Public Library'),
('BID00003','Sanath','Kumara','Jayasekara','895467235v','1989-12-26','D S Senanayaka St','Ampara',null,'Male','Rathnapura Public Library'),
('BID00004','Amara',null,'Gunasekara','992354563v','1999-11-25','Gonagolla','Ampara',null,'Male','Anurapura Public Library'),
('BID00005','Sama',null,'Samaraweera','981234567v','1998-09-24','245/52','Old Awissawella Rd','Orugodawatta','Female','Anurapura Public Library'),
('BID00006','Kamal',null,'Senanayaka','970987654v','1997-07-15','M D H Jayawardana Mw','Madinnagoda',null,'Male','Jafna Public Library'),
('BID00007','Jagath',null,'Abesnayaka','871234567v','1987-06-12','Maradana Rd','Borella',null,'Male','Kandy Public Library'),
('BID00008','Leela','kalyani','Silva','963452167v','1996-04-30',' 202','Galle Rd','Wellawatta','Female','Gampaha Public Library'),
('BID00009','Neela','Kumari','Herath','950987654v','1995-02-23','No 347','Galle Rd','Colombo 05','Female','Puttalam Public Library'),
('BID00010','Puja',null,'Herath','966574932v','1996-01-03','Rubber watte Rd','Gangodawila',null,'Female','Vauniya Public Library');


insert into managesBORROWER values
('SID001','BID00001','ADD','jan 23 2020  1:45AM'),
('SID002','BID00002','DELETE','feb 13 2020  8:45AM'),
('SID003','BID00003','ADD','feb 30 2020  9:45AM'),
('SID004','BID00004','ADD','march 11 2020  8:45AM'),
('SID005','BID00005','ADD','june 08 2020  10:45AM'),
('SID006','BID00006','DELETE','oct 09 2020  11:45AM'),
('SID007','BID00007','DELETE','oct 24 2020  3:45AM'),
('SID008','BID00008','ADD','nov 01 2020  8:45AM'),
('SID009','BID00009','DELETE','nov 01 2020  8:45AM'),
('SID010','BID00010','ADD','Dec 11 2020  8:45AM');

insert into Loans values
('2020-03-24','SID001','BID00001','CID000000001'),
('2020-03-29','SID002','BID00002','CID000000002'),
('2020-04-09','SID003','BID00003','CID000000003'),
('2020-05-16','SID004','BID00004','CID000000004'),
('2020-05-27','SID005','BID00005','CID000000005'),
('2020-06-01','SID006','BID00006','CID000000006'),
('2020-07-12','SID007','BID00007','CID000000007'),
('2020-07-20','SID008','BID00008','CID000000007'),
('2020-07-23','SID009','BID00009','CID000000006'),
('2020-08-19','SID010','BID00010','CID000000005');

insert into OVERDUE values
('BID00002','CID000000001','2020-04-07'),
('BID00003','CID000000003','2020-05-04'),
('BID00004','CID000000007','2020-05-01'),
('BID00005','CID000000005','2020-06-02'),
('BID00006','CID000000006','2020-10-03'),
('BID00007','CID000000005','2020-11-04'),
('BID00008','CID000000004','2020-12-05'),
('BID00009','CID000000003','2020-12-06'),
('BID00001','CID000000003','2020-12-04'),
('BID00010','CID000000002','2020-12-07');

insert into ManagesOVERDUE values
('SID001',1),
('SID002',2),
('SID003',3),
('SID004',4),
('SID005',5),
('SID006',6),
('SID007',7),
('SID008',8),
('SID009',9),
('SID008',10);

insert into BorrowerTELEPHONE values
(0313040111,'BID00001'),
(0314567238,'BID00002'),
(0334567213,'BID00003'),
(0312410678,'BID00004'),
(0334789235,'BID00005'),
(0312456781,'BID00006'),
(0333114422,'BID00007'),
(0332345006,'BID00008'),
(0314576183,'BID00009'),
(0334787742,'BID00010');

insert into RETURNS values
('2020-04-24','BID00001','CID000000001'),
('2020-04-29','BID00002','CID000000002'),
('2020-05-09','BID00003','CID000000003'),
('2020-06-16','BID00004','CID000000004'),
('2020-06-27','BID00005','CID000000005'),
('2020-07-01','BID00006','CID000000006'),
('2020-08-12','BID00007','CID000000007'),
('2020-08-20','BID00008','CID000000006'),
('2020-08-23','BID00009','CID000000007'),
('2020-09-19','BID00010','CID000000001');

insert into ACTIVITYLOG values 
('Dec 30 2020  8:45AM','Dec 30 2020  2:45PM','SID001'),
('Dec 28 2020  8:45AM','Dec 28 2020  2:45PM','SID010'),
('Dec 27 2020  8:45AM','Dec 27 2020  4:45PM','SID009'),
('Dec 26 2020  8:45AM','Dec 26 2020  2:45PM','SID008'),
('Dec 25 2020  8:45AM','Dec 25 2020  4:45PM','SID007'),
('Nov 24 2020  8:45AM','Nov 24 2020  4:45PM','SID008'),
('Nov 23 2020  8:45AM','Nov 23 2020  4:45PM','SID010'),
('Oct 30 2020  8:45AM','Oct 30 2020  2:45PM','SID001'),
('Oct 28 2020  8:45AM','Oct 28 2020  2:45PM','SID002'),
('Oct 27 2020  8:45AM','Oct 27 2020  4:45PM','SID003'),
('Sep 26 2020  8:45AM','Sep 26 2020  2:45PM','SID004'),
('Sep 25 2020  8:45AM','Sep 25 2020  4:45PM','SID005'),
('Sep 24 2020  8:45AM','Sep 24 2020  4:45PM','SID006'),
('Sep 23 2020  8:45AM','Sep 23 2020  4:45PM','SID010');

insert into managesBORROWER values
('SID001','BID00001','ADD','Dec 30 2020  2:45PM'),
('SID002','BID00002','DELETE','Dec 30 2020  2:45PM'),
('SID003','BID00003','ADD','Dec 30 2020  3:45PM'),
('SID004','BID00004','ADD','Dec 30 2020  2:45PM'),
('SID005','BID00005','ADD','nov 30 2020  8:45PM'),
('SID006','BID00006','DELETE','nov 30 2020  2:45PM'),
('SID007','BID00007','DELETE','june 30 2020  1:45PM'),
('SID008','BID00008','ADD','feb 30 2020  2:45PM'),
('SID009','BID00009','DELETE','feb 30 2020  7:45PM'),
('SID010','BID00010','ADD','jan 30 2020  2:45PM');


--Trigger book_delete

create TRIGGER [dbo].[book_delete]
ON [dbo].[AUTHOR]
after DELETE
AS
BEGIN
 DELETE FROM COPY WHERE ISBN = (SELECT top 1 ISBN FROM deleted)
 DELETE FROM CONTAIN WHERE ISBN = (SELECT top 1 ISBN FROM deleted)
 declare @b varchar(20) = (select top 1 ISBN from deleted)
 exec deleteBook @a = @b
END

--Trigger insert_BookHistory

create TRIGGER [dbo].[insert_BookHistory]
ON [dbo].[BOOK]
for DELETE
AS
BEGIN
 insert into BOOK_HISTORY select * from deleted
END

--Trigger Insert_ActivityLog

CREATE TRIGGER Insert_ActivityLog
ON dbo.Tempary_ActLog
for delete
AS
begin
insert into ACTIVITYLOG select * from deleted
end

--Trigger insert_StaffHistory

create TRIGGER [dbo].[insert_StaffHistory]
ON [dbo].[STAFF]
for DELETE
AS
BEGIN
insert into STAFF_HISTORY (StaffID,FName,LName,SADLine1,SADLine2,SADLine3,Gender,Position,MLName)
select StaffID,FName,LName,SADLine1,SADLine2,SADLine3,Gender,Position,MLName from deleted
END

--Trigger insert_BorrowerHistory

create TRIGGER [dbo].[insert_BorrowerHistory]
ON [dbo].[BORROWER]
for DELETE
AS
BEGIN
insert into BORROWER_HISTORY (BorrowerID,FName,LName,NICNo,Dob,BADLine1,BADLine2,BADLine3,Gender,MLName)
select BorrowerID,FName,LName,NICNo,Dob,BADLine1,BADLine2,BADLine3,Gender,MLName from deleted
END

--Trigger delete_borrower

create trigger delete_borrower
on dbo.BorrowerTELEPHONE
for delete
as 
begin
delete from managesBORROWER where BorrowerID = (select borrowerid from deleted)
delete from Loans where BorrowerID = (select borrowerid from deleted)
delete from RETURNS where BorrowerID = (select borrowerid from deleted)
declare @b varchar(20) = (select BorrowerID from deleted)
exec deleteBorrower @a = @b
end


--Procedure InsertLoginTime

CREATE PROCEDURE InsertLoginTime	--	to take login time
@staffid varchar(6)
AS
INSERT INTO Tempary_ActLog (LoginTime, StaffID) VALUES (GETDATE(), @staffid)


--Procedure InsertLogoutTime

CREATE PROCEDURE InsertLogoutTime	--	to take logout time and tempry log
@staffid varchar(6)
AS
UPDATE Tempary_ActLog SET LogoutTime = GETDATE() WHERE StaffID = @staffid
delete from Tempary_ActLog where StaffID = @staffid

select * from Tempary_ActLog
select * from ACTIVITYLOG


--Procedure deleteBook

create procedure deleteBook @a varchar(20)	--	to delete a book from book table
as
delete from BOOK where ISBN = @a


--Procedure deleteBorrower

create procedure deleteBorrower @a varchar(8)	--	to delete a borrower from borrower table
as
delete from BORROWER where BorrowerID = @a

		

		/*		Functions		*/

--Function calculate_fine

CREATE FUNCTION calculate_fine
(
@DaysCount int,
@price float(2)
)
RETURNS float(2)
AS
BEGIN
return @DaysCount * @price;
end

--select dbo.calculate_fine(@DaysCount, @price)

--Function name_sort

Create function name_sort
(
@FName varchar(20),
@LName varchar(20)
)
returns varchar(42)
As
Begin return (Select @FName+ ' '+ @LName);
end
--drop function name_sort

             /*       Views      */
--View Book_and_Copy_Details

create view Book_and_Copy_Details
as
SELECT b.Title,a.Author,b.Publisher,b.Genre,c.Price,b.ISBN,c.CopyID,c.LibraryName
FROM BOOK b,AUTHOR a,COPY c
where 
b.ISBN = a.ISBN
and 
b.ISBN = c.ISBN

select * from Book_and_Copy_Details
drop view Book_and_Copy_Details

--View Book_Details

create view Book_Details
as
select b.Title,a.Author,b.Publisher,b.Genre,b.ISBN,(select COUNT(CopyID) from COPY where ISBN=b.ISBN)
as NumberOfCopies
from book as b
join author as a
on b.ISBN=a.ISBN

select * from Book_Details
drop view Book_Details

--View View_Librarian

create VIEW View_Librarian
AS
SELECT l.StaffID, l.FName, l.LName, l.Position, l.Gender, l.Telephone,
(select dbo.name_sort(h.FName,h.LName)) AS 'Head_Librarian_Name',l.MLName
FROM Staff_Active AS l
JOIN Staff_Active AS h ON l.ManagerID = h.StaffID

select * from View_Librarian
drop view View_Librarian

--View View_HeadLibrarian


create VIEW View_HeadLibrarian
AS
SELECT l.StaffID, l.FName, l.MName, l.LName, l.Position, l.SAdLine1, l.SAdLine2, l.SAdLine3, l.Telephone, l.Gender,
(select dbo.name_sort(h.FName,h.LName)) AS 'Head_Librarian_Name',l.ManagerID
FROM Staff_Active AS l JOIN Staff_Active AS h
ON l.ManagerID = h.StaffID

select * from View_HeadLibrarian
drop view View_HeadLibrarian

--View borrower_details
create view borrower_details
as
select 
b.MLName,b.BorrowerID,b.FName,b.MName,b.NICNo,b.Dob,b.BADLine1,b.BADLine2,b.BADLine3,b.Gender,t.Telephone 
from borrower as b 
join BorrowerTELEPHONE as t 
on b.BorrowerID=t.BorrowerID 

select * from borrower_details
drop view borrower_details

--View library_details

create view library_details
as
select 
m.MLName as Main_Library_Name,m.Telephone as ML_Telephone,m.MLAdLine1 as ML_Address_Line01,m.MLAdLine2
as ML_Address_Line02,m.MLAdLine3 as ML_Address_Line03,
b.BLName as Branch_Library_Name,b.Telephone as BL_Telephone,b.BLAdLine1
as BL_Address_Line01,b.BLAdLine2 as BL_Address_Line02,b.BLAdLine3 as BL_Address_Line03
from MAINLIBRARY as m
join BRANCHLIBRARY as b
on m.MLName=b.MLName

select * from library_details
drop view library_details

--View Librarians

create view Librarians
as
select l.* 
from Staff_Active as h
join Staff_Active as l
on h.StaffID = l.ManagerID


select * from librarians
drop view Librarians

--View Head_Librarians

create view Head_Librarians
as
select * 
from Staff_Active
where
Position <> 'Librarian'

select * from heaD_librarians
drop view Head_Librarians

--View Staff_Active

create view Staff_Active
as
select
StaffID,FName,MName,Lname,SADLine1,SADLine2,SADLine3,Username,Password,Gender,
Telephone,Position,MLName,ManagerID
from staff where status = 'Active'

select * from Staff_Active
drop view Staff_Active

--View Staff_History


create view Staff_History
as
select
StaffID,FName,MName,Lname,SADLine1,SADLine2,SADLine3,Username,Password,Gender,
Telephone,Position,MLName,ManagerID
from staff where status = 'Deactive'

select * from Staff_History
drop view Staff_History
