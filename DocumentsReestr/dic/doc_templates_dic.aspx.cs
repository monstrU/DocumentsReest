using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using RCO.PopUpButtons;


namespace DocumentsReestr.PopupButtons.dic
{
    public partial class doc_templates_dic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDocNames();
            }
        }

        public void LoadDocNames()
        {
            var docNames = ReestrFacade.DocNamesFacade.LoadDocNames();
            gvDocNames.DataSource = docNames;
            gvDocNames.DataBind();
        }

        protected void pbtnAddDoc_OnAfterChildClose(object sender, PopUpItems e)
        {
            LoadDocNames();
        }

        protected void pbtnEditDoc_OnAfterChildClose(object sender, PopUpItems e)
        {
            LoadDocNames();
        }

        protected void gvDocNames_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var pbtnEditDoc = e.Row.FindControl("pbtnEditDoc") as PopUpButton;
                if (pbtnEditDoc != null)
                {
                    var doc = e.Row.DataItem as DocNameModel;
                    if (doc != null)
                    {
                        pbtnEditDoc.PostParams.Add(new paramItem("docNameId", doc.DocNameId.ToString()));
                    }
                }
            }
        }
    }
}