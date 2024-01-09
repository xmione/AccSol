CREATE TABLE [dbo].[Coas] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Category]    NVARCHAR (MAX) NULL,
    [SubCategory] NVARCHAR (MAX) NULL,
    [AccountName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Coas] PRIMARY KEY CLUSTERED ([ID] ASC)
);

