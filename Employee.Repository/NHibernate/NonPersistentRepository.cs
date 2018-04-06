using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.NHibernate
{
    public abstract class NonPersistentRepository : INonPersistentRepository
    {
        public T GetById<T>(object id)
        {
            using(var session = SessionFactory.OpenSession())
            {
                return session.Get<T>(id);
            }
        }
    }
}
