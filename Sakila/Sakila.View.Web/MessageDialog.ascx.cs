using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakila.View.Web
{
    public partial class MessageDialog : System.Web.UI.UserControl
    {
        #region Properties

        public String Title
        {
            get
            {
                if (ViewState["Title"] == null)
                {
                    ViewState["Title"] = String.Empty;
                }
                return (String)ViewState["Title"];
            }
            set
            {
                ViewState["Title"] = value;
            }
        }

        public String Message
        {
            get
            {
                if (ViewState["Message"] == null)
                {
                    ViewState["Message"] = String.Empty;
                }
                return (String)ViewState["Message"];
            }
            set
            {
                ViewState["Message"] = value;
            }
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e) {}

        protected void messageDialog_PreRender(object sender, EventArgs e)
        {
            this.lblTitleDialog.Text = Title;
            this.lblMessage.Text     = Message;
        }

        #endregion
    }
}