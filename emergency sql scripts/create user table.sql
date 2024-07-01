USE [Ticketing System]
GO

/****** Object:  Table [dbo].[User Table]    Script Date: 2024/07/01 19:51:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User Table](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Role] [nvarchar](max) NULL,
 CONSTRAINT [PK_User Table] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[User Table]  WITH CHECK ADD  CONSTRAINT [FK_User Table_User Table] FOREIGN KEY([UserId])
REFERENCES [dbo].[User Table] ([UserId])
GO

ALTER TABLE [dbo].[User Table] CHECK CONSTRAINT [FK_User Table_User Table]
GO


