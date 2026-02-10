using Hazar_ASP_1hw.DB.models;
using Hazar_ASP_1hw.DB.services;
using Microsoft.AspNetCore.Mvc;

namespace Hazar_ASP_1hw.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private CustomerServices _services;
        public CustomerController(CustomerServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? year)
        {
            return Ok(await _services.GetAll(year));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _services.GetById(id));
        }

        [HttpGet("unique-names")]
        public async Task<IActionResult> GetUniqueNames()
        {
            return Ok(await _services.GetAllUniqueName());
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete([FromRoute] int id)
        {
            await _services.Delete(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Customer customer)
        {
            await _services.Add(customer);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Customer customer)
        {
            await _services.Update(customer);
            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateYear([FromQuery] int year, [FromRoute] int id)
        {
            await _services.UpdateYear(id, year);
            return Ok();
        }
    }
}
