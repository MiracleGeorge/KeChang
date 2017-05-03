/******************************************************************
* 表名：youhoo_rebate_RebateWay
* 时间：2017/4/5 14:10:46
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_exists]
GO
------------------------------------
--用途：是否已经存在 
--时间：2017/4/5 14:10:46
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_exists
(
	@id		int		--
)
AS
	select count(1) from youhoo_rebate_RebateWay where flag=1 and id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_insertupdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_insertupdate]
GO
------------------------------------
--用途：添加、修改 
--时间：2017/4/5 14:10:46
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_insertupdate
(
	@id		int,		--
	@rebate_type		bit,		--返利类型
	@Name		nvarchar(50),		--
	@Code		varchar(50)=null,		--返利方式编码
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
	If @id = 0
	Begin
		Insert Into youhoo_rebate_RebateWay	
			(rebate_type
			,Name
			,Code
			,remark
			,flag
			,user_id
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@rebate_type
			,@Name
			,@Code
			,@remark
			,1
			,@operator_id
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_rebate_RebateWay',
				'',
				':'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'返利类型:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+':'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'返利方式编码:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建者ID:'+CONVERT(nvarchar,@operator_id)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_rebate_RebateWay',
		':'+CONVERT(nvarchar,case when id is null then '' else CONVERT(nvarchar,id) end)+';'+'返利类型:'+CONVERT(nvarchar,case when rebate_type is null then '' else CONVERT(nvarchar,rebate_type) end)+';'+':'+CONVERT(nvarchar,case when Name is null then '' else CONVERT(nvarchar,Name) end)+';'+'返利方式编码:'+CONVERT(nvarchar,case when Code is null then '' else CONVERT(nvarchar,Code) end)+';'+'备注:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'修改人:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		':'+CONVERT(nvarchar,case when @id is null then '' else CONVERT(nvarchar,@id) end)+';'+'返利类型:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+':'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'返利方式编码:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'修改人:'+CONVERT(nvarchar,@operator_name)+';'+'修改时间:'+CONVERT(nvarchar,getdate()),
		'修改数据',
		'操作员：'+@operator_name
		from youhoo_rebate_RebateWay where flag=1 and id=@id
		set @v_id=@id;
		
		Update youhoo_rebate_RebateWay		
			Set rebate_type = @rebate_type
				,Name = @Name
				,Code = @Code
				,remark = @remark
				,flag = @flag
				,user_id = @user_id
				,createoperator = @createoperator
				,createdate = @createdate
				,updateoperator = @operator_name
				,updatedate = getdate()
		Where id=@id;
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_delete]
GO
------------------------------------
--用途：删除记录 
--时间：2017/4/5 14:10:46
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_delete
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
	values('youhoo_rebate_RebateWay','系统删除编号为【'+@array_id+'】的数据','','删除数据','操作员：'+@operator_name);

	exec('update youhoo_rebate_RebateWay set flag=0 where id in ('+@array_id+')');	
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getmodel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getmodel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2017/4/5 14:10:46
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getmodel
(
	@id		int		--
)
AS
	select * from youhoo_rebate_RebateWay where flag=1 and id=@id

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getlist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getlist]
GO
------------------------------------
--用途：按条件查询记录信息 
--时间：2017/4/5 14:10:46
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlist
(
	@strWhere		nvarchar(500)		--where条件
)
AS
	exec('select a.* from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere+'')

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2017/4/5 14:10:46
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlistbypage
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
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*
			from youhoo_rebate_RebateWay a
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);

GO

/******************************************************************
* 表名：youhoo_rebate_RebateWay
* 时间：2017/4/5 14:15:55
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_exists]
GO
------------------------------------
--用途：是否已经存在 
--时间：2017/4/5 14:15:55
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_exists
(
	@id		int		--
)
AS
	select count(1) from youhoo_rebate_RebateWay where flag=1 and id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_insertupdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_insertupdate]
GO
------------------------------------
--用途：添加、修改 
--时间：2017/4/5 14:15:55
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_insertupdate
(
	@id		int,		--
	@rebate_type		bit,		--返利类型
	@Name		nvarchar(50),		--返利方式名称
	@Code		varchar(50)=null,		--返利方式编码
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
	If @id = 0
	Begin
		Insert Into youhoo_rebate_RebateWay	
			(rebate_type
			,Name
			,Code
			,remark
			,flag
			,user_id
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@rebate_type
			,@Name
			,@Code
			,@remark
			,1
			,@operator_id
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_rebate_RebateWay',
				'',
				':'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'返利类型:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+'返利方式名称:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'返利方式编码:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建者ID:'+CONVERT(nvarchar,@operator_id)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_rebate_RebateWay',
		':'+CONVERT(nvarchar,case when id is null then '' else CONVERT(nvarchar,id) end)+';'+'返利类型:'+CONVERT(nvarchar,case when rebate_type is null then '' else CONVERT(nvarchar,rebate_type) end)+';'+'返利方式名称:'+CONVERT(nvarchar,case when Name is null then '' else CONVERT(nvarchar,Name) end)+';'+'返利方式编码:'+CONVERT(nvarchar,case when Code is null then '' else CONVERT(nvarchar,Code) end)+';'+'备注:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'修改人:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		':'+CONVERT(nvarchar,case when @id is null then '' else CONVERT(nvarchar,@id) end)+';'+'返利类型:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+'返利方式名称:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'返利方式编码:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'修改人:'+CONVERT(nvarchar,@operator_name)+';'+'修改时间:'+CONVERT(nvarchar,getdate()),
		'修改数据',
		'操作员：'+@operator_name
		from youhoo_rebate_RebateWay where flag=1 and id=@id
		set @v_id=@id;
		
		Update youhoo_rebate_RebateWay		
			Set rebate_type = @rebate_type
				,Name = @Name
				,Code = @Code
				,remark = @remark
				,flag = @flag
				,user_id = @user_id
				,createoperator = @createoperator
				,createdate = @createdate
				,updateoperator = @operator_name
				,updatedate = getdate()
		Where id=@id;
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_delete]
GO
------------------------------------
--用途：删除记录 
--时间：2017/4/5 14:15:55
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_delete
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
	values('youhoo_rebate_RebateWay','系统删除编号为【'+@array_id+'】的数据','','删除数据','操作员：'+@operator_name);

	exec('update youhoo_rebate_RebateWay set flag=0 where id in ('+@array_id+')');	
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getmodel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getmodel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2017/4/5 14:15:55
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getmodel
(
	@id		int		--
)
AS
	select * from youhoo_rebate_RebateWay where flag=1 and id=@id

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getlist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getlist]
GO
------------------------------------
--用途：按条件查询记录信息 
--时间：2017/4/5 14:15:55
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlist
(
	@strWhere		nvarchar(500)		--where条件
)
AS
	exec('select a.* from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere+'')

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2017/4/5 14:15:55
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlistbypage
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
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*
			from youhoo_rebate_RebateWay a
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);

GO

/******************************************************************
* 表名：youhoo_rebate_RebateWay
* 时间：2017/4/5 14:54:13
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_exists]
GO
------------------------------------
--用途：是否已经存在 
--时间：2017/4/5 14:54:13
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_exists
(
	@id		int		--
)
AS
	select count(1) from youhoo_rebate_RebateWay where flag=1 and id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_insertupdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_insertupdate]
GO
------------------------------------
--用途：添加、修改 
--时间：2017/4/5 14:54:13
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_insertupdate
(
	@id		int,		--
	@rebate_type		int,		--返利类型
	@Name		nvarchar(50),		--返利方式名称
	@Code		varchar(50)=null,		--返利方式编码
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
	If @id = 0
	Begin
		Insert Into youhoo_rebate_RebateWay	
			(rebate_type
			,Name
			,Code
			,remark
			,flag
			,user_id
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@rebate_type
			,@Name
			,@Code
			,@remark
			,1
			,@operator_id
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_rebate_RebateWay',
				'',
				':'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'返利类型:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+'返利方式名称:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'返利方式编码:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建者ID:'+CONVERT(nvarchar,@operator_id)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_rebate_RebateWay',
		':'+CONVERT(nvarchar,case when id is null then '' else CONVERT(nvarchar,id) end)+';'+'返利类型:'+CONVERT(nvarchar,case when rebate_type is null then '' else CONVERT(nvarchar,rebate_type) end)+';'+'返利方式名称:'+CONVERT(nvarchar,case when Name is null then '' else CONVERT(nvarchar,Name) end)+';'+'返利方式编码:'+CONVERT(nvarchar,case when Code is null then '' else CONVERT(nvarchar,Code) end)+';'+'备注:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'修改人:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		':'+CONVERT(nvarchar,case when @id is null then '' else CONVERT(nvarchar,@id) end)+';'+'返利类型:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+'返利方式名称:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'返利方式编码:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'修改人:'+CONVERT(nvarchar,@operator_name)+';'+'修改时间:'+CONVERT(nvarchar,getdate()),
		'修改数据',
		'操作员：'+@operator_name
		from youhoo_rebate_RebateWay where flag=1 and id=@id
		set @v_id=@id;
		
		Update youhoo_rebate_RebateWay		
			Set rebate_type = @rebate_type
				,Name = @Name
				,Code = @Code
				,remark = @remark
				,flag = @flag
				,user_id = @user_id
				,createoperator = @createoperator
				,createdate = @createdate
				,updateoperator = @operator_name
				,updatedate = getdate()
		Where id=@id;
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_delete]
GO
------------------------------------
--用途：删除记录 
--时间：2017/4/5 14:54:13
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_delete
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
	values('youhoo_rebate_RebateWay','系统删除编号为【'+@array_id+'】的数据','','删除数据','操作员：'+@operator_name);

	exec('update youhoo_rebate_RebateWay set flag=0 where id in ('+@array_id+')');	
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getmodel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getmodel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2017/4/5 14:54:13
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getmodel
(
	@id		int		--
)
AS
	select * from youhoo_rebate_RebateWay where flag=1 and id=@id

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getlist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getlist]
GO
------------------------------------
--用途：按条件查询记录信息 
--时间：2017/4/5 14:54:13
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlist
(
	@strWhere		nvarchar(500)		--where条件
)
AS
	exec('select a.* from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere+'')

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2017/4/5 14:54:13
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlistbypage
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
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*
			from youhoo_rebate_RebateWay a
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);

GO

/******************************************************************
* 表名：youhoo_rebate_RebateWay
* 时间：2017/4/5 15:34:11
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_exists]
GO
------------------------------------
--用途：是否已经存在 
--时间：2017/4/5 15:34:11
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_exists
(
	@id		int		--
)
AS
	select count(1) from youhoo_rebate_RebateWay where flag=1 and id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_insertupdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_insertupdate]
GO
------------------------------------
--用途：添加、修改 
--时间：2017/4/5 15:34:11
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_insertupdate
(
	@id		int,		--
	@rebate_type		varchar(50),		--返利类型
	@Name		nvarchar(50),		--返利方式名称
	@Code		varchar(50)=null,		--返利方式编码
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
	If @id = 0
	Begin
		Insert Into youhoo_rebate_RebateWay	
			(rebate_type
			,Name
			,Code
			,remark
			,flag
			,user_id
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@rebate_type
			,@Name
			,@Code
			,@remark
			,1
			,@operator_id
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_rebate_RebateWay',
				'',
				':'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'返利类型:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+'返利方式名称:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'返利方式编码:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建者ID:'+CONVERT(nvarchar,@operator_id)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_rebate_RebateWay',
		':'+CONVERT(nvarchar,case when id is null then '' else CONVERT(nvarchar,id) end)+';'+'返利类型:'+CONVERT(nvarchar,case when rebate_type is null then '' else CONVERT(nvarchar,rebate_type) end)+';'+'返利方式名称:'+CONVERT(nvarchar,case when Name is null then '' else CONVERT(nvarchar,Name) end)+';'+'返利方式编码:'+CONVERT(nvarchar,case when Code is null then '' else CONVERT(nvarchar,Code) end)+';'+'备注:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'修改人:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		':'+CONVERT(nvarchar,case when @id is null then '' else CONVERT(nvarchar,@id) end)+';'+'返利类型:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+'返利方式名称:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'返利方式编码:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'修改人:'+CONVERT(nvarchar,@operator_name)+';'+'修改时间:'+CONVERT(nvarchar,getdate()),
		'修改数据',
		'操作员：'+@operator_name
		from youhoo_rebate_RebateWay where flag=1 and id=@id
		set @v_id=@id;
		
		Update youhoo_rebate_RebateWay		
			Set rebate_type = @rebate_type
				,Name = @Name
				,Code = @Code
				,remark = @remark
				,flag = @flag
				,user_id = @user_id
				,createoperator = @createoperator
				,createdate = @createdate
				,updateoperator = @operator_name
				,updatedate = getdate()
		Where id=@id;
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_delete]
GO
------------------------------------
--用途：删除记录 
--时间：2017/4/5 15:34:11
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_delete
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
	values('youhoo_rebate_RebateWay','系统删除编号为【'+@array_id+'】的数据','','删除数据','操作员：'+@operator_name);

	exec('update youhoo_rebate_RebateWay set flag=0 where id in ('+@array_id+')');	
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getmodel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getmodel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2017/4/5 15:34:11
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getmodel
(
	@id		int		--
)
AS
	select * from youhoo_rebate_RebateWay where flag=1 and id=@id

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getlist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getlist]
GO
------------------------------------
--用途：按条件查询记录信息 
--时间：2017/4/5 15:34:11
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlist
(
	@strWhere		nvarchar(500)		--where条件
)
AS
	exec('select a.* from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere+'')

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2017/4/5 15:34:11
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlistbypage
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
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*
			from youhoo_rebate_RebateWay a
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);

GO

/******************************************************************
* 表名：youhoo_rebate_RebatePolicy
* 时间：2017/4/5 22:18:30
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_exists]
GO
------------------------------------
--用途：是否已经存在 
--时间：2017/4/5 22:18:30
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_exists
(
	@id		int		--
)
AS
	select count(1) from youhoo_rebate_RebatePolicy where flag=1 and id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_insertupdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_insertupdate]
GO
------------------------------------
--用途：添加、修改 
--时间：2017/4/5 22:18:30
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_insertupdate
(
	@id		int,		--
	@Code		varchar(50),		--返利政策编码
	@Name		nvarchar(50),		--返利政策名称
	@brand_id		int,		--品牌
	@channel_id		int=null,		--渠道
	@item_id		int=null,		--品项
	@price_id		int=null,		--价格
	@region_id		int=null,		--地区
	@sort_id_id		int=null,		--品类
	@SupportWay_id		int=null,		--支持方式
	@SupportPrice_id		int=null,		--支持价格
	@RebateType_id		int=null,		--返利方式
	@time_id		int=null,		--时段
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
	If @id = 0
	Begin
		Insert Into youhoo_rebate_RebatePolicy	
			(Code
			,Name
			,brand_id
			,channel_id
			,item_id
			,price_id
			,region_id
			,sort_id_id
			,SupportWay_id
			,SupportPrice_id
			,RebateType_id
			,time_id
			,remark
			,flag
			,user_id
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@Code
			,@Name
			,@brand_id
			,@channel_id
			,@item_id
			,@price_id
			,@region_id
			,@sort_id_id
			,@SupportWay_id
			,@SupportPrice_id
			,@RebateType_id
			,@time_id
			,@remark
			,1
			,@operator_id
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_rebate_RebatePolicy',
				'',
				':'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'返利政策编码:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'返利政策名称:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'品牌:'+CONVERT(nvarchar,case when @brand_id is null then '' else CONVERT(nvarchar,@brand_id) end)+';'+'渠道:'+CONVERT(nvarchar,case when @channel_id is null then '' else CONVERT(nvarchar,@channel_id) end)+';'+'品项:'+CONVERT(nvarchar,case when @item_id is null then '' else CONVERT(nvarchar,@item_id) end)+';'+'价格:'+CONVERT(nvarchar,case when @price_id is null then '' else CONVERT(nvarchar,@price_id) end)+';'+'地区:'+CONVERT(nvarchar,case when @region_id is null then '' else CONVERT(nvarchar,@region_id) end)+';'+'品类:'+CONVERT(nvarchar,case when @sort_id_id is null then '' else CONVERT(nvarchar,@sort_id_id) end)+';'+'支持方式:'+CONVERT(nvarchar,case when @SupportWay_id is null then '' else CONVERT(nvarchar,@SupportWay_id) end)+';'+'支持价格:'+CONVERT(nvarchar,case when @SupportPrice_id is null then '' else CONVERT(nvarchar,@SupportPrice_id) end)+';'+'返利方式:'+CONVERT(nvarchar,case when @RebateType_id is null then '' else CONVERT(nvarchar,@RebateType_id) end)+';'+'时段:'+CONVERT(nvarchar,case when @time_id is null then '' else CONVERT(nvarchar,@time_id) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建者ID:'+CONVERT(nvarchar,@operator_id)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_rebate_RebatePolicy',
		':'+CONVERT(nvarchar,case when id is null then '' else CONVERT(nvarchar,id) end)+';'+'返利政策编码:'+CONVERT(nvarchar,case when Code is null then '' else CONVERT(nvarchar,Code) end)+';'+'返利政策名称:'+CONVERT(nvarchar,case when Name is null then '' else CONVERT(nvarchar,Name) end)+';'+'品牌:'+CONVERT(nvarchar,case when brand_id is null then '' else CONVERT(nvarchar,brand_id) end)+';'+'渠道:'+CONVERT(nvarchar,case when channel_id is null then '' else CONVERT(nvarchar,channel_id) end)+';'+'品项:'+CONVERT(nvarchar,case when item_id is null then '' else CONVERT(nvarchar,item_id) end)+';'+'价格:'+CONVERT(nvarchar,case when price_id is null then '' else CONVERT(nvarchar,price_id) end)+';'+'地区:'+CONVERT(nvarchar,case when region_id is null then '' else CONVERT(nvarchar,region_id) end)+';'+'品类:'+CONVERT(nvarchar,case when sort_id_id is null then '' else CONVERT(nvarchar,sort_id_id) end)+';'+'支持方式:'+CONVERT(nvarchar,case when SupportWay_id is null then '' else CONVERT(nvarchar,SupportWay_id) end)+';'+'支持价格:'+CONVERT(nvarchar,case when SupportPrice_id is null then '' else CONVERT(nvarchar,SupportPrice_id) end)+';'+'返利方式:'+CONVERT(nvarchar,case when RebateType_id is null then '' else CONVERT(nvarchar,RebateType_id) end)+';'+'时段:'+CONVERT(nvarchar,case when time_id is null then '' else CONVERT(nvarchar,time_id) end)+';'+'备注:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'修改人:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		':'+CONVERT(nvarchar,case when @id is null then '' else CONVERT(nvarchar,@id) end)+';'+'返利政策编码:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'返利政策名称:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'品牌:'+CONVERT(nvarchar,case when @brand_id is null then '' else CONVERT(nvarchar,@brand_id) end)+';'+'渠道:'+CONVERT(nvarchar,case when @channel_id is null then '' else CONVERT(nvarchar,@channel_id) end)+';'+'品项:'+CONVERT(nvarchar,case when @item_id is null then '' else CONVERT(nvarchar,@item_id) end)+';'+'价格:'+CONVERT(nvarchar,case when @price_id is null then '' else CONVERT(nvarchar,@price_id) end)+';'+'地区:'+CONVERT(nvarchar,case when @region_id is null then '' else CONVERT(nvarchar,@region_id) end)+';'+'品类:'+CONVERT(nvarchar,case when @sort_id_id is null then '' else CONVERT(nvarchar,@sort_id_id) end)+';'+'支持方式:'+CONVERT(nvarchar,case when @SupportWay_id is null then '' else CONVERT(nvarchar,@SupportWay_id) end)+';'+'支持价格:'+CONVERT(nvarchar,case when @SupportPrice_id is null then '' else CONVERT(nvarchar,@SupportPrice_id) end)+';'+'返利方式:'+CONVERT(nvarchar,case when @RebateType_id is null then '' else CONVERT(nvarchar,@RebateType_id) end)+';'+'时段:'+CONVERT(nvarchar,case when @time_id is null then '' else CONVERT(nvarchar,@time_id) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'修改人:'+CONVERT(nvarchar,@operator_name)+';'+'修改时间:'+CONVERT(nvarchar,getdate()),
		'修改数据',
		'操作员：'+@operator_name
		from youhoo_rebate_RebatePolicy where flag=1 and id=@id
		set @v_id=@id;
		
		Update youhoo_rebate_RebatePolicy		
			Set Code = @Code
				,Name = @Name
				,brand_id = @brand_id
				,channel_id = @channel_id
				,item_id = @item_id
				,price_id = @price_id
				,region_id = @region_id
				,sort_id_id = @sort_id_id
				,SupportWay_id = @SupportWay_id
				,SupportPrice_id = @SupportPrice_id
				,RebateType_id = @RebateType_id
				,time_id = @time_id
				,remark = @remark
				,flag = @flag
				,user_id = @user_id
				,createoperator = @createoperator
				,createdate = @createdate
				,updateoperator = @operator_name
				,updatedate = getdate()
		Where id=@id;
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_delete]
GO
------------------------------------
--用途：删除记录 
--时间：2017/4/5 22:18:30
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_delete
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
	values('youhoo_rebate_RebatePolicy','系统删除编号为【'+@array_id+'】的数据','','删除数据','操作员：'+@operator_name);

	exec('update youhoo_rebate_RebatePolicy set flag=0 where id in ('+@array_id+')');	
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_getmodel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_getmodel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2017/4/5 22:18:30
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_getmodel
(
	@id		int		--
)
AS
	select * from youhoo_rebate_RebatePolicy where flag=1 and id=@id

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_getlist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_getlist]
GO
------------------------------------
--用途：按条件查询记录信息 
--时间：2017/4/5 22:18:30
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_getlist
(
	@strWhere		nvarchar(500)		--where条件
)
AS
	exec('select a.* from youhoo_rebate_RebatePolicy a where a.flag=1 '+@strWhere+'')

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_getlistbypage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_getlistbypage]
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2017/4/5 22:18:30
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_getlistbypage
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
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_rebate_RebatePolicy a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*
			from youhoo_rebate_RebatePolicy a
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);

GO

/******************************************************************
* 表名：youhoo_rebate_RebatePolicy
* 时间：2017/4/5 23:45:03
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_exists]
GO
------------------------------------
--用途：是否已经存在 
--时间：2017/4/5 23:45:03
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_exists
(
	@id		int		--
)
AS
	select count(1) from youhoo_rebate_RebatePolicy where flag=1 and id=@id 

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_insertupdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_insertupdate]
GO
------------------------------------
--用途：添加、修改 
--时间：2017/4/5 23:45:03
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_insertupdate
(
	@id		int,		--
	@Code		varchar(50),		--返利政策编码
	@Name		nvarchar(50),		--返利政策名称
	@brand_id		int,		--品牌
	@channel_id		int=null,		--渠道
	@item_id		int=null,		--品项
	@price_id		int=null,		--价格
	@region_id		int=null,		--地区
	@sort_id_id		int=null,		--品类
	@SupportWay_id		int=null,		--支持方式
	@SupportPrice_id		int=null,		--支持价格
	@RebateType_id		int=null,		--返利方式
	@time_id		int=null,		--时段
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
	If @id = 0
	Begin
		Insert Into youhoo_rebate_RebatePolicy	
			(Code
			,Name
			,brand_id
			,channel_id
			,item_id
			,price_id
			,region_id
			,sort_id_id
			,SupportWay_id
			,SupportPrice_id
			,RebateType_id
			,time_id
			,remark
			,flag
			,user_id
			,createoperator
			,createdate
			,updateoperator
			,updatedate)
		Values	
			(@Code
			,@Name
			,@brand_id
			,@channel_id
			,@item_id
			,@price_id
			,@region_id
			,@sort_id_id
			,@SupportWay_id
			,@SupportPrice_id
			,@RebateType_id
			,@time_id
			,@remark
			,1
			,@operator_id
			,@operator_name
			,getdate()
			,@updateoperator
			,@updatedate)
		set @v_id=@@IDENTITY;
		insert into Logs (tablename,olddata,newdata,datatype,cname)
		values('youhoo_rebate_RebatePolicy',
				'',
				':'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'返利政策编码:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'返利政策名称:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'品牌:'+CONVERT(nvarchar,case when @brand_id is null then '' else CONVERT(nvarchar,@brand_id) end)+';'+'渠道:'+CONVERT(nvarchar,case when @channel_id is null then '' else CONVERT(nvarchar,@channel_id) end)+';'+'品项:'+CONVERT(nvarchar,case when @item_id is null then '' else CONVERT(nvarchar,@item_id) end)+';'+'价格:'+CONVERT(nvarchar,case when @price_id is null then '' else CONVERT(nvarchar,@price_id) end)+';'+'地区:'+CONVERT(nvarchar,case when @region_id is null then '' else CONVERT(nvarchar,@region_id) end)+';'+'品类:'+CONVERT(nvarchar,case when @sort_id_id is null then '' else CONVERT(nvarchar,@sort_id_id) end)+';'+'支持方式:'+CONVERT(nvarchar,case when @SupportWay_id is null then '' else CONVERT(nvarchar,@SupportWay_id) end)+';'+'支持价格:'+CONVERT(nvarchar,case when @SupportPrice_id is null then '' else CONVERT(nvarchar,@SupportPrice_id) end)+';'+'返利方式:'+CONVERT(nvarchar,case when @RebateType_id is null then '' else CONVERT(nvarchar,@RebateType_id) end)+';'+'时段:'+CONVERT(nvarchar,case when @time_id is null then '' else CONVERT(nvarchar,@time_id) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,1)+';'+'创建者ID:'+CONVERT(nvarchar,@operator_id)+';'+'创建人:'+CONVERT(nvarchar,@operator_name)+';'+'创建时间:'+CONVERT(nvarchar,getdate())+';'+'修改人:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'添加数据',
				'操作员：'+@operator_name);
	End
	--添加结束-------------------------------------------------------------------------------------------------
	
	--修改开始-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_rebate_RebatePolicy',
		':'+CONVERT(nvarchar,case when id is null then '' else CONVERT(nvarchar,id) end)+';'+'返利政策编码:'+CONVERT(nvarchar,case when Code is null then '' else CONVERT(nvarchar,Code) end)+';'+'返利政策名称:'+CONVERT(nvarchar,case when Name is null then '' else CONVERT(nvarchar,Name) end)+';'+'品牌:'+CONVERT(nvarchar,case when brand_id is null then '' else CONVERT(nvarchar,brand_id) end)+';'+'渠道:'+CONVERT(nvarchar,case when channel_id is null then '' else CONVERT(nvarchar,channel_id) end)+';'+'品项:'+CONVERT(nvarchar,case when item_id is null then '' else CONVERT(nvarchar,item_id) end)+';'+'价格:'+CONVERT(nvarchar,case when price_id is null then '' else CONVERT(nvarchar,price_id) end)+';'+'地区:'+CONVERT(nvarchar,case when region_id is null then '' else CONVERT(nvarchar,region_id) end)+';'+'品类:'+CONVERT(nvarchar,case when sort_id_id is null then '' else CONVERT(nvarchar,sort_id_id) end)+';'+'支持方式:'+CONVERT(nvarchar,case when SupportWay_id is null then '' else CONVERT(nvarchar,SupportWay_id) end)+';'+'支持价格:'+CONVERT(nvarchar,case when SupportPrice_id is null then '' else CONVERT(nvarchar,SupportPrice_id) end)+';'+'返利方式:'+CONVERT(nvarchar,case when RebateType_id is null then '' else CONVERT(nvarchar,RebateType_id) end)+';'+'时段:'+CONVERT(nvarchar,case when time_id is null then '' else CONVERT(nvarchar,time_id) end)+';'+'备注:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'修改人:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'修改时间:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		':'+CONVERT(nvarchar,case when @id is null then '' else CONVERT(nvarchar,@id) end)+';'+'返利政策编码:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'返利政策名称:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'品牌:'+CONVERT(nvarchar,case when @brand_id is null then '' else CONVERT(nvarchar,@brand_id) end)+';'+'渠道:'+CONVERT(nvarchar,case when @channel_id is null then '' else CONVERT(nvarchar,@channel_id) end)+';'+'品项:'+CONVERT(nvarchar,case when @item_id is null then '' else CONVERT(nvarchar,@item_id) end)+';'+'价格:'+CONVERT(nvarchar,case when @price_id is null then '' else CONVERT(nvarchar,@price_id) end)+';'+'地区:'+CONVERT(nvarchar,case when @region_id is null then '' else CONVERT(nvarchar,@region_id) end)+';'+'品类:'+CONVERT(nvarchar,case when @sort_id_id is null then '' else CONVERT(nvarchar,@sort_id_id) end)+';'+'支持方式:'+CONVERT(nvarchar,case when @SupportWay_id is null then '' else CONVERT(nvarchar,@SupportWay_id) end)+';'+'支持价格:'+CONVERT(nvarchar,case when @SupportPrice_id is null then '' else CONVERT(nvarchar,@SupportPrice_id) end)+';'+'返利方式:'+CONVERT(nvarchar,case when @RebateType_id is null then '' else CONVERT(nvarchar,@RebateType_id) end)+';'+'时段:'+CONVERT(nvarchar,case when @time_id is null then '' else CONVERT(nvarchar,@time_id) end)+';'+'备注:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'逻辑状态（1：存在；0：不存在）:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'创建者ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'创建人:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'创建时间:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'修改人:'+CONVERT(nvarchar,@operator_name)+';'+'修改时间:'+CONVERT(nvarchar,getdate()),
		'修改数据',
		'操作员：'+@operator_name
		from youhoo_rebate_RebatePolicy where flag=1 and id=@id
		set @v_id=@id;
		
		Update youhoo_rebate_RebatePolicy		
			Set Code = @Code
				,Name = @Name
				,brand_id = @brand_id
				,channel_id = @channel_id
				,item_id = @item_id
				,price_id = @price_id
				,region_id = @region_id
				,sort_id_id = @sort_id_id
				,SupportWay_id = @SupportWay_id
				,SupportPrice_id = @SupportPrice_id
				,RebateType_id = @RebateType_id
				,time_id = @time_id
				,remark = @remark
				,flag = @flag
				,user_id = @user_id
				,createoperator = @createoperator
				,createdate = @createdate
				,updateoperator = @operator_name
				,updatedate = getdate()
		Where id=@id;
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_delete]
GO
------------------------------------
--用途：删除记录 
--时间：2017/4/5 23:45:03
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_delete
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
	values('youhoo_rebate_RebatePolicy','系统删除编号为【'+@array_id+'】的数据','','删除数据','操作员：'+@operator_name);

	exec('update youhoo_rebate_RebatePolicy set flag=0 where id in ('+@array_id+')');	
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_getmodel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_getmodel]
GO
------------------------------------
--用途：得到实体对象的详细信息 
--时间：2017/4/5 23:45:03
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_getmodel
(
	@id		int		--
)
AS
	select * from youhoo_rebate_RebatePolicy where flag=1 and id=@id

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_getlist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_getlist]
GO
------------------------------------
--用途：按条件查询记录信息 
--时间：2017/4/5 23:45:03
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_getlist
(
	@strWhere		nvarchar(500)		--where条件
)
AS
	exec('select a.* from youhoo_rebate_RebatePolicy a where a.flag=1 '+@strWhere+'')

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_getlistbypage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_getlistbypage]
GO
------------------------------------
--用途：分页查询记录信息 
--时间：2017/4/5 23:45:03
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_getlistbypage
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
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_rebate_RebatePolicy a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--分页
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*
			from youhoo_rebate_RebatePolicy a
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);

GO

