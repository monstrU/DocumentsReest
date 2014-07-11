using System;
using System.Collections.Generic;

namespace DocumentsReestr
{
    using System.Web.UI.WebControls;

    using DomainModel;

    using RCO.PopUpButtons;

    using ReestrFacade;

    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = User.Identity;
            if (!Page.IsPostBack)
            {
                LoadDocuments();
            }
        }

        private void LoadDocuments()
        {
            IList<DocumentModel> list = DocumentFacade.LoadDocuments();
            gvDocuments.DataSource = list;
            gvDocuments.DataBind();
        }

        protected void pbtnAdd_AfterChildClose(object sender, RCO.PopUpButtons.PopUpItems e)
        {
            gvDocuments.PageIndex = 0;
            this.LoadDocuments();
        }

        protected void gvDocuments_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var pbtnEditDoc = e.Row.FindControl("pbtnEditDoc") as PopUpButton;
                if (pbtnEditDoc != null)
                {
                    var doc = e.Row.DataItem as DocumentModel;
                    if (doc != null)
                    {
                        pbtnEditDoc.PostParams.Add(new paramItem("docId", doc.DocumentId.ToString()));
                    }
                }
            }
        }
    }
}