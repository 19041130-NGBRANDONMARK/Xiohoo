CREATE TABLE [dbo].[CourseSchedule] (
    [CourseScheduleId] INT           NOT NULL,
    [TrainerId]        VARCHAR (150) NULL,
    [CourseId]         INT           NULL,
    [Date]             DATE          NULL,
    [StartTime]        TIME (7)      NULL,
    [EndTime]          TIME (7)      NULL,
    [Venue]            VARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([CourseScheduleId] ASC)
);

