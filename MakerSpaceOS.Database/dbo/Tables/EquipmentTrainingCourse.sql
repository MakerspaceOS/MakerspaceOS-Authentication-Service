CREATE TABLE [dbo].[EquipmentTrainingCourse] (
    [EquipmentID]      INT NOT NULL,
    [TrainingCourseID] INT NOT NULL,
    [RequiredForUse]   INT NULL,
    CONSTRAINT [PK_EquipmentTrainingCourse] PRIMARY KEY CLUSTERED ([EquipmentID] ASC, [TrainingCourseID] ASC),
    CONSTRAINT [FK_EquipmentTrainingCourse_Equipment] FOREIGN KEY ([EquipmentID]) REFERENCES [dbo].[Equipment] ([EquipmentID]),
    CONSTRAINT [FK_EquipmentTrainingCourse_TrainingCourse] FOREIGN KEY ([TrainingCourseID]) REFERENCES [dbo].[TrainingCourse] ([TrainingCourseID])
);

