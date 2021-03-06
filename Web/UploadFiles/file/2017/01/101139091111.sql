USE [FengLin]
GO
/****** Object:  StoredProcedure [dbo].[sp_logs_getlistbypage]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2016/4/21 14:44:50
------------------------------------
CREATE PROCEDURE [dbo].[sp_logs_getlistbypage]
(
	@pageIndex		int,		--页码
	@pageSize		int,		--每页显示的记录数
	@count		int output		--总记录数
)
AS
	--统计总记录数
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from Logs a'
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by a.log_id desc) as r_id, a.*
			from Logs a
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);
GO
/****** Object:  UserDefinedFunction [dbo].[Rtrimstring]    Script Date: 12/28/2016 14:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[Rtrimstring]
               (@string nvarchar(max),
                @trimStr nvarchar(50))
RETURNS nvarchar(max)
AS
BEGIN
set @string =isnull(@string ,'')--2010.05.14更改
    WHILE (Len(@string) > 0)
      BEGIN
        IF RIGHT(@string,Len(@trimStr)) = @trimStr
          BEGIN
          --与去掉前导字符串函数正好相反，截取的时候是从左侧截取，从而忽略尾部的匹配字符串
            SET @string = LEFT(@string,Len(@string) - Len(@trimStr))
          END
        ELSE
          BREAK
      END
    RETURN @string
END
GO
/****** Object:  UserDefinedFunction [dbo].[Ltrimstring]    Script Date: 12/28/2016 14:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[Ltrimstring]
               (@string nvarchar(max),--原始字符串
                @trimStr nvarchar(50))--要去掉的前导字符串
RETURNS nvarchar(max)
AS
BEGIN
set @string =isnull(@string ,'')--2010.05.14更改
--当原始字符串长度>0就检查前导字符串是否出现在原始字符串前面
    WHILE (Len(@string) > 0)
      BEGIN
        IF LEFT(@string,Len(@trimStr)) = @trimStr
          BEGIN
               --如果出现了前导字符串就将忽略前导字符串，从字符串尾部开始截取原始字符串，长度为原始字符串的长度-前导字符串的长度
            SET @string = RIGHT(@string,Len(@string) - Len(@trimStr))
          END
        ELSE
            --如果原始字符串前面没有出现相匹配的前导字符串则中断循环
          BREAK
      END
    RETURN @string
END
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_pu_region_getlistbypage]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2016/5/16 16:52:46
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_pu_region_getlistbypage]
(
	@pageIndex		int,		--页码
	@pageSize		int,		--每页显示的记录数
	@strWhere		nvarchar(500),		--条件
	@OrderBy		nvarchar(500),		--排序
	@count		int output		--总记录数
)
AS
	--统计总记录数
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_pu_region a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*, b.region_name as parent_name
			from youhoo_pu_region a
			left join youhoo_pu_region b on b.region_id = a.parent_id
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_pu_region_getlist]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：按条件查询记录信息 
--时间：2016/5/16 16:52:46
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_pu_region_getlist]
(
	@strWhere		nvarchar(500)		--where条件
)
AS
	exec('select a.* from youhoo_pu_region a where a.flag=1 '+@strWhere+'')
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_action_getlistbypage]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2015/3/27 10:49:45
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_action_getlistbypage]
(
	@pageIndex		int,		--页码
	@pageSize		int,		--每页显示的记录数
	@strWhere		nvarchar(500),		--条件
	@OrderBy		nvarchar(500),		--排序
	@count		int output		--总记录数
)
AS
	--统计总记录数
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_sys_action a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*
			from youhoo_sys_action a
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_action_getlist]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：按条件查询记录信息 
--时间：2015/3/27 10:49:45
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_action_getlist]
(
	@strWhere		nvarchar(500)		--where条件
)
AS
	exec('select * from youhoo_sys_action a where a.flag=1 '+@strWhere+'')
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_child_getlist]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：按条件查询记录信息 
--时间：2016/6/6 12:40:32
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_child_getlist]
(
	@strWhere		nvarchar(500)		--where条件
)
AS
	exec('select a.* from youhoo_sys_dictionary_child a where a.flag=1 '+@strWhere+'')
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_getlistbypage]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2015/11/15 10:54:21
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_getlistbypage]
(
	@pageIndex		int,		--页码
	@pageSize		int,		--每页显示的记录数
	@strWhere		nvarchar(500),		--条件
	@OrderBy		nvarchar(500),		--排序
	@count		int output		--总记录数
)
AS
	--统计总记录数
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_sys_dictionary a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*
			from youhoo_sys_dictionary a
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_getlist]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：按条件查询记录信息 
--时间：2015/11/15 10:54:21
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_getlist]
(
	@strWhere		nvarchar(500)		--where条件
)
AS
	exec('select a.* from youhoo_sys_dictionary a where a.flag=1 '+@strWhere+'')
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_files_getfilepath]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：获取图片路径 
--时间：2015/7/6 15:41:13
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_files_getfilepath]
(
	@table_id		int,		--表ID
	@table_file_id		int		--表记录ID
)
AS
	select dbo.GetFilePath(@table_id, @table_file_id)
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_child_getlistbypage]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2015/4/11 12:19:44
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_child_getlistbypage]
(
	@pageIndex		int,		--页码
	@pageSize		int,		--每页显示的记录数
	@strWhere		nvarchar(500),		--条件
	@OrderBy		nvarchar(500),		--排序
	@count		int output		--总记录数
)
AS
	--统计总记录数
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_sys_dictionary_child a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*, b.dictionary_name, 
			c.dictionary_child_name as  parent_dictionary_child_name
			from youhoo_sys_dictionary_child a
			left join youhoo_sys_dictionary b on b.dictionary_id = a.dictionary_id
			left join youhoo_sys_dictionary_child c on c.dictionary_child_id = a.parent_dictionary_child_id
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_files_getlistbypage]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2015/4/11 12:19:44
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_files_getlistbypage]
(
	@pageIndex		int,		--页码
	@pageSize		int,		--每页显示的记录数
	@strWhere		nvarchar(500),		--条件
	@OrderBy		nvarchar(500),		--排序
	@count		int output		--总记录数
)
AS
	--统计总记录数
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_sys_files a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*
			from youhoo_sys_files a
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_module_getlistbypage]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2015/3/27 10:49:47
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_module_getlistbypage]
(
	@pageIndex		int,		--页码
	@pageSize		int,		--每页显示的记录数
	@strWhere		nvarchar(500),		--条件
	@OrderBy		nvarchar(500),		--排序
	@count		int output		--总记录数
)
AS
	--统计总记录数
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_sys_module a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*, b.module_name as parent_name
			from youhoo_sys_module a
			left join youhoo_sys_module b on b.module_id = a.parentmodule_id
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_module_getlist]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：按条件查询记录信息 
--时间：2015/3/27 10:49:47
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_module_getlist]
(
	@strWhere		nvarchar(500)		--where条件
)
AS
	exec('select * from youhoo_sys_module a where a.flag=1 '+@strWhere+'')
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_power_getlistbypage]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2015/3/27 10:49:48
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_power_getlistbypage]
(
	@pageIndex		int,		--页码
	@pageSize		int,		--每页显示的记录数
	@strWhere		nvarchar(500),		--条件
	@OrderBy		nvarchar(500),		--排序
	@count		int output		--总记录数
)
AS
	--统计总记录数
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_sys_power a
		left join youhoo_sys_module b on b.module_id = a.module_id
		left join youhoo_sys_action c on c.action_id = a.action_id
		where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*, b.module_name, c.action_name
			from youhoo_sys_power a
			left join youhoo_sys_module b on b.module_id = a.module_id
			left join youhoo_sys_action c on c.action_id = a.action_id
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_power_getlist]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：按条件查询记录信息 
--时间：2015/3/27 10:49:48
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_power_getlist]
(
	@strWhere		nvarchar(500)		--where条件
)
AS
	exec('select * from youhoo_sys_power a where a.flag=1 '+@strWhere+'')
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_users_getlistbypage]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2015/3/27 10:49:50
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_users_getlistbypage]
(
	@pageIndex		int,		--页码
	@pageSize		int,		--每页显示的记录数
	@strWhere		nvarchar(500),		--条件
	@OrderBy		nvarchar(500),		--排序
	@count		int output		--总记录数
)
AS
	--统计总记录数
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_sys_users a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*, b.powergroup_name
			from youhoo_sys_users a
			left join youhoo_sys_powergroup b on b.powergroup_id = a.powergroup_id
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_users_getlist]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：按条件查询记录信息 
--时间：2015/3/27 10:49:50
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_users_getlist]
(
	@strWhere		nvarchar(500)		--where条件
)
AS
	exec('select * from youhoo_sys_users a where a.flag=1 '+@strWhere+'')
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_powergroup_getlistbypage]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2015/3/27 10:49:49
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_powergroup_getlistbypage]
(
	@pageIndex		int,		--页码
	@pageSize		int,		--每页显示的记录数
	@strWhere		nvarchar(500),		--条件
	@OrderBy		nvarchar(500),		--排序
	@count		int output		--总记录数
)
AS
	--统计总记录数
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_sys_powergroup a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*
			from youhoo_sys_powergroup a
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_powergroup_getlist]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：按条件查询记录信息 
--时间：2015/3/27 10:49:49
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_powergroup_getlist]
(
	@strWhere		nvarchar(500)		--where条件
)
AS
	exec('select * from youhoo_sys_powergroup a where a.flag=1 '+@strWhere+'')
GO
/****** Object:  UserDefinedFunction [dbo].[SplitNum]    Script Date: 12/28/2016 14:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SplitNum] (@src nvarchar(max),@num int,@delimeter nvarchar(50)) 
 RETURNS nvarchar(max) AS 
 /**取得字符串（有约定分割符）第几个子字符串
  */
 BEGIN
  declare @final nvarchar(max)
  declare @p int,@count int
  set @final='';
  set @count=1
  while @count<(@num + 1)
  begin
   set @p=charindex(@delimeter,@src collate   Chinese_PRC_CS_AS_WS)
   if @p>0
   begin
    set @src=right(@src,(len(@src)-len(@delimeter)+1)-@p)
    set @count=@count+1
   end
   else
    break
  end
  set @p=charindex(@delimeter,@src collate   Chinese_PRC_CS_AS_WS)
  if @p>0
  begin
 	set @final=left(@src,@p-1) 
  end
  else
 	set @final=@src
  return case when @final is null then '' else @final end;
 END
