using Microsoft.EntityFrameworkCore;
using Project.Core;
using Project.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Infrastructure.Repository
{



    public class EntityRepository<T> : IEntityRepository<T> where T : BaseEntity
    {
        protected readonly FileManagementDbContext context;

        public EntityRepository(FileManagementDbContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().Where(s => s.IsSoftDeleted == false).ToListAsync(cancellationToken);
        }

        public virtual async Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().Where(s => s.IsSoftDeleted == false).CountAsync(cancellationToken);
        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            try
            {
                entity = await GetAddAsyncProperties(entity);
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync(cancellationToken);
                return entity;
            }

            catch (Exception ex)
            {
                entity = null;
                return entity;
            }

        }

        public async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            entity = await GetUpdateAsyncProperties(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        public async Task<T> FirstAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().FirstAsync(cancellationToken);
        }

        public async Task<T> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<int> CountAsync()
        {
            return await context.Set<T>().Where(s => s.IsSoftDeleted == false).CountAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllPagedAsync(int recSkip, int recTake, CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().Where(s => s.IsSoftDeleted == false).Skip(recSkip).Take(recTake).ToListAsync();
        }

        public IQueryable<T> AllIQueryableAsync(CancellationToken cancellationToken = default)
        {
            return context.Set<T>().Where(s => s.IsSoftDeleted == false).AsQueryable();
        }

        public async Task<IReadOnlyList<T>> GetAllDeletedAsync(CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().Where(s => s.IsSoftDeleted).ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> GetDeletedPagedAsync(int recSkip, int recTake, CancellationToken cancellationToken = default)
        {
            return await context.Set<T>().Where(s => s.IsSoftDeleted).Skip(recSkip).Take(recTake).ToListAsync(cancellationToken);
        }

        public async Task<bool> PermanentDeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }

        public async Task<bool> PermanentDeleteByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            context.Set<T>().Remove(context.Set<T>().Find(id));
            await context.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }

        public async Task<bool> SoftDeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            entity = await GetSoftDeleteAsyncProperties(entity);

            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }

        public async Task<bool> SoftDeleteByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await context.Set<T>().FindAsync(id);
            entity = await GetSoftDeleteAsyncProperties(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }

        public async Task<bool> RestoreAsync(T entity, CancellationToken cancellationToken = default)
        {
            entity = await GetRestoreAsyncProperties(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }

        public async Task<bool> RestoreByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await context.Set<T>().FindAsync(id);
            entity = await GetRestoreAsyncProperties(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }

        private async Task<T> GetAddAsyncProperties(T entity)
        {

            entity.IsSoftDeleted = false;
            return entity;
        }
        private async Task<T> GetUpdateAsyncProperties(T entity)
        {

            entity.IsSoftDeleted = false;
            return entity;
        }

        private async Task<T> GetSoftDeleteAsyncProperties(T entity)
        {

            entity.IsSoftDeleted = true;
            return entity;
        }

        private async Task<T> GetRestoreAsyncProperties(T entity)
        {

            entity.IsSoftDeleted = false;
            return entity;
        }
    }
}
