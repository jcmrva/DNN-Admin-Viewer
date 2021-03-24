SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Exceptions](
	[ExceptionHash] [varchar](100) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[StackTrace] [nvarchar](max) NULL,
	[InnerMessage] [nvarchar](500) NULL,
	[InnerStackTrace] [nvarchar](max) NULL,
	[Source] [nvarchar](500) NULL,
 CONSTRAINT [PK_Exceptions] PRIMARY KEY CLUSTERED 
(
	[ExceptionHash] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
