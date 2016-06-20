using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Model.Dao.Interface
{
    public interface IDao<E>
    {
        #region Abstratc methods

        void Insert(E entity);
        void Update(E entity);
        void Delete(E entity);
        List<E> Select(E entity);

        #endregion
    }
}
