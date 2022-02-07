CREATE TABLE [dbo].[AppUser] (
    [Id]        VARCHAR (50)   NOT NULL,
    [Name]      VARCHAR (50)   NOT NULL,
    [Password]  VARBINARY (50) NOT NULL,
    [Role]      VARCHAR (50)   NOT NULL,
    [LastLogin] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

