CREATE TABLE [dbo].[PettyCashes] (
    [ID]            INT             IDENTITY (1, 1) NOT NULL,
    [PCFNo]         NVARCHAR (255)  NOT NULL,
    [Date]          DATETIME2 (7)   NULL,
    [Payee]         NVARCHAR (MAX)  NULL,
    [Particulars]   NVARCHAR (MAX)  NULL,
    [ClientId]      INT             NULL,
    [ProjectCodeId] INT             NULL,
    [Amount]        DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_PettyCashes] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PettyCashes_PCFNo]
    ON [dbo].[PettyCashes]([PCFNo] ASC);

