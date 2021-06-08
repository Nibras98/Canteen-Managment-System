CREATE TABLE [dbo].[SignUp]
(

    [ID]          NVARCHAR(50) NOT NULL,
    [name]        NVARCHAR (50) NULL,
    [password]    NVARCHAR (50) NULL,
    [mail]        NVARCHAR (50) NULL,
    [Phonenumber] NVARCHAR (50) NULL,
    [UserType]    NVARCHAR (50) NULL, 
    CONSTRAINT [PK_SignUp] PRIMARY KEY ([ID]), 
)
