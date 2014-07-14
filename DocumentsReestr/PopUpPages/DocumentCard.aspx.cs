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
        public bool IsAdd
        {
            get
            {
                return !string.IsNullOrEmpty(Request.QueryString["add"]);
            }
        }

        public int docId
        {
            get
            {
                return Convert.ToInt32(Request.QueryString["docId"]);
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
                    this.LoadDocument(docId);
                }

            }
        }

        private void LoadDocument(int documentId)
        {
            var doc = DocumentFacade.LoadDocument(documentId);
            fvDocument.DataSource = new object[] { doc };
            if (doc.DocSender != null)
            {
                idSenderId.Value = doc.DocSender.DocSenderId.ToString();
                idSenderName.Value = doc.DocSender.SenderName;
            }
            if (doc.DocName != null)
            {
                idDocNameId.Value = doc.DocName.DocNameId.ToString();
                idDocNameText.Value = doc.DocName.Name;
            }
            idTermExecution.Value = doc.TermExecution.ToString();

            fvDocument.DataBind();
        }

        private DocumentModel ReadDocument()
        {
            DocumentModel doc = new DocumentModel();

            
            if (!IsAdd)
            {
                doc.DocumentId = docId;
            }

            var docName = GetControlValue<TextBox>(fvDocument, "txtDocName").Text;
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
            else
            {
                doc.Name = docName;
                
                var termExecution = GetControlValue<TextBox>(fvDocument, "txtTermExecution").Text;
                doc.TermExecution = Convert.ToInt32(termExecution);
            }

            var idSenderIdForm = idSenderId.Value;
            var idSenderNameForm = idSenderName.Value;
            var senderName = GetControlValue<TextBox>(fvDocument, "txtSenderName").Text;
            if (senderName.Equals(idSenderNameForm) && !string.IsNullOrEmpty(idSenderId.Value))
            {
                doc.DocSender = new DocSenderModel()
                               {
                                   DocSenderId = Convert.ToInt32(idSenderIdForm),
                                   SenderName = senderName
                               };
            }




            var comment = GetControlValue<TextBox>(fvDocument, "txtComments").Text;
            doc.Comments = comment;

            var dateAdmission = GetControlValue<TextBox>(fvDocument, "txtDateAdmission").Text;
            doc.DateAdmission = ParseDateTime(dateAdmission);

            


            

            return doc;
        }

        public static DateTime ParseDateTime(string valueString)
        {
            return DateTime.Parse(valueString);
        }

        public void InsertCard()
        {
                var doc = this.ReadDocument();
                doc.Created = DateTime.Now;
                DocumentFacade.SaveDocument(doc);
        }

        public void UpdateCard(DocumentModel document)
        {
            
                DocumentFacade.UpdateDocument(document);
            
            
        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsAdd)
                {
                    this.InsertCard();
                }
                else
                {
                    var doc = this.ReadDocument();
                    UpdateCard(doc);
                }
                this.CloseDialog();
            }
            catch (Exception exception)
            {
                lblError.Text = exception.Message;
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
            GetControlValue<TextBox>(fvDocument, "txtDocName").Text = docNameText.ToString();
            var txtTermExecution =GetControlValue<TextBox>(fvDocument, "txtTermExecution");
            txtTermExecution.Enabled = false;
            txtTermExecution.Text = termExecution.ToString();


        }

        protected void pbtnFio_OnAfterChildClose(object sender, PopUpItems e)
        {
            var senderId = e.Items["senderId"];
            var senderNameId = e.Items["senderNameId"];
            idSenderId.Value = senderId.ToString();
            idSenderName.Value = senderNameId.ToString();
            GetControlValue<TextBox>(fvDocument, "txtSenderName").Text = senderNameId.ToString();
        }
    }
}