USE [ReestrStore]
GO

/****** Object:  Table [dbo].[Documents]    Script Date: 07/09/2014 20:45:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Documents]') AND type in (N'U'))
DROP TABLE [dbo].[Documents]
GO

USE [ReestrStore]
GO

/****** Object:  Table [dbo].[Documents]    Script Date: 07/09/2014 20:45:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Documents](
	[DocumentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Created] [datetime] NOT NULL,
	[TermExecution] [datetime] NULL,
	[SenderId] [int] NOT NULL,
	[NameId] [int] NOT NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


