using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnimalService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private static List<AnimalModel> _animals = new List<AnimalModel>
        {
            new AnimalModel("Lion"), new AnimalModel("Tiger")
        };

        private readonly ILogger<AnimalsController> _logger;

        public AnimalsController(ILogger<AnimalsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<AnimalModel> Get()
        {
            return _animals;
        }

        [HttpGet]
        [Route("First")]
        public AnimalModel GetFirst()
        {
            return _animals.FirstOrDefault();
        }

        [HttpPost]
        public AnimalModel Post([FromBody] NewAnimalModel value)
        {
            var result = new AnimalModel(value.Name);
            _animals.Add(result);

            return result;
        }

        [HttpPut("{id}")]
        public AnimalModel Put(Guid id, [FromBody] NewAnimalModel value)
        {
            var model = _animals.FirstOrDefault(x => x.Id == id);
            if (model == null)
                throw new Exception("Id not found");

            model.Name = value.Name;
            return model;
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var model = _animals.FirstOrDefault(x => x.Id == id);
            return model != null;
        }
    }
}
