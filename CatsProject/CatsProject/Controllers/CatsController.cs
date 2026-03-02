using DLL;
using DLL.Models;
using DLL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CatsProject.Controllers
{
    [ApiController]
    [Route("api/cats")]
    public class CatsController : ControllerBase
    {
        // я завтикав і написав такі контроллери

        //private readonly CatRepository _repository;
        //public CatsController(CatRepository repo)
        //{

        //    _repository = repo;
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAll([FromQuery] int limit = 10, [FromQuery] int offset = 0, [FromQuery] string? name = null)
        //{
        //    var cats = await _repository.GetAll(limit, offset);
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        cats = cats.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        //    }
        //    return Ok(cats);
        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var cat = await _repository.GetById(id);
        //    if (cat == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(cat);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(Cat cat)
        //{
        //    var createdCat = await _repository.Add(cat);
        //    return CreatedAtAction(nameof(GetById), new { id = createdCat.Id }, createdCat);
        //}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, Cat cat)
        //{
        //    if (id != cat.Id)
        //    {
        //        return BadRequest();
        //    }
        //    var existingCat = await _repository.GetById(id);
        //    if (existingCat == null)
        //    {
        //        return NotFound();
        //    }
        //    var updatedCat = await _repository.Update(cat);
        //    return Ok(updatedCat);
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var deletedCat = await _repository.Delete(id);
        //    if (deletedCat == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(deletedCat);
        //}
    }
}
