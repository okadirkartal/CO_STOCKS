USE [co_stocks]
GO
/****** Object:  Table [dbo].[s_stocks]    Script Date: 9/22/2016 4:57:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[s_stocks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](15) NULL,
	[name] [varchar](25) NULL,
	[quantity] [int] NULL,
	[price] [int] NULL,
	[user_guid] [varchar](32) NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[s_users]    Script Date: 9/22/2016 4:57:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[s_users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_guid] [varchar](32) NULL,
	[username] [varchar](20) NULL,
	[name] [varchar](50) NULL,
	[surname] [varchar](50) NULL,
	[password] [varchar](15) NULL,
	[creation_date] [datetime] NULL,
	[last_logindate] [datetime] NULL,
 CONSTRAINT [PK_s_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stock_settings]    Script Date: 9/22/2016 4:57:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stock_settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[user_guid] [varchar](32) NOT NULL,
	[stock_ticker_min] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[stock_settings] ADD  DEFAULT ((10)) FOR [stock_ticker_min]
GO
