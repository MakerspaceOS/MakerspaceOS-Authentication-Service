CREATE TABLE [dbo].[EquipmentType] (
    [EquipmentTypeID]   INT           IDENTITY (1, 1) NOT NULL,
    [EquipmentTypeName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_EquipmentType] PRIMARY KEY CLUSTERED ([EquipmentTypeID] ASC)
);

