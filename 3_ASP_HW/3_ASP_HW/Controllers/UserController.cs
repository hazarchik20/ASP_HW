using DLL.Models;
using DLL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _3_ASP_HW.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserRepo _userRepo;
        public UserController(UserRepo u) 
        {
            _userRepo = u;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepo.GetAllAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var createdUser = await _userRepo.AddAsync(user);
            return CreatedAtAction(nameof(Create), new { id = createdUser.Id }, createdUser);
        }
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            var updatedUser = await _userRepo.UpdateAsync(user);
            return Ok(updatedUser);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRepo.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet("name/startsWithA")]
        public async Task<IActionResult> GetUsersWithNameStartingWithA()
        {
            var users = await _userRepo.GetUsersWithNameStartingWithAAsync();
            return Ok(users);
        }
        [HttpGet("withsubscriptions")]
        public async Task<IActionResult> GetUsersWithSubscriptions()
        {
            var users = await _userRepo.GetUsersWithSubscriptionsAsync();
            return Ok(users);
        }
        [HttpGet("premium/count/{count}")]
        public async Task<IActionResult> GetUserNamesWithPremium(int count)
        {
            var userNames = await _userRepo.GetUserNamesWithPremiumAsync(count);
            return Ok(userNames);
        }
        [HttpGet("mostsubscriptions")]
        public async Task<IActionResult> GetUserWithMostSubscriptions()
        {
            var user = await _userRepo.GetUserWithMostSubscriptionsAsync();
            return Ok(user);
        }


    }
}