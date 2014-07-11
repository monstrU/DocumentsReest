using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DocumentsReestr.PopupButtons.PopUpPages
{
    using DomainModel;

    using RCO.PopUpButton;

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
            doc.Name = docName;

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
                doc.DateAdmission= DateTime.Now;
                doc.SenderName = "";
                
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
    }
}