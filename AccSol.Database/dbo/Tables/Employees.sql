CREATE TABLE [dbo].[Employees] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (MAX) NULL,
    [MiddleName]   NVARCHAR (MAX) NULL,
    [LastName]     NVARCHAR (MAX) NULL,
    [DepartmentId] INT            NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([ID] ASC)
);

