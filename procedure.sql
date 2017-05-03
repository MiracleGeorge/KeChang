/******************************************************************
* ������youhoo_rebate_RebateWay
* ʱ�䣺2017/4/5 14:10:46
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_exists]
GO
------------------------------------
--��;���Ƿ��Ѿ����� 
--ʱ�䣺2017/4/5 14:10:46
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
--��;����ӡ��޸� 
--ʱ�䣺2017/4/5 14:10:46
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_insertupdate
(
	@id		int,		--
	@rebate_type		bit,		--��������
	@Name		nvarchar(50),		--
	@Code		varchar(50)=null,		--������ʽ����
	@remark		ntext=null,		--��ע
	@flag		int=null,		--�߼�״̬��1�����ڣ�0�������ڣ�
	@user_id		int,		--������ID
	@createoperator		nvarchar(50)=null,		--������
	@createdate		datetime=null,		--����ʱ��
	@updateoperator		nvarchar(50)=null,		--�޸���
	@updatedate		datetime=null,		--�޸�ʱ��
	@v_id		int output,		--��ʱID����
	@operator_id		int		--������ID
)
AS

--�������-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --��ʼ���� 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--��ӿ�ʼ-------------------------------------------------------------------------------------------------
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
				':'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'��������:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+':'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'��ע:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,1)+';'+'������ID:'+CONVERT(nvarchar,@operator_id)+';'+'������:'+CONVERT(nvarchar,@operator_name)+';'+'����ʱ��:'+CONVERT(nvarchar,getdate())+';'+'�޸���:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'�������',
				'����Ա��'+@operator_name);
	End
	--��ӽ���-------------------------------------------------------------------------------------------------
	
	--�޸Ŀ�ʼ-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_rebate_RebateWay',
		':'+CONVERT(nvarchar,case when id is null then '' else CONVERT(nvarchar,id) end)+';'+'��������:'+CONVERT(nvarchar,case when rebate_type is null then '' else CONVERT(nvarchar,rebate_type) end)+';'+':'+CONVERT(nvarchar,case when Name is null then '' else CONVERT(nvarchar,Name) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when Code is null then '' else CONVERT(nvarchar,Code) end)+';'+'��ע:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'������ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'������:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'����ʱ��:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'�޸���:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		':'+CONVERT(nvarchar,case when @id is null then '' else CONVERT(nvarchar,@id) end)+';'+'��������:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+':'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'��ע:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'������ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'������:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'����ʱ��:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'�޸���:'+CONVERT(nvarchar,@operator_name)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,getdate()),
		'�޸�����',
		'����Ա��'+@operator_name
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
	--�޸Ľ���-------------------------------------------------------------------------------------------------
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
--��;��ɾ����¼ 
--ʱ�䣺2017/4/5 14:10:46
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_delete
(
	@array_id		nvarchar(500),		--ID����
	@operator_id		int		--������ID
)
AS

--�������-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --��ʼ���� 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--ɾ����ʼ-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_rebate_RebateWay','ϵͳɾ�����Ϊ��'+@array_id+'��������','','ɾ������','����Ա��'+@operator_name);

	exec('update youhoo_rebate_RebateWay set flag=0 where id in ('+@array_id+')');	
	--ɾ������-------------------------------------------------------------------------------------------------
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
--��;���õ�ʵ��������ϸ��Ϣ 
--ʱ�䣺2017/4/5 14:10:46
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
--��;����������ѯ��¼��Ϣ 
--ʱ�䣺2017/4/5 14:10:46
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlist
(
	@strWhere		nvarchar(500)		--where����
)
AS
	exec('select a.* from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere+'')

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]
GO
------------------------------------
--��;����ҳ��ѯ��¼��Ϣ 
--ʱ�䣺2017/4/5 14:10:46
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlistbypage
(
	@pageIndex		int,		--ҳ��
	@pageSize		int,		--ÿҳ��ʾ�ļ�¼��
	@strWhere		nvarchar(500),		--����
	@OrderBy		nvarchar(500),		--����
	@count		int output		--�ܼ�¼��
)
AS
	--ͳ���ܼ�¼��
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--��ҳ
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
* ������youhoo_rebate_RebateWay
* ʱ�䣺2017/4/5 14:15:55
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_exists]
GO
------------------------------------
--��;���Ƿ��Ѿ����� 
--ʱ�䣺2017/4/5 14:15:55
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
--��;����ӡ��޸� 
--ʱ�䣺2017/4/5 14:15:55
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_insertupdate
(
	@id		int,		--
	@rebate_type		bit,		--��������
	@Name		nvarchar(50),		--������ʽ����
	@Code		varchar(50)=null,		--������ʽ����
	@remark		ntext=null,		--��ע
	@flag		int=null,		--�߼�״̬��1�����ڣ�0�������ڣ�
	@user_id		int,		--������ID
	@createoperator		nvarchar(50)=null,		--������
	@createdate		datetime=null,		--����ʱ��
	@updateoperator		nvarchar(50)=null,		--�޸���
	@updatedate		datetime=null,		--�޸�ʱ��
	@v_id		int output,		--��ʱID����
	@operator_id		int		--������ID
)
AS

--�������-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --��ʼ���� 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--��ӿ�ʼ-------------------------------------------------------------------------------------------------
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
				':'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'��������:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'��ע:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,1)+';'+'������ID:'+CONVERT(nvarchar,@operator_id)+';'+'������:'+CONVERT(nvarchar,@operator_name)+';'+'����ʱ��:'+CONVERT(nvarchar,getdate())+';'+'�޸���:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'�������',
				'����Ա��'+@operator_name);
	End
	--��ӽ���-------------------------------------------------------------------------------------------------
	
	--�޸Ŀ�ʼ-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_rebate_RebateWay',
		':'+CONVERT(nvarchar,case when id is null then '' else CONVERT(nvarchar,id) end)+';'+'��������:'+CONVERT(nvarchar,case when rebate_type is null then '' else CONVERT(nvarchar,rebate_type) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when Name is null then '' else CONVERT(nvarchar,Name) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when Code is null then '' else CONVERT(nvarchar,Code) end)+';'+'��ע:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'������ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'������:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'����ʱ��:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'�޸���:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		':'+CONVERT(nvarchar,case when @id is null then '' else CONVERT(nvarchar,@id) end)+';'+'��������:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'��ע:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'������ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'������:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'����ʱ��:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'�޸���:'+CONVERT(nvarchar,@operator_name)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,getdate()),
		'�޸�����',
		'����Ա��'+@operator_name
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
	--�޸Ľ���-------------------------------------------------------------------------------------------------
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
--��;��ɾ����¼ 
--ʱ�䣺2017/4/5 14:15:55
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_delete
(
	@array_id		nvarchar(500),		--ID����
	@operator_id		int		--������ID
)
AS

--�������-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --��ʼ���� 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--ɾ����ʼ-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_rebate_RebateWay','ϵͳɾ�����Ϊ��'+@array_id+'��������','','ɾ������','����Ա��'+@operator_name);

	exec('update youhoo_rebate_RebateWay set flag=0 where id in ('+@array_id+')');	
	--ɾ������-------------------------------------------------------------------------------------------------
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
--��;���õ�ʵ��������ϸ��Ϣ 
--ʱ�䣺2017/4/5 14:15:55
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
--��;����������ѯ��¼��Ϣ 
--ʱ�䣺2017/4/5 14:15:55
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlist
(
	@strWhere		nvarchar(500)		--where����
)
AS
	exec('select a.* from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere+'')

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]
GO
------------------------------------
--��;����ҳ��ѯ��¼��Ϣ 
--ʱ�䣺2017/4/5 14:15:55
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlistbypage
(
	@pageIndex		int,		--ҳ��
	@pageSize		int,		--ÿҳ��ʾ�ļ�¼��
	@strWhere		nvarchar(500),		--����
	@OrderBy		nvarchar(500),		--����
	@count		int output		--�ܼ�¼��
)
AS
	--ͳ���ܼ�¼��
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--��ҳ
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
* ������youhoo_rebate_RebateWay
* ʱ�䣺2017/4/5 14:54:13
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_exists]
GO
------------------------------------
--��;���Ƿ��Ѿ����� 
--ʱ�䣺2017/4/5 14:54:13
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
--��;����ӡ��޸� 
--ʱ�䣺2017/4/5 14:54:13
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_insertupdate
(
	@id		int,		--
	@rebate_type		int,		--��������
	@Name		nvarchar(50),		--������ʽ����
	@Code		varchar(50)=null,		--������ʽ����
	@remark		ntext=null,		--��ע
	@flag		int=null,		--�߼�״̬��1�����ڣ�0�������ڣ�
	@user_id		int,		--������ID
	@createoperator		nvarchar(50)=null,		--������
	@createdate		datetime=null,		--����ʱ��
	@updateoperator		nvarchar(50)=null,		--�޸���
	@updatedate		datetime=null,		--�޸�ʱ��
	@v_id		int output,		--��ʱID����
	@operator_id		int		--������ID
)
AS

--�������-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --��ʼ���� 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--��ӿ�ʼ-------------------------------------------------------------------------------------------------
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
				':'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'��������:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'��ע:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,1)+';'+'������ID:'+CONVERT(nvarchar,@operator_id)+';'+'������:'+CONVERT(nvarchar,@operator_name)+';'+'����ʱ��:'+CONVERT(nvarchar,getdate())+';'+'�޸���:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'�������',
				'����Ա��'+@operator_name);
	End
	--��ӽ���-------------------------------------------------------------------------------------------------
	
	--�޸Ŀ�ʼ-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_rebate_RebateWay',
		':'+CONVERT(nvarchar,case when id is null then '' else CONVERT(nvarchar,id) end)+';'+'��������:'+CONVERT(nvarchar,case when rebate_type is null then '' else CONVERT(nvarchar,rebate_type) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when Name is null then '' else CONVERT(nvarchar,Name) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when Code is null then '' else CONVERT(nvarchar,Code) end)+';'+'��ע:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'������ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'������:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'����ʱ��:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'�޸���:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		':'+CONVERT(nvarchar,case when @id is null then '' else CONVERT(nvarchar,@id) end)+';'+'��������:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'��ע:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'������ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'������:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'����ʱ��:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'�޸���:'+CONVERT(nvarchar,@operator_name)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,getdate()),
		'�޸�����',
		'����Ա��'+@operator_name
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
	--�޸Ľ���-------------------------------------------------------------------------------------------------
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
--��;��ɾ����¼ 
--ʱ�䣺2017/4/5 14:54:13
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_delete
(
	@array_id		nvarchar(500),		--ID����
	@operator_id		int		--������ID
)
AS

--�������-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --��ʼ���� 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--ɾ����ʼ-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_rebate_RebateWay','ϵͳɾ�����Ϊ��'+@array_id+'��������','','ɾ������','����Ա��'+@operator_name);

	exec('update youhoo_rebate_RebateWay set flag=0 where id in ('+@array_id+')');	
	--ɾ������-------------------------------------------------------------------------------------------------
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
--��;���õ�ʵ��������ϸ��Ϣ 
--ʱ�䣺2017/4/5 14:54:13
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
--��;����������ѯ��¼��Ϣ 
--ʱ�䣺2017/4/5 14:54:13
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlist
(
	@strWhere		nvarchar(500)		--where����
)
AS
	exec('select a.* from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere+'')

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]
GO
------------------------------------
--��;����ҳ��ѯ��¼��Ϣ 
--ʱ�䣺2017/4/5 14:54:13
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlistbypage
(
	@pageIndex		int,		--ҳ��
	@pageSize		int,		--ÿҳ��ʾ�ļ�¼��
	@strWhere		nvarchar(500),		--����
	@OrderBy		nvarchar(500),		--����
	@count		int output		--�ܼ�¼��
)
AS
	--ͳ���ܼ�¼��
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--��ҳ
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
* ������youhoo_rebate_RebateWay
* ʱ�䣺2017/4/5 15:34:11
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_exists]
GO
------------------------------------
--��;���Ƿ��Ѿ����� 
--ʱ�䣺2017/4/5 15:34:11
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
--��;����ӡ��޸� 
--ʱ�䣺2017/4/5 15:34:11
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_insertupdate
(
	@id		int,		--
	@rebate_type		varchar(50),		--��������
	@Name		nvarchar(50),		--������ʽ����
	@Code		varchar(50)=null,		--������ʽ����
	@remark		ntext=null,		--��ע
	@flag		int=null,		--�߼�״̬��1�����ڣ�0�������ڣ�
	@user_id		int,		--������ID
	@createoperator		nvarchar(50)=null,		--������
	@createdate		datetime=null,		--����ʱ��
	@updateoperator		nvarchar(50)=null,		--�޸���
	@updatedate		datetime=null,		--�޸�ʱ��
	@v_id		int output,		--��ʱID����
	@operator_id		int		--������ID
)
AS

--�������-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --��ʼ���� 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--��ӿ�ʼ-------------------------------------------------------------------------------------------------
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
				':'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'��������:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'��ע:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,1)+';'+'������ID:'+CONVERT(nvarchar,@operator_id)+';'+'������:'+CONVERT(nvarchar,@operator_name)+';'+'����ʱ��:'+CONVERT(nvarchar,getdate())+';'+'�޸���:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'�������',
				'����Ա��'+@operator_name);
	End
	--��ӽ���-------------------------------------------------------------------------------------------------
	
	--�޸Ŀ�ʼ-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_rebate_RebateWay',
		':'+CONVERT(nvarchar,case when id is null then '' else CONVERT(nvarchar,id) end)+';'+'��������:'+CONVERT(nvarchar,case when rebate_type is null then '' else CONVERT(nvarchar,rebate_type) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when Name is null then '' else CONVERT(nvarchar,Name) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when Code is null then '' else CONVERT(nvarchar,Code) end)+';'+'��ע:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'������ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'������:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'����ʱ��:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'�޸���:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		':'+CONVERT(nvarchar,case when @id is null then '' else CONVERT(nvarchar,@id) end)+';'+'��������:'+CONVERT(nvarchar,case when @rebate_type is null then '' else CONVERT(nvarchar,@rebate_type) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'������ʽ����:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'��ע:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'������ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'������:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'����ʱ��:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'�޸���:'+CONVERT(nvarchar,@operator_name)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,getdate()),
		'�޸�����',
		'����Ա��'+@operator_name
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
	--�޸Ľ���-------------------------------------------------------------------------------------------------
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
--��;��ɾ����¼ 
--ʱ�䣺2017/4/5 15:34:11
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_delete
(
	@array_id		nvarchar(500),		--ID����
	@operator_id		int		--������ID
)
AS

--�������-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --��ʼ���� 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--ɾ����ʼ-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_rebate_RebateWay','ϵͳɾ�����Ϊ��'+@array_id+'��������','','ɾ������','����Ա��'+@operator_name);

	exec('update youhoo_rebate_RebateWay set flag=0 where id in ('+@array_id+')');	
	--ɾ������-------------------------------------------------------------------------------------------------
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
--��;���õ�ʵ��������ϸ��Ϣ 
--ʱ�䣺2017/4/5 15:34:11
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
--��;����������ѯ��¼��Ϣ 
--ʱ�䣺2017/4/5 15:34:11
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlist
(
	@strWhere		nvarchar(500)		--where����
)
AS
	exec('select a.* from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere+'')

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebateWay_getlistbypage]
GO
------------------------------------
--��;����ҳ��ѯ��¼��Ϣ 
--ʱ�䣺2017/4/5 15:34:11
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebateWay_getlistbypage
(
	@pageIndex		int,		--ҳ��
	@pageSize		int,		--ÿҳ��ʾ�ļ�¼��
	@strWhere		nvarchar(500),		--����
	@OrderBy		nvarchar(500),		--����
	@count		int output		--�ܼ�¼��
)
AS
	--ͳ���ܼ�¼��
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_rebate_RebateWay a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--��ҳ
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
* ������youhoo_rebate_RebatePolicy
* ʱ�䣺2017/4/5 22:18:30
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_exists]
GO
------------------------------------
--��;���Ƿ��Ѿ����� 
--ʱ�䣺2017/4/5 22:18:30
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
--��;����ӡ��޸� 
--ʱ�䣺2017/4/5 22:18:30
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_insertupdate
(
	@id		int,		--
	@Code		varchar(50),		--�������߱���
	@Name		nvarchar(50),		--������������
	@brand_id		int,		--Ʒ��
	@channel_id		int=null,		--����
	@item_id		int=null,		--Ʒ��
	@price_id		int=null,		--�۸�
	@region_id		int=null,		--����
	@sort_id_id		int=null,		--Ʒ��
	@SupportWay_id		int=null,		--֧�ַ�ʽ
	@SupportPrice_id		int=null,		--֧�ּ۸�
	@RebateType_id		int=null,		--������ʽ
	@time_id		int=null,		--ʱ��
	@remark		ntext=null,		--��ע
	@flag		int=null,		--�߼�״̬��1�����ڣ�0�������ڣ�
	@user_id		int,		--������ID
	@createoperator		nvarchar(50)=null,		--������
	@createdate		datetime=null,		--����ʱ��
	@updateoperator		nvarchar(50)=null,		--�޸���
	@updatedate		datetime=null,		--�޸�ʱ��
	@v_id		int output,		--��ʱID����
	@operator_id		int		--������ID
)
AS

--�������-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --��ʼ���� 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--��ӿ�ʼ-------------------------------------------------------------------------------------------------
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
				':'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'�������߱���:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'������������:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when @brand_id is null then '' else CONVERT(nvarchar,@brand_id) end)+';'+'����:'+CONVERT(nvarchar,case when @channel_id is null then '' else CONVERT(nvarchar,@channel_id) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when @item_id is null then '' else CONVERT(nvarchar,@item_id) end)+';'+'�۸�:'+CONVERT(nvarchar,case when @price_id is null then '' else CONVERT(nvarchar,@price_id) end)+';'+'����:'+CONVERT(nvarchar,case when @region_id is null then '' else CONVERT(nvarchar,@region_id) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when @sort_id_id is null then '' else CONVERT(nvarchar,@sort_id_id) end)+';'+'֧�ַ�ʽ:'+CONVERT(nvarchar,case when @SupportWay_id is null then '' else CONVERT(nvarchar,@SupportWay_id) end)+';'+'֧�ּ۸�:'+CONVERT(nvarchar,case when @SupportPrice_id is null then '' else CONVERT(nvarchar,@SupportPrice_id) end)+';'+'������ʽ:'+CONVERT(nvarchar,case when @RebateType_id is null then '' else CONVERT(nvarchar,@RebateType_id) end)+';'+'ʱ��:'+CONVERT(nvarchar,case when @time_id is null then '' else CONVERT(nvarchar,@time_id) end)+';'+'��ע:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,1)+';'+'������ID:'+CONVERT(nvarchar,@operator_id)+';'+'������:'+CONVERT(nvarchar,@operator_name)+';'+'����ʱ��:'+CONVERT(nvarchar,getdate())+';'+'�޸���:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'�������',
				'����Ա��'+@operator_name);
	End
	--��ӽ���-------------------------------------------------------------------------------------------------
	
	--�޸Ŀ�ʼ-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_rebate_RebatePolicy',
		':'+CONVERT(nvarchar,case when id is null then '' else CONVERT(nvarchar,id) end)+';'+'�������߱���:'+CONVERT(nvarchar,case when Code is null then '' else CONVERT(nvarchar,Code) end)+';'+'������������:'+CONVERT(nvarchar,case when Name is null then '' else CONVERT(nvarchar,Name) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when brand_id is null then '' else CONVERT(nvarchar,brand_id) end)+';'+'����:'+CONVERT(nvarchar,case when channel_id is null then '' else CONVERT(nvarchar,channel_id) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when item_id is null then '' else CONVERT(nvarchar,item_id) end)+';'+'�۸�:'+CONVERT(nvarchar,case when price_id is null then '' else CONVERT(nvarchar,price_id) end)+';'+'����:'+CONVERT(nvarchar,case when region_id is null then '' else CONVERT(nvarchar,region_id) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when sort_id_id is null then '' else CONVERT(nvarchar,sort_id_id) end)+';'+'֧�ַ�ʽ:'+CONVERT(nvarchar,case when SupportWay_id is null then '' else CONVERT(nvarchar,SupportWay_id) end)+';'+'֧�ּ۸�:'+CONVERT(nvarchar,case when SupportPrice_id is null then '' else CONVERT(nvarchar,SupportPrice_id) end)+';'+'������ʽ:'+CONVERT(nvarchar,case when RebateType_id is null then '' else CONVERT(nvarchar,RebateType_id) end)+';'+'ʱ��:'+CONVERT(nvarchar,case when time_id is null then '' else CONVERT(nvarchar,time_id) end)+';'+'��ע:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'������ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'������:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'����ʱ��:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'�޸���:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		':'+CONVERT(nvarchar,case when @id is null then '' else CONVERT(nvarchar,@id) end)+';'+'�������߱���:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'������������:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when @brand_id is null then '' else CONVERT(nvarchar,@brand_id) end)+';'+'����:'+CONVERT(nvarchar,case when @channel_id is null then '' else CONVERT(nvarchar,@channel_id) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when @item_id is null then '' else CONVERT(nvarchar,@item_id) end)+';'+'�۸�:'+CONVERT(nvarchar,case when @price_id is null then '' else CONVERT(nvarchar,@price_id) end)+';'+'����:'+CONVERT(nvarchar,case when @region_id is null then '' else CONVERT(nvarchar,@region_id) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when @sort_id_id is null then '' else CONVERT(nvarchar,@sort_id_id) end)+';'+'֧�ַ�ʽ:'+CONVERT(nvarchar,case when @SupportWay_id is null then '' else CONVERT(nvarchar,@SupportWay_id) end)+';'+'֧�ּ۸�:'+CONVERT(nvarchar,case when @SupportPrice_id is null then '' else CONVERT(nvarchar,@SupportPrice_id) end)+';'+'������ʽ:'+CONVERT(nvarchar,case when @RebateType_id is null then '' else CONVERT(nvarchar,@RebateType_id) end)+';'+'ʱ��:'+CONVERT(nvarchar,case when @time_id is null then '' else CONVERT(nvarchar,@time_id) end)+';'+'��ע:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'������ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'������:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'����ʱ��:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'�޸���:'+CONVERT(nvarchar,@operator_name)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,getdate()),
		'�޸�����',
		'����Ա��'+@operator_name
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
	--�޸Ľ���-------------------------------------------------------------------------------------------------
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
--��;��ɾ����¼ 
--ʱ�䣺2017/4/5 22:18:30
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_delete
(
	@array_id		nvarchar(500),		--ID����
	@operator_id		int		--������ID
)
AS

--�������-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --��ʼ���� 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--ɾ����ʼ-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_rebate_RebatePolicy','ϵͳɾ�����Ϊ��'+@array_id+'��������','','ɾ������','����Ա��'+@operator_name);

	exec('update youhoo_rebate_RebatePolicy set flag=0 where id in ('+@array_id+')');	
	--ɾ������-------------------------------------------------------------------------------------------------
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
--��;���õ�ʵ��������ϸ��Ϣ 
--ʱ�䣺2017/4/5 22:18:30
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
--��;����������ѯ��¼��Ϣ 
--ʱ�䣺2017/4/5 22:18:30
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_getlist
(
	@strWhere		nvarchar(500)		--where����
)
AS
	exec('select a.* from youhoo_rebate_RebatePolicy a where a.flag=1 '+@strWhere+'')

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_getlistbypage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_getlistbypage]
GO
------------------------------------
--��;����ҳ��ѯ��¼��Ϣ 
--ʱ�䣺2017/4/5 22:18:30
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_getlistbypage
(
	@pageIndex		int,		--ҳ��
	@pageSize		int,		--ÿҳ��ʾ�ļ�¼��
	@strWhere		nvarchar(500),		--����
	@OrderBy		nvarchar(500),		--����
	@count		int output		--�ܼ�¼��
)
AS
	--ͳ���ܼ�¼��
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_rebate_RebatePolicy a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--��ҳ
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
* ������youhoo_rebate_RebatePolicy
* ʱ�䣺2017/4/5 23:45:03
******************************************************************/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_exists]
GO
------------------------------------
--��;���Ƿ��Ѿ����� 
--ʱ�䣺2017/4/5 23:45:03
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
--��;����ӡ��޸� 
--ʱ�䣺2017/4/5 23:45:03
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_insertupdate
(
	@id		int,		--
	@Code		varchar(50),		--�������߱���
	@Name		nvarchar(50),		--������������
	@brand_id		int,		--Ʒ��
	@channel_id		int=null,		--����
	@item_id		int=null,		--Ʒ��
	@price_id		int=null,		--�۸�
	@region_id		int=null,		--����
	@sort_id_id		int=null,		--Ʒ��
	@SupportWay_id		int=null,		--֧�ַ�ʽ
	@SupportPrice_id		int=null,		--֧�ּ۸�
	@RebateType_id		int=null,		--������ʽ
	@time_id		int=null,		--ʱ��
	@remark		ntext=null,		--��ע
	@flag		int=null,		--�߼�״̬��1�����ڣ�0�������ڣ�
	@user_id		int,		--������ID
	@createoperator		nvarchar(50)=null,		--������
	@createdate		datetime=null,		--����ʱ��
	@updateoperator		nvarchar(50)=null,		--�޸���
	@updatedate		datetime=null,		--�޸�ʱ��
	@v_id		int output,		--��ʱID����
	@operator_id		int		--������ID
)
AS

