USE [Ticketing System]
GO

/****** Object:  Table [dbo].[Bug]    Script Date: 2024/07/01 19:51:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bug](
	[BugId] [int] IDENTITY(1,1) NOT NULL,
	[Summary] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
 CONSTRAINT [PK_Bug] PRIMARY KEY CLUSTERED 
(
	[BugId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Bug]  WITH CHECK ADD  CONSTRAINT [FK_Bug_User Table] FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User Table] ([UserId])
GO

ALTER TABLE [dbo].[Bug] CHECK CONSTRAINT [FK_Bug_User Table]
GO


