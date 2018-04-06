using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.NHibernate
{
    public interface IPersistentRepository
    {
        void Add<TEntity>(TEntity entity);
    }
}
