using ProjectManagementSystem.Core.Interfaces.Repositories;
using ProjectManagementSystem.Core.Interfaces.Services;

namespace ProjectManagementSystem.Infrastructure.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            return await _repository.AddAsync(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
            }
        }
    }
}