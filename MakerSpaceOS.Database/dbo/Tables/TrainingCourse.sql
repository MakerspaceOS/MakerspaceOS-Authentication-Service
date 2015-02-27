CREATE TABLE [dbo].[TrainingCourse] (
    [TrainingCourseID]   INT           IDENTITY (1, 1) NOT NULL,
    [TrainingCourseName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_TrainingCourse] PRIMARY KEY CLUSTERED ([TrainingCourseID] ASC)
);

