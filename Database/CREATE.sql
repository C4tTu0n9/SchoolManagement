CREATE DATABASE PRN212_Student_Management;

USE PRN212_Student_Management

CREATE TABLE [Students] (
  [StudentId] varchar(8) PRIMARY KEY,
  [FirstName] Varchar(128),
  [LastName] Varchar(128),
  [Dob] Date
);

CREATE TABLE [Subjects] (
  [SubjectId] varchar(7) PRIMARY KEY,
  [Title] Varchar(128)
);

CREATE TABLE [Marks] (
  [MarkId] Integer IDENTITY(1,1) PRIMARY KEY,
  [StudentId] varchar(8),
  [SubjectId] varchar(7),
  [Date] DateTime,
  [Mark] Integer,
  CONSTRAINT [FK_Marks.StudentId]
    FOREIGN KEY ([StudentId])
      REFERENCES [Students]([StudentId]),
  CONSTRAINT [FK_Marks.SubjectId]
    FOREIGN KEY ([SubjectId])
      REFERENCES [Subjects]([SubjectId])
);

CREATE TABLE [Teachers] (
  [TeacherId] varchar(8) PRIMARY KEY,
  [FirstName] Varchar(128),
  [LastName] Varchar(128),
  [Dob] Date
);

CREATE TABLE [Classes] (
  [ClassId] varchar(6) PRIMARY KEY,
  [Name] Varchar(128)
);

CREATE TABLE [StudentClass] (
  [StudentId] Varchar(8) NOT NULL,
  [ClassId] Varchar(6) NOT NULL,
  CONSTRAINT [FK_StudentClass.ClassId]
    FOREIGN KEY ([ClassId])
      REFERENCES [Classes]([ClassId]),
  CONSTRAINT [FK_StudentClass.StudentId]
    FOREIGN KEY ([StudentId])
      REFERENCES [Students]([StudentId]),
  PRIMARY KEY ([StudentId], [ClassId])
);

CREATE TABLE [SubjectTeacher] (
  [SubjectId] varchar(7),
  [TeacherId] varchar(8),
  [ClassId] varchar(6),
  CONSTRAINT [FK_SubjectTeacher.ClassId]
    FOREIGN KEY ([ClassId])
      REFERENCES [Classes]([ClassId]),
  CONSTRAINT [FK_SubjectTeacher.SubjectId]
    FOREIGN KEY ([SubjectId])
      REFERENCES [Subjects]([SubjectId]),
  CONSTRAINT [FK_SubjectTeacher.TeacherId]
    FOREIGN KEY ([TeacherId])
      REFERENCES [Teachers]([TeacherId]),
  PRIMARY KEY ([SubjectId], [TeacherId],[ClassId])
);