--�������-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --��ʼ���� 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--��ӿ�ʼ-------------------------------------------------------------------------------------------------
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
				':'+CONVERT(nvarchar,case when @v_id is null then '' else CONVERT(nvarchar,@v_id) end)+';'+'�������߱���:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'������������:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when @brand_id is null then '' else CONVERT(nvarchar,@brand_id) end)+';'+'����:'+CONVERT(nvarchar,case when @channel_id is null then '' else CONVERT(nvarchar,@channel_id) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when @item_id is null then '' else CONVERT(nvarchar,@item_id) end)+';'+'�۸�:'+CONVERT(nvarchar,case when @price_id is null then '' else CONVERT(nvarchar,@price_id) end)+';'+'����:'+CONVERT(nvarchar,case when @region_id is null then '' else CONVERT(nvarchar,@region_id) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when @sort_id_id is null then '' else CONVERT(nvarchar,@sort_id_id) end)+';'+'֧�ַ�ʽ:'+CONVERT(nvarchar,case when @SupportWay_id is null then '' else CONVERT(nvarchar,@SupportWay_id) end)+';'+'֧�ּ۸�:'+CONVERT(nvarchar,case when @SupportPrice_id is null then '' else CONVERT(nvarchar,@SupportPrice_id) end)+';'+'������ʽ:'+CONVERT(nvarchar,case when @RebateType_id is null then '' else CONVERT(nvarchar,@RebateType_id) end)+';'+'ʱ��:'+CONVERT(nvarchar,case when @time_id is null then '' else CONVERT(nvarchar,@time_id) end)+';'+'��ע:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,1)+';'+'������ID:'+CONVERT(nvarchar,@operator_id)+';'+'������:'+CONVERT(nvarchar,@operator_name)+';'+'����ʱ��:'+CONVERT(nvarchar,getdate())+';'+'�޸���:'+CONVERT(nvarchar,case when @updateoperator is null then '' else CONVERT(nvarchar,@updateoperator) end)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,case when @updatedate is null then '' else CONVERT(nvarchar,@updatedate) end),
				'�������',
				'����Ա��'+@operator_name);
	End
	--��ӽ���-------------------------------------------------------------------------------------------------
	
	--�޸Ŀ�ʼ-------------------------------------------------------------------------------------------------
	Else
	Begin
		insert into Logs (tablename,olddata,newdata,datatype,cname) select 
		'youhoo_rebate_RebatePolicy',
		':'+CONVERT(nvarchar,case when id is null then '' else CONVERT(nvarchar,id) end)+';'+'�������߱���:'+CONVERT(nvarchar,case when Code is null then '' else CONVERT(nvarchar,Code) end)+';'+'������������:'+CONVERT(nvarchar,case when Name is null then '' else CONVERT(nvarchar,Name) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when brand_id is null then '' else CONVERT(nvarchar,brand_id) end)+';'+'����:'+CONVERT(nvarchar,case when channel_id is null then '' else CONVERT(nvarchar,channel_id) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when item_id is null then '' else CONVERT(nvarchar,item_id) end)+';'+'�۸�:'+CONVERT(nvarchar,case when price_id is null then '' else CONVERT(nvarchar,price_id) end)+';'+'����:'+CONVERT(nvarchar,case when region_id is null then '' else CONVERT(nvarchar,region_id) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when sort_id_id is null then '' else CONVERT(nvarchar,sort_id_id) end)+';'+'֧�ַ�ʽ:'+CONVERT(nvarchar,case when SupportWay_id is null then '' else CONVERT(nvarchar,SupportWay_id) end)+';'+'֧�ּ۸�:'+CONVERT(nvarchar,case when SupportPrice_id is null then '' else CONVERT(nvarchar,SupportPrice_id) end)+';'+'������ʽ:'+CONVERT(nvarchar,case when RebateType_id is null then '' else CONVERT(nvarchar,RebateType_id) end)+';'+'ʱ��:'+CONVERT(nvarchar,case when time_id is null then '' else CONVERT(nvarchar,time_id) end)+';'+'��ע:'+CONVERT(nvarchar,case when remark is null then '' else CONVERT(nvarchar,remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,case when flag is null then '' else CONVERT(nvarchar,flag) end)+';'+'������ID:'+CONVERT(nvarchar,case when user_id is null then '' else CONVERT(nvarchar,user_id) end)+';'+'������:'+CONVERT(nvarchar,case when createoperator is null then '' else CONVERT(nvarchar,createoperator) end)+';'+'����ʱ��:'+CONVERT(nvarchar,case when createdate is null then '' else CONVERT(nvarchar,createdate) end)+';'+'�޸���:'+CONVERT(nvarchar,case when updateoperator is null then '' else CONVERT(nvarchar,updateoperator) end)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,case when updatedate is null then '' else CONVERT(nvarchar,updatedate) end),
		':'+CONVERT(nvarchar,case when @id is null then '' else CONVERT(nvarchar,@id) end)+';'+'�������߱���:'+CONVERT(nvarchar,case when @Code is null then '' else CONVERT(nvarchar,@Code) end)+';'+'������������:'+CONVERT(nvarchar,case when @Name is null then '' else CONVERT(nvarchar,@Name) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when @brand_id is null then '' else CONVERT(nvarchar,@brand_id) end)+';'+'����:'+CONVERT(nvarchar,case when @channel_id is null then '' else CONVERT(nvarchar,@channel_id) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when @item_id is null then '' else CONVERT(nvarchar,@item_id) end)+';'+'�۸�:'+CONVERT(nvarchar,case when @price_id is null then '' else CONVERT(nvarchar,@price_id) end)+';'+'����:'+CONVERT(nvarchar,case when @region_id is null then '' else CONVERT(nvarchar,@region_id) end)+';'+'Ʒ��:'+CONVERT(nvarchar,case when @sort_id_id is null then '' else CONVERT(nvarchar,@sort_id_id) end)+';'+'֧�ַ�ʽ:'+CONVERT(nvarchar,case when @SupportWay_id is null then '' else CONVERT(nvarchar,@SupportWay_id) end)+';'+'֧�ּ۸�:'+CONVERT(nvarchar,case when @SupportPrice_id is null then '' else CONVERT(nvarchar,@SupportPrice_id) end)+';'+'������ʽ:'+CONVERT(nvarchar,case when @RebateType_id is null then '' else CONVERT(nvarchar,@RebateType_id) end)+';'+'ʱ��:'+CONVERT(nvarchar,case when @time_id is null then '' else CONVERT(nvarchar,@time_id) end)+';'+'��ע:'+CONVERT(nvarchar,case when @remark is null then '' else CONVERT(nvarchar,@remark) end)+';'+'�߼�״̬��1�����ڣ�0�������ڣ�:'+CONVERT(nvarchar,case when @flag is null then '' else CONVERT(nvarchar,@flag) end)+';'+'������ID:'+CONVERT(nvarchar,case when @user_id is null then '' else CONVERT(nvarchar,@user_id) end)+';'+'������:'+CONVERT(nvarchar,case when @createoperator is null then '' else CONVERT(nvarchar,@createoperator) end)+';'+'����ʱ��:'+CONVERT(nvarchar,case when @createdate is null then '' else CONVERT(nvarchar,@createdate) end)+';'+'�޸���:'+CONVERT(nvarchar,@operator_name)+';'+'�޸�ʱ��:'+CONVERT(nvarchar,getdate()),
		'�޸�����',
		'����Ա��'+@operator_name
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
	--�޸Ľ���-------------------------------------------------------------------------------------------------
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
--��;��ɾ����¼ 
--ʱ�䣺2017/4/5 23:45:03
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_delete
(
	@array_id		nvarchar(500),		--ID����
	@operator_id		int		--������ID
)
AS

