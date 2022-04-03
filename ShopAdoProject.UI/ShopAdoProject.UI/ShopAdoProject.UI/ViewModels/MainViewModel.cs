using ShopAdoProject.BLL.DTO;
using ShopAdoProject.BLL.Services;
using ShopAdoProject.UI.Infrastructure;
using ShopAdoProject.UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ShopAdoProject.UI.ViewModels
{
    class MainViewModel : BaseNotifyPropertyChanged, INavigate
    {
        private UserControl currentPage;
        public UserControl CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                NotifyOfPopertyChanged();
            }
        }
        public MainViewModel()
        {
            CurrentPage = new ListGoodView();
            InitCommands();
            Switcher.ContentArea = this;
        }

        public void InitCommands()
        {
            CreateGoodCommand = new RelayCommand(param =>
            {
                Switcher.Switch(new CreateGoodView());
            });

            ListGoodsCommand = new RelayCommand(param =>
            {
                Switcher.Switch(new ListGoodView());
            });

            EditGoodCommand = new RelayCommand(param =>
            {
                if (CurrentPage.DataContext is ListGoodViewModel vm)
                {
                    CreateGoodView page = new CreateGoodView();
                    CreateGoodViewModel cgvm = page.DataContext as CreateGoodViewModel;
                    cgvm.SetGoodToEdit(vm.SelectedGood.GoodId);
                    Switcher.Switch(page);
                }
            });




            CreateCategoryCommand = new RelayCommand(param =>
            {
                Switcher.Switch(new CreateCategoryView());
            });

            ListCategoryCommand = new RelayCommand(param =>
            {
                Switcher.Switch(new ListCategoryView());
            });

            EditCategoryCommand = new RelayCommand(param =>
            {
                if (CurrentPage.DataContext is ListCategoryViewModel vm)
                {
                    CreateCategoryView page = new CreateCategoryView();
                    CreateCategoryViewModel cgvm = page.DataContext as CreateCategoryViewModel;
                    cgvm.SetCategoryToEdit(vm.SelectedCategory.CategoryId);
                    Switcher.Switch(page);
                }
            });


            CreateManufacturerCommand = new RelayCommand(param =>
            {
                Switcher.Switch(new CreateManufacturerView());
            });

            ListManufacturerCommand = new RelayCommand(param =>
            {
                Switcher.Switch(new ListManufacturerView());
            });

            EditManufacturerCommand = new RelayCommand(param =>
            {
                if (CurrentPage.DataContext is ListManufacturerViewModel vm)
                {
                    CreateManufacturerView page = new CreateManufacturerView();
                    CreateManufacturerViewModel cgvm = page.DataContext as CreateManufacturerViewModel;
                    cgvm.SetManufacturerToEdit(vm.SelectedManufacturer.ManufacturerId);
                    Switcher.Switch(page);
                }
            });


            DeleteSelectedCommand = new RelayCommand(param =>
            {
                if (CurrentPage.DataContext is ListGoodViewModel vm)
                    vm.goodService.Delete(vm.SelectedGood);
                else
                    MessageBox.Show("This category or manufacturer" +
                        " can't be deleted because it can be used in table \"Goods\"");
            });
        }

       

        public ICommand CreateGoodCommand { get; private set; }
        public ICommand ListGoodsCommand { get; private set; }
        public ICommand EditGoodCommand { get; private set; }



        public ICommand CreateCategoryCommand { get; private set; }
        public ICommand ListCategoryCommand { get; private set; }
        public ICommand EditCategoryCommand { get; private set; }


        public ICommand CreateManufacturerCommand { get; private set; }
        public ICommand ListManufacturerCommand { get; private set; }
        public ICommand EditManufacturerCommand { get; private set; }


        public ICommand DeleteSelectedCommand { get; private set; }


        public void Navigate(UserControl page)
        {
            CurrentPage = page;
        }
    }
}
