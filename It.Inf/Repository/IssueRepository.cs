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
    public class IssueRepository : IIssueRepository
    {
        private readonly MongoRepository<IssueDto> _repository = new MongoRepository<IssueDto>(); 
     
        public void Insert(Issue entity)
        {
            var dto = Map(entity);
            _repository.Add(dto);
        }

        public void Delete(Issue entity)
        {
            var dto = Map(entity);
            _repository.Delete(dto);
        }

        public void Update(Issue entity)
        {
            var dto = Map(entity);
            dto.Id = GetByGuid(entity.Id).Id;
            _repository.Update(dto);
        }

        private IssueDto GetByGuid(Guid guid)
        {
            return _repository.FirstOrDefault(dto => dto.Guid == guid.ToString());
        }

        public ICollection<Issue> SearchFor(Func<Issue, bool> predicate)
        {
            var list = _repository.Where(dto => predicate.Invoke(Map(dto))).ToList();
            var result = new List<Issue>();
            list.ForEach(dto => result.Add(Map(dto)));
            return result;
        }

        public ICollection<Issue> GetAll()
        {
            var list = _repository.ToList();
            var result = new List<Issue>();
            list.ForEach(dto => result.Add(Map(dto)));
            return result;
        }

        public Issue GetById(Guid id)
        {
            return Map(_repository.FirstOrDefault(dto => dto.Guid == id.ToString()));
        }

        private static IssueDto Map(Issue entity)
        {
            return AutomapperConfiguration.Mapper.Map<Issue, IssueDto>(entity);
        }

        private static Issue Map(IssueDto dto)
        {
            return AutomapperConfiguration.Mapper.Map<IssueDto, Issue>(dto);
        }
    }
}
