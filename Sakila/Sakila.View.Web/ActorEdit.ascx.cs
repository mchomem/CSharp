using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sakila.Model.Dao;

namespace Sakila.View.Web
{
    public partial class ActorEdit : System.Web.UI.UserControl
    {
        public Sakila.Model.Actor Actor
        {
            get
            {
                if (ViewState["Actor"] == null)
                {
                    Sakila.Model.Actor actor = new Sakila.Model.Actor();
                    ViewState["Actor"]       = actor;
                }
                return (Sakila.Model.Actor)ViewState["Actor"];
            }
            set
            {
                ViewState["Actor"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {}

        protected void actorEdit_PreRender(object sender, EventArgs e)
        {
            if (Actor != null)
                this.LoadActor(Actor);
        }

        private void LoadActor(Sakila.Model.Actor actor)
        {
            Sakila.Model.Actor chooseActor = new ActorDao().Select(actor).FirstOrDefault();
            this.txtEditFirstName.Text     = chooseActor.FirstName;
            this.txtEditLastName.Text      = chooseActor.LastName;
            this.txtLastUpdate.Text        = chooseActor.LastUpdate.ToString("dd/MM/yyyy HH:mm:ss");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Sakila.Model.Actor actor   = new Sakila.Model.Actor();
            this.txtEditFirstName.Text = actor.FirstName;
            this.txtEditLastName.Text  = actor.LastName;

            new Sakila.Model.Dao.ActorDao().Update(actor);
        }
    }
}