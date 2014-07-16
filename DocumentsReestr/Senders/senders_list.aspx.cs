using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DocumentsReestr.PopupButtons.Senders
{
    public partial class senders_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadSenders();
            }
        }

        private void LoadSenders()
        {
            gvSenders.DataSource = ReestrFacade.SendersFacade.LoadSenders();
            gvSenders.DataBind();
        }
    }
}