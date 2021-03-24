SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventLogTypes](
	[LogTypeKey] [nvarchar](35) NOT NULL,
	[LogTypeFriendlyName] [nvarchar](50) NOT NULL,
	[LogTypeDescription] [nvarchar](128) NOT NULL,
	[LogTypeOwner] [nvarchar](100) NOT NULL,
	[LogTypeCSSClass] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_EventLogTypes] PRIMARY KEY CLUSTERED 
(
	[LogTypeKey] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
