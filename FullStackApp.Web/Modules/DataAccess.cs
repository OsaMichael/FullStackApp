using FullStackApp.Infrastructure;
using FullStackApp.Infrastructure.Interface;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FullStackApp.Web.Modules
{
    public class DataAccess : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<DataContext>().InRequestScope();
            Bind<IDataRepository>().To<EntityRepository>().InRequestScope();
            //Bind<IAccountQueries>().To<AccountQueries>();

        }
    }
}