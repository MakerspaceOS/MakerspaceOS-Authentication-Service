CREATE TABLE [dbo].[MembersTrainingCourse] (
    [TrainingCourseID] INT NOT NULL,
    [MemberID]         INT NOT NULL,
    [PassedCourse]     BIT NULL,
    CONSTRAINT [PK_MembersTrainingCourse] PRIMARY KEY CLUSTERED ([TrainingCourseID] ASC, [MemberID] ASC),
    CONSTRAINT [FK_MembersTrainingCourse_Members] FOREIGN KEY ([MemberID]) REFERENCES [dbo].[Members] ([MemberID]),
    CONSTRAINT [FK_MembersTrainingCourse_TrainingCourse] FOREIGN KEY ([TrainingCourseID]) REFERENCES [dbo].[TrainingCourse] ([TrainingCourseID])
);

