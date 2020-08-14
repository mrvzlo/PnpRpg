using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity<int>
    {
        protected readonly AppDbContext DbContext;
        protected readonly DbSet<T> DbSet;

        protected BaseRepository(AppDbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<T>();
        }

        public virtual IQueryable<T> Select()
        {
            return DbSet;
        }

        public virtual T Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual T GetRandom()
        {
            var count = DbSet.Count();
            if (count == 0) 
                return null;

            var rand = new Random().Next(count);
            return DbSet.OrderBy(x => x.Id).Skip(rand).First();
        }

        public virtual int InsertOrUpdate(T entity)
        {
            DbContext.Entry(entity).State = entity.Id == 0 ? EntityState.Added : EntityState.Modified;
            DbContext.SaveChanges();
            return entity.Id;
        }

        public virtual void Delete(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            Delete(Get(id));
            DbContext.SaveChanges();
        }

        public virtual void BatchInsert(IQueryable<T> list)
        {
            foreach (var entity in list)
                InsertOrUpdate(entity);

            DbContext.SaveChanges();
        }

        public virtual void BatchDelete(IQueryable<T> list)
        {
            foreach (var entity in list)
                DbContext.Entry(entity).State = EntityState.Deleted;

            DbContext.SaveChanges();
        }
    }
}
