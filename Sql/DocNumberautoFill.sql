USE [ReestrStore]
GO

/****** Object:  Trigger [DocNumberautoFill]    Script Date: 15.07.2014 21:38:04 ******/
DROP TRIGGER [dbo].[DocNumberAutoFill]
GO

/****** Object:  Trigger [dbo].[DocNumberautoFill]    Script Date: 15.07.2014 21:38:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE  TRIGGER [dbo].[DocNumberAutoFill]
on [dbo].[Documents] after update
AS
begin 
	update Documents set DocNumber=next value for [SeqDocNumber]
	where DocumentId in (select DocNameId from inserted)
end

GO


