using ShopAdoProject.BLL.DTO;
using ShopAdoProject.BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdoProject.UI.ViewModels
{
    class ListGoodViewModel
    {
        public GoodService goodService;
        public ObservableCollection<GoodDTO> Goods { get; set; }

        public GoodDTO SelectedGood { get; set; }

        public ListGoodViewModel(GoodService service)
        {
            goodService = service;
            Goods = new ObservableCollection<GoodDTO>(goodService.GetAll());
        }
    
    }
}
