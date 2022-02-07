CREATE TABLE [dbo].[CourseAttendance] (
    [CourseId]         INT           NOT NULL,
    [Participant_Name] VARCHAR (255) NOT NULL,
    [Attendance]       INT           NULL,
    PRIMARY KEY CLUSTERED ([CourseId] ASC, [Participant_Name] ASC)
);

