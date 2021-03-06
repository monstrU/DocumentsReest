USE [ReestrStore]
GO
/****** Object:  Trigger [dbo].[DocNumberAutoFill]    Script Date: 15.07.2014 21:47:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER  TRIGGER [dbo].[DocNumberAutoFill]
on [dbo].[Documents] after insert
AS
begin 
	update Documents set DocNumber=next value for [SeqDocNumber]
	where DocumentId in (select DocumentId from inserted)	
end
