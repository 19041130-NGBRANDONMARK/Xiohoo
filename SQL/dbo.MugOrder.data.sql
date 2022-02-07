SET IDENTITY_INSERT [dbo].[MugOrder] ON
INSERT INTO [dbo].[MugOrder] ([Id], [Email], [FullName], [Courses], [DOB], [CreatedBy], [AdditionalCourses]) VALUES (1, N'jonlee@yahoo.com', N'Jonathan Lee', N'Advanced Android Programming', N'1996-04-04', N'jonlee@yahoo.com', NULL)
INSERT INTO [dbo].[MugOrder] ([Id], [Email], [FullName], [Courses], [DOB], [CreatedBy], [AdditionalCourses]) VALUES (2, N'felkang@yahoo.com', N'Felicia Kang', N'Android Programming', N'1996-04-04', N'felkang@yahoo.com', N'Test')
INSERT INTO [dbo].[MugOrder] ([Id], [Email], [FullName], [Courses], [DOB], [CreatedBy], [AdditionalCourses]) VALUES (3, N'dorta@yahoo.com', N'Dorothy Tan', N'Introduction to iOS', N'1996-04-02', N'dorta@yahoo.com', N'aaaaaa')
SET IDENTITY_INSERT [dbo].[MugOrder] OFF
