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
    class ListCategoryViewModel
    {
        public CategoryService categoryService;
        public ObservableCollection<CategoryDTO> Categories { get; set; }

        public CategoryDTO SelectedCategory { get; set; }

        public ListCategoryViewModel(CategoryService service)
        {
            categoryService = service;
            Categories = new ObservableCollection<CategoryDTO>(categoryService.GetAll());
        }
    }
}
