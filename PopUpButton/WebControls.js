function openPopUp(url, feathers, isConfirm, confirmText, reloadControlId )
{
    if (isConfirm==true && (confirm(confirmText)==false)) return false;
    window.open(url+((reloadControlId.length>0)?"&controlID="+reloadControlId:""), '_blank', feathers, true);
}
        


function openFRSDChildDialog(url, dialogName, width,height, idForReload, isConfirm, confirmText, isStatus , isScrollBar, isResizable)
{
	if (isConfirm==true && (confirm(confirmText)==false)) return false;
		
	var rValue = window.showModalDialog(url,(dialogName!=null)?dialogName:"","center:yes;dialogHeight:  "+ height +"px; dialogWidth: "+ width +"px; dialogTop: 300px; dialogLeft: 30px; edge: Raised; center: yes; help: No; resizable: Yes; status:" + isStatus+";scroll="+isScrollBar+";resizable="+isResizable);
	
	
	var separetedChar="&",separetedPair="=";	

		if (rValue!=null  && rValue.indexOf("reload")>=0)
		{
			var theform = document.forms[0];			
			
			theform.__EVENTTARGET.value = arguments[4];
			theform.__EVENTARGUMENT.value = rValue;			
			__doPostBack(arguments[4],rValue);			
			
		}
	
			
}


