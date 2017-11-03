using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.SqlAzure;

namespace dbsrvc.Models.NHibernate {
	public class NHibernateHelper {
		public static ISession OpenSession() {
			ISessionFactory sessionFactory = Fluently.Configure()
				.Database(MsSqlConfiguration.MsSql2012.ConnectionString(
					@"Server=tcp:dynamicsqlserver.database.windows.net,1433;
					Initial Catalog=dynamicsqldb;
					Persist Security Info=False;
					User ID=geezer;
					Password=adgqet1357Q!;
					MultipleActiveResultSets=False;
					Encrypt=True;
					TrustServerCertificate=False;
					Connection Timeout=30;").ShowSql().Driver<SqlAzureClientDriver>())
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Word>())
				.ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
				.BuildSessionFactory();
			return sessionFactory.OpenSession();
		}
	}
}