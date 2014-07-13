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
            fvDocument.ChangeMode(FormViewMode.Edit);
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

            fvDocument.DataBind();
        }

        private DocumentModel ReadDocument()
        {
            DocumentModel doc = new DocumentModel();

            var documentIdString = GetControlValue<HtmlInputHidden>("idDocId").Value;
            if (!string.IsNullOrEmpty(documentIdString))
            {
                doc.DocumentId = Convert.ToInt32(documentIdString);
            }
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
            

            var idSenderIdForm = idSenderId.Value;
            var idSenderNameForm = idSenderName.Value;
            var senderName = GetControlValue<TextBox>("txtSenderName").Text;
            if (senderName.Equals(idSenderNameForm) && !string.IsNullOrEmpty(idSenderId.Value))
            {
                doc.DocSender = new DocSenderModel()
                               {
                                   DocSenderId = Convert.ToInt32(idSenderIdForm),
                                   SenderName = senderName
                               };
            }

            


            var comment = GetControlValue<TextBox>("txtComments").Text;
            doc.Comments = comment;

            var dateAdmission = GetControlValue<TextBox>("txtDateAdmission").Text;
            doc.DateAdmission = ParseDateTime(dateAdmission);

            var termExecution = GetControlValue<TextBox>("txtTermExecution").Text;
            doc.TermExecution = ParseDateTime(termExecution);


            

            return doc;
        }

        private T GetControlValue<T>(string controlId) where T : class
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

        public void InsertCard()
        {
            try
            {
                var doc = this.ReadDocument();
                doc.Created = DateTime.Now;

                doc.ControlTermExecution = DateTime.Now;



                DocumentFacade.SaveDocument(doc);

            }
            catch (Exception e)
            {
                lblError.Text = e.Message;
            }

        }

        public void UpdateCard(DocumentModel document)
        {
            try
            {
                DocumentFacade.UpdateDocument(document);
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
            else
            {
                var doc = this.ReadDocument();
                UpdateCard(doc);
            }
            this.CloseDialog();
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