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
    public class ProjectRepository : IProjectRepository
    {
        private readonly MongoRepository<ProjectDto> _repository = new MongoRepository<ProjectDto>();

        public void Insert(Project entity)
        {
            var dto = Map(entity);
            _repository.Add(dto);
        }

        public void Delete(Project entity)
        {
            var dto = Map(entity);
            _repository.Delete(dto);
        }

        public void Update(Project entity)
        {
            var dto = Map(entity);
            dto.Id = GetByGuid(entity.Id).Id;
            _repository.Update(dto);
        }

        private ProjectDto GetByGuid(Guid guid)
        {
            return _repository.FirstOrDefault(dto => dto.Guid == guid.ToString());
        }

        public ICollection<Project> SearchFor(Func<Project, bool> predicate)
        {
            var list = _repository.Where(dto => predicate.Invoke(Map(dto))).ToList();
            var result = new List<Project>();
            list.ForEach(dto => result.Add(Map(dto)));
            return result;
        }

        public ICollection<Project> GetAll()
        {
            var list = _repository.ToList();
            var result = new List<Project>();
            list.ForEach(dto => result.Add(Map(dto)));
            return result;
        }

        public Project GetById(Guid id)
        {
            return Map(_repository.FirstOrDefault(dto => dto.Guid == id.ToString()));
        }

        private static ProjectDto Map(Project entity)
        {
            return AutomapperConfiguration.Mapper.Map<Project, ProjectDto>(entity);
        }

        private static Project Map(ProjectDto dto)
        {
            return AutomapperConfiguration.Mapper.Map<ProjectDto, Project>(dto);
        }
    }
}
