using Sakila.Model;
using Sakila.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakila.Tests
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {}

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            this.LoadActors();
        }

        protected void btnQueryGenericHandler_Click(object sender, EventArgs e)
        {
            String queryString = "?firstName=" + this.txtFirstName.Text + "&lastName=" + this.txtLastName.Text;
            String server      = HttpContext.Current.Request.Url.Host;
            String port        = HttpContext.Current.Request.Url.Port.ToString();
            String url         = "http://" + server + ":" + port + "/" + "ListActors.ashx" + queryString;

            Response.Redirect(url);
        }

        private void LoadActors()
        {
            Actor actor     = new Actor();
            actor.FirstName = (!String.IsNullOrEmpty(this.txtFirstName.Text) ? this.txtFirstName.Text : null);
            actor.LastName  = (!String.IsNullOrEmpty(this.txtLastName.Text)  ? this.txtLastName.Text  : null);

            List<Actor> actors        = new ActorDao().Select(actor);
            JavaScriptSerializer json = new JavaScriptSerializer();
            String result             = json.Serialize(actors);

            this.grid.InnerHtml = result;
        }
    }
}