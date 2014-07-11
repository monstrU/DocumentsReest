using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DocumentsReestr.PopupButtons.PopUpPages
{
    using RCO.PopUpButton;

    public partial class SenderName : PopUpPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CancelButton = btnCancel;
        }
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

        protected void gvSenders_SelectedIndexChanged(object sender, EventArgs e)
        {
            string senderId = gvSenders.SelectedDataKey.Values[0].ToString();
            Arguments.Add("senderId", senderId);

            string senderNameId = gvSenders.SelectedDataKey.Values[1].ToString();
            Arguments.Add("senderNameId", senderNameId);
            this.CloseDialog();
        }
    }
}