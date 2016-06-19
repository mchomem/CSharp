using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FuncionarioApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {}

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            //Instanciando o nosso web service
            ServiceReference1.FuncionariosSoapClient ws = new ServiceReference1.FuncionariosSoapClient();

            //Chamando o método ObterFuncionariosPorSexo do nosso web service passando o sexo como parâmetro
            ServiceReference1.Xml obj = ws.ObterFuncionariosPorSexo(ddlSexo.SelectedValue);

            //Criando DataTable que conterá a informação dos funcionários
            DataTable dteFunc = new DataTable();
            dteFunc.Columns.Add("idt_func");
            dteFunc.Columns.Add("cpf_func");
            dteFunc.Columns.Add("nom_func");
            dteFunc.Columns.Add("ci_func");
            dteFunc.Columns.Add("email_func");
            dteFunc.Columns.Add("tel_res_func");
            dteFunc.Columns.Add("tel_cel_func");
            dteFunc.Columns.Add("dat_nasc_func");
            dteFunc.Columns.Add("sexo_func");

            //Percorrendo o objeto retornado pelo nosso web service e adicionando ao DataTable
            for (int i = 0; i < obj.funcionarios.Length; i++)
            {
                dteFunc.Rows.Add(
                    obj.funcionarios[i].idt_func,
                    obj.funcionarios[i].cpf,
                    obj.funcionarios[i].nome,
                    obj.funcionarios[i].rg,
                    obj.funcionarios[i].email,
                    obj.funcionarios[i].tel_residencial,
                    obj.funcionarios[i].tel_celular,
                    obj.funcionarios[i].data_nascimento,
                    obj.funcionarios[i].sexo
                    );
            }

            //Vinculando o DataTable ja preenchido ao GridView
            gvwFuncionarios.DataSource = dteFunc;
            gvwFuncionarios.DataBind();
        }
    }
}