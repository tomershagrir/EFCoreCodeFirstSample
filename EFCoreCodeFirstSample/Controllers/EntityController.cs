using System.Collections.Generic;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCodeFirstSample.Controllers
{
    [Route("api/entity")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly IDataRepository<Entity> _dataRepository;

        public EntityController(IDataRepository<Entity> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Entity
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Entity> Entities = _dataRepository.GetAll();
            return Ok(Entities);
        }

		// GET: api/Entity/5
		[HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Entity entity = _dataRepository.Get(id);

            if (entity == null)
            {
                return NotFound("The entity record couldn't be found.");
            }

            return Ok(entity);
        }

		// POST: api/Entity
		[HttpPost]
        public IActionResult Post([FromBody] Entity entity)
        {
            if (entity == null)
            {
                return BadRequest("entity is null.");
            }

            _dataRepository.Add(entity);
            return CreatedAtRoute(
                  "Get",
                  new { Id = entity.Id },
                  entity);
        }

		// PUT: api/Entity/5
		[HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Entity entity)
        {
            if (entity == null)
            {
                return BadRequest("entity is null.");
            }

            Entity entityToUpdate = _dataRepository.Get(id);
            if (entityToUpdate == null)
            {
                return NotFound("The entity record couldn't be found.");
            }

            _dataRepository.Update(entityToUpdate, entity);
            return NoContent();
        }

		// DELETE: api/Entity/5
		[HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Entity entity = _dataRepository.Get(id);
            if (entity == null)
            {
                return NotFound("The entity record couldn't be found.");
            }

            _dataRepository.Delete(entity);
            return NoContent();
        }
    }
}