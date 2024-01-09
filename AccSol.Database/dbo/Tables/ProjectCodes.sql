CREATE TABLE [dbo].[ProjectCodes] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Code]        NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ProjectCodes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

