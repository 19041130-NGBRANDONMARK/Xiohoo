CREATE TABLE [dbo].[MugOrder] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [Email]             VARCHAR (50)  NOT NULL,
    [FullName]          VARCHAR (50)  NOT NULL,
    [Courses]           VARCHAR (MAX) NOT NULL,
    [DOB]               DATE          NOT NULL,
    [CreatedBy]         VARCHAR (50)  NULL,
    [AdditionalCourses] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

