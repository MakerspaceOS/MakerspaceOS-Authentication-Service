CREATE TABLE [dbo].[Equipment] (
    [EquipmentID]            INT           IDENTITY (1, 1) NOT NULL,
    [EquipmentSiteUniqueID]  VARCHAR (10)  NULL,
    [EquipmentName]          NVARCHAR (50) NULL,
    [EquipmentTypeID]        INT           NULL,
    [RequiresTrainingCourse] BIT           NULL,
    CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED ([EquipmentID] ASC),
    CONSTRAINT [FK_Equipment_EquipmentType] FOREIGN KEY ([EquipmentTypeID]) REFERENCES [dbo].[EquipmentType] ([EquipmentTypeID])
);

