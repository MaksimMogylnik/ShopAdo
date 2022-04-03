using Ninject;
using ShopAdoProject.BLL.Modules;
using ShopAdoProject.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdoProject.UI.Infrastructure
{
    class ViewModelsLocator
    {
        IKernel kernel;
        public ViewModelsLocator()
        {
            kernel = new StandardKernel(new ShopAdoModule());
        }

        public CreateGoodViewModel CreateGoodViewModel => kernel.Get<CreateGoodViewModel>();
        public ListGoodViewModel ListGoodViewModel => kernel.Get<ListGoodViewModel>();
        public CreateCategoryViewModel CreateCategoryViewModel => kernel.Get<CreateCategoryViewModel>();
        public ListCategoryViewModel ListCategoryViewModel => kernel.Get<ListCategoryViewModel>();
        public CreateManufacturerViewModel CreateManufacturerViewModel => kernel.Get<CreateManufacturerViewModel>();
        public ListManufacturerViewModel ListManufacturerViewModel => kernel.Get<ListManufacturerViewModel>();
    }
}
