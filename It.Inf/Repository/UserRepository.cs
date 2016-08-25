using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using It.Data.Dto;
using It.Inf.Mappers;
using It.Model.Domain;
using It.Model.Interfaces;
using MongoRepository;

namespace It.Inf.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MongoRepository<UserDto> _repository = new MongoRepository<UserDto>(); 
           
        public void Insert(User entity)
        {
            var dto = Map(entity);
            _repository.Add(dto);
        }

        public void Delete(User entity)
        {
            var dto = Map(entity);
            _repository.Delete(dto);
        }

        public ICollection<User> SearchFor(Func<User, bool> predicate)
        {
            var list = _repository.Where(dto => predicate.Invoke(Map(dto))).ToList();
            var result = new List<User>();
            list.ForEach(dto => result.Add(Map(dto)));
            return result;
        }

        public ICollection<User> GetAll()
        {
            var list = _repository.ToList();
            var result = new List<User>();
            list.ForEach(dto => result.Add(Map(dto)));
            return result;
        }

        public void Update(User entity)
        {
            var dto = Map(entity);
            dto.Id = GetByGuid(entity.Id).Id;
            _repository.Update(dto);
        }

        private UserDto GetByGuid(Guid guid)
        {
            return _repository.FirstOrDefault(dto => dto.Guid == guid.ToString());
        }


        public User GetById(Guid id)
        {
            return Map(_repository.FirstOrDefault(dto => dto.Guid == id.ToString()));
        }

        private static UserDto Map(User user)
        {
            return AutomapperConfiguration.Mapper.Map<User, UserDto>(user);
        }

        private static User Map(UserDto dto)
        {
            return AutomapperConfiguration.Mapper.Map<UserDto, User>(dto);
        }
    }
}
