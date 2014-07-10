using System;
using System.Collections;
using System.Drawing.Design;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.ComponentModel.Design;

using ComponentModel_TypeConverter = System.ComponentModel.TypeConverter;

namespace RCO.PopUpButtons
{
    

    public delegate void AfterChildCloseHandler(object sender, PopUpItems e);
    /// <summary>
    /// PopUp  кнопка 
    /// </summary>
    [ToolboxData("<{0}:PopUpButton runat=server></{0}:PopUpButton>")]
    [Description("Контрол для версии ASP.NET 2.0")]
    //[ParseChildren(true), PersistChildren(false)]		
    public class PopUpButton : System.Web.UI.WebControls.Button,
      IPostBackEventHandler
    {

        string _url;
        string _windowTitle;
        bool _postBack, _isScrollTo, _isClientConfirm, _isResizable;

        paramsCollection _params;
        Unit _windowWidth, _windowHeight;
        string _confirmText;
        string _src;
        PopUpButtonStyle _controlShowType;
        private bool _isDialog;


        const string csJavaScriptFile = "RCO.PopUpButtons.WebControls.js";
        public bool _isShowStatusBar;

        public const string qControlID = "controlID";


        private bool _isShowAddressBar;

        private string _lastClientID;


        /// <remarks>Включать отображение скроллера</remarks>
        private bool _isScrollBar;


        /// <summary>
        /// сохраняет предыдущее значение  при databind контейнера , содержащего кнопку
        /// </summary>
        [Description("сохраняет предыдущее значение  при databind контейнера , содержащего кнопку")]
        [Browsable(false)]
        [Bindable(false)]
        private string lastClientID
        {
            get { return _lastClientID; }
            set { _lastClientID = value; }
        }

        
        /// <summary>
        /// Указывает стиль окна true - окно изменяет размеры
        /// </summary>
        [Description("Указывает стиль окна true - окно изменяет размеры")]
        [DefaultValue(false)]
        public bool IsResizable
        {
            get { return _isResizable; }
            set { _isResizable = value; }
        }

        /// <summary>
        /// Включает и выключает строку адреса в дочернем окне в режиме IsDialog=false
        /// </summary>
        [Description("Включает и выключает строку адреса в дочернем окне в режиме IsDialog=false")]
        [DefaultValue(true)]
        public bool isShowAddressBar
        {
            get { return _isShowAddressBar; }
            set { _isShowAddressBar = value; }
        }


        /// <summary>
        /// Включает и выключает строку статуса в дочернем окне
        /// </summary>
        [Description("Включает и выключает строку статуса в дочернем окне")]
        [DefaultValue(true)]
        public bool isShowStatusBar
        {
            get { return _isShowStatusBar; }
            set { _isShowStatusBar = value; }
        }

        public event AfterChildCloseHandler AfterChildClose;

        public PopUpButton()
            : base()
        {
            _url = "";
            _windowTitle = "";

            Text = "";
            _postBack = false;
            _params = new paramsCollection();
            _windowWidth = new Unit();
            _windowHeight = new Unit();

            _windowWidth = Unit.Pixel(300);
            _windowHeight = Unit.Pixel(200);
            _isScrollTo = false;
            _isClientConfirm = false;
            _confirmText = " ";

            _controlShowType = PopUpButtonStyle.Button;
            _src = "";
            _isDialog = true;
            _isShowStatusBar = true;
            _isShowAddressBar = true;
            _isScrollBar = true;
            _isResizable = false;

        }


        #region Свойства

        /// <summary>
        /// Определяет тип открываемого окна web-диалог или popup окно
        /// </summary>
        [Description("Определяет тип открываемого окна web-диалог или popup окно")]
        [DefaultValue(true)]
        public bool IsDialog
        {
            get { return _isDialog; }
            set { _isDialog = value; }
        }


        /// <summary>
        /// Стиль отображения компоненты 
        /// </summary>
        [Browsable(true), Bindable(false),
        Description("Стиль отображения компоненты ")]
        [DefaultValue(PopUpButtonStyle.Button)]
        [NotifyParentProperty(true)]
        [Category("Control style")]
        public PopUpButtonStyle ControlShowType
        {
            get { return _controlShowType; }
            set { _controlShowType = value; }
        }

        /// <summary>
        /// Источник для картинки при графическом стиле отображения 
        /// </summary>
        [Browsable(true), Bindable(true),
        Description("Источник для картинки при графическом стиле отображения")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Category("Control style")]
        [EditorAttribute(typeof(System.Web.UI.Design.UrlEditor), typeof(UITypeEditor))]
        public string Src
        {
            get { return GetSitePathBaseUrl(_src); }
            set { _src = value; }
        }

        /// <summary>
        /// Разрешить подтверждение нажатия кнопки на клиенте
        /// </summary>
        [Browsable(true), Bindable(false),
        Description("Разрешить подтверждение нажатия кнопки на клиенте")]
        [DefaultValue(" ")]
        [NotifyParentProperty(true)]
        [Category("Confirms action ")]
        public string confirmText
        {
            get { return _confirmText; }
            set { _confirmText = value; }
        }


        /// <summary>
        /// Разрешить подтверждение нажатия кнопки на клиенте
        /// </summary>
        [Browsable(true), Bindable(false),
        Description("Разрешить подтверждение нажатия кнопки на клиенте")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Category("Confirms action ")]
        public bool isClientConfirm
        {
            get { return _isClientConfirm; }
            set { _isClientConfirm = value; }
        }

        /// <summary>
        /// Прокручивать окно до кнопки
        /// </summary>
        [Browsable(true), Bindable(false),
        Description("Прокручивать окно до кнопки")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        public bool isScrollTo
        {
            get { return _isScrollTo; }
            set { _isScrollTo = value; }
        }

        /// <summary>
        /// Ширина popup окна
        /// </summary>
        [Browsable(true), Bindable(false),
        Description("Ширина popup окна")]
        [DefaultValue(typeof(Unit), "300px")]
        [NotifyParentProperty(true)]
        public Unit windowWidth
        {
            get { return _windowWidth; }
            set { _windowWidth = value; }
        }

        [Browsable(true), Bindable(false),
        Description("Высота popup окна")]
        [DefaultValue(typeof(Unit), "200px")]
        [NotifyParentProperty(true)]
        public Unit windowHeight
        {
            get { return _windowHeight; }
            set { _windowHeight = value; }
        }


        [Browsable(true), Bindable(false),
        Description("Параметры  для передачи на сервер"),
        NotifyParentProperty(true),
        PersistenceMode(PersistenceMode.InnerProperty),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        TypeConverter(typeof(System.ComponentModel.CollectionConverter)),
        Editor(typeof(RCO.PopUpButtons.Design.ParamsCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))
        ]
        public paramsCollection PostParams
        {
            get { return _params; }
        }



        [EditorAttribute(typeof(System.Web.UI.Design.UrlEditor), typeof(UITypeEditor))]
        [Description("Адрес popup страницы ")]
        [DefaultValue("")]
        public string Url
        {
            get
            {
                return GetSitePathBaseUrl(_url);
            }
            set { _url = value; }
        }

        private string GetSitePathBaseUrl(string tUrl)
        {
            if (!this.DesignMode)
            {
                if (string.IsNullOrEmpty(tUrl))
                    return tUrl;
                if (!tUrl.StartsWith("~/"))
                    return tUrl;
                else
                    return ((this.Context.Request.ApplicationPath != "/") ? this.Context.Request.ApplicationPath : "") + tUrl.Substring(1);
            }
            else
                return tUrl;
        }


        /// <summary>
        /// Вызывать постбек на странице
        /// </summary>
        [DefaultValue(false)]
        [Browsable(true)]
        [Description("Вызывать постбек на странице")]
        public bool PostBack
        {
            get { return _postBack; }
            set { _postBack = value; }
        }


        /// <summary>
        /// заголовок Popup окна
        /// </summary>
        public string windowTitle
        {
            get
            {
                return _windowTitle;
            }
            set
            {
                _windowTitle = value;
            }
        }

        /// <summary>
        /// ширина контрола
        /// </summary>
        [DefaultValue(typeof(Unit), "100")]
        public override Unit Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value;
            }
        }

