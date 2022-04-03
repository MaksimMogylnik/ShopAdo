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
    class CreateGoodViewModel : BaseNotifyPropertyChanged
    {
        GoodService goodService;
      
        private GoodDTO selectedGood;
        public GoodDTO SelectedGood
        {
            get => selectedGood;
            set
            {
                selectedGood = value;
                NotifyOfPopertyChanged();
            }
        }
        public CreateGoodViewModel(GoodService service)
        {
            goodService = service;

            SelectedGood = new GoodDTO();
            AddGoodCommand = new RelayCommand(param =>
            {
                goodService.CreateOrUpdate(SelectedGood);
                Switcher.Switch(new ListGoodView());
            });
        }

        public ICommand AddGoodCommand { get; private set; }

        public void SetGoodToEdit(int goodId)
        {
            SelectedGood = goodService.Get(goodId);
        }
    }
}
