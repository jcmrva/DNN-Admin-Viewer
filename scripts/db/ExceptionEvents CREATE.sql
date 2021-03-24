SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ExceptionEvents](
	[LogEventID] [bigint] NOT NULL,
	[AssemblyVersion] [varchar](20) NOT NULL,
	[PortalId] [int] NULL,
	[UserId] [int] NULL,
	[TabId] [int] NULL,
	[RawUrl] [nvarchar](260) NULL,
	[Referrer] [nvarchar](260) NULL,
	[UserAgent] [nvarchar](260) NULL,
 CONSTRAINT [PK_ExceptionEvents] PRIMARY KEY CLUSTERED 
(
	[LogEventID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ExceptionEvents]  WITH CHECK ADD  CONSTRAINT [FK_ExceptionEvents_LogEventId] FOREIGN KEY([LogEventID])
REFERENCES [dbo].[EventLog] ([LogEventID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ExceptionEvents] CHECK CONSTRAINT [FK_ExceptionEvents_LogEventId]
GO
