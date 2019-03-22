CREATE TABLE [dbo].[User] (
    [IdUser]       INT            IDENTITY (1, 1) NOT NULL,
    [UserName]     NVARCHAR (64)  NOT NULL,
    [Password]     NVARCHAR (256) NOT NULL,
    [CreationUser] NVARCHAR (64)  NOT NULL,
    [CreationDate] DATETIME       NOT NULL,
    [UpdateUser]   NVARCHAR (64)  NOT NULL,
    [UpdateDate]   DATETIME       NOT NULL,
    [Active]       BIT            NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([IdUser] ASC)
);
