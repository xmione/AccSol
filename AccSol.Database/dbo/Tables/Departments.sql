CREATE TABLE [dbo].[Departments] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Code]        NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED ([ID] ASC)
);

