using _2_ASP_HW.DB;
using _2_ASP_HW.DB.models;
using _2_ASP_HW.DB.services;
using Microsoft.AspNetCore.Mvc;

namespace _2_ASP_HW.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController: ControllerBase
    {
        private BookRepo _repo;
        public DopServices _dopServices;
        public BookController(BookRepo repo, DopServices dopServices)
        {
            _repo = repo;
            _dopServices = dopServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _repo.GetById(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _repo.Delete(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Book book)
        {
            book.Description = _dopServices.CheckText(book.Description);
            await _repo.Add(book);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Book book)
        {
            await _repo.Update(book);
            return Ok();
        }

    }
}
