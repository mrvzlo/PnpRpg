﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;

namespace Pnprpg.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
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

        public virtual IQueryable<T> Get(int id)
        {
            return Select().Where(x => x.Id == id);
        }

        public virtual IQueryable<T> GetRandom()
        {
            var count = DbSet.Count();
            if (count == 0) 
                return null;

            var rand = new Random().Next(count);
            return DbSet.OrderBy(x => x.Id).Skip(rand).Take(1);
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
            Delete(DbSet.Find(id));
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
