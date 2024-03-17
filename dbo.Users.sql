CREATE TABLE [dbo].[Users] (
    [Id]     INT      IDENTITY(1,1)    NOT NULL,
    [name]   VARCHAR (50) NULL,
    [email]  VARCHAR (50) NULL,
    [gender] VARCHAR (50) NULL,
    [age]    INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

