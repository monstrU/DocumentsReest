﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DocumentsReestr.PopupButtons.PopUpPages
{
    using RCO.PopUpButton;

    using ReestrFacade;

    public partial class DocNames : PopUpPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CancelButton = btnCancel;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDocNames();
            }
        }

        public  void LoadDocNames()
        {
            var docNames = DocNamesFacade.LoadDocNames();
            gvDocNames.DataSource = docNames;
            gvDocNames.DataBind();
        }

        protected void gvDocNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            string docNameId = gvDocNames.SelectedDataKey.Values[0].ToString();
            Arguments.Add("docNameId", docNameId);

            string docNameText = gvDocNames.SelectedDataKey.Values[1].ToString();
            Arguments.Add("docNameText", docNameText);

            string termExecutionDays = gvDocNames.SelectedDataKey.Values[2].ToString();
            Arguments.Add("termExecution", termExecutionDays);
            this.CloseDialog();
        }
    }
}