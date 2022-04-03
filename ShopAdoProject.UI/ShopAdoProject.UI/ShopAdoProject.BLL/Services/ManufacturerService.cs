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
    public class ManufacturerService
    {
        IRepository<Manufacturer> manufacturerRepository;
        IMapper mapper;
        public ManufacturerService(IRepository<Manufacturer> repository)
        {
            manufacturerRepository = repository;
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.CreateMap<Manufacturer, ManufacturerDTO>()
                    .ForMember(y => y.ManufacturerId, y => y.MapFrom(prop => prop.ManufacturerId))
                    .ForMember(y => y.ManufacturerName, y => y.MapFrom(prop => prop.ManufacturerName));
                x.CreateMap<ManufacturerDTO, Manufacturer>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<ManufacturerDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Manufacturer>, IEnumerable<ManufacturerDTO>>(manufacturerRepository.GetAll());
        }

        public ManufacturerDTO Get(int manufacturerId)
        {
            Manufacturer manufacturer = manufacturerRepository.Get(manufacturerId);
            return mapper.Map<Manufacturer, ManufacturerDTO>(manufacturer);
        }

        public ManufacturerDTO Delete(ManufacturerDTO manufacturerDTO)
        {
            Manufacturer manufacturerToRemove = manufacturerRepository.Get(manufacturerDTO.ManufacturerId);
            manufacturerRepository.Delete(manufacturerToRemove);
            manufacturerRepository.SaveChanges();
            return manufacturerDTO;
        }

        public void CreateOrUpdate(ManufacturerDTO manufacturerDTO)
        {
            Manufacturer manufacturer = mapper.Map<ManufacturerDTO, Manufacturer>(manufacturerDTO);
            manufacturerRepository.CreateOrUpdate(manufacturer);
            manufacturerRepository.SaveChanges();
        }
    }
}
