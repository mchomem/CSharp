using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using Sakila.Model;

namespace Sakila.Model.Dao.Generic
{
    public class GenericDao
    {
        #region Fields

        private String connectionString = ConfigurationManager.ConnectionStrings["Sakila"].ConnectionString;

        #endregion

        #region Constructors

        public GenericDao() { }

        #endregion

        #region Methods

        public MySqlConnection Open()
        {
            MySqlConnection conn = new MySqlConnection();

            try
            {
                conn.ConnectionString = new Sakila.Model.Security().Decrypt(connectionString);
                conn.Open();
            }
            catch(Exception e)
            {
                throw e;
            }

            return conn;
        }

        public void Close(MySqlConnection conn, MySqlCommand command, MySqlDataReader dataReader)
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                    conn = null;
                }

                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }

                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader = null;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
