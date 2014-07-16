using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using RCO.PopUpButton;
using ReestrFacade;

namespace DocumentsReestr.PopupButtons.PopUpPages
{
    public partial class doc_template_card : PopUpPage
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
                return Convert.ToInt32(Request.QueryString["docNameId"]);
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
                    fvDocTemplate.ChangeMode(FormViewMode.Insert);
                    btnDelete.Visible = false;
                }
                else
                {
                    fvDocTemplate.ChangeMode(FormViewMode.Edit);
                    LoadDocNames();
                }

            }
        }

        public void LoadDocNames()
        {
            var doc = DocNamesFacade.GetDocName(docId);
            fvDocTemplate.DataSource = new[] { doc };
            fvDocTemplate.DataBind();
        }
        private DocNameModel ReadDocument()
        {
            DocNameModel docName = new DocNameModel();

            var docNameString = GetControlValue<TextBox>(fvDocTemplate, "txtName").Text;
            docName.Name = docNameString;

            var terExec = Convert.ToInt32(GetControlValue<TextBox>(fvDocTemplate, "txtTermExecution").Text);
            docName.TermExecutionDays = terExec;

            if (!IsAdd)
            {
                docName.DocNameId = docId;
            }
            
            return docName;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var docName = ReadDocument();
                if (IsAdd)
                {
                    AddItem(docName);
                }
                else
                {
                    UpdateItem(docName);
                }
                CloseDialog();
            }
            catch (Exception exception)
            {
                lblError.Text = exception.Message;
            }
        }

        public void AddItem(DocNameModel docName)
        {
            try
            {
                DocNamesFacade.AddDocNames(docName);
            }
            catch (Exception e)
            {
                lblError.Text = e.Message;
            }
        }

        public void UpdateItem(DocNameModel docName)
        {
            try
            {
                DocNamesFacade.UpdateDocName(docName);
            }
            catch (Exception e)
            {
                lblError.Text = e.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var docName = ReadDocument();
                DocNamesFacade.DeleteDocName(docName);
                CloseDialog();
            }
            catch (Exception exception)
            {
                lblError.Text = exception.Message;
            }
        }


    }
}