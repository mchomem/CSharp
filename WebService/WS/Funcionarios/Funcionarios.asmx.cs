using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Xml.Serialization;
using System.Data;
using System.Web.Script.Serialization;

namespace WS.Funcionarios
{
    // Tutorial em: http://www.devmedia.com.br/criando-e-consumindo-um-web-service/32368

    /// <summary>
    /// Summary description for Funcionario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Funcionarios : System.Web.Services.WebService
    {
        private String[] email = new String[2];

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public Xml ObterFuncionariosPorSexo(String sexo)
        {
            //Criando lista de funcionarios
            List<Funcionario> funcionarios = new List<Funcionario>();

            //Obtendo todos os funcionários
            DataTable dteFunc = this.DadosFuncionarios(1000);
            //Populando a lista de funcionários
            foreach (DataRow row in dteFunc.Rows)
            {
                Funcionario funcionario = new Funcionario();

                funcionario.idt_func      = row["idt_func"].ToString();
                funcionario.cpf_func      = row["cpf_func"].ToString();
                funcionario.nom_func      = row["nom_func"].ToString();
                funcionario.ci_func       = row["ci_func"].ToString();
                funcionario.email_func    = row["email_func"].ToString();
                funcionario.tel_res_func  = row["tel_res_func"].ToString();
                funcionario.tel_cel_func  = row["tel_cel_func"].ToString();
                funcionario.dat_nasc_func = row["dat_nasc_func"].ToString();
                funcionario.sexo_func     = row["sexo_func"].ToString();
                
                funcionarios.Add(funcionario);
            }

            Xml dadosXML = new Xml();

            if(!String.IsNullOrEmpty(sexo))
            {
                //Filtrando apenas funcionários do sexo escolhido
                var result = from f in funcionarios
                             where f.sexo_func.Equals(sexo.ToUpper())
                             select f;

                //Popular a Classe xml
                dadosXML = new Xml(result.ToList());
            }
            else
            {
                dadosXML = new Xml(funcionarios);
            }
            
            //Retornar o xml
            return dadosXML;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public String ObterFuncionariosPorSexoJSON(String sexo)
        {
            //Criando lista de funcionarios
            List<Funcionario> funcionarios = new List<Funcionario>();

            //Obtendo todos os funcionários
            DataTable dteFunc = this.DadosFuncionarios(1000);
            //Populando a lista de funcionários
            foreach (DataRow row in dteFunc.Rows)
            {
                Funcionario funcionario = new Funcionario();

                funcionario.idt_func      = row["idt_func"].ToString();
                funcionario.cpf_func      = row["cpf_func"].ToString();
                funcionario.nom_func      = row["nom_func"].ToString();
                funcionario.ci_func       = row["ci_func"].ToString();
                funcionario.email_func    = row["email_func"].ToString();
                funcionario.tel_res_func  = row["tel_res_func"].ToString();
                funcionario.tel_cel_func  = row["tel_cel_func"].ToString();
                funcionario.dat_nasc_func = row["dat_nasc_func"].ToString();
                funcionario.sexo_func     = row["sexo_func"].ToString();

                funcionarios.Add(funcionario);
            }
            
            if (!String.IsNullOrEmpty(sexo))
            {
                //Filtrando apenas funcionários do sexo escolhido
                var result = from f in funcionarios
                             where f.sexo_func.Equals(sexo.ToUpper())
                             select f;

                //Popular a Classe xml
                funcionarios = result.ToList();
            }

            //Criando objeto para serializar a lista de funcionários.
            JavaScriptSerializer js = new JavaScriptSerializer();

            //Retornar o JSON
            return js.Serialize(funcionarios);
        }

        //Estrutura do XML de funcionário
        public class Funcionario
        {
            [XmlElement("idt_func")]
            public string idt_func { get; set; }

            [XmlElement("cpf")]
            public string cpf_func { get; set; }

            [XmlElement("nome")]
            public string nom_func { get; set; }

            [XmlElement("rg")]
            public string ci_func { get; set; }

            [XmlElement("email")]
            public string email_func { get; set; }

            [XmlElement("tel_residencial")]
            public string tel_res_func { get; set; }

            [XmlElement("tel_celular")]
            public string tel_cel_func { get; set; }

            [XmlElement("data_nascimento")]
            public string dat_nasc_func { get; set; }

            [XmlElement("sexo")]
            public string sexo_func { get; set; }
        }

        //Classe que recebe a lista de funcionário e retorna o XML
        [XmlRoot("Xml")]
        public class Xml
        {
            public Xml() { }
            public Xml(List<Funcionario> funcionarios)
            {
                this.funcionarios = funcionarios;
            }
            public List<Funcionario> funcionarios { get; set; }
        }

        //Criando dados fictícios de funcionários
        public DataTable DadosFuncionarios(int maxRows)
        {
            DataTable dteDadosFunc = new DataTable();

            dteDadosFunc.Columns.Add("idt_func");      // ID
            dteDadosFunc.Columns.Add("cpf_func");      // CPF
            dteDadosFunc.Columns.Add("nom_func");      // NOME
            dteDadosFunc.Columns.Add("ci_func");       // RG
            dteDadosFunc.Columns.Add("email_func");    // EMAIL
            dteDadosFunc.Columns.Add("tel_res_func");  // TELEFONE RESIDENCIAL
            dteDadosFunc.Columns.Add("tel_cel_func");  // TELEFONE CELULAR
            dteDadosFunc.Columns.Add("dat_nasc_func"); // DATA NASCIMENTO
            dteDadosFunc.Columns.Add("sexo_func");     // SEXO

            Random rand = new Random();

            for (int i = 0; i < maxRows; i++ )
            {
                String sexo = this.GetRandomSex(rand);
                String ddd  = this.GetRandomDDD(rand);

                dteDadosFunc.Rows.Add
                    (
                        (i + 1).ToString()
                        , this.GetRandomEspecificId(rand)
                        , this.GetRandomName(rand, sexo)
                        , this.GetRandomId(rand)
                        , this.GetEmail()
                        , this.GetRandomPhone(rand, "res", ddd)
                        , this.GetRandomPhone(rand, "cel", ddd)
                        , this.GetRandomBirthday(rand)
                        , sexo
                    );
            }

            return dteDadosFunc;
        }

        private String GetRandomBirthday(Random rand)
        {
            String year, month, day;
            year = month = day = String.Empty;

            year  = rand.Next((DateTime.Now.Year - 50), (DateTime.Now.Year - 20)).ToString();
            month = rand.Next(1, 12).ToString();
            day   = (month.Equals("2")) ? rand.Next(1, 28).ToString() : rand.Next(1, 30).ToString();

            // 2 = 28
            // 4, 6, 9, 11 = 30
            // 1 ,3 ,5, 7, 8, 10, 12 = 31

            if (month.Equals("2"))
            {
                /* Desprezado o cálculo para ano bissexto, visto que nos cartórios
                 * as pessoas dificilmente registram os filhos no dia 29 de fevereiro
                 */
                day = rand.Next(1, 28).ToString();
            }
            else if (month.Equals("4") || month.Equals("6") || month.Equals("9") || month.Equals("11"))
            {
                day = rand.Next(1, 30).ToString();
            }
            else
            {
                day = rand.Next(1, 31).ToString();
            }

            return (day.PadLeft(2, '0') + "/" + month.PadLeft(2, '0') + "/" + year);
        }

        private String GetEmail()
        {
            String e = String.Empty;

            e += email[0] + "." + email[1] + "@empresa.com.br";

            return e;
        }

        private String GetRandomPhone(Random rand, String type, String ddd)
        {
            String phone = (type.Equals("res") ? "3" : "9");

            for (int i = 0; i < 7; i++)
            {
                if (phone.Length == 4)
                {
                    phone += "-";
                }

                phone += rand.Next(9).ToString();
            }

            return ddd + " " + phone;
        }

        private String GetRandomDDD(Random rand)
        {
            int[] ddd = new int[] { 11, 12, 13, 14, 15, 16, 17, 18, 19, 21, 22, 24, 27, 28, 31, 32, 33, 34, 35, 37, 38, 41, 42, 43, 44, 45, 46, 47, 48, 49, 51, 53, 54, 55, 61, 62, 63, 64, 65, 66, 67, 68, 69, 71, 73, 74, 75, 77, 79, 81, 82, 83, 84, 85, 86, 87, 88, 89, 91, 92, 93, 94, 95, 96, 97, 98, 99 };
            int n = rand.Next(67);

            return "(" + ddd[n] + ")";

        }

        private String GetRandomId(Random rand)
        {
            String id = String.Empty;

            for (int i = 0; i < 10; i++)
            {
                id += rand.Next(9).ToString();
            }

            return id;
        }

        private String GetRandomEspecificId(Random rand)
        {
            String idEspec = String.Empty;

            for (int i = 0; i < 11; i++)
            {
                idEspec += (idEspec.Length == 3 || idEspec.Length == 7) ? "." : String.Empty;
                idEspec += (idEspec.Length == 11) ? "-" : String.Empty;
                idEspec += rand.Next(9).ToString();
            }

            return idEspec;
        }

        private String GetRandomSex(Random rand)
        {
            int n        = (rand.Next(0, 10) % 2);
            String[] sex = new String[] { "M", "F" };

            return sex[n];
        }

        private String GetRandomName(Random rand, String sexo)
        {
            int n = rand.Next(30);
            String[] names = new String[] {};

            if (sexo.Equals("M"))
            {
                names = new String[]
                {
                    "Andre"
                    , "Alam"
                    , "Arthur"
                    , "Bob"
                    , "Bartolomeu"
                    , "Barnei"
                    , "Carlos"
                    , "Cleiton"
                    , "Cidinei"
                    , "Daniel"
                    , "Darley"
                    , "Danri"
                    , "Eduardo"
                    , "Estevam"
                    , "Euclides"
                    , "Fabio"
                    , "Felipe"
                    , "Fernando"
                    , "Gabriel"
                    , "Getúlio"
                    , "Gaio"
                    , "Henrique"
                    , "Heron"
                    , "Hermes"
                    , "Idevaldo"
                    , "Ivam"
                    , "Ildo"
                    , "Jonas"
                    , "João"
                    , "Jonatas"
                };
            }
            else
            {
                names = new String[]
                {
                    "Andreia"
                    , "Alana"
                    , "Andriana"
                    , "Beatriz"
                    , "Bibiana"
                    , "Bartira"
                    , "Carla"
                    , "Cleidir"
                    , "Cristina"
                    , "Daniela"
                    , "Daiana"
                    , "Daiane"
                    , "Eduarda"
                    , "Estefani"
                    , "Euvira"
                    , "Fabiana"
                    , "Fátima"
                    , "Fernanda"
                    , "Gabriela"
                    , "Gisele"
                    , "Gina"
                    , "Hines"
                    , "Hilda"
                    , "Helem"
                    , "Ivone"
                    , "Iris"
                    , "Isabel"
                    , "Joana"
                    , "Jade"
                    , "Jerusa"
                };
            }

            email[0] = names[n].ToLower();

            return names[n] + " " + this.GetRandomSecondName(rand) + " " + this.GetRandomThridName(rand);
        }

        private String GetRandomSecondName(Random rand)
        {
            int n          = rand.Next(30);
            String[] sName =
                new String[]
                {
                    "Antunes"
                    , "Antônio"
                    , "Alaor"
                    , "Barbosa"
                    , "Bordin"
                    , "Baltazar"
                    , "Carvalho"
                    , "Castro"
                    , "Cavalcanti"
                    , "Dantes"
                    , "Demétrio"
                    , "Dalto"
                    , "Escobar"
                    , "Escrivão"
                    , "Esdras"
                    , "Fantim"
                    , "Ferreira"
                    , "Fail"
                    , "Gantt"
                    , "Genésio"
                    , "Ganis"
                    , "Hilton"
                    , "Hies"
                    , "Holarin"
                    , "Ildo"
                    , "Idânio"
                    , "Icaro"
                    , "James"
                    , "Jain"
                    , "Jonvênio"
                };

            email[1] = sName[n].ToLower();

            return sName[n];
        }

        private String GetRandomThridName(Random rand)
        {
            int n          = rand.Next(30);
            String[] tName =
                new String[]
                {
                    "de Amaral"
                    , "Albuquerque"
                    , "Ariano"
                    , "de Barros"
                    , "Brasil"
                    , "Bitencourt"
                    , "de Cabral"
                    , "Costa"
                    , "Coimbra"
                    , "de Damasco"
                    , "Dominique"
                    , "Daltom"
                    , "da Esbornia"
                    , "Eriel"
                    , "Elton"
                    , "da Fonseca"
                    , "Freitas"
                    , "Farias"
                    , "Gentil"
                    , "Galante"
                    , "Garibaldo"
                    , "Hilbron"
                    , "Hilson"
                    , "Hackmann"
                    , "de Islovenia"
                    , "Island"
                    , "Iruano"
                    , "Joaquim"
                    , "Jarbas"
                    , "Jairo"
                };

            return tName[n];
        }
    }
}