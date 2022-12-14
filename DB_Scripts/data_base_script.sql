USE [VoiceSage]
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_Contact]    Script Date: 11-09-2022 19:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Akhil Varghese
-- Create date: 08-Sep-2022
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_delete_Contact]
@contactId Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


   
DELETE FROM [dbo].[ContactDetail]
       where columnId = @contactId
END

GO
/****** Object:  StoredProcedure [dbo].[sp_delete_Group]    Script Date: 11-09-2022 19:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Akhil Varghese
-- Create date: 08-Sep-2022
-- Description:	
-- =============================================
Create PROCEDURE [dbo].[sp_delete_Group]
@groupId Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


   
DELETE FROM [dbo].[GroupDetail]
       where GroupId = @groupId
END

GO
/****** Object:  StoredProcedure [dbo].[sp_insert_Contact_details]    Script Date: 11-09-2022 19:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_insert_Contact_details]
@name nvarchar(50), 
@number int,
@email nchar(10),
@groupId int
AS

INSERT INTO [dbo].[ContactDetail]
           ([name]
           ,[number]
           ,[email]
           ,[groupId])
     VALUES
           (@name
           ,@number
           ,@email
           ,@groupId)


GO
/****** Object:  StoredProcedure [dbo].[sp_insert_groupdetails]    Script Date: 11-09-2022 19:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_insert_groupdetails]
@groupName nvarchar(50), 
@groupDescription nvarchar(50)
AS
INSERT INTO [dbo].[GroupDetail]
           ([GroupName]
           ,[GroupDescription])
     VALUES
           (@groupName
           ,@groupDescription)


GO
/****** Object:  StoredProcedure [dbo].[sp_select_Contact]    Script Date: 11-09-2022 19:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Akhil Varghese
-- Create date: 08-Sep-2022
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_select_Contact]
@contactId Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT * from ContactDetail inner join GroupDetail on ContactDetail.groupid = GroupDetail.GroupId  where columnId = @contactId
	
END

GO
/****** Object:  StoredProcedure [dbo].[sp_select_ContactDetail]    Script Date: 11-09-2022 19:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Akhil Varghese
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_select_ContactDetail]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
	SELECT * from ContactDetail inner join GroupDetail on ContactDetail.groupid = GroupDetail.GroupId
END

GO
/****** Object:  StoredProcedure [dbo].[sp_select_Group]    Script Date: 11-09-2022 19:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Akhil Varghese
-- Create date: 08-Sep-2022
-- Description:	
-- =============================================
Create PROCEDURE [dbo].[sp_select_Group]
@groupId Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
	SELECT * from GroupDetail where GroupId = @groupId
END

GO
/****** Object:  StoredProcedure [dbo].[sp_select_GroupDetail]    Script Date: 11-09-2022 19:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Akhil Varghese
-- Create date: 08-Sep-2022
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[sp_select_GroupDetail]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
	SELECT * from GroupDetail
END

GO
/****** Object:  StoredProcedure [dbo].[sp_update_contact_details]    Script Date: 11-09-2022 19:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_update_contact_details]
@contactId int,
@name nvarchar(50), 
@number int,
@email nchar(10), 
@groupId int
AS
Begin
UPDATE [dbo].[ContactDetail]
   SET [name] = @name
      ,[number] = @number
      ,[email] = @email
      ,[groupId] = @groupId
 WHERE columnId = @contactId
 
END

 

GO
/****** Object:  StoredProcedure [dbo].[sp_update_groupdetails]    Script Date: 11-09-2022 19:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_update_groupdetails]
@groupId int,
@groupName nvarchar(50), 
@groupDescription nvarchar(50)
AS
Begin
 UPDATE [dbo].[GroupDetail]
   SET [GroupName] = @groupName
      ,[GroupDescription] = @groupDescription
    where GroupId = @groupId
END


GO
/****** Object:  Table [dbo].[ContactDetail]    Script Date: 11-09-2022 19:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContactDetail](
	[columnId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[number] [int] NOT NULL,
	[email] [nchar](10) NOT NULL,
	[groupId] [int] NOT NULL,
 CONSTRAINT [PK_columnId] PRIMARY KEY CLUSTERED 
(
	[columnId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GroupDetail]    Script Date: 11-09-2022 19:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupDetail](
	[GroupId] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](50) NOT NULL,
	[GroupDescription] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GroupId] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ContactDetail]  WITH CHECK ADD FOREIGN KEY([groupId])
REFERENCES [dbo].[GroupDetail] ([GroupId])
GO
