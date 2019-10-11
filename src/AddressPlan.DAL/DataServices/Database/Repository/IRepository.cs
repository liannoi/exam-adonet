using System.Collections.Generic;

namespace AddressPlan.DAL.DataServices.Database.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entity);

        void Delete(int id);

        TEntity GetEntity(int id);

        IEnumerable<TEntity> GetEntities(string query, params object[] parameters);

        List<TREntity> GetEntities<TREntity>(string query, params object[] parameters) where TREntity : class;

        List<TREntity> GetEntities<TREntity>(string query) where TREntity : class;

        void Insert(TEntity entity);

        void Update(TEntity entity);
    }
}
