using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HumanService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HumansController : ControllerBase
    {
        private static List<HumanModel> _humans = new List<HumanModel>
        {
            new HumanModel("Felix Gift"), new HumanModel("Felix Mirabel")
        };

        private readonly ILogger<HumansController> _logger;

        public HumansController(ILogger<HumansController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<HumanModel> Get()
        {
            return _humans;
        }

        [HttpGet]
        [Route("First")]
        public HumanModel GetFirst()
        {
            return _humans.FirstOrDefault();
        }

        [HttpPost]
        public HumanModel Post([FromBody] NewHumanModel value)
        {
            var result = new HumanModel(value.Name);
            _humans.Add(result);

            return result;
        }

        [HttpPut("{id}")]
        public HumanModel Put(Guid id, [FromBody] NewHumanModel value)
        {
            var model = _humans.FirstOrDefault(x => x.Id == id);
            if (model == null)
                throw new Exception("Id not found");

            model.Name = value.Name;
            return model;
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var model = _humans.FirstOrDefault(x => x.Id == id);
            return model != null;
        }
    }
}
