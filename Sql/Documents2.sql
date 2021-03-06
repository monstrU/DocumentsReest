/*
   10 июля 2014 г.12:23:06
   User: 
   Server: vvv
   Database: ReestrStore
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Documents
	(
	DocumentId int NOT NULL IDENTITY (1, 1),
	Name nvarchar(100) NOT NULL,
	Created datetime NULL,
	TermExecution datetime NULL,
	SenderId int NULL,
	NameId int NULL,
	DocNumber int NOT NULL,
	SenderName nvarchar(200) NOT NULL,
	DateAdmission datetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Documents SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Documents ON
GO
IF EXISTS(SELECT * FROM dbo.Documents)
	 EXEC('INSERT INTO dbo.Tmp_Documents (DocumentId, Name, Created, TermExecution, SenderId, NameId)
		SELECT DocumentId, Name, Created, TermExecution, SenderId, NameId FROM dbo.Documents WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Documents OFF
GO
DROP TABLE dbo.Documents
GO
EXECUTE sp_rename N'dbo.Tmp_Documents', N'Documents', 'OBJECT' 
GO
ALTER TABLE dbo.Documents ADD CONSTRAINT
	PK_Documents PRIMARY KEY CLUSTERED 
	(
	DocumentId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Documents', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Documents', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Documents', 'Object', 'CONTROL') as Contr_Per 