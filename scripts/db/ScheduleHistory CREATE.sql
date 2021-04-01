SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ScheduleHistory](
	[ScheduleHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleID] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[Succeeded] [bit] NULL,
	[LogNotes] [ntext] NULL,
	[NextStart] [datetime] NULL,
	[Server] [nvarchar](150) NULL,
 CONSTRAINT [PK_ScheduleHistory] PRIMARY KEY CLUSTERED 
(
	[ScheduleHistoryID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ScheduleHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_ScheduleHistory_Schedule] FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[Schedule] ([ScheduleID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ScheduleHistory] CHECK CONSTRAINT [FK_ScheduleHistory_Schedule]
GO


