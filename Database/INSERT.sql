-- Inserting data into Students table
INSERT INTO [Students] ([StudentId], [FirstName], [LastName], [Dob]) VALUES
('S0000001', 'John', 'Doe', '2005-06-15'),
('S0000002', 'Jane', 'Smith', '2004-08-22'),
('S0000003', 'Michael', 'Brown', '2006-01-10'),
('S0000004', 'Emily', 'Davis', '2005-11-03'),
('S0000005', 'Daniel', 'Wilson', '2004-05-27');

-- Inserting data into Subjects table
INSERT INTO [Subjects] ([SubjectId], [Title]) VALUES
('SUB0001', 'Mathematics'),
('SUB0002', 'Science'),
('SUB0003', 'History'),
('SUB0004', 'English'),
('SUB0005', 'Art');

-- Inserting data into Marks table
INSERT INTO [Marks] ([StudentId], [SubjectId], [Date], [Mark]) VALUES
('S0000001', 'SUB0001', '2024-05-15 10:00:00', 85),
('S0000002', 'SUB0002', '2024-05-16 11:00:00', 90),
('S0000003', 'SUB0003', '2024-05-17 09:00:00', 78),
('S0000004', 'SUB0004', '2024-05-18 08:30:00', 88),
('S0000005', 'SUB0005', '2024-05-19 12:00:00', 92);

-- Inserting data into Teachers table
INSERT INTO [Teachers] ([TeacherId], [FirstName], [LastName], [Dob]) VALUES
('T000001', 'Alice', 'Johnson', '2005-06-15'),
('T000002', 'Robert', 'Miller', '2005-06-15'),
('T000003', 'Laura', 'Garcia', '2005-06-15'),
('T000004', 'David', 'Martinez', '2005-06-15'),
('T000005', 'Maria', 'Rodriguez', '2005-06-15');

-- Inserting data into Classes table
INSERT INTO [Classes] ([ClassId], [Name]) VALUES
('C00001', 'Class 1'),
('C00002', 'Class 2'),
('C00003', 'Class 3'),
('C00004', 'Class 4'),
('C00005', 'Class 5');

-- Inserting data into StudentClass table
INSERT INTO [StudentClass] ([StudentId], [ClassId]) VALUES
('S0000001', 'C00001'),
('S0000002', 'C00002'),
('S0000003', 'C00003'),
('S0000004', 'C00004'),
('S0000005', 'C00005');

-- Inserting data into SubjectTeacher table
INSERT INTO [SubjectTeacher] ([SubjectId], [TeacherId], [ClassId]) VALUES
('SUB0001', 'T000001', 'C00001'),
('SUB0002', 'T000002', 'C00002'),
('SUB0003', 'T000003', 'C00003'),
('SUB0004', 'T000004', 'C00004'),
('SUB0005', 'T000005', 'C00005');
