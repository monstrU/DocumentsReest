using System;
using System.Collections.Generic;

namespace DocumentsReestr
{
    using DomainModel;

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
    }
}