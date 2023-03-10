USE [TimeJournal]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 2/28/2023 6:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedOn] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 2/28/2023 6:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(10000,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedOn] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workload]    Script Date: 2/28/2023 6:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workload](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActivityId] [int] NOT NULL,
	[Duration] [float] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedOn] [datetime2](7) NOT NULL,
	[UpdatedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Workload] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Project_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_Project_ProjectId]
GO
ALTER TABLE [dbo].[Workload]  WITH CHECK ADD  CONSTRAINT [FK_Workload_Activity_ActivityId] FOREIGN KEY([ActivityId])
REFERENCES [dbo].[Activity] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Workload] CHECK CONSTRAINT [FK_Workload_Activity_ActivityId]
GO
