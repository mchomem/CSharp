using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Model
{
    [Serializable]
    public class User
    {
        #region Fields

        private Int64 id;
        private String login;
        private String password;
        private DateTime createdIn;
        private DateTime updatedIn;

        #endregion

        #region Constructors

        public User() { }

        public User(String login, String password, DateTime createdIn, DateTime updatedIn)
        {
            this.login     = login;
            this.password  = password;
            this.createdIn = createdIn;
            this.updatedIn = updatedIn;
        }

        public User(Int64 id, String login, String password, DateTime createdIn, DateTime updatedIn)
        {
            this.id        = id;
            this.login     = login;
            this.password  = password;
            this.createdIn = createdIn;
            this.updatedIn = updatedIn;
        }

        #endregion

        #region Properties

        public Int64 Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Login
        {
            get { return login; }
            set { login = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public DateTime CreatedIn
        {
            get { return createdIn; }
            set { createdIn = value; }
        }

        public DateTime UpdatedIn
        {
            get { return updatedIn; }
            set { updatedIn = value; }
        }
        
        #endregion
    }
}
