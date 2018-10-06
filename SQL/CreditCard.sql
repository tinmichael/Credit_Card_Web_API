USE [ServiceDB]
GO

/****** Object:  Table [dbo].[CreditCard]    Script Date: 10/07/2018 03:14:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CreditCard](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[CardNumber] [bigint] NULL,
	[ExpiryDate] [datetime] NULL,
 CONSTRAINT [PK_T_CreditCard] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