        /// <summary>
        /// высота контрола
        /// </summary>
        [DefaultValue(typeof(Unit), "100")]
        public override Unit Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;
            }
        }

        /// <summary>
        /// Клиентский скрипт, вызывающий pop up окно 
        /// </summary>
        [DefaultValue("")]
        [Description("Клиентский скрипт, вызывающий pop up окно ")]
        [Browsable(false)]
        public string ClientPopUpClick
        {
            get { return GetClickJS(); }
        }

        /// <summary>
        /// Включать отображение скроллера
        /// </summary>
        [DefaultValue(true)]
        [Description("Включать отображение скроллера")]
        [Browsable(true)]
        public bool IsScrollBar
        {
            get { return _isScrollBar; }
            set { _isScrollBar = value; }
        }

        #endregion


        #region Перекрытие методы

        protected override void RaisePostBackEvent(string eventArgument)
        {

            OnAfterChildClose(eventArgument);

            if (isScrollTo)
                if (!this.Page.ClientScript.IsStartupScriptRegistered(this.GetType(), "scroll" + this.ClientID))
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "scroll" + this.ClientID, "var obj=document.getElementById('" + this.lastClientID + "'); " +
                      "  if (obj!=null) obj.scrollIntoView(true);", true);
                    this.Page.SetFocus(this.lastClientID);
                }


        }


        protected virtual void OnAfterChildClose(string keyValue)
        {
            char separetedChar = '&', separetedPair = '=';
            if (AfterChildClose != null)
            {
                PopUpItems e = new PopUpItems();
                if (keyValue != null && keyValue.Length > 0)
                {

                    string[] pairs = new string[2];
                    int lastPair = -1, countChars = keyValue.Length;
                    string ts = null;
                    for (int i = 0; i < countChars; i++)
                    {
                        lastPair = keyValue.IndexOf(separetedChar, i);
                        if (lastPair > 0)
                        {// найдено 2 и больше  пар
                            ts = keyValue.Substring(i, lastPair - i);
                            pairs = ts.Split(separetedPair);
                            if (pairs[1] != "reload")
                                e.Items.Add(pairs[0], pairs[1]);
                            i += ts.Length;
                        }
                        else
                        {// одна пара или меньше
                            ts = keyValue.Substring(i, countChars - i);
                            pairs = ts.Split(separetedPair);
                            if (pairs[1] != "reload")
                                e.Items.Add(pairs[0], pairs[1]);
                            i = countChars - 1;
                        }
                    }
                }
                AfterChildClose(this, e);
            }
        }


        protected override void Render(HtmlTextWriter writer)
        {

            switch (this.ControlShowType)
            {
                case PopUpButtonStyle.Button:

                    if (this.CssClass != "")
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass);

                    if (!base.Enabled)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "true");
                        writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "javascript:return false;");
                    }
                    else
                        writer.AddAttribute(HtmlTextWriterAttribute.Onclick, this.Attributes["onclick"]);

                    writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
                    writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);
                    writer.AddAttribute(HtmlTextWriterAttribute.Type, "button");
                    writer.AddAttribute(HtmlTextWriterAttribute.Value, this.Text);

                    if (this.Width.Value > 0)
                        writer.AddStyleAttribute(HtmlTextWriterStyle.Width, this.Width.ToString());

                    if (this.Height.Value > 0)
                        writer.AddStyleAttribute(HtmlTextWriterStyle.Height, this.Height.ToString());

                    if (this.ToolTip.Length > 0)
                        writer.AddAttribute(HtmlTextWriterAttribute.Title, this.ToolTip);

                    writer.RenderBeginTag(HtmlTextWriterTag.Input);

                    writer.RenderEndTag();


                    break;
                case PopUpButtonStyle.HyperLink:

                    if (this.CssClass != "")
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass);


                    if (!base.Enabled)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "true");
                    }
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, "#");
                    writer.AddAttribute(HtmlTextWriterAttribute.Onclick, this.Attributes["onclick"] + "; return false;");



                    writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
                    writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);

                    if (this.ToolTip.Length > 0)
                        writer.AddAttribute(HtmlTextWriterAttribute.Title, this.ToolTip);

                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write(this.Text);
                    writer.RenderEndTag();
                    break;
                case PopUpButtonStyle.ImageButton:
                    writer.AddAttribute(HtmlTextWriterAttribute.Type, "Image");
                    writer.AddAttribute(HtmlTextWriterAttribute.Alt, this.Text);
                    writer.AddAttribute(HtmlTextWriterAttribute.Src, this.Src);


                    if (this.CssClass != "")
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass);

                    if (base.Enabled)
                        writer.AddAttribute(HtmlTextWriterAttribute.Onclick, this.Attributes["onclick"] + " return false;");
                    else
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "true");
                        writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "javascript:return false;");
                    }



                    writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
                    writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);

                    if (this.ToolTip.Length > 0)
                        writer.AddAttribute(HtmlTextWriterAttribute.Title, this.ToolTip);


                    writer.RenderBeginTag(HtmlTextWriterTag.Input);

                    writer.RenderEndTag();
                    break;

            }


        }


        private string GetFeatures()
        {
            return "'scrollbars="+ Convert.ToInt32(IsScrollBar)+",height=" + windowHeight.ToString() + ",width=" + windowWidth.ToString()
                   + GetStatusBarString()
                   + ((this.isShowAddressBar) ? ",location=1" : ",location=0")
                   + ","
                   + "resizable="+ Convert.ToByte(IsResizable)
                   + "'";
        }

        private string GetStatusBarString()
        {
            return (this.isShowStatusBar) ? ",status=1" : ",status=0;";
        }

        private string GetReloadControlId()
        {
            return (this.PostBack) ? this.UniqueID : "";
        }





        protected override void OnPreRender(EventArgs e)
        {

            base.OnPreRender(e);

            lastClientID = ClientID;
            this.Attributes["onclick"] = GetClickJS();

            Type t = this.GetType();
            string url = Page.ClientScript.GetWebResourceUrl(t, csJavaScriptFile);
            if (!Page.ClientScript.IsClientScriptIncludeRegistered(t, csJavaScriptFile))
                Page.ClientScript.RegisterClientScriptInclude(t, csJavaScriptFile, url);

            this.Page.ClientScript.GetPostBackEventReference(this, "");

        }

        private string GetClickJS()
        {
            string sPost = "";
            if (this.PostBack)
                sPost = "&result=reload";
            string paramsToPop = "";
            if (this.PostParams.Count > 0)
            {
                foreach (paramItem pi in this.PostParams)
                    paramsToPop += "&" + pi.Key + "=" + pi.KeyValue;
            }

            string clickJS = "";

            if (this.IsDialog)
                clickJS = "javascript:openFRSDChildDialog('" + this.Url + "?modal=1" + sPost + paramsToPop + "','" + windowTitle + "','" + windowWidth.Value + "','" + windowHeight.Value + "','" + this.UniqueID + "'," + this.isClientConfirm.ToString().ToLower() + ",'" + this.confirmText + "', " + Convert.ToByte(isShowStatusBar) + "," + Convert.ToByte(IsScrollBar) + "," + Convert.ToByte(IsResizable) + ");";
            else
            {
                clickJS = "javascript:openPopUp('" + this.Url + "?modal=0" + paramsToPop + "'," + GetFeatures() + ", " + this.isClientConfirm.ToString().ToLower() + ",'" + this.confirmText + "','" +
                          GetReloadControlId() + "' );";
            }

            return clickJS;
        }


        protected override object SaveViewState()
        {
            object[] obj = new object[14];
            obj[0] = base.SaveViewState();
            obj[1] = this.windowWidth;
            obj[2] = this.windowHeight;
            obj[3] = this.isScrollTo;
            obj[4] = this.isClientConfirm;
            obj[5] = this.confirmText;
            obj[6] = this.ControlShowType;
            obj[7] = this.Src;
            obj[8] = this.PostParams;
            obj[9] = this.IsDialog;
            obj[10] = this.isShowStatusBar;
            obj[11] = this.isShowAddressBar;
            obj[12] = this.lastClientID;
            obj[13] = this.IsScrollBar;

            return obj;
        }
        protected override void LoadViewState(object savedState)
        {
            if (savedState != null)
            {
                // Load State from the array of objects that was saved at ;
                // SavedViewState.
                object[] myState = (object[])savedState;
                if (myState[0] != null)
                    base.LoadViewState(myState[0]);

                if (myState[1] != null)
                    this.windowWidth = (Unit)myState[1];
                if (myState[2] != null)
                    this.windowHeight = (Unit)myState[2];
                if (myState[3] != null)
                    this.isScrollTo = (bool)myState[3];
                if (myState[4] != null)
                    this.isClientConfirm = (bool)myState[4];
                if (myState[5] != null)
                    this.confirmText = (string)myState[5];
                if (myState[6] != null)
                    this.ControlShowType = (PopUpButtonStyle)myState[6];

                if (myState[7] != null)
                    this.Src = (string)myState[7];

                if (myState[8] != null)
                {
                    paramsCollection p = (paramsCollection)myState[8];
                    if (this.PostParams.Count != 0) this.PostParams.Clear();
                    foreach (paramItem pi in p)
                        this.PostParams.Add(pi);
                }
                if (myState[9] != null)
                    this.IsDialog = (bool)myState[9];

                if (myState[10] != null)
                    this.isShowStatusBar = (bool)myState[10];

                if (myState[11] != null)
                    this.isShowAddressBar = (bool)myState[11];

                if (myState[12] != null)
                    this.lastClientID = (string)myState[12];

                if (myState[13] != null)
                    this.IsScrollBar = (bool)myState[13];
            }

        }


        #endregion





    }

    /// <summary>
    /// Коллекция ID элементов на странице
    /// </summary>
    public class IDS : CollectionBase
    {
        #region IDS body


        public virtual int Add(ID value)
        {
            if (value.Equals(null))
                throw new ArgumentException("item");
            else
                return base.List.Add(value);
        }

        public void insert(int index, ID param)
        {
            this.List.Insert(index, param);
        }

        public int indexOf(ID param)
        {
            return this.List.IndexOf(param);
        }

        public bool Contains(ID param)
        {
            return this.List.Contains(param);
        }

        public void Remove(ID param)
        {
            this.List.Remove(param);
        }

        public void CopyTo(ID[] items, int index)
        {
            this.List.CopyTo(items, index);
        }

        public ID this[int index]
        {
            get { return (ID)base.List[index]; }
            set { base.List[index] = value; }
        }


        protected override void OnInsert(int index, object value)
        {
            if (!(value is ID))
                throw new ArgumentException("Invalid type");
            else
                base.OnInsert(index, value);
        }

        protected override void OnSet(int index, object oldValue, object newValue)
        {
            if (!(newValue is ID))
                throw new ArgumentException("Invalid type");
            else
                base.OnSet(index, oldValue, newValue);
        }

        protected override void OnValidate(object value)
        {
            if (!(value is ID))
                throw new ArgumentException("Invalid type");
            else
                base.OnValidate(value);
        }

        public void AddRange(ID[] ci)
        {
            this.InnerList.AddRange(ci);
        }

        public ID[] GetValues()
        {
            //It is used by the ComplexItemConverter
            ID[] ci = new ID[this.InnerList.Count];
            this.InnerList.CopyTo(0, ci, 0, this.InnerList.Count);
            return ci;
        }
        #endregion
    }

    /// <summary>
    /// Стиль отображения popup  кнопки
    /// </summary>
    public enum PopUpButtonStyle
    {
        Button = 0,
        HyperLink = 1,
        ImageButton = 2
    }


    [ControlBuilder(typeof(ControlBuilder)),
    TypeConverter(typeof(ExpandableObjectConverter))]
    [DefaultProperty("Text")]
    public class ID
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public ID()
        {
        }
        public override string ToString()
        {
            return "id=" + Text;
        }

    }
}

