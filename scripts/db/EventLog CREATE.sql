SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventLog](
	[LogGUID] [varchar](36) NOT NULL,
	[LogTypeKey] [nvarchar](35) NOT NULL,
	[LogConfigID] [int] NULL,
	[LogUserID] [int] NULL,
	[LogUserName] [nvarchar](50) NULL,
	[LogPortalID] [int] NULL,
	[LogPortalName] [nvarchar](100) NULL,
	[LogCreateDate] [datetime] NOT NULL,
	[LogServerName] [nvarchar](50) NOT NULL,
	[LogProperties] [xml] NULL,
	[LogNotificationPending] [bit] NULL,
	[LogEventID] [bigint] IDENTITY(1,1) NOT NULL,
	[ExceptionHash] [varchar](100) NULL,
 CONSTRAINT [PK_EventLogMaster] PRIMARY KEY CLUSTERED 
(
	[LogEventID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[EventLog]  WITH NOCHECK ADD  CONSTRAINT [FK_EventLog_EventLogConfig] FOREIGN KEY([LogConfigID])
REFERENCES [dbo].[EventLogConfig] ([ID])
GO

ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK_EventLog_EventLogConfig]
GO

ALTER TABLE [dbo].[EventLog]  WITH NOCHECK ADD  CONSTRAINT [FK_EventLog_EventLogTypes] FOREIGN KEY([LogTypeKey])
REFERENCES [dbo].[EventLogTypes] ([LogTypeKey])
GO

ALTER TABLE [dbo].[EventLog] CHECK CONSTRAINT [FK_EventLog_EventLogTypes]
GO
