using System.Collections.Generic;
using System.Linq;
using EFCoreCodeFirstSample.Models.Repository;

namespace EFCoreCodeFirstSample.Models.DataManager
{
    public class EntityManager : IDataRepository<Entity>
    {
        readonly EntityContext _entityContext;

        public EntityManager(EntityContext context)
        {
            _entityContext = context;
        }

        public IEnumerable<Entity> GetAll()
        {
            return _entityContext.Entities.ToList();
        }

        public Entity Get(long id)
        {
            return _entityContext.Entities.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Entity entity)
        {
            _entityContext.Entities.Add(entity);
            _entityContext.SaveChanges();
        }

        public void Update(Entity _entity, Entity entity)
        {
            _entity.Name = entity.Name;
            _entity.Description = entity.Description;
            _entity.Amount = entity.Amount;
            _entity.Date = entity.Date;
            _entity.IsPrivate = entity.IsPrivate;

            _entityContext.SaveChanges();
        }

        public void Delete(Entity entity)
        {
            _entityContext.Entities.Remove(entity);
            _entityContext.SaveChanges();
        }
    }
}
