using Sakila.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sakila.View.Web
{
    public partial class Actor : System.Web.UI.Page
    {
        #region Properties

        public Sakila.Model.Actor FilterActor
        {
            get
            {
                if (ViewState["Actor"] == null)
                {
                    Sakila.Model.Actor actor = new Sakila.Model.Actor();
                    ViewState["Actor"] = actor;
                }

                return (Sakila.Model.Actor)ViewState["Actor"];
            }
            set
            {
                ViewState["Actor"] = value;
            }
        }

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadActors(FilterActor);
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            FilterActor.FirstName = this.txtFirstName.Text;
            FilterActor.LastName  = this.txtLastName.Text;

            this.LoadActors(FilterActor);
        }

        protected void gvActor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.LoadActors(FilterActor);
            this.gvActor.PageIndex = e.NewPageIndex;
            this.gvActor.DataBind();
        }

        protected void gvActor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "UP":

                        mActorEdit.Actor = new Sakila.Model.Actor() { ActorId = Convert.ToInt32(e.CommandArgument) };
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "modal", "$('[id*=actorEdit]').modal();", true);

                        break;

                    case "DEL":

                        ShowConfirmDialog("Aviso", "Deseja excluir o registro?");

                        if (mConfirmDialog.OperationReturn)
                        {
                            new ActorDao()
                                .Delete(
                                    new ActorDao()
                                        .Select(new Sakila.Model.Actor() { ActorId = Convert.ToInt32(e.CommandArgument) })
                                            .FirstOrDefault()
                                        );
                        }
                        
                        this.txtFirstName.Text  = String.Empty;
                        this.txtLastName.Text   = String.Empty;

                        this.gvActor.DataSource = null;
                        this.gvActor.DataBind();
                        
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Page.ErrorPage = ex.Message;
                ShowMessageDialog("Erro", "Falha");
            }
        }

        protected void gvActor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Sakila.Model.Actor actor = (Sakila.Model.Actor)e.Row.DataItem;

                    ((Literal)e.Row.FindControl("litActorId")).Text    = actor.ActorId.ToString();
                    ((Literal)e.Row.FindControl("litFirstName")).Text  = actor.FirstName;
                    ((Literal)e.Row.FindControl("litLastName")).Text   = actor.LastName;
                    ((Literal)e.Row.FindControl("litLastUpdate")).Text = actor.LastUpdate.ToString();
                }
            }
            catch (Exception ex)
            {
                Page.ErrorPage = ex.Message;
            }
        }

        #endregion

        #region Methods

        private void LoadActors(Sakila.Model.Actor actor)
        {
            this.gvActor.DataSource = new ActorDao().Select(actor);
            this.gvActor.DataBind();

            if (this.gvActor.Rows.Count == 0)
            {
                ShowMessageDialog("Aviso", "Não foram encontrados dados para a pesquisa solicitada.");
            }
        }

        private void ShowMessageDialog(String title, String message)
        {
            mMessageDialog.Title   = title;
            mMessageDialog.Message = message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "modalMessage", "$('[id*=messageDialog]').modal();", true);
        }

        private void ShowConfirmDialog(String title, String message)
        {
            mConfirmDialog.Title   = title;
            mConfirmDialog.Message = message;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "modalConfirm", "$('[id*=confirmDialog]').modal();", true);
        }

        #endregion
    }
}