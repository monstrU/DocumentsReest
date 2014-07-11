using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DocumentsReestr.PopupButtons.PopUpPages
{
    using System.Web.UI.HtmlControls;

    using DomainModel;

    using RCO.PopUpButton;
    using RCO.PopUpButtons;

    using ReestrFacade;

    public partial class DocumentCard : PopUpPage
    {
        public bool  IsAdd
        {
            get
            {
                return !string.IsNullOrEmpty(Request.QueryString["add"]);
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            CancelButton = btnCancel;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (IsAdd)
                {
                    fvDocument.ChangeMode(FormViewMode.Insert);
                }
                else
                {
                    fvDocument.ChangeMode(FormViewMode.Edit);
                }

            }   
        }

        private DocumentModel ReadDocument()
        {
            DocumentModel doc= new DocumentModel();
            var docName = GetControlValue<TextBox>("txtDocName").Text;
            var idDocNameTextForm = idDocNameText.Value;
            var idDocNameIdForm = idDocNameId.Value;
            var idTermExecutionForm = idTermExecution.Value;

            if (docName.Equals(idDocNameTextForm) && !string.IsNullOrEmpty(idDocNameId.ToString()))
            {
                doc.DocName = new DocNameModel()
                              {
                                  DocNameId = Convert.ToInt32(idDocNameIdForm),
                                  Name = idDocNameTextForm,
                                  TermExecutionDays = Convert.ToInt32(idTermExecutionForm)
                              };
            }
            doc.Name = docName;

            var idSenderIdForm = idSenderId.Value;
            var idSenderNameForm = idSenderName.Value;
            var senderName = GetControlValue<TextBox>("txtSenderName").Text;
            if (senderName.Equals(idSenderNameForm) && !string.IsNullOrEmpty(idSenderId.Value))
            {
                doc.DocSender= new DocSenderModel()
                               {
                                   DocSenderId = Convert.ToInt32(idSenderIdForm),
                                   SenderName = senderName
                               };
            }

            doc.SenderName = senderName;
            

            var comment = GetControlValue<TextBox>("txtComments").Text;
            doc.Comments = comment;

            var dateAdmission = GetControlValue<TextBox>("txtDateAdmission").Text;
            doc.DateAdmission = ParseDateTime(dateAdmission);

            var termExecution = GetControlValue<TextBox>("txtTermExecution").Text;
            doc.TermExecution = ParseDateTime(termExecution);


                
            return doc;
        }

        private T GetControlValue<T>(string controlId) where T:class
        {
            
            var control = fvDocument.FindControl(controlId) as T;
            if (control == null)
            {
                control = default(T);
            }
            return control;
        }

        public static DateTime ParseDateTime(string valueString)
        {
            return DateTime.Parse(valueString);
        }

        public  void InsertCard()
        {
            try
            {
                var doc = this.ReadDocument();
                doc.Created = DateTime.Now;
                
                doc.ControlTermExecution = DateTime.Now;
                
                
                
                DocumentFacade.SaveDocument(doc);
                this.CloseDialog();
            }
            catch (Exception e)
            {
                lblError.Text = e.Message;
            }

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                this.InsertCard();
            }
        }

        protected void pbtnDocName_OnAfterChildClose(object sender, PopUpItems e)
        {
            var docNameId = e.Items["docNameId"];
            var docNameText = e.Items["docNameText"];
            var termExecution = e.Items["termExecution"];
            idDocNameId.Value = docNameId.ToString();
            idDocNameText.Value = docNameText.ToString();
            idTermExecution.Value = termExecution.ToString();
            GetControlValue<TextBox>("txtDocName").Text = docNameText.ToString();
            
        }

        protected void pbtnFio_OnAfterChildClose(object sender, PopUpItems e)
        {
            var senderId = e.Items["senderId"];
            var senderNameId = e.Items["senderNameId"];
            idSenderId.Value = senderId.ToString();
            idSenderName.Value = senderNameId.ToString();
            GetControlValue<TextBox>("txtSenderName").Text = senderNameId.ToString();
        }
    }
}