using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IAlbumService
    {
        void Add(Album album);
        IEnumerable<string> GetAll();
        void AddCountry(string name);
        IEnumerable<string> GetCountries();
    }
    public class AlbumService : IAlbumService
    {
        IUnitOfWork unitOfWork;
        IRepository<Album> albums;
        IMapper mapper;

        public AlbumService()
        {
            unitOfWork = new UnitOfWork();
            albums = unitOfWork.AlbumRepository;

            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AlbumDTO, Album>();
            });

            mapper = new Mapper(config);
        }

        public void Add(Album album)
        {
            try
            {
                unitOfWork.AlbumRepository.Insert(album);
                unitOfWork.Save();
            }
            catch (Exception EX)
            {
                throw new Exception($"{EX}");
            }
        }

        public IEnumerable<string> GetAll()
        {
            return unitOfWork.AlbumRepository.Get().Select(c => c.Name);
        }

        public void AddCountry(string name)
        {
            unitOfWork.CountryRepository.Insert(new Country { Name = name });
            unitOfWork.Save();
        }
        public IEnumerable<string> GetCountries()
        {
            return unitOfWork.CountryRepository.Get().Select(c => c.Name);
        }
    }
}
