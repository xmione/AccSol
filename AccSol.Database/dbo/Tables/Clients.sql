CREATE TABLE [dbo].[Clients] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([ID] ASC)
);

