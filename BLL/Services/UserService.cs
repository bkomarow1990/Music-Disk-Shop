using AutoMapper;
using DAL;
using DAL.Enties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUserService
    {
        void Add(User user);
        void Remove(User user);
        IEnumerable<string> GetLogin();
        IEnumerable<string> GetPassword();
    }
    public class UserService : IUserService
    {
        IUnitOfWork unitOfWork;
        IRepository<User> users;
        IMapper mapper;
        MusciCollectionModel context = new MusciCollectionModel();
        public UserService()
        {
            unitOfWork = new UnitOfWork(context);
            users = unitOfWork.UserRepository;

            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, User>(); // Maybe add user dto
            });

            mapper = new Mapper(config);
        }
        public void Add(User user)
        {
            unitOfWork.UserRepository.Insert(user);
            unitOfWork.Save();
        }
        public IEnumerable<string> GetLogin()
        {
            return unitOfWork.UserRepository.Get().Select(c => c.Login);
        }

        public IEnumerable<string> GetPassword()
        {
            return unitOfWork.UserRepository.Get().Select(c => c.Password);
        }

        public void Remove(User user)
        {
            unitOfWork.UserRepository.Delete(user);
            unitOfWork.Save();
        }
    }
}
