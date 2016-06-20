using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Model
{
    [Serializable]
    public class Actor
    {
        #region Fields

        private Int64 actorId;
        private String firstName;
        private String lastName;
        private DateTime lastUpdate;

        #endregion

        #region Constructors

        public Actor() { }

        public Actor(Int64 actorId, String firstName, String lastName, DateTime lastUpdate)
        {
            this.actorId    = actorId;
            this.firstName  = firstName;
            this.lastName   = lastName;
            this.lastUpdate = lastUpdate;
        }

        public Actor(String firstName, String lastName, DateTime lastUpdate)
        {
            this.firstName  = firstName;
            this.lastName   = lastName;
            this.lastUpdate = lastUpdate;
        }

        #endregion

        #region Properties

        public Int64 ActorId
        {
            get { return actorId; }
            set { actorId = value; }
        }

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public DateTime LastUpdate
        {
            get { return lastUpdate; }
            set { lastUpdate = value; }
        }

        #endregion
    }
}
