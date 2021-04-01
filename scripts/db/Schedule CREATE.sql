SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Schedule](
	[ScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[TypeFullName] [varchar](200) NOT NULL,
	[TimeLapse] [int] NOT NULL,
	[TimeLapseMeasurement] [varchar](2) NOT NULL,
	[RetryTimeLapse] [int] NOT NULL,
	[RetryTimeLapseMeasurement] [varchar](2) NOT NULL,
	[RetainHistoryNum] [int] NOT NULL,
	[AttachToEvent] [varchar](50) NOT NULL,
	[CatchUpEnabled] [bit] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[ObjectDependencies] [varchar](300) NOT NULL,
	[Servers] [nvarchar](2000) NULL,
	[CreatedByUserID] [int] NULL,
	[CreatedOnDate] [datetime] NULL,
	[LastModifiedByUserID] [int] NULL,
	[LastModifiedOnDate] [datetime] NULL,
	[FriendlyName] [nvarchar](200) NULL,
	[ScheduleStartDate] [datetime] NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


