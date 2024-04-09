using PIMTool.Core.Domain.Entities;
using PIMTool.Core.Interfaces.Repositories;
using PIMTool.Core.Interfaces.Services;

namespace PIMTool.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _repository;

        public ProjectService(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task<Project?> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetAsync(id, cancellationToken);
            return entity;
        }

        public async Task<IQueryable<Project>> Get()
        {
            var entity = _repository.Get();
            return entity;
        }

        public async Task AddAsync(Project entity, CancellationToken cancellationToken = default)
        {
            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await GetAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new InvalidOperationException("Entity not found");
            }

            _repository.Delete(entity);
            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}