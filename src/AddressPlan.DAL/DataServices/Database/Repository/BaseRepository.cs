using AddressPlan.DAL.DataServices.Database.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AddressPlan.DAL.DataServices.Database.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly BaseContext _context;
        private readonly DbSet<TEntity> _entities;

        public BaseRepository(BaseContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public virtual void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            TEntity entity = _entities.Find(id);
            Delete(entity);
        }

        public virtual IEnumerable<TEntity> GetEntities(string query, params object[] parameters)
        {
            return _entities.SqlQuery(query, parameters).ToList();
        }

        public virtual List<TREntity> GetEntities<TREntity>(string query, params object[] parameters) where TREntity : class
        {
            return _context.Database.SqlQuery<TREntity>(query, parameters).ToList();
        }

        public virtual List<TREntity> Execute<TREntity>(string query) where TREntity : class
        {
            return _context.Database.SqlQuery<TREntity>(query).ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return _entities.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _entities.AddOrUpdate(entity);
        }
    }
}
