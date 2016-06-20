using Sakila.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Sakila.View.Web.Handlers
{
    /// <summary>
    /// Summary description for ListActors
    /// </summary>
    public class ListActors : IHttpHandler
    {
        #region Methods

        public void ProcessRequest(HttpContext context)
        {
            this.LoadActors(context);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #region User Methods

        private void LoadActors(HttpContext context)
        {
            Sakila.Model.Actor actor = new Sakila.Model.Actor();
            actor.FirstName = (context.Request.QueryString["firstName"] != null) ? context.Request.QueryString["firstName"] : null;
            actor.LastName = (context.Request.QueryString["lastName"] != null) ? context.Request.QueryString["lastName"] : null;

            List<Sakila.Model.Actor> actors = new ActorDao().Select(actor);
            JavaScriptSerializer json = new JavaScriptSerializer();
            String result = json.Serialize(actors);

            context.Response.Write(result);
        }

        #endregion

        #endregion
    }
}