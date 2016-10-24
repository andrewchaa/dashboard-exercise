USE [Dashboard]
GO

/****** Object:  Table [dbo].[PnLs]    Script Date: 24/10/2016 23:33:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PnLs](
	[PnLId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Strategy] [int] NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_PnL] PRIMARY KEY CLUSTERED
(
	[PnLId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PnLs]  WITH CHECK ADD  CONSTRAINT [FK_PnLs_Strategies] FOREIGN KEY([Strategy])
REFERENCES [dbo].[Strategies] ([StrategyId])
GO

ALTER TABLE [dbo].[PnLs] CHECK CONSTRAINT [FK_PnLs_Strategies]
GO
