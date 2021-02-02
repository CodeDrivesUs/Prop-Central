USE [FlatsDatabase]
GO

INSERT INTO [dbo].[AspNetRoles]([Id], [Name])
     VALUES
           ('CAA44127-FB1F-4ACC-97DB-02CD28358B93','Admin')
GO
INSERT INTO [dbo].[AspNetRoles]([Id] ,[Name])
     VALUES
           ('b138fc4f-da74-49e4-8243-0fd2f275d07c','Tenet')
GO
INSERT INTO [dbo].[AspNetRoles]([Id] ,[Name])
     VALUES
           ('2F36C5E2-68A1-42F7-B147-0E70678CEBF5','LandLord')
GO
INSERT INTO [dbo].[Status]
           ([ShortDescription]
           ,[LongDescription])
     VALUES ('ApplicationSubmitted','The Flat application has been successfully submitted to the system pending approval')

GO

INSERT INTO [dbo].[AspNetUsers]
           ([Id],[FirstName],[LastName],[Gender],[Email],[EmailConfirmed],[PasswordHash],[SecurityStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnabled],[AccessFailedCount],[UserName])
     VALUES
           ('CAA44127-FB1F-4ACC-97DB-02CD28358B93','Zweli','Nkuna',1,'Admin@Flats.com',1,'AGig1qwCaaT03lZe2vsaeMKNJ9Yreh8bn3vcle6qO6MTJuHzx8ZtVZFwPnJbDV6Big==','CAA44127-FB1F-4ACC-97DB-02CD28358B93','0606633845',1,2,0,0,'Admin')
GO

INSERT INTO [dbo].[AspNetUserRoles]([UserId],[RoleId])
     VALUES('CAA44127-FB1F-4ACC-97DB-02CD28358B93','CAA44127-FB1F-4ACC-97DB-02CD28358B93')       
GO





