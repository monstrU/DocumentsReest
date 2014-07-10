using System;
using System.Web;
using System.Web.UI;
using System.ComponentModel;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace RCO.PopUpButton
{
    /// <summary>
    /// Summary description for popuppage.
    /// </summary>
    public class PopUpPage : System.Web.UI.Page
    {

        private Hashtable _argumenst;
        private Button _okButton;
        private Button _cancelButton;
        private bool _isClosable;
        private string _pageHeader;


        #region Public ����

        public SqlCommand Command;

        /// <summary>
        /// ������ ��� ���������� ������� ��� �������������� ����������� ������ 
        /// </summary>
        public System.Globalization.CultureInfo SelectLocale;

        #endregion





        #region	 ������ ���  ������������� ������� SQLCommand

        protected virtual void InitSelectCommand()
        {

        }

        protected virtual void InitUpdateCommand()
        {

        }

        protected virtual void InitDeleteCommand()
        {

        }

        protected virtual void InitInsertCommand()
        {

        }

        protected virtual DataTable SelectCard()
        {
            if (this.Command == null)
                Command = new SqlCommand();
            else
                if (Command.Parameters.Count > 0)
                    Command.Parameters.Clear();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter da;
            DataSet ds;
            using (conn)
            {
                conn.ConnectionString = this.ConnectionString;
                conn.Open();
                Command.Connection = conn;
                Command.CommandText = this.SelectCommandText;
                this.InitSelectCommand();
                da = new SqlDataAdapter();
                ds = new DataSet();
                ds.Locale = SelectLocale;
                da.SelectCommand = Command;
                da.Fill(ds);

                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();

                return ds.Tables[0];

            }
        }


        protected virtual void InsertCard()
        {
            if (this.Command == null)
                Command = new SqlCommand();
            SqlConnection conn = new SqlConnection();

            try
            {
                using (conn)
                {
                    conn.ConnectionString = this.ConnectionString;
                    conn.Open();
                    this.InitInsertCommand();
                    Command.Connection = conn;
                    Command.CommandText = this.InsertCommandText;

                    this.Command.ExecuteNonQuery();
                }

            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }


        }


        protected virtual void UpdateCard()
        {
            if (this.Command == null)
                Command = new SqlCommand();
            else
                if (Command.Parameters.Count > 0)
                    Command.Parameters.Clear();

            SqlConnection conn = new SqlConnection();

            try
            {
                using (conn)
                {
                    conn.ConnectionString = this.ConnectionString;



                    conn.Open();
                    this.InitUpdateCommand();


                    Command.Connection = conn;
                    Command.CommandText = this.UpdateCommandText;

                    this.Command.ExecuteNonQuery();
                }
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }


        }



        protected virtual void DeleteCard()
        {
            if (this.Command == null)
                Command = new SqlCommand();
            else
                if (Command.Parameters.Count > 0)
                    Command.Parameters.Clear();

            SqlConnection conn = new SqlConnection();

            using (conn)
            {
                conn.ConnectionString = this.ConnectionString;
                conn.Open();
                Command.Connection = conn;
                Command.CommandText = this.DeleteCommandText;
                this.InitDeleteCommand();
                this.Command.ExecuteNonQuery();
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }


        }

        #endregion



        #region ��������

        public string PageHeader
        {
            get { return _pageHeader; }
            set { _pageHeader = value; }
        }

        public bool IsClosable
        {
            get { return _isClosable; }
            set { _isClosable = value; }
        }

        public Button OkButton
        {
            get { return _okButton; }
            set { _okButton = value; }
        }

        public Button CancelButton
        {
            get { return _cancelButton; }
            set
            {
                _cancelButton = value;
            }
        }


        /// <summary>
        /// ��������� ������������ ����������
        /// </summary>
        [Browsable(false),
        Description("��������� ������������ ����������")]
        public Hashtable Arguments
        {
            get { return _argumenst; }
            set { _argumenst = value; }
        }

        [Browsable(false),
        Description("���������� ��� ��������� ����")]
        public bool IsModalWindow
        {
            get
            {
                return (Request.QueryString["modal"] != null && Request.QueryString["modal"] == "1") ? true : false;
            }
        }
        private bool DoPostBack
        {
            get
            {
                return (Request.QueryString["result"] != null && Request.QueryString["result"] == "reload") ? true : false;
            }
        }

        /// <summary>
        /// ������ ��� ������ ������ ��������. 
        /// � �������� ���������� ���������  ���������� �������, ������������ ��������.
        /// ������������� ���������� ������ ���� ������. 
        /// </summary>
        [Browsable(false)]
        public string SelectCommandText
        {
            get { return ViewState["SelectCommandText"] as string; }
            set { ViewState["SelectCommandText"] = value; }
        }

        /// <summary>
        /// ������ ��� ���������� ������ ��������
        /// </summary>
        [Browsable(false)]
        public string InsertCommandText
        {
            get { return ViewState["InsertCommandText"] as string; }
            set { ViewState["InsertCommandText"] = value; }
        }

        /// <summary>
        /// ������ ��� �������� ������ ��������
        /// </summary>
        [Browsable(false)]
        public string DeleteCommandText
        {
            get { return ViewState["DeleteCommandtext"] as string; }
            set { ViewState["DeleteCommandtext"] = value; }
        }

        /// <summary>
        /// ������ ��� ���������� ������ ��������
        /// </summary>
        [Browsable(false)]
        public string UpdateCommandText
        {
            get { return ViewState["UpdateCommandtext"] as string; }
            set { ViewState["UpdateCommandtext"] = value; }
        }


        /// <summary>
        /// ������ ����������� � ����
        /// </summary>
        [Browsable(false)]
        public string ConnectionString
        {
            get { return ViewState["ConnectionString"] as string; }
            set { ViewState["ConnectionString"] = value; }
        }

        #endregion



        public PopUpPage()
        {
            //
            // TODO: Add constructor logic here
            //
            _argumenst = new Hashtable();
            _isClosable = true;

            Command = new SqlCommand();
            SelectLocale = new System.Globalization.CultureInfo("ru-RU");
        }


        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //


            base.OnInit(e);

            if (this.OkButton != null)
            {
                this.OkButton.Click += new EventHandler(this.okButton_Click);
                SetDefaults(OkButton);
            }
            if (IsModalWindow)
            {
                if (this.CancelButton != null)
                {
                    this.CancelButton.Attributes["onclick"] = CloseWindowJSNoReload();
                    this.CancelButton.CausesValidation = false;
                    this.CancelButton.ToolTip = "������� ���� ��� ������������ ������������� ����";



                }
            }
            else
                if (this.CancelButton != null)
                    this.CancelButton.Attributes["onclick"] = "javascript:window.close();return false;";


            if (IsModalWindow && DoPostBack)
            {
                this.Arguments.Add("result", "reload");
                if (this.OkButton != null)
                    this.OkButton.ToolTip = "������� ���� � ������������� ������������� ����";
            }


            this.Context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.Context.Response.Cache.SetExpires(DateTime.MinValue);

            this.Context.Response.Cache.SetExpires(DateTime.Now.AddYears(-1));
            this.Context.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            this.Context.Response.Cache.SetNoServerCaching();
            this.Context.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (this.Header != null && this.IsModalWindow)
            {
                if (IsModalWindow)
                {
                    HtmlGenericControl baseT = new HtmlGenericControl("base");
                    baseT.Attributes.Add("target", "_self");
                    this.Header.Controls.Add(baseT);
                }
                if (PageHeader != null)
                    this.Header.Title = PageHeader;
            }
        }

        /// <summary>
        /// ������ ��� �������� ���� � �������������
        /// </summary>
        /// <returns></returns>
        public static string CloseWindowJSWithReload()
        {
            return "javascript: return true;";
        }

        /// <summary>
        /// ������ ��� �������� ���� ��� ������������
        /// </summary>
        /// <returns></returns>
        public static string CloseWindowJSNoReload()
        {
            return "javascript:window.close();return false;";
        }

        private void SetDefaults(Control btn)
        {
            this.SetFocus(btn);
            this.Page.Form.DefaultButton = btn.UniqueID;
            this.Form.DefaultFocus = btn.ClientID;
        }

        #region ������  ������ � ��������

        protected void okButton_Click(Object sender, EventArgs e)
        {
            CloseDialog();
        }


        /// <summary>
        /// ������� ��������� �������� ������
        /// </summary>
        public void CloseDialog()
        {
            if (IsModalWindow)
            {
                if (IsClosable && !Page.ClientScript.IsStartupScriptRegistered("closeOk"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "closeOk", "\n<script language='javascript'>" +
                                                                                       " window.returnValue='" + GetParsedArguments() +
                                                                                       "';window.close();" +
                                                                                       "</script>\n");
                }
            }
            else
                if (IsClosable)
                {
                    if (!this.ClientScript.IsStartupScriptRegistered(this.UniqueID + "btnClose"))
                        this.ClientScript.RegisterStartupScript(this.GetType(), this.UniqueID + "btnClose",
                            @"if (window.opener!=null && window.opener.__doPostBack!=null) " +
                            @"window.opener.__doPostBack('" + Request.QueryString[PopUpButtons.PopUpButton.qControlID] + "','" + GetParsedArguments() + @"');
                        window.close();", true);
                }
        }
        private string GetParsedArguments()
        {
            string s = "";
            IDictionaryEnumerator myEnumerator = Arguments.GetEnumerator();

            while (myEnumerator.MoveNext())
                s += myEnumerator.Key + "=" + myEnumerator.Value + "&";
            return (s.Length > 0) ? s.Remove(s.Length - 1, 1) : "";

        }

        #endregion



        #region  ������ ������������� SQL ���������

        public void InitSqlParameter(string paramName, SqlDbType t, object value)
        {
            if (value != null || !(value.GetType() == typeof(string) && !string.IsNullOrEmpty(value.ToString())))
                this.Command.Parameters.Add(paramName, t).Value = value;
            else
                this.Command.Parameters.AddWithValue(paramName, DBNull.Value);

        }



        public void InitSqlParameterDBNull(string paramName, SqlDbType t)
        {
            this.Command.Parameters.Add(paramName, t);
            this.Command.Parameters[paramName].Value = DBNull.Value;
        }


        public void InitSqlParameter(string paramName, bool paramValue)
        {
            this.Command.Parameters.Add(paramName, SqlDbType.Bit).Value = paramValue;
        }

        protected void InitSqlParameter(string paramName, byte paramValue)
        {
            this.Command.Parameters.Add(paramName, SqlDbType.Bit).Value = paramValue;
        }
        protected void InitSqlParameter(string paramName, string paramValue, int size)
        {
            if (!string.IsNullOrEmpty(paramValue))
                this.Command.Parameters.Add(paramName, SqlDbType.VarChar, size).Value = paramValue;
            else
                this.Command.Parameters.Add(paramName, SqlDbType.VarChar, size).Value = DBNull.Value;
        }
        public void InitSqlParameter(string paramName,  ParameterDirection direction)
        {
            this.Command.Parameters.Add(paramName, SqlDbType.Int).Direction = direction;
        }
        protected void InitSqlParameter(string paramName, int paramValue)
        {
            this.Command.Parameters.Add(paramName, SqlDbType.Int).Value = paramValue;
        }

        protected void InitSqlParameter(string paramName, decimal paramValue)
        {
            this.Command.Parameters.Add(paramName, SqlDbType.Decimal).Value = paramValue;
        }
        protected void InitSqlParameter(string paramName, DateTime paramValue)
        {
            if (!paramValue.Equals(new DateTime()))
                this.Command.Parameters.Add(paramName, SqlDbType.DateTime).Value = paramValue;
            else
                this.Command.Parameters.Add(paramName, SqlDbType.DateTime).Value = DBNull.Value;
        }

        #endregion

        #region ������� �������������� ��������, ���������� �� ��

        /// <summary>
        /// ������� �������� � ���� ����
        /// </summary>
        /// <param name="dr">��� �� �������</param>
        /// <param name="index">������ ������� � �������</param>
        /// <returns></returns>
        public DateTime DBValueAsDateTime(DataRow dr, int index)
        {
            if (!Convert.IsDBNull(dr[index]))
                return DateTime.Parse(dr[index].ToString());
            else
                return new DateTime();
        }
        /// <summary>
        /// ������� �������� � ���� ����
        /// </summary>
        /// <param name="dr">��� �� �������</param>
        /// <param name="paramName">��� ������� � �������</param>
        /// <returns></returns>
        public DateTime DBValueAsDateTime(DataRow dr, string paramName)
        {
            if (!Convert.IsDBNull(dr[paramName]))
                return DateTime.Parse(dr[paramName].ToString());
            else
                return new DateTime();
        }
        /// <summary>
        /// ������� �������� � ���� ������
        /// </summary>
        /// <param name="dr">��� �� �������</param>
        /// <param name="paramName">��� ������� � �������</param>
        /// <returns></returns>
        public string DBValueAsString(DataRow dr, string paramName)
        {
            return (!Convert.IsDBNull(dr[paramName])) ? dr[paramName].ToString() : string.Empty;
        }

        /// <summary>
        /// ������� �������� � ���� ������
        /// </summary>
        /// <param name="dr">��� �� �������</param>
        /// <param name="paramIndex">������ ������� � �������</param>
        /// <returns></returns>
        public string DBValueAsString(DataRow dr, int paramIndex)
        {
            return (!Convert.IsDBNull(dr[paramIndex])) ? dr[paramIndex].ToString() : string.Empty;
        }

        /// <summary>
        /// ������� �������� ���������� ����
        /// </summary>
        /// <param name="dr">��� �� �������</param>
        /// <param name="paramName">��� ������� � �������</param>
        /// <returns></returns>
        public bool DBValueAsBool(DataRow dr, string paramName)
        {
            return (!Convert.IsDBNull(dr[paramName])) ? Convert.ToBoolean(dr[paramName]) : false;
        }

        /// <summary>
        /// ������� �������� ���������� ����
        /// </summary>
        /// <param name="dr">��� �� �������</param>
        /// <param name="paramIndex">������ ������� � �������</param>
        /// <returns></returns>
        public bool DBValueAsBool(DataRow dr, int paramIndex)
        {
            return (!Convert.IsDBNull(dr[paramIndex])) ? Convert.ToBoolean(dr[paramIndex]) : false;
        }

        #endregion

        #region ��������� �������


        #endregion
    }
}
