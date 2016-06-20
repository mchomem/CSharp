using Sakila.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakila.View.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {}

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Sakila.Model.User user = new Sakila.Model.User();
            user.Login             = this.txtUser.Text;
            user.Password          = this.txtPassword.Text;

            if (new UserDao().CheckLogin(user) != null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                // TODO modal não executa.
                this.ShowMessageDialog("Aviso", "Não foi possível efetuar o login no sistema.");
            }
        }

        private void ShowMessageDialog(String title, String message)
        {
            mMessageDialog.Title   = title;
            mMessageDialog.Message = message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "modalMessage", "$('[id*=messageDialog]').modal();", true);
        }
    }
}