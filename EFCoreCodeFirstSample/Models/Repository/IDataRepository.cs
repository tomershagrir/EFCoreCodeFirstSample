using System.Collections.Generic;

namespace EFCoreCodeFirstSample.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(Entity _entity, TEntity entity);
        void Delete(Entity entity);
    }
}
