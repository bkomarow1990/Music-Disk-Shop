﻿using AutoMapper;
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
        void Add(AlbumDTO album);
        IEnumerable<AlbumDTO> GetAll();
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

        public void Add(AlbumDTO album)
        {
            //Flight f = new Flight()
            //{
            //    Number = flight.Number,
            //    DepartureTime = flight.DepartureTime,
            //    AirplaneId = flight.AirplaneId,
            //    ArrivalCityId = flight.ArrivalCityId,
            //    DispatchCityId = flight.DispatchCityId
            //};
            //flights.Insert(f);
            albums.Insert(mapper.Map<Album>(album));
        }

        public IEnumerable<AlbumDTO> GetAll()
        {
            //IList<FlightDTO> result = new List<FlightDTO>();

            //foreach (var flight in flights.Get())
            //{
            //    FlightDTO dto = new FlightDTO()
            //    {
            //        Number = flight.Number,
            //        DepartureTime = flight.DepartureTime,
            //        AirplaneId = flight.AirplaneId,
            //        ArrivalCityId = flight.ArrivalCityId,
            //        DispatchCityId = flight.DispatchCityId,
            //        CityFrom = new CityDTO()
            //        {
            //            Id = flight.DispatchCity.Id,
            //            Name = flight.DispatchCity.Name,
            //            CountryName = flight.DispatchCity.Country.Name
            //        },
            //        CityTo = new CityDTO()
            //        {
            //            Id = flight.ArrivalCity.Id,
            //            Name = flight.ArrivalCity.Name,
            //            CountryName = flight.ArrivalCity.Country.Name
            //        }
            //    };
            //    result.Add(dto);
            //}

            //return result;

            //foreach (var flight in flights.Get())
            //{
            //    yield return new FlightDTO()
            //    {
            //        Number = flight.Number,
            //        DepartureTime = flight.DepartureTime,
            //        AirplaneId = flight.AirplaneId,
            //        ArrivalCityId = flight.ArrivalCityId,
            //        DispatchCityId = flight.DispatchCityId,
            //        CityFrom = new CityDTO()
            //        {
            //            Id = flight.DispatchCity.Id,
            //            Name = flight.DispatchCity.Name,
            //            CountryName = flight.DispatchCity.Country.Name
            //        },
            //        CityTo = new CityDTO()
            //        {
            //            Id = flight.ArrivalCity.Id,
            //            Name = flight.ArrivalCity.Name,
            //            CountryName = flight.ArrivalCity.Country.Name
            //        }
            //    };
            //}

            return mapper.Map<IEnumerable<AlbumDTO>>(albums.Get());
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
