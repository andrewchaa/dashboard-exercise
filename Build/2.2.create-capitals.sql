USE [Dashboard]
GO

/****** Object:  Table [dbo].[Capitals]    Script Date: 24/10/2016 23:31:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Capitals](
	[CapitalId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Strategy] [int] NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Capital] PRIMARY KEY CLUSTERED
(
	[CapitalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Capitals]  WITH CHECK ADD  CONSTRAINT [FK_Capitals_Strategies] FOREIGN KEY([Strategy])
REFERENCES [dbo].[Strategies] ([StrategyId])
GO

ALTER TABLE [dbo].[Capitals] CHECK CONSTRAINT [FK_Capitals_Strategies]
GO
