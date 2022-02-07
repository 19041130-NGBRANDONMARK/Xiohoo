CREATE TABLE CourseSchedule (
	CourseScheduleId int,
	TrainerId int ,
	CourseId int ,
	Date date ,
	StartTime time(7) ,
	EndTime time(7) ,
	Venue varchar(150) ,
 PRIMARY KEY(CourseScheduleId) 
 );