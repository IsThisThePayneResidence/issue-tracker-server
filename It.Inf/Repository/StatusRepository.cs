using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Data.Dto;
using It.Inf.Mappers;
using It.Model.Domain;
using It.Model.Interfaces;
using MongoRepository;

namespace It.Inf.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly MongoRepository<StatusDto> _repository = new MongoRepository<StatusDto>();

        public void Insert(Status entity)
        {
            var dto = Map(entity);
            _repository.Add(dto);
        }

        public void Delete(Status entity)
        {
            var dto = Map(entity);
            _repository.Delete(dto);
        }

        public ICollection<Status> SearchFor(Func<Status, bool> predicate)
        {
            var list = _repository.Where(dto => predicate.Invoke(Map(dto))).ToList();
            var result = new List<Status>();
            list.ForEach(dto => result.Add(Map(dto)));
            return result;
        }

        public ICollection<Status> GetAll()
        {
            var list = _repository.ToList();
            var result = new List<Status>();
            list.ForEach(dto => result.Add(Map(dto)));
            return result;
        }

        public void Update(Status entity)
        {
            var dto = Map(entity);
            dto.Id = GetByGuid(entity.Id).Id;
            _repository.Update(dto);
        }

        private StatusDto GetByGuid(Guid guid)
        {
            return _repository.FirstOrDefault(dto => dto.Guid == guid);
        }


        public Status GetById(Guid id)
        {
            return Map(_repository.FirstOrDefault(dto => dto.Guid == id));
        }

        private static StatusDto Map(Status entity)
        {
            return AutomapperConfiguration.Mapper.Map<Status, StatusDto>(entity);
        }

        private static Status Map(StatusDto dto)
        {
            return AutomapperConfiguration.Mapper.Map<StatusDto, Status>(dto);
        }
    }
}
