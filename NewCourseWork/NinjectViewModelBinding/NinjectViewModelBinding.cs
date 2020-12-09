using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.DataOperations;
using Ninject.Modules;

namespace NewCourseWork.NinjectViewModelBinding
{
    public class NinjectViewModelBinding: NinjectModule
    {
        public override void Load()
        {
           // Bind<IDbCrud>().To<DbDataOperations>().InSingletonScope().WithConstructorArgument(connectionString);
        }
    }
}
