using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sakila.Model;
using Sakila.Model.Dao.Interface;
using Sakila.Model.Dao.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace Sakila.Model.Dao
{
    public class UserDao : IDao<User>
    {
        #region Fields

        private GenericDao dao;

        #endregion

        #region Constructor

        public UserDao()
        {
            this.dao = new GenericDao();
        }

        #endregion

        #region Methods

        public void Insert(User user)
        {
            try
            {
                MySqlConnection conn = this.dao.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandType  = CommandType.StoredProcedure;
                command.CommandText  = "PROC_USER_INSERT";
                command.Parameters.Add(new MySqlParameter("@P_LOGIN", user.Login));
                command.Parameters.Add(new MySqlParameter("@P_PASSWORD", user.Password));
                command.ExecuteNonQuery();

                this.dao.Close(conn, command, null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(User user)
        {
            try
            {
                MySqlConnection conn = this.dao.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandType  = CommandType.StoredProcedure;
                command.CommandText  = "PROC_USER_UPDATE";
                command.Parameters.Add(new MySqlParameter("@P_ID", user.Id));
                command.Parameters.Add(new MySqlParameter("@P_LOGIN", user.Login));
                command.Parameters.Add(new MySqlParameter("@P_PASSWORD", user.Password));
                command.ExecuteNonQuery();

                this.dao.Close(conn, command, null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(User user)
        {
            try
            {
                MySqlConnection conn = this.dao.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandType  = CommandType.StoredProcedure;
                command.CommandText  = "PROC_USER_DELETE";
                command.Parameters.Add(new MySqlParameter("@P_ID", user.Id));
                command.ExecuteNonQuery();

                this.dao.Close(conn, command, null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<User> Select(User user)
        {
            try
            {
                MySqlConnection conn = this.dao.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandType  = CommandType.StoredProcedure;
                command.CommandText  = "PROC_USER_SELECT";
                command.Parameters.Add(new MySqlParameter("@P_ID", user.Id));
                command.Parameters.Add(new MySqlParameter("@P_LOGIN", user.Login));
                MySqlDataReader reader = command.ExecuteReader();
                List<User> users       = new List<User>();

                while (reader.Read())
                {
                    User u      = new User();
                    u.Id        = Convert.ToInt64(reader["id"].ToString());
                    u.Login     = reader["login"].ToString();
                    u.CreatedIn = Convert.ToDateTime(reader["createdin"]);
                    u.UpdatedIn = Convert.ToDateTime(reader["updatedin"]);

                    users.Add(u);
                }

                this.dao.Close(conn, command, null);

                return users;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User CheckLogin(User user)
        {
            try
            {
                MySqlConnection conn = this.dao.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandType  = CommandType.StoredProcedure;
                command.CommandText  = "PROC_USER_LOGIN_SELECT";
                command.Parameters.Add(new MySqlParameter("@P_LOGIN", user.Login));
                command.Parameters.Add(new MySqlParameter("@P_PASSWORD", user.Password));
                MySqlDataReader reader = command.ExecuteReader();
                List<User> users = new List<User>();

                while (reader.Read())
                {
                    User u      = new User();
                    u.Id        = Convert.ToInt64(reader["id"].ToString());
                    u.Login     = reader["login"].ToString();
                    u.CreatedIn = Convert.ToDateTime(reader["createdin"]);
                    u.UpdatedIn = Convert.ToDateTime(reader["updatedin"]);

                    users.Add(u);
                }

                this.dao.Close(conn, command, null);

                return users.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
