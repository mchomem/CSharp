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
    public class ActorDao : IDao<Actor>
    {
        #region Fields

        private GenericDao dao;

        #endregion

        #region Constructors

        public ActorDao()
        {
            this.dao = new GenericDao();
        }

        #endregion

        #region Methods

        public void Insert(Actor actor)
        {
            try
            {
                MySqlConnection conn = this.dao.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandType  = CommandType.StoredProcedure;
                command.CommandText  = "PROC_ACTOR_INSERT";
                command.Parameters.Add(new MySqlParameter("@P_FIRST_NAME", actor.FirstName));
                command.Parameters.Add(new MySqlParameter("@P_LAST_NAME",  actor.LastName));
                command.ExecuteNonQuery();

                this.dao.Close(conn, command, null);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void Update(Actor actor)
        {
            try
            {
                MySqlConnection conn = this.dao.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandType  = CommandType.StoredProcedure;
                command.CommandText  = "PROC_ACTOR_UPDATE";
                command.Parameters.Add(new MySqlParameter("@P_ACTOR_ID", actor.ActorId));
                command.Parameters.Add(new MySqlParameter("@P_FIRST_NAME", actor.FirstName));
                command.Parameters.Add(new MySqlParameter("@P_LAST_NAME", actor.LastName));
                command.ExecuteNonQuery();

                this.dao.Close(conn, command, null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(Actor actor)
        {
            try
            {
                MySqlConnection conn = this.dao.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandType  = CommandType.StoredProcedure;
                command.CommandText  = "PROC_ACTOR_DELETE";
                command.Parameters.Add(new MySqlParameter("@P_ACTOR_ID", actor.ActorId));
                command.ExecuteNonQuery();

                this.dao.Close(conn, command, null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Actor> Select(Actor actor)
        {
            try
            {
                MySqlConnection conn   = this.dao.Open();
                MySqlCommand command   = conn.CreateCommand();
                command.CommandType    = CommandType.StoredProcedure;
                command.CommandText    = "PROC_ACTOR_SELECT";
                command.Parameters.Add(new MySqlParameter("@P_ACTOR_ID"  , actor.ActorId));
                command.Parameters.Add(new MySqlParameter("@P_FIRST_NAME", actor.FirstName));
                command.Parameters.Add(new MySqlParameter("@P_LAST_NAME" , actor.LastName));
                MySqlDataReader reader = command.ExecuteReader();
                List<Actor> actors     = new List<Actor>();

                while (reader.Read())
                {
                    Actor act      = new Actor();
                    act.ActorId    = Convert.ToInt64(reader["actor_id"].ToString());
                    act.FirstName  = reader["first_name"].ToString();
                    act.LastName   = reader["last_name"].ToString();
                    act.LastUpdate = Convert.ToDateTime(reader["last_update"].ToString());

                    actors.Add(act);
                }

                this.dao.Close(conn, command, null);

                return actors;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
