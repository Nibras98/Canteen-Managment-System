CREATE TABLE [dbo].[SignUp]
(
	[Id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(50) NULL, 
    [password] NVARCHAR(50) NULL, 
    [mail] NVARCHAR(50) NULL, 
    [Phonenumber] NVARCHAR(50) NULL , 
    [UserType] NVARCHAR(50) NOT NULL
)
