CREATE TABLE [dbo].[RFIDTags] (
    [ID]       INT          IDENTITY (1, 1) NOT NULL,
    [RFIDCode] NCHAR (10)   NULL,
    [PIN]      NVARCHAR (4) NULL,
    [MemberID] INT          NULL,
    CONSTRAINT [PK_RFIDTags] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_RFIDTags_Members] FOREIGN KEY ([MemberID]) REFERENCES [dbo].[Members] ([MemberID])
);



