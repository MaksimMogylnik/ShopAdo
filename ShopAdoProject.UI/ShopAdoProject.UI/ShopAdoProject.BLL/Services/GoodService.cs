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
    public class GoodService
    {
        IRepository<Good> goodRepository;
        IMapper mapper;
        public GoodService(IRepository<Good> repository)
        {
            goodRepository = repository;
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.CreateMap<Good, GoodDTO>()
                    .ForMember(y => y.CategoryName, y => y.MapFrom(prop => prop.Category.CategoryName))
                    .ForMember(y => y.ManufacturerName, y => y.MapFrom(prop => prop.Manufacturer.ManufacturerName));
                x.CreateMap<GoodDTO, Good>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<GoodDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Good>, IEnumerable<GoodDTO>>(goodRepository.GetAll());
        }

        public GoodDTO Get(int goodId)
        {
            Good good = goodRepository.Get(goodId);
            return mapper.Map<Good, GoodDTO>(good);
        }

        public GoodDTO Delete(GoodDTO goodDto)
        {
            Good goodToRemove = goodRepository.Get(goodDto.GoodId);
            goodRepository.Delete(goodToRemove);
            goodRepository.SaveChanges();
            return goodDto;
        }

        public void CreateOrUpdate(GoodDTO goodDto)
        {
            Good good = mapper.Map<GoodDTO, Good>(goodDto); 
            goodRepository.CreateOrUpdate(good);
            goodRepository.SaveChanges();
        }
    }
}
