/*
declare @appId uniqueidentifier
set @appId = newid()


select * from aspnet_Applications
insert into aspnet_Applications( ApplicationId, ApplicationName, LoweredApplicationName) values(@appid, 'app', 'app')

declare @userId uniqueidentifier
set @userId  = newid()

insert into aspnet_Users (ApplicationId, UserId, UserName, LoweredUserName, LastActivityDate) values(@appid, @appid, 'person1', 'person1', getdate())

select * from aspnet_Users
*/

insert into Documents(Name, DocNumber, SenderName, DateAdmission, creatoruserid) values ('������� ������ ����� �� ����',1,'�������� �.�.','20140710','5D8E89C3-3CE6-44FD-B3E0-D52D5E67E5DD')
select * from Documents

update Documents set Created  ='20140710'

select * from DocSenders
insert into DocSenders(SenderName) values('�������� ������� ����������')
insert into DocSenders(SenderName) values('������� ���� ��������')

select * from docnames
insert into docnames(Name, TermExecutionDays) values('��������� ���������', 1)
insert into docnames(Name, TermExecutionDays) values('����� ������ �����', 2)
insert into docnames(Name, TermExecutionDays) values('������������ ��������', 3)
insert into docnames(Name, TermExecutionDays) values('������', 7)
insert into docnames(Name, TermExecutionDays) values('�������� ��������', 10)