using ShopAdoProject.BLL.DTO;
using ShopAdoProject.BLL.Services;
using ShopAdoProject.UI.Infrastructure;
using ShopAdoProject.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopAdoProject.UI.ViewModels
{
    class CreateManufacturerViewModel : BaseNotifyPropertyChanged
    {
        ManufacturerService manufacturerService;

        private ManufacturerDTO selectedManufacturer;
        public ManufacturerDTO SelectedManufacturer
        {
            get => selectedManufacturer;
            set
            {
                selectedManufacturer = value;
                NotifyOfPopertyChanged();
            }
        }
        public CreateManufacturerViewModel(ManufacturerService service)
        {
            manufacturerService = service;

            SelectedManufacturer = new ManufacturerDTO();
            AddManufacturerCommand = new RelayCommand(param =>
            {
                manufacturerService.CreateOrUpdate(SelectedManufacturer);
                Switcher.Switch(new ListManufacturerView());
            });
        }

        public ICommand AddManufacturerCommand { get; private set; }

        public void SetManufacturerToEdit(int manufacturerId)
        {
            SelectedManufacturer = manufacturerService.Get(manufacturerId);
        }
    }
}