GO
/****** Object:  UserDefinedFunction [dbo].[split]    Script Date: 12/28/2016 14:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[split]
(
 @OriginalStr nvarchar(max),
 @SplitChar nvarchar(1000)
)

returns @temp table(splitValue nvarchar(max))
As
	Begin
		declare @index int
		declare @s nvarchar(max)
   
		while(1=1)
		Begin
			set @index=charindex(@SplitChar,@OriginalStr collate Chinese_PRC_CS_AS_WS)
			if @index=0 or @index is null
			begin
				if @OriginalStr<>'' and  @index is not null 
					insert into @temp(splitValue) values(@OriginalStr)
				break;
			End
   
			set @s=left(@OriginalStr,@index-1)
			if @OriginalStr <> ''
				insert into @temp(splitValue) values(@s)
			set @OriginalStr=Right(@OriginalStr,(len(@OriginalStr)-len(@SplitChar)+1)-@index)
		End
		return
	End
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_pu_region_getmodel]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2016/5/16 16:52:46
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_pu_region_getmodel]
(
	@region_id		int		--ID
)
AS
	select * from youhoo_pu_region where flag=1 and region_id=@region_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_pu_region_exists]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：是否已经存在 
--时间：2016/5/16 16:52:46
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_pu_region_exists]
(
	@region_id		int		--ID
)
AS
	select count(1) from youhoo_pu_region where flag=1 and region_id=@region_id
GO
/****** Object:  UserDefinedFunction [dbo].[TrimString]    Script Date: 12/28/2016 14:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[TrimString] (@string nvarchar(max),--原始字符串 
                @trimStr nvarchar(50))--要去掉的前导字符串 
RETURNS nvarchar(max) 
AS 
BEGIN 
set @string=isnull( @string,'');
--当原始字符串长度>0就检查前导字符串是否出现在原始字符串前面 
    if (Len(@string) > 0) 
      BEGIN 
        set @string=dbo.rtrimstring( dbo.ltrimstring(@string,@trimstr),@trimstr)
      END 
    RETURN @string 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_users_pwdreset]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：密码重置
--时间：2015/3/27 10:49:50
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_users_pwdreset]
(
	@array_id		nvarchar(500),		--ID集合
	@password		nvarchar(50),		--新密码
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--密码重置开始-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_sys_users','系统对编号为【'+@array_id+'】的数据进行密码重置操作','','密码重置','操作员：'+@operator_name);

	exec('update youhoo_sys_users set password='''+@password+''' where user_id in ('+@array_id+')');	
	--密码重置结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_users_insertupdate]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：添加、修改 
--时间：2016/4/21 14:24:58
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_users_insertupdate]
(
	@user_id		int,		--用户编号
	@username		nvarchar(20),		--用户名
	@password		nvarchar(50),		--密码
	@real_name		nvarchar(20)=null,		--姓名
	@tel		nvarchar(20)=null,		--联系电话
	@email		nvarchar(50)=null,		--电子邮箱
	@powergroup_id		int,		--角色编号（引用权限组表，用于获取用户角色信息）
	@status		int,		--状态（0：正常；1：冻结）
	@remark		ntext=null,		--备注
	@flag		int=null,		--逻辑状态（1：存在；0：不存在）
	@createoperator		nvarchar(50)=null,		--创建人
	@createdate		datetime=null,		--创建时间
	@updateoperator		nvarchar(50)=null,		--修改人
	@updatedate		datetime=null,		--修改时间
	@v_id		int output,		--临时ID储存
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end
	
	--判断用户名是否存在开始-----------------------------------------------------------------------------------
	if((@user_id = 0 and exists(select 1 from youhoo_sys_users where flag = 1 and username = @username)) or (@user_id != 0 and exists(select 1 from youhoo_sys_users where flag = 1 and username = @username and user_id != @user_id)))
	begin
		RollBack Tran
		Return -101
	end
	--判断用户名是否存在结束-----------------------------------------------------------------------------------

	--添加开始-------------------------------------------------------------------------------------------------
	If @user_id = 0
	Begin
		Insert Into youhoo_sys_users	
			(username
			,password
			,real_name
			,tel
			,email
			,powergroup_id
			,status
			,remark
			,flag
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@username
			,@password
			,@real_name
			,@tel
			,@email
			,@powergroup_id
			,@status
			,@remark
			,1
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_sys_users',
				'',
				'用户编号:'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'用户名:'+CONVERT(nvarchar,case when @username is null then '' else CONVERT(nvarchar,@username) end)+';'+'密码:'+CONVERT(nvarchar,case when @password is null then '' else CONVERT(nvarchar,@password) end)+';'+'姓名:'+CONVERT(nvarchar,case when @real_name is null then '' else CONVERT(nvarchar,@real_name) end)+';'+'联系电话:'+CONVERT(nvarchar,case when @tel is null then '' else CONVERT(nvarchar,@tel) end)+';'+'电子邮箱:'+CONVERT(nvarchar,case when @email is null then '' else CONVERT(nvarchar,@email) end)+';'+'角色编号（引用权限组表，用于获取用户角色信息）:'+CONVERT(nvarchar,case when @powergroup_id is null then '' else CONVERT(nvarchar,@powergroup_id) end)+';'+'状态（0：正常；1：冻结）:'+CONVERT(nvarchar,case when @status is null then '' else CONVERT(nvarchar,@status) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_sys_users',
		'用户编号:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'用户名:'+CONVERT(nvarchar,case when username is null then '' else CONVERT(nvarchar,username) end)+';'+'密码:'+CONVERT(nvarchar,case when password is null then '' else CONVERT(nvarchar,password) end)+';'+'姓名:'+CONVERT(nvarchar,case when real_name is null then '' else CONVERT(nvarchar,real_name) end)+';'+'联系电话:'+CONVERT(nvarchar,case when tel is null then '' else CONVERT(nvarchar,tel) end)+';'+'电子邮箱:'+CONVERT(nvarchar,case when email is null then '' else CONVERT(nvarchar,email) end)+';'+'角色编号（引用权限组表，用于获取用户角色信息）:'+CONVERT(nvarchar,case when powergroup_id is null then '' else CONVERT(nvarchar,powergroup_id) end)+';'+'状态（0：正常；1：冻结）:'+CONVERT(nvarchar,case when status is null then '' else CONVERT(nvarchar,status) end)+';'+'备注:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'创建人:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'修改人:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		'用户编号:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'用户名:'+CONVERT(nvarchar,case when @username is null then '' else CONVERT(nvarchar,@username) end)+';'+'密码:'+CONVERT(nvarchar,case when @password is null then '' else CONVERT(nvarchar,@password) end)+';'+'姓名:'+CONVERT(nvarchar,case when @real_name is null then '' else CONVERT(nvarchar,@real_name) end)+';'+'联系电话:'+CONVERT(nvarchar,case when @tel is null then '' else CONVERT(nvarchar,@tel) end)+';'+'电子邮箱:'+CONVERT(nvarchar,case when @email is null then '' else CONVERT(nvarchar,@email) end)+';'+'角色编号（引用权限组表，用于获取用户角色信息）:'+CONVERT(nvarchar,case when @powergroup_id is null then '' else CONVERT(nvarchar,@powergroup_id) end)+';'+'状态（0：正常；1：冻结）:'+CONVERT(nvarchar,case when @status is null then '' else CONVERT(nvarchar,@status) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'创建人:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'修改人:'+CONVERT(nvarchar,@operator_name)+';'+'修改时间:'+CONVERT(nvarchar,getdate()),
		'修改数据',
		'操作员：'+@operator_name
		from youhoo_sys_users where flag=1 and user_id=@user_id
		set @v_id=@user_id;
		
		Update youhoo_sys_users		
			Set username = @username
				,password = @password
				,real_name = @real_name
				,tel = @tel
				,email = @email
				,powergroup_id = @powergroup_id
				,status = @status
				,remark = @remark
				,flag = @flag
				,createoperator = @createoperator
				,createdate = @createdate
				,updateoperator = @operator_name
				,updatedate = getdate()
		Where user_id=@user_id;
	End
	--修改结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_users_getmodelbyusernamepassword]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2015/3/23 11:04:24
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_users_getmodelbyusernamepassword]
(
	@username		nvarchar(50),		--用户名
	@password		nvarchar(50)		--密码
)
AS
	SELECT a.*, b.powergroup_value
	FROM youhoo_sys_users a
	left join youhoo_sys_powergroup b on b.powergroup_id = a.powergroup_id
	WHERE a.flag=1 and a.username=@username and a.password=@password and a.status=0
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_users_getmodel]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2015/3/27 10:49:50
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_users_getmodel]
(
	@user_id		int		--用户编号
)
AS
	select a.*, b.powergroup_value
	from youhoo_sys_users a
	left join youhoo_sys_powergroup b on b.powergroup_id = a.powergroup_id
	where a.flag=1 and a.user_id=@user_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_powergroup_exists]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：是否已经存在 
--时间：2015/3/27 10:49:49
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_powergroup_exists]
(
	@powergroup_id		int		--权限组编号
)
AS
	select count(1) from youhoo_sys_powergroup where flag=1 and powergroup_id=@powergroup_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_powergroup_delete]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：删除记录 
--时间：2015/3/27 10:49:49
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_powergroup_delete]
(
	@array_id		nvarchar(500),		--ID集合
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--删除开始-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_sys_powergroup','系统删除编号为 【'+@array_id+'】的数据','','删除数据','操作员：'+@operator_name);

	exec('update youhoo_sys_powergroup set flag=0 where powergroup_id in ('+@array_id+')');	
	--删除结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_power_insertupdate]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================
--用途：添加、修改 
--时间：2015/4/8 17:02:12
--=============================================
CREATE PROCEDURE [dbo].[sp_youhoo_sys_power_insertupdate]
(
	@power_id		int,		--权限编号
	@module_id		int,		--模块编号
	@action_id		int,		--动作编号
	@power_value		nvarchar(50)=null,		--标识编号
	@remark		ntext=null,		--备注
	@flag		int=null,		--逻辑状态（1：存在；0：不存在）
	@user_id		int,		--创建者ID
	@createoperator		nvarchar(50)=null,		--创建人
	@createdate		datetime=null,		--创建时间
	@updateoperator		nvarchar(50)=null,		--修改人
	@updatedate		datetime=null,		--修改时间
	@v_id		int output,		--临时ID储存
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end
	
	--判断标识编号是否存在开始---------------------------------------------------------------------------------
	if((@power_id = 0 and exists(select 1 from youhoo_sys_power where flag = 1 and power_value = @power_value)) or (@power_id != 0 and exists(select 1 from youhoo_sys_power where flag = 1 and power_value = @power_value and power_id != @power_id)))
	begin
		RollBack Tran
		Return -101
	end
	--判断标识编号是否存在结束---------------------------------------------------------------------------------

	--添加开始-------------------------------------------------------------------------------------------------
	If @power_id = 0
	Begin
		Insert Into youhoo_sys_power	
			(module_id
			,action_id
			,power_value
			,remark
			,flag
			,user_id
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@module_id
			,@action_id
			,@power_value
			,@remark
			,1
			,@operator_id
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_sys_power',
				'',
				'权限编号:'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'模块编号:'+CONVERT(nvarchar,case when @module_id is null then '' else CONVERT(nvarchar,@module_id) end)+';'+'动作编号:'+CONVERT(nvarchar,case when @action_id is null then '' else CONVERT(nvarchar,@action_id) end)+';'+'标识编号:'+CONVERT(nvarchar,case when @power_value is null then '' else CONVERT(nvarchar,@power_value) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建者ID:'+CONVERT(nvarchar,@operator_id)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_sys_power',
		'权限编号:'+CONVERT(nvarchar,case when power_id is null then '' else CONVERT(nvarchar,power_id) end)+';'+'模块编号:'+CONVERT(nvarchar,case when module_id is null then '' else CONVERT(nvarchar,module_id) end)+';'+'动作编号:'+CONVERT(nvarchar,case when action_id is null then '' else CONVERT(nvarchar,action_id) end)+';'+'标识编号:'+CONVERT(nvarchar,case when power_value is null then '' else CONVERT(nvarchar,power_value) end)+';'+'备注:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'修改人:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		'权限编号:'+CONVERT(nvarchar,case when @power_id is null then '' else CONVERT(nvarchar,@power_id) end)+';'+'模块编号:'+CONVERT(nvarchar,case when @module_id is null then '' else CONVERT(nvarchar,@module_id) end)+';'+'动作编号:'+CONVERT(nvarchar,case when @action_id is null then '' else CONVERT(nvarchar,@action_id) end)+';'+'标识编号:'+CONVERT(nvarchar,case when @power_value is null then '' else CONVERT(nvarchar,@power_value) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'修改人:'+CONVERT(nvarchar,@operator_name)+';'+'修改时间:'+CONVERT(nvarchar,getdate()),
		'修改数据',
		'操作员：'+@operator_name
		from youhoo_sys_power where flag=1 and power_id=@power_id
		set @v_id=@power_id;
		
		Update youhoo_sys_power		
			Set module_id = @module_id
				,action_id = @action_id
				,power_value = @power_value
				,remark = @remark
				,flag = @flag
				,user_id = @user_id
				,createoperator = @createoperator
				,createdate = @createdate
				,updateoperator = @operator_name
				,updatedate = getdate()
		Where power_id=@power_id;
	End
	--修改结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_power_getmodel]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2015/3/27 10:49:48
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_power_getmodel]
(
	@power_id		int		--权限编号
)
AS
	select * from youhoo_sys_power where flag=1 and power_id=@power_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_users_freeze]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：冻结记录 
--时间：2015/3/27 10:49:50
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_users_freeze]
(
	@array_id		nvarchar(500),		--ID集合
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--冻结开始-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_sys_users','系统冻结编号为 【'+@array_id+'】的数据','','冻结数据','操作员：'+@operator_name);

	exec('update youhoo_sys_users set status=1 where user_id in ('+@array_id+')');	
	--冻结结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_users_exists]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：是否已经存在 
--时间：2015/3/27 10:49:50
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_users_exists]
(
	@username		nvarchar(20)		--用户名
)
AS
	select count(1) from youhoo_sys_users where flag=1 and username=@username
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_users_delete]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：删除记录 
--时间：2015/3/27 10:49:50
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_users_delete]
(
	@array_id		nvarchar(500),		--ID集合
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--删除开始-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_sys_users','系统删除编号为 【'+@array_id+'】的数据','','删除数据','操作员：'+@operator_name);

	exec('update youhoo_sys_users set flag=0 where user_id in ('+@array_id+')');	
	--删除结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_users_cancelfreeze]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：取消冻结记录 
--时间：2015/3/27 10:49:50
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_users_cancelfreeze]
(
	@array_id		nvarchar(500),		--ID集合
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--取消冻结开始-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_sys_users','系统取消冻结编号为 【'+@array_id+'】的数据','','取消冻结数据','操作员：'+@operator_name);

	exec('update youhoo_sys_users set status=0 where user_id in ('+@array_id+')');	
	--取消冻结结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_system_set_insertupdate]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：添加、修改 
--时间：2016-10-13 17:08:52
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_system_set_insertupdate]
(
	@system_set_id		int,		--ID
	@system_set_name		nvarchar(50)=null,		--系统名称
	@system_set_hou_logo		nvarchar(200)=null,		--系统logo
	@system_set_login_biaozhi		nvarchar(200)=null,		--系统登陆页标识
	@system_set_icon		nvarchar(200)=null,		--系统图标
	@initial_pwd		nvarchar(16),		--初始密码
	@list_show_count		int,		--列表显示数量
	@remark		ntext=null,		--备注
	@flag		int=null,		--逻辑状态（1：存在；0：不存在）
	@user_id		int,		--创建者ID
	@createoperator		nvarchar(50)=null,		--创建人
	@createdate		datetime=null,		--创建时间
	@updateoperator		nvarchar(50)=null,		--修改人
	@updatedate		datetime=null,		--修改时间
	@v_id		int output,		--临时ID储存
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--添加开始-------------------------------------------------------------------------------------------------
	If @system_set_id = 0
	Begin
		Insert Into youhoo_sys_system_set	
			(system_set_name
			,system_set_hou_logo
			,system_set_login_biaozhi
			,system_set_icon
			,initial_pwd
			,list_show_count
			,remark
			,flag
			,user_id
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@system_set_name
			,@system_set_hou_logo
			,@system_set_login_biaozhi
			,@system_set_icon
			,@initial_pwd
			,@list_show_count
			,@remark
			,1
			,@operator_id
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_sys_system_set',
				'',
				'ID:'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'系统名称:'+CONVERT(nvarchar,case when @system_set_name is null then '' else CONVERT(nvarchar,@system_set_name) end)+';'+'系统logo:'+CONVERT(nvarchar,case when @system_set_hou_logo is null then '' else CONVERT(nvarchar,@system_set_hou_logo) end)+';'+'系统登陆页标识:'+CONVERT(nvarchar,case when @system_set_login_biaozhi is null then '' else CONVERT(nvarchar,@system_set_login_biaozhi) end)+';'+'系统图标:'+CONVERT(nvarchar,case when @system_set_icon is null then '' else CONVERT(nvarchar,@system_set_icon) end)+';'+'初始密码:'+CONVERT(nvarchar,case when @initial_pwd is null then '' else CONVERT(nvarchar,@initial_pwd) end)+';'+'列表显示数量:'+CONVERT(nvarchar,case when @list_show_count is null then '' else CONVERT(nvarchar,@list_show_count) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建者ID:'+CONVERT(nvarchar,@operator_id)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_sys_system_set',
		'ID:'+CONVERT(nvarchar,case when system_set_id is null then '' else CONVERT(nvarchar,system_set_id) end)+';'+'系统名称:'+CONVERT(nvarchar,case when system_set_name is null then '' else CONVERT(nvarchar,system_set_name) end)+';'+'系统logo:'+CONVERT(nvarchar,case when system_set_hou_logo is null then '' else CONVERT(nvarchar,system_set_hou_logo) end)+';'+'系统登陆页标识:'+CONVERT(nvarchar,case when system_set_login_biaozhi is null then '' else CONVERT(nvarchar,system_set_login_biaozhi) end)+';'+'系统图标:'+CONVERT(nvarchar,case when system_set_icon is null then '' else CONVERT(nvarchar,system_set_icon) end)+';'+'初始密码:'+CONVERT(nvarchar,case when initial_pwd is null then '' else CONVERT(nvarchar,initial_pwd) end)+';'+'列表显示数量:'+CONVERT(nvarchar,case when list_show_count is null then '' else CONVERT(nvarchar,list_show_count) end)+';'+'备注:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'修改人:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		'ID:'+CONVERT(nvarchar,case when @system_set_id is null then '' else CONVERT(nvarchar,@system_set_id) end)+';'+'系统名称:'+CONVERT(nvarchar,case when @system_set_name is null then '' else CONVERT(nvarchar,@system_set_name) end)+';'+'系统logo:'+CONVERT(nvarchar,case when @system_set_hou_logo is null then '' else CONVERT(nvarchar,@system_set_hou_logo) end)+';'+'系统登陆页标识:'+CONVERT(nvarchar,case when @system_set_login_biaozhi is null then '' else CONVERT(nvarchar,@system_set_login_biaozhi) end)+';'+'系统图标:'+CONVERT(nvarchar,case when @system_set_icon is null then '' else CONVERT(nvarchar,@system_set_icon) end)+';'+'初始密码:'+CONVERT(nvarchar,case when @initial_pwd is null then '' else CONVERT(nvarchar,@initial_pwd) end)+';'+'列表显示数量:'+CONVERT(nvarchar,case when @list_show_count is null then '' else CONVERT(nvarchar,@list_show_count) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'修改人:'+CONVERT(nvarchar,@operator_name)+';'+'修改时间:'+CONVERT(nvarchar,getdate()),
		'修改数据',
		'操作员：'+@operator_name
		from youhoo_sys_system_set where flag=1 and system_set_id=@system_set_id
		set @v_id=@system_set_id;
		
		Update youhoo_sys_system_set		
			Set system_set_name = @system_set_name
				,system_set_hou_logo = @system_set_hou_logo
				,system_set_login_biaozhi = @system_set_login_biaozhi
				,system_set_icon = @system_set_icon
				,initial_pwd = @initial_pwd
				,list_show_count = @list_show_count
				,remark = @remark
				,flag = @flag
				,user_id = @user_id
				,createoperator = @createoperator
				,createdate = @createdate
				,updateoperator = @operator_name
				,updatedate = getdate()
		Where system_set_id=@system_set_id;
	End
	--修改结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_system_set_getmodel]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2016/9/14 11:22:40
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_system_set_getmodel]
(
	@system_set_id		int		--ID
)
AS
	select * from youhoo_sys_system_set where flag=1 and system_set_id=@system_set_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_powergroup_insertupdate]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================
--用途：添加、修改 
--时间：2015/4/8 17:02:13
--=============================================
CREATE PROCEDURE [dbo].[sp_youhoo_sys_powergroup_insertupdate]
(
	@powergroup_id		int,		--权限组编号
	@powergroup_name		nvarchar(400),		--权限组名称
	@powergroup_value		ntext=null,		--标识编号
	@remark		ntext=null,		--备注
	@flag		int=null,		--逻辑状态（1：存在；0：不存在）
	@user_id		int,		--创建者ID
	@createoperator		nvarchar(50)=null,		--创建人
	@createdate		datetime=null,		--创建时间
	@updateoperator		nvarchar(50)=null,		--修改人
	@updatedate		datetime=null,		--修改时间
	@v_id		int output,		--临时ID储存
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--添加开始-------------------------------------------------------------------------------------------------
	If @powergroup_id = 0
	Begin
		Insert Into youhoo_sys_powergroup	
			(powergroup_name
			,powergroup_value
			,remark
			,flag
			,user_id
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@powergroup_name
			,@powergroup_value
			,@remark
			,1
			,@operator_id
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_sys_powergroup',
				'',
				'权限组编号:'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'权限组名称:'+CONVERT(nvarchar,case when @powergroup_name is null then '' else CONVERT(nvarchar,@powergroup_name) end)+';'+'标识编号:'+CONVERT(nvarchar,case when @powergroup_value is null then '' else CONVERT(nvarchar,@powergroup_value) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建者ID:'+CONVERT(nvarchar,@operator_id)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_sys_powergroup',
		'权限组编号:'+CONVERT(nvarchar,case when powergroup_id is null then '' else CONVERT(nvarchar,powergroup_id) end)+';'+'权限组名称:'+CONVERT(nvarchar,case when powergroup_name is null then '' else CONVERT(nvarchar,powergroup_name) end)+';'+'标识编号:'+CONVERT(nvarchar,case when powergroup_value is null then '' else CONVERT(nvarchar,powergroup_value) end)+';'+'备注:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'修改人:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		'权限组编号:'+CONVERT(nvarchar,case when @powergroup_id is null then '' else CONVERT(nvarchar,@powergroup_id) end)+';'+'权限组名称:'+CONVERT(nvarchar,case when @powergroup_name is null then '' else CONVERT(nvarchar,@powergroup_name) end)+';'+'标识编号:'+CONVERT(nvarchar,case when @powergroup_value is null then '' else CONVERT(nvarchar,@powergroup_value) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'修改人:'+CONVERT(nvarchar,@operator_name)+';'+'修改时间:'+CONVERT(nvarchar,getdate()),
		'修改数据',
		'操作员：'+@operator_name
		from youhoo_sys_powergroup where flag=1 and powergroup_id=@powergroup_id
		set @v_id=@powergroup_id;
		
		Update youhoo_sys_powergroup		
			Set powergroup_name = @powergroup_name
				,powergroup_value = @powergroup_value
				,remark = @remark
				,flag = @flag
				,user_id = @user_id
				,createoperator = @createoperator
				,createdate = @createdate
				,updateoperator = @operator_name
				,updatedate = getdate()
		Where powergroup_id=@powergroup_id;
	End
	--修改结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_powergroup_getmodel]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2015/3/27 10:49:49
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_powergroup_getmodel]
(
	@powergroup_id		int		--权限组编号
)
AS
	select * from youhoo_sys_powergroup where flag=1 and powergroup_id=@powergroup_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_power_exists]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：是否已经存在 
--时间：2015/3/27 10:49:48
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_power_exists]
(
	@power_value		nvarchar(50)		--标识编号
)
AS
	select count(1) from youhoo_sys_power where flag=1 and power_value=@power_value
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_power_delete]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：删除记录 
--时间：2015/3/27 10:49:48
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_power_delete]
(
	@array_id		nvarchar(500),		--ID集合
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--删除开始-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_sys_power','系统删除编号为 【'+@array_id+'】的数据','','删除数据','操作员：'+@operator_name);

	exec('update youhoo_sys_power set flag=0 where power_id in ('+@array_id+')');	
	--删除结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_power_action]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_youhoo_sys_power_action]
	@module_id int,        --页码
	@powergroup_id int

as

    --统计总页数
	declare @powergroup_value nvarchar(max);
	select @powergroup_value=convert(nvarchar(max),powergroup_value) 
			from dbo.youhoo_sys_powergroup where powergroup_id=@powergroup_id

	select ROW_NUMBER() over(Order by a.action_value) as r_id,
			p.*, m.module_id, m.module_name, a.action_name, @powergroup_value as powergroup_value,
			(select count(*) from dbo.split(@powergroup_value,',') t where t.splitValue=p.power_value) ispower
		from youhoo_sys_power p
left outer join youhoo_sys_module m on (p.module_id=m.module_id)
left outer join youhoo_sys_action a on (p.action_id=a.action_id)
	   where p.flag=1 and p.module_id=@module_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_module_insertupdate]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================
--用途：添加、修改 
--时间：2015/4/8 17:02:12
--=============================================
CREATE PROCEDURE [dbo].[sp_youhoo_sys_module_insertupdate]
(
	@module_id		int,		--模块编号
	@module_name		nvarchar(400),		--模块名称
	@parentmodule_id		int,		--父级模块id
	@module_url		nvarchar(400)=null,		--模块链接地址
	@module_value		nvarchar(50)=null,		--标识编号
	@sort		int,		--排序
	@remark		ntext=null,		--备注
	@flag		int=null,		--逻辑状态（1：存在；0：不存在）
	@user_id		int,		--创建者ID
	@createoperator		nvarchar(50)=null,		--创建人
	@createdate		datetime=null,		--创建时间
	@updateoperator		nvarchar(50)=null,		--修改人
	@updatedate		datetime=null,		--修改时间
	@v_id		int output,		--临时ID储存
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--添加开始-------------------------------------------------------------------------------------------------
	If @module_id = 0
	Begin
		Insert Into youhoo_sys_module	
			(module_name
			,parentmodule_id
			,module_url
			,module_value
			,sort
			,remark
			,flag
			,user_id
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@module_name
			,@parentmodule_id
			,@module_url
			,@module_value
			,@sort
			,@remark
			,1
			,@operator_id
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_sys_module',
				'',
				'模块编号:'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'模块名称:'+CONVERT(nvarchar,case when @module_name is null then '' else CONVERT(nvarchar,@module_name) end)+';'+'父级模块id:'+CONVERT(nvarchar,case when @parentmodule_id is null then '' else CONVERT(nvarchar,@parentmodule_id) end)+';'+'模块链接地址:'+CONVERT(nvarchar,case when @module_url is null then '' else CONVERT(nvarchar,@module_url) end)+';'+'标识编号:'+CONVERT(nvarchar,case when @module_value is null then '' else CONVERT(nvarchar,@module_value) end)+';'+'排序:'+CONVERT(nvarchar,case when @sort is null then '' else CONVERT(nvarchar,@sort) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建者ID:'+CONVERT(nvarchar,@operator_id)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_sys_module',
		'模块编号:'+CONVERT(nvarchar,case when module_id is null then '' else CONVERT(nvarchar,module_id) end)+';'+'模块名称:'+CONVERT(nvarchar,case when module_name is null then '' else CONVERT(nvarchar,module_name) end)+';'+'父级模块id:'+CONVERT(nvarchar,case when parentmodule_id is null then '' else CONVERT(nvarchar,parentmodule_id) end)+';'+'模块链接地址:'+CONVERT(nvarchar,case when module_url is null then '' else CONVERT(nvarchar,module_url) end)+';'+'标识编号:'+CONVERT(nvarchar,case when module_value is null then '' else CONVERT(nvarchar,module_value) end)+';'+'排序:'+CONVERT(nvarchar,case when sort is null then '' else CONVERT(nvarchar,sort) end)+';'+'备注:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'修改人:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		'模块编号:'+CONVERT(nvarchar,case when @module_id is null then '' else CONVERT(nvarchar,@module_id) end)+';'+'模块名称:'+CONVERT(nvarchar,case when @module_name is null then '' else CONVERT(nvarchar,@module_name) end)+';'+'父级模块id:'+CONVERT(nvarchar,case when @parentmodule_id is null then '' else CONVERT(nvarchar,@parentmodule_id) end)+';'+'模块链接地址:'+CONVERT(nvarchar,case when @module_url is null then '' else CONVERT(nvarchar,@module_url) end)+';'+'标识编号:'+CONVERT(nvarchar,case when @module_value is null then '' else CONVERT(nvarchar,@module_value) end)+';'+'排序:'+CONVERT(nvarchar,case when @sort is null then '' else CONVERT(nvarchar,@sort) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'修改人:'+CONVERT(nvarchar,@operator_name)+';'+'修改时间:'+CONVERT(nvarchar,getdate()),
		'修改数据',
		'操作员：'+@operator_name
		from youhoo_sys_module where flag=1 and module_id=@module_id
		set @v_id=@module_id;
		
		Update youhoo_sys_module		
			Set module_name = @module_name
				,parentmodule_id = @parentmodule_id
				,module_url = @module_url
				,module_value = @module_value
				,sort = @sort
				,remark = @remark
				,flag = @flag
				,user_id = @user_id
				,createoperator = @createoperator
				,createdate = @createdate
				,updateoperator = @operator_name
				,updatedate = getdate()
		Where module_id=@module_id;
	End
	--修改结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_module_getmodel]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2015/3/27 10:49:47
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_module_getmodel]
(
	@module_id		int		--模块编号
)
AS
	select * from youhoo_sys_module where flag=1 and module_id=@module_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_module_exists]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：是否已经存在 
--时间：2015/3/27 10:49:47
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_module_exists]
(
	@module_id		int		--模块编号
)
AS
	select count(1) from youhoo_sys_module where flag=1 and module_id=@module_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_module_delete]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：删除记录 
--时间：2015/3/27 10:49:47
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_module_delete]
(
	@array_id		nvarchar(500),		--ID集合
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--删除开始-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_sys_module','系统删除编号为 【'+@array_id+'】的数据','','删除数据','操作员：'+@operator_name);

	exec('update youhoo_sys_module set flag=0 where module_id in ('+@array_id+')');	
	--删除结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_files_insertupdate]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================
--用途：添加、修改 
--时间：2015/4/11 12:19:44
--=============================================
CREATE PROCEDURE [dbo].[sp_youhoo_sys_files_insertupdate]
(
	@file_id		int,		--文件编号
	@table_id		int,		--表ID
	@table_file_id		int,		--表记录ID
	@file_name		nvarchar(500),		--文件名
	@file_path		nvarchar(500)=null,		--文件路径
	@file_size		nvarchar(50)=null,		--文件大小
	@remark		ntext=null,		--备注
	@flag		int=null,		--逻辑状态（1：存在；0：不存在）
	@user_id		int,		--创建者ID
	@createoperator		nvarchar(50)=null,		--创建人
	@createdate		datetime=null,		--创建时间
	@updateoperator		nvarchar(50)=null,		--修改人
	@updatedate		datetime=null,		--修改时间
	@v_id		int output,		--临时ID储存
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		set @operator_name = '网友';
	end

	--添加开始-------------------------------------------------------------------------------------------------
	If @file_id = 0
	Begin
		Insert Into youhoo_sys_files	
			(table_id
			,table_file_id
			,file_name
			,file_path
			,file_size
			,remark
			,flag
			,user_id
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@table_id
			,@table_file_id
			,@file_name
			,@file_path
			,@file_size
			,@remark
			,1
			,@operator_id
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_sys_files',
				'',
				'文件编号:'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'表ID:'+CONVERT(nvarchar,case when @table_id is null then '' else CONVERT(nvarchar,@table_id) end)+';'+'表记录ID:'+CONVERT(nvarchar,case when @table_file_id is null then '' else CONVERT(nvarchar,@table_file_id) end)+';'+'文件名:'+CONVERT(nvarchar,case when @file_name is null then '' else CONVERT(nvarchar,@file_name) end)+';'+'文件路径:'+CONVERT(nvarchar,case when @file_path is null then '' else CONVERT(nvarchar,@file_path) end)+';'+'文件大小:'+CONVERT(nvarchar,case when @file_size is null then '' else CONVERT(nvarchar,@file_size) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建者ID:'+CONVERT(nvarchar,@operator_id)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin

		set @v_id=@file_id;
		
		update s set s.remark=''
			from youhoo_sys_files s
		where exists (select '*' from youhoo_sys_files f where s.table_id=f.table_id and s.table_file_id=f.table_file_id and f.file_id=@file_id)
		Update youhoo_sys_files set remark=@remark where file_id=@file_id
	End
	--修改结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_files_getmodel]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2015/4/11 12:19:44
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_files_getmodel]
(
	@file_id		int		--文件编号
)
AS
	select * from youhoo_sys_files where flag=1 and file_id=@file_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_files_getlist]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：按条件查询记录信息 
--时间：2015/4/11 12:19:44
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_files_getlist]
(
	@table_id		int,
	@table_file_id int
)
AS
	select a.* from youhoo_sys_files a
	where a.flag=1 and a.table_id=@table_id and a.table_file_id=@table_file_id
	order by (case when convert(nvarchar(20), a.remark) = '1' then 1 else 0 end) desc, a.file_id asc
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_child_getlistbydictionaryid]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：根据字典ID获得数据列表 
--时间：2015/4/11 12:19:44
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_child_getlistbydictionaryid]
(
	@dictionary_id		int		--字典ID
)
AS
	select a.* from youhoo_sys_dictionary_child a
	where a.flag=1 and a.dictionary_id = @dictionary_id and a.is_start = 1
	order by sort asc
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_files_exists]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：是否已经存在 
--时间：2015/4/11 12:19:44
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_files_exists]
(
	@file_id		int		--文件编号
)
AS
	select count(1) from youhoo_sys_files where flag=1 and file_id=@file_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_files_delete]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：删除记录 
--时间：2015/4/11 12:19:44
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_files_delete]
(
	@array_id		nvarchar(500),		--ID集合
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		set @operator_name = '网友';
	end

	--删除开始-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_sys_files','系统删除编号为【'+@array_id+'】的数据','','删除数据','操作员：'+@operator_name);

	exec('delete youhoo_sys_files where file_id in ('+@array_id+')');	
	--删除结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_insertupdate]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：添加、修改 
--时间：2016/6/7 9:26:32
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_insertupdate]
(
	@dictionary_id		int,		--字典编号
	@dictionary_name		nvarchar(50),		--字典名称
	@is_multilayer		int,		--是否为多层级结构（1：是；0：否）
	@sort		int,		--排序
	@remark		ntext=null,		--备注
	@flag		int=null,		--逻辑状态（1：存在；0：不存在）
	@user_id		int,		--创建者ID
	@createoperator		nvarchar(50)=null,		--创建人
	@createdate		datetime=null,		--创建时间
	@updateoperator		nvarchar(50)=null,		--修改人
	@updatedate		datetime=null,		--修改时间
	@v_id		int output,		--临时ID储存
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--添加开始-------------------------------------------------------------------------------------------------
	If @dictionary_id = 0
	Begin
		Insert Into youhoo_sys_dictionary	
			(dictionary_name
			,is_multilayer
			,sort
			,remark
			,flag
			,user_id
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@dictionary_name
			,@is_multilayer
			,@sort
			,@remark
			,1
			,@operator_id
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_sys_dictionary',
				'',
				'字典编号:'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'字典名称:'+CONVERT(nvarchar,case when @dictionary_name is null then '' else CONVERT(nvarchar,@dictionary_name) end)+';'+'是否为多层级结构（1：是；0：否）:'+CONVERT(nvarchar,case when @is_multilayer is null then '' else CONVERT(nvarchar,@is_multilayer) end)+';'+'排序:'+CONVERT(nvarchar,case when @sort is null then '' else CONVERT(nvarchar,@sort) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建者ID:'+CONVERT(nvarchar,@operator_id)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_sys_dictionary',
		'字典编号:'+CONVERT(nvarchar,case when dictionary_id is null then '' else CONVERT(nvarchar,dictionary_id) end)+';'+'字典名称:'+CONVERT(nvarchar,case when dictionary_name is null then '' else CONVERT(nvarchar,dictionary_name) end)+';'+'是否为多层级结构（1：是；0：否）:'+CONVERT(nvarchar,case when is_multilayer is null then '' else CONVERT(nvarchar,is_multilayer) end)+';'+'排序:'+CONVERT(nvarchar,case when sort is null then '' else CONVERT(nvarchar,sort) end)+';'+'备注:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'修改人:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		'字典编号:'+CONVERT(nvarchar,case when @dictionary_id is null then '' else CONVERT(nvarchar,@dictionary_id) end)+';'+'字典名称:'+CONVERT(nvarchar,case when @dictionary_name is null then '' else CONVERT(nvarchar,@dictionary_name) end)+';'+'是否为多层级结构（1：是；0：否）:'+CONVERT(nvarchar,case when @is_multilayer is null then '' else CONVERT(nvarchar,@is_multilayer) end)+';'+'排序:'+CONVERT(nvarchar,case when @sort is null then '' else CONVERT(nvarchar,@sort) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'修改人:'+CONVERT(nvarchar,@operator_name)+';'+'修改时间:'+CONVERT(nvarchar,getdate()),
		'修改数据',
		'操作员：'+@operator_name
		from youhoo_sys_dictionary where flag=1 and dictionary_id=@dictionary_id
		set @v_id=@dictionary_id;
		
		Update youhoo_sys_dictionary		
			Set dictionary_name = @dictionary_name
				,is_multilayer = @is_multilayer
				,sort = @sort
				,remark = @remark
				,flag = @flag
				,user_id = @user_id
				,createoperator = @createoperator
				,createdate = @createdate
				,updateoperator = @operator_name
				,updatedate = getdate()
		Where dictionary_id=@dictionary_id;
	End
	--修改结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_getmodel]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2015/11/15 10:54:21
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_getmodel]
(
	@dictionary_id		int		--字典编号
)
AS
	select * from youhoo_sys_dictionary where flag=1 and dictionary_id=@dictionary_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_exists]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：是否已经存在 
--时间：2015/11/15 10:54:21
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_exists]
(
	@dictionary_id		int		--字典编号
)
AS
	select count(1) from youhoo_sys_dictionary where flag=1 and dictionary_id=@dictionary_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_delete]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：删除记录 
--时间：2015/11/15 10:54:21
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_delete]
(
	@array_id		nvarchar(500),		--ID集合
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--删除开始-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_sys_dictionary','系统删除编号为【'+@array_id+'】的数据','','删除数据','操作员：'+@operator_name);

	exec('update youhoo_sys_dictionary set flag=0 where dictionary_id in ('+@array_id+')');	
	--删除结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_child_start]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：启用记录 
--时间：2015/4/11 12:19:44
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_child_start]
(
	@array_id		nvarchar(500),		--ID集合
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--启用开始-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_sys_dictionary_child','系统启用编号为【'+@array_id+'】的数据','','启用数据','操作员：'+@operator_name);

	exec('update youhoo_sys_dictionary_child set is_start=1 where dictionary_child_id in ('+@array_id+')');	
	--启用结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_child_insertupdate]    Script Date: 12/28/2016 14:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：添加、修改 
--时间：2016/6/6 12:40:32
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_child_insertupdate]
(
	@dictionary_child_id		int,		--选项编号
	@dictionary_child_name		nvarchar(500),		--选项名称
	@dictionary_id		int,		--所属字典（引用字典表，用于判断此选项属于哪一类字典）
	@parent_dictionary_child_id		int,		--所属父级
	@is_start		int,		--是否启用（1：是；0：否）
	@sort		int,		--排序
	@remark		ntext=null,		--备注
	@flag		int=null,		--逻辑状态（1：存在；0：不存在）
	@user_id		int,		--创建者ID
	@createoperator		nvarchar(50)=null,		--创建人
	@createdate		datetime=null,		--创建时间
	@updateoperator		nvarchar(50)=null,		--修改人
	@updatedate		datetime=null,		--修改时间
	@v_id		int output,		--临时ID储存
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--添加开始-------------------------------------------------------------------------------------------------
	If @dictionary_child_id = 0
	Begin
		Insert Into youhoo_sys_dictionary_child	
			(dictionary_child_name
			,dictionary_id
			,parent_dictionary_child_id
			,is_start
			,sort
			,remark
			,flag
			,user_id
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@dictionary_child_name
			,@dictionary_id
			,@parent_dictionary_child_id
			,@is_start
			,@sort
			,@remark
			,1
			,@operator_id
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_sys_dictionary_child',
				'',
				'选项编号:'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'选项名称:'+CONVERT(nvarchar,case when @dictionary_child_name is null then '' else CONVERT(nvarchar,@dictionary_child_name) end)+';'+'所属字典（引用字典表，用于判断此选项属于哪一类字典）:'+CONVERT(nvarchar,case when @dictionary_id is null then '' else CONVERT(nvarchar,@dictionary_id) end)+';'+'所属父级:'+CONVERT(nvarchar,case when @parent_dictionary_child_id is null then '' else CONVERT(nvarchar,@parent_dictionary_child_id) end)+';'+'是否启用（1：是；0：否）:'+CONVERT(nvarchar,case when @is_start is null then '' else CONVERT(nvarchar,@is_start) end)+';'+'排序:'+CONVERT(nvarchar,case when @sort is null then '' else CONVERT(nvarchar,@sort) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建者ID:'+CONVERT(nvarchar,@operator_id)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_sys_dictionary_child',
		'选项编号:'+CONVERT(nvarchar,case when dictionary_child_id is null then '' else CONVERT(nvarchar,dictionary_child_id) end)+';'+'选项名称:'+CONVERT(nvarchar,case when dictionary_child_name is null then '' else CONVERT(nvarchar,dictionary_child_name) end)+';'+'所属字典（引用字典表，用于判断此选项属于哪一类字典）:'+CONVERT(nvarchar,case when dictionary_id is null then '' else CONVERT(nvarchar,dictionary_id) end)+';'+'所属父级:'+CONVERT(nvarchar,case when parent_dictionary_child_id is null then '' else CONVERT(nvarchar,parent_dictionary_child_id) end)+';'+'是否启用（1：是；0：否）:'+CONVERT(nvarchar,case when is_start is null then '' else CONVERT(nvarchar,is_start) end)+';'+'排序:'+CONVERT(nvarchar,case when sort is null then '' else CONVERT(nvarchar,sort) end)+';'+'备注:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'修改人:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		'选项编号:'+CONVERT(nvarchar,case when @dictionary_child_id is null then '' else CONVERT(nvarchar,@dictionary_child_id) end)+';'+'选项名称:'+CONVERT(nvarchar,case when @dictionary_child_name is null then '' else CONVERT(nvarchar,@dictionary_child_name) end)+';'+'所属字典（引用字典表，用于判断此选项属于哪一类字典）:'+CONVERT(nvarchar,case when @dictionary_id is null then '' else CONVERT(nvarchar,@dictionary_id) end)+';'+'所属父级:'+CONVERT(nvarchar,case when @parent_dictionary_child_id is null then '' else CONVERT(nvarchar,@parent_dictionary_child_id) end)+';'+'是否启用（1：是；0：否）:'+CONVERT(nvarchar,case when @is_start is null then '' else CONVERT(nvarchar,@is_start) end)+';'+'排序:'+CONVERT(nvarchar,case when @sort is null then '' else CONVERT(nvarchar,@sort) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'修改人:'+CONVERT(nvarchar,@operator_name)+';'+'修改时间:'+CONVERT(nvarchar,getdate()),
		'修改数据',
		'操作员：'+@operator_name
		from youhoo_sys_dictionary_child where flag=1 and dictionary_child_id=@dictionary_child_id
		set @v_id=@dictionary_child_id;
		
		Update youhoo_sys_dictionary_child		
			Set dictionary_child_name = @dictionary_child_name
				,dictionary_id = @dictionary_id
				,parent_dictionary_child_id = @parent_dictionary_child_id
				,is_start = @is_start
				,sort = @sort
				,remark = @remark
				,flag = @flag
				,user_id = @user_id
				,createoperator = @createoperator
				,createdate = @createdate
				,updateoperator = @operator_name
				,updatedate = getdate()
		Where dictionary_child_id=@dictionary_child_id;
	End
	--修改结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_child_getmodel]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2016/6/6 12:40:32
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_child_getmodel]
(
	@dictionary_child_id		int		--选项编号
)
AS
	select * from youhoo_sys_dictionary_child where flag=1 and dictionary_child_id=@dictionary_child_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_child_getdictionarychildname]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：是否已经存在 
--时间：2015/4/11 12:19:44
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_child_getdictionarychildname]
(
	@dictionary_child_id		int		--选项编号
)
AS
	select dictionary_child_name from youhoo_sys_dictionary_child where flag=1 and dictionary_child_id=@dictionary_child_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_child_exists]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：是否已经存在 
--时间：2016/6/6 12:40:32
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_child_exists]
(
	@dictionary_child_id		int		--选项编号
)
AS
	select count(1) from youhoo_sys_dictionary_child where flag=1 and dictionary_child_id=@dictionary_child_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_child_disabled]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：不启用记录 
--时间：2015/4/11 12:19:44
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_child_disabled]
(
	@array_id		nvarchar(500),		--ID集合
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--不启用开始-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_sys_dictionary_child','系统不启用编号为【'+@array_id+'】的数据','','不启用数据','操作员：'+@operator_name);

	exec('update youhoo_sys_dictionary_child set is_start=0 where dictionary_child_id in ('+@array_id+')');	
	--不启用结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_dictionary_child_delete]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：删除记录 
--时间：2016/6/6 12:40:32
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_dictionary_child_delete]
(
	@array_id		nvarchar(500),		--ID集合
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--删除开始-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_sys_dictionary_child','系统删除编号为【'+@array_id+'】的数据','','删除数据','操作员：'+@operator_name);

	exec('update youhoo_sys_dictionary_child set flag=0 where dictionary_child_id in ('+@array_id+')');	
	--删除结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_action_insertupdate]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================
--用途：添加、修改 
--时间：2015/4/8 17:02:10
--=============================================
CREATE PROCEDURE [dbo].[sp_youhoo_sys_action_insertupdate]
(
	@action_id		int,		--动作编号
	@action_name		nvarchar(400),		--动作名称
	@action_value		nvarchar(50)=null,		--标识编号
	@remark		ntext=null,		--备注
	@flag		int=null,		--逻辑状态（1：存在；0：不存在）
	@user_id		int,		--创建者ID
	@createoperator		nvarchar(50)=null,		--创建人
	@createdate		datetime=null,		--创建时间
	@updateoperator		nvarchar(50)=null,		--修改人
	@updatedate		datetime=null,		--修改时间
	@v_id		int output,		--临时ID储存
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--添加开始-------------------------------------------------------------------------------------------------
	If @action_id = 0
	Begin
		Insert Into youhoo_sys_action	
			(action_name
			,action_value
			,remark
			,flag
			,user_id
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@action_name
			,@action_value
			,@remark
			,1
			,@operator_id
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_sys_action',
				'',
				'动作编号:'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'动作名称:'+CONVERT(nvarchar,case when @action_name is null then '' else CONVERT(nvarchar,@action_name) end)+';'+'标识编号:'+CONVERT(nvarchar,case when @action_value is null then '' else CONVERT(nvarchar,@action_value) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建者ID:'+CONVERT(nvarchar,@operator_id)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_sys_action',
		'动作编号:'+CONVERT(nvarchar,case when action_id is null then '' else CONVERT(nvarchar,action_id) end)+';'+'动作名称:'+CONVERT(nvarchar,case when action_name is null then '' else CONVERT(nvarchar,action_name) end)+';'+'标识编号:'+CONVERT(nvarchar,case when action_value is null then '' else CONVERT(nvarchar,action_value) end)+';'+'备注:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'修改人:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		'动作编号:'+CONVERT(nvarchar,case when @action_id is null then '' else CONVERT(nvarchar,@action_id) end)+';'+'动作名称:'+CONVERT(nvarchar,case when @action_name is null then '' else CONVERT(nvarchar,@action_name) end)+';'+'标识编号:'+CONVERT(nvarchar,case when @action_value is null then '' else CONVERT(nvarchar,@action_value) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'修改人:'+CONVERT(nvarchar,@operator_name)+';'+'修改时间:'+CONVERT(nvarchar,getdate()),
		'修改数据',
		'操作员：'+@operator_name
		from youhoo_sys_action where flag=1 and action_id=@action_id
		set @v_id=@action_id;
		
		Update youhoo_sys_action		
			Set action_name = @action_name
				,action_value = @action_value
				,remark = @remark
				,flag = @flag
				,user_id = @user_id
				,createoperator = @createoperator
				,createdate = @createdate
				,updateoperator = @operator_name
				,updatedate = getdate()
		Where action_id=@action_id;
	End
	--修改结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_action_getmodel]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2015/3/27 10:49:45
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_action_getmodel]
(
	@action_id		int		--动作编号
)
AS
	select * from youhoo_sys_action where flag=1 and action_id=@action_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_action_exists]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：是否已经存在 
--时间：2015/3/27 10:49:45
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_action_exists]
(
	@action_id		int		--动作编号
)
AS
	select count(1) from youhoo_sys_action where flag=1 and action_id=@action_id
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_sys_action_delete]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：删除记录 
--时间：2015/3/27 10:49:45
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_sys_action_delete]
(
	@array_id		nvarchar(500),		--ID集合
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--删除开始-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_sys_action','系统删除编号为 【'+@array_id+'】的数据','','删除数据','操作员：'+@operator_name);

	exec('update youhoo_sys_action set flag=0 where action_id in ('+@array_id+')');	
	--删除结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_pu_region_insertupdate]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：添加、修改 
--时间：2016/5/17 16:41:50
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_pu_region_insertupdate]
(
	@region_id		int,		--ID
	@region_name		nvarchar(50),		--地区名称
	@parent_id		int,		--上级地区
	@sort		int,		--排序
	@remark		ntext=null,		--备注
	@flag		int=null,		--逻辑状态（1：存在；0：不存在）
	@user_id		int,		--创建者ID
	@createoperator		nvarchar(50)=null,		--创建人
	@createdate		datetime=null,		--创建时间
	@updateoperator		nvarchar(50)=null,		--修改人
	@updatedate		datetime=null,		--修改时间
	@v_id		int output,		--临时ID储存
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--添加开始-------------------------------------------------------------------------------------------------
	If @region_id = 0
	Begin
		Insert Into youhoo_pu_region	
			(region_name
			,parent_id
			,sort
			,remark
			,flag
			,user_id
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@region_name
			,@parent_id
			,@sort
			,@remark
			,1
			,@operator_id
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_pu_region',
				'',
				'ID:'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'地区名称:'+CONVERT(nvarchar,case when @region_name is null then '' else CONVERT(nvarchar,@region_name) end)+';'+'上级地区:'+CONVERT(nvarchar,case when @parent_id is null then '' else CONVERT(nvarchar,@parent_id) end)+';'+'排序:'+CONVERT(nvarchar,case when @sort is null then '' else CONVERT(nvarchar,@sort) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建者ID:'+CONVERT(nvarchar,@operator_id)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_pu_region',
		'ID:'+CONVERT(nvarchar,case when region_id is null then '' else CONVERT(nvarchar,region_id) end)+';'+'地区名称:'+CONVERT(nvarchar,case when region_name is null then '' else CONVERT(nvarchar,region_name) end)+';'+'上级地区:'+CONVERT(nvarchar,case when parent_id is null then '' else CONVERT(nvarchar,parent_id) end)+';'+'排序:'+CONVERT(nvarchar,case when sort is null then '' else CONVERT(nvarchar,sort) end)+';'+'备注:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'修改人:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		'ID:'+CONVERT(nvarchar,case when @region_id is null then '' else CONVERT(nvarchar,@region_id) end)+';'+'地区名称:'+CONVERT(nvarchar,case when @region_name is null then '' else CONVERT(nvarchar,@region_name) end)+';'+'上级地区:'+CONVERT(nvarchar,case when @parent_id is null then '' else CONVERT(nvarchar,@parent_id) end)+';'+'排序:'+CONVERT(nvarchar,case when @sort is null then '' else CONVERT(nvarchar,@sort) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'修改人:'+CONVERT(nvarchar,@operator_name)+';'+'修改时间:'+CONVERT(nvarchar,getdate()),
		'修改数据',
		'操作员：'+@operator_name
		from youhoo_pu_region where flag=1 and region_id=@region_id
		set @v_id=@region_id;
		
		Update youhoo_pu_region		
			Set region_name = @region_name
				,parent_id = @parent_id
				,sort = @sort
				,remark = @remark
				,flag = @flag
				,user_id = @user_id
				,createoperator = @createoperator
				,createdate = @createdate
				,updateoperator = @operator_name
				,updatedate = getdate()
		Where region_id=@region_id;
	End
	--修改结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
/****** Object:  StoredProcedure [dbo].[sp_youhoo_pu_region_delete]    Script Date: 12/28/2016 14:17:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：删除记录 
--时间：2016/5/16 16:52:46
------------------------------------
CREATE PROCEDURE [dbo].[sp_youhoo_pu_region_delete]
(
	@array_id		nvarchar(500),		--ID集合
	@operator_id		int		--操作人ID
)
AS

--定义变量-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --开始事务 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--删除开始-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_pu_region','系统删除编号为【'+@array_id+'】的数据','','删除数据','操作员：'+@operator_name);

	exec('update youhoo_pu_region set flag=0 where region_id in ('+@array_id+')');	
	--删除结束-------------------------------------------------------------------------------------------------
If @@Error <> 0
Begin
	RollBack Tran
	Return -1
End
Else
Begin
	Commit Tran
	Return 1
End
--------------------------------
GO
