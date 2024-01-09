CREATE TABLE [dbo].[JournalEntries] (
    [ID]          INT             IDENTITY (1, 1) NOT NULL,
    [PettyCashId] INT             NULL,
    [CoaId]       INT             NULL,
    [Debit]       DECIMAL (18, 2) NULL,
    [Credit]      DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_JournalEntries] PRIMARY KEY CLUSTERED ([ID] ASC)
);