--�������-----------------------------------------------------------------------------------------------------
	SET NOCOUNT ON;
	declare @operator_name nvarchar(400);
	Begin Tran; --��ʼ���� 
	
	select @operator_name = username from youhoo_sys_users where flag=1 and user_id = @operator_id
	if(@operator_name is null)
	begin
		RollBack Tran
		Return -11
	end

	--ɾ����ʼ-------------------------------------------------------------------------------------------------
	insert into Logs (tablename,olddata,newdata,datatype,cname)
	values('youhoo_rebate_RebatePolicy','ϵͳɾ�����Ϊ��'+@array_id+'��������','','ɾ������','����Ա��'+@operator_name);

	exec('update youhoo_rebate_RebatePolicy set flag=0 where id in ('+@array_id+')');	
	--ɾ������-------------------------------------------------------------------------------------------------
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
--��;���õ�ʵ��������ϸ��Ϣ 
--ʱ�䣺2017/4/5 23:45:03
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
--��;����������ѯ��¼��Ϣ 
--ʱ�䣺2017/4/5 23:45:03
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_getlist
(
	@strWhere		nvarchar(500)		--where����
)
AS
	exec('select a.* from youhoo_rebate_RebatePolicy a where a.flag=1 '+@strWhere+'')

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_youhoo_rebate_RebatePolicy_getlistbypage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_youhoo_rebate_RebatePolicy_getlistbypage]
GO
------------------------------------
--��;����ҳ��ѯ��¼��Ϣ 
--ʱ�䣺2017/4/5 23:45:03
------------------------------------
CREATE PROCEDURE sp_youhoo_rebate_RebatePolicy_getlistbypage
(
	@pageIndex		int,		--ҳ��
	@pageSize		int,		--ÿҳ��ʾ�ļ�¼��
	@strWhere		nvarchar(500),		--����
	@OrderBy		nvarchar(500),		--����
	@count		int output		--�ܼ�¼��
)
AS
	--ͳ���ܼ�¼��
	declare @strSQL   nvarchar(4000);
	
	set @strSQL = 'select @count=COUNT(*) from youhoo_rebate_RebatePolicy a where a.flag=1 '+@strWhere
	exec sp_executesql @strSQL,N'@count int OUTPUT',@count OUTPUT
	
	--��ҳ
	set @strSQL = 'select t.* from (
			select ROW_NUMBER() over(Order by '+@OrderBy+') as r_id, a.*
			from youhoo_rebate_RebatePolicy a
			where a.flag=1 '+@strWhere+'
		) as t
		where t.r_id>('+CONVERT(nvarchar(50), @pageIndex)+'-1)*'+CONVERT(nvarchar(50), @pageSize)+' and t.r_id<='+CONVERT(nvarchar(50), @pageIndex)+'*'+CONVERT(nvarchar(50), @pageSize)+'
	'
	exec (@strSQL);

GO

