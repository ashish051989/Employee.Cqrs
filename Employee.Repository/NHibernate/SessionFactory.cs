using Employee.Repository.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.NHibernate
{
    public static class SessionFactory
    {
        public static ISession OpenSession()
        {
            var connectionString = @"Data Source=BEWTS0541\SQLD01;Initial Catalog=NhibernateTest;User Id=DevUser;Password=BERocks1";

            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PersistentRepository>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}
