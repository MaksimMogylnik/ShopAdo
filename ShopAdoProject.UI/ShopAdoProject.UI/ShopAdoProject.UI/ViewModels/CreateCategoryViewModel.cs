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
    class CreateCategoryViewModel : BaseNotifyPropertyChanged
    {
        CategoryService categoryService;

        private CategoryDTO selectedCategory;
        public CategoryDTO SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                NotifyOfPopertyChanged();
            }
        }
        public CreateCategoryViewModel(CategoryService service)
        {
            categoryService = service;

            SelectedCategory = new CategoryDTO();
            AddCategoryCommand = new RelayCommand(param =>
            {
                categoryService.CreateOrUpdate(SelectedCategory);
                Switcher.Switch(new ListCategoryView());
            });
        }

        public ICommand AddCategoryCommand { get; private set; }

        public void SetCategoryToEdit(int categryId)
        {
            SelectedCategory = categoryService.Get(categryId);
        }
    }
}
