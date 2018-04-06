using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.NHibernate
{
    public abstract class PersistentRepository : IPersistentRepository
    {
        public virtual void Add<TEntity>(TEntity entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
               using(var uow = session.BeginTransaction())
                {
                    session.Save(entity);
                    uow.Commit();
                }
               
            }
        }
    }
}
