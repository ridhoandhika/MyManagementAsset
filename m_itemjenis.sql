USE [dbatsis131]
GO
/****** Object:  Table [dbo].[m_itemjenis]    Script Date: 4/21/2021 9:45:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[m_itemjenis](
	[jns_kode] [varchar](10) NOT NULL,
	[jns_description] [varchar](150) NOT NULL,
	[jns_initial] [varchar](4) NULL,
	[jns_kodekategori] [varchar](10) NOT NULL,
	[jns_aktifyn] [char](1) NOT NULL,
	[jns_updateid] [varchar](15) NOT NULL,
	[jns_updatetime] [datetime] NOT NULL,
	[jns_profit] [int] NULL,
 CONSTRAINT [PK_m_itemjenis] PRIMARY KEY CLUSTERED 
(
	[jns_kode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[m_itemjenis] ADD  CONSTRAINT [DF_m_itemgroup_grp_aktifyn]  DEFAULT ('Y') FOR [jns_aktifyn]
GO
ALTER TABLE [dbo].[m_itemjenis] ADD  CONSTRAINT [DF_m_itemgroup_grp_updatetime]  DEFAULT (getdate()) FOR [jns_updatetime]
GO
