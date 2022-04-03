using Ninject.Modules;
using ShopAdoProject.BLL.Services;
using ShopAdoProject.DAL.Context;
using ShopAdoProject.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdoProject.BLL.Modules
{
    public class ShopAdoModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<ShopContext>();

            Bind<IRepository<Good>>().To<GoodRepository>();
            Bind<GoodService>().To<GoodService>();

            Bind<IRepository<Category>>().To<CategoryRepository>();
            Bind<CategoryService>().To<CategoryService>();

            Bind<IRepository<Manufacturer>>().To<ManufacturerRepository>();
            Bind<ManufacturerService>().To<ManufacturerService>();
        }
    }
}
