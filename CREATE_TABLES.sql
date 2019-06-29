USE [C#FinalProject];
GO

Drop table [dbo].[Ticket];
Drop table [dbo].[Account];
Drop table [dbo].[Show];
GO

CREATE TABLE [dbo].[Account] (
[AccountID] INT NOT NULL,
	CONSTRAINT ACCOUNT_ID_PK PRIMARY KEY(AccountID),
[Email] NVARCHAR(50) NOT NULL,
	CONSTRAINT ACCOUNT_EMAIL_UK UNIQUE(Email),
[Name] NVARCHAR(30) NULL,
[Phone] INT NULL,
	CONSTRAINT ACCOUNT_PHONE_UK UNIQUE(Phone),
[BillingAddress] NVARCHAR(50) NULL,
[Password] NVARCHAR(30) NOT NULL
)
GO

CREATE TABLE [dbo].[Show] (
[ShowID] INT NOT NULL,
	CONSTRAINT SHOW_ID_PK PRIMARY KEY(ShowID),
[Title] NVARCHAR(50) NOT NULL,
[ShowTime] NVARCHAR(50)
)
GO

CREATE TABLE [dbo].[Ticket] (
[TicketID] INT NOT NULL,
	CONSTRAINT TICKET_ID_PK PRIMARY KEY(TicketID),
[OwnerID] INT NOT NULL,
[ShowID] INT NOT NULL
)
GO

ALTER TABLE [dbo].[Ticket]
ADD CONSTRAINT TICKET_SHOWID_FK FOREIGN KEY(ShowID) REFERENCES [dbo].[Show] ([ShowID]);
GO

ALTER TABLE [dbo].[Ticket]
ADD CONSTRAINT TICKET_OWNER_FK FOREIGN KEY(OwnerID) REFERENCES [dbo].[Account] ([AccountID]);
GO


USE [C#FinalProject];
GO
--INSERT DATA
--Shows
INSERT INTO Show VALUES (1000, 'The Sound of Music',	'Tue, May 28th, 7:30 PM');
INSERT INTO Show VALUES (1001, 'The Sound of Music',	'Wed, May 29th, 1:30 PM');
INSERT INTO Show VALUES (1002, 'The Lion King',			'Thu, Jun 13th, 7:30 PM');
INSERT INTO Show VALUES (1003, 'The Lion King',			'Fri, Jun 14th, 7:30 PM');
INSERT INTO Show VALUES (1004, 'Elton John - Farewell', 'Tue, Oct 22th, 8:00 PM');
INSERT INTO Show VALUES (1005, 'Elton John - Farewell', 'Wed, Oct 23th, 8:00 PM');
GO

INSERT INTO Account VALUES (1000, 'adam@gmail.com', 'Adam', 416000, '100 Somewhere Rd. Toronto ON', 'adam');
INSERT INTO Account VALUES (1001, 'bob@gmail.com', 'Bob', 647000, '200 Nowhere Rd. Toronto ON', 'bob');
GO

INSERT INTO Ticket VALUES (1000, 1000, 1003);
INSERT INTO Ticket VALUES (1001, 1001, 1005);
GO
