using FullStackApp.Core.Interface;
using FullStackApp.Core.Manager;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackApp.Web.Modules
{
    public class Manager : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserManager>().To<UserManager>().InRequestScope();
            Bind<IEmployeeManager>().To<EmployeeManager>().InRequestScope();

        }
    }
}