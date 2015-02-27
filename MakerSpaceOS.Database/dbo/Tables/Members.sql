CREATE TABLE [dbo].[Members] (
    [MemberID]     INT            IDENTITY (1, 1) NOT NULL,
    [EmailAddress] NVARCHAR (100) NULL,
    [FirstName]    NVARCHAR (50)  NULL,
    [LastName]     NVARCHAR (50)  NULL,
    [JoinDate]     DATE           NULL,
    [IsActive]     BIT            NULL,
    CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED ([MemberID] ASC)
);

