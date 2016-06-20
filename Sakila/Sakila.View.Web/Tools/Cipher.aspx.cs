using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sakila.Model;

namespace Sakila.View.Web.Tools
{
    public partial class Cipher : System.Web.UI.Page
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e) {}

        protected void btnCipher_Click(object sender, EventArgs e)
        {
            this.CipherValue();
        }

        protected void btnBackSystem_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        #endregion

        #region Methods

        private void CipherValue()
        {
            this.txtResult.Text = new Sakila.Model.Security().Encrypt(this.txtPlainText.Text);
        }

        #endregion
    }
}