SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventLogConfig](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LogTypeKey] [nvarchar](35) NULL,
	[LogTypePortalID] [int] NULL,
	[LoggingIsActive] [bit] NOT NULL,
	[KeepMostRecent] [int] NOT NULL,
	[EmailNotificationIsActive] [bit] NOT NULL,
	[NotificationThreshold] [int] NULL,
	[NotificationThresholdTime] [int] NULL,
	[NotificationThresholdTimeType] [int] NULL,
	[MailFromAddress] [nvarchar](50) NOT NULL,
	[MailToAddress] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EventLogConfig] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EventLogConfig]  WITH NOCHECK ADD  CONSTRAINT [FK_EventLogConfig_EventLogTypes] FOREIGN KEY([LogTypeKey])
REFERENCES [dbo].[EventLogTypes] ([LogTypeKey])
GO

ALTER TABLE [dbo].[EventLogConfig] CHECK CONSTRAINT [FK_EventLogConfig_EventLogTypes]
GO
