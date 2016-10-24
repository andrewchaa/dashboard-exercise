USE [Dashboard]
GO

/****** Object:  Table [dbo].[Strategies]    Script Date: 24/10/2016 22:52:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Strategies](
	[StrategyId] [int] NOT NULL,
	[Region] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Strategy] PRIMARY KEY CLUSTERED
(
	[StrategyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
