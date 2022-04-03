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
    class ListManufacturerViewModel
    {
        public ManufacturerService manufacturerService;
        public ObservableCollection<ManufacturerDTO> Manufacturers { get; set; }

        public ManufacturerDTO SelectedManufacturer { get; set; }

        public ListManufacturerViewModel(ManufacturerService service)
        {
            manufacturerService = service;
            Manufacturers = new ObservableCollection<ManufacturerDTO>(manufacturerService.GetAll());
        }
    }
}
