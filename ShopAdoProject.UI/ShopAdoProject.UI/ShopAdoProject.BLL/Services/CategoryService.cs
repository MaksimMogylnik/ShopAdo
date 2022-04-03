using AutoMapper;
using ShopAdoProject.BLL.DTO;
using ShopAdoProject.DAL.Context;
using ShopAdoProject.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdoProject.BLL.Services
{
    public class CategoryService
    {
        IRepository<Category> categoryRepository;
        IMapper mapper;
        public CategoryService(IRepository<Category> repository)
        {
            categoryRepository = repository;
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.CreateMap<Category, CategoryDTO>()
                    .ForMember(y => y.CategoryId, y => y.MapFrom(prop => prop.CategoryId))
                    .ForMember(y => y.CategoryName, y => y.MapFrom(prop => prop.CategoryName));
                x.CreateMap<CategoryDTO, Category>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categoryRepository.GetAll());
        }

        public CategoryDTO Get(int categoryId)
        {
            Category category = categoryRepository.Get(categoryId);
            return mapper.Map<Category, CategoryDTO>(category);
        }

        public CategoryDTO Delete(CategoryDTO categoryDTO)
        {
            Category categoryToRemove = categoryRepository.Get(categoryDTO.CategoryId);
            categoryRepository.Delete(categoryToRemove);
            categoryRepository.SaveChanges();
            return categoryDTO;
        }

        public void CreateOrUpdate(CategoryDTO categoryDTO)
        {
            Category category = mapper.Map<CategoryDTO, Category>(categoryDTO);
            categoryRepository.CreateOrUpdate(category);
            categoryRepository.SaveChanges();
        }
    }
}
