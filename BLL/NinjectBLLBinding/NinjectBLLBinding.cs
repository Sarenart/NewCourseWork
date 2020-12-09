using System;
using DAL.Interfaces;
using DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using Ninject.Modules;
using System.Text;
using System.Threading.Tasks;

namespace BLL.NinjectBLLBinding
{
    public class NinjectBLLBinding:NinjectModule
    {
        private string connectionString;
        public NinjectBLLBinding(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IDbRepository>().To<DbRepositorySQLServer>().InSingletonScope().WithConstructorArgument(connectionString);
        }
    }
}
