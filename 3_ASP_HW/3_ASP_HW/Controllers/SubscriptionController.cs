using DLL;
using DLL.Models;
using DLL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _3_ASP_HW.Controllers
{
    [ApiController]
    [Route("api/subscription")]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionRepo _subscriptionRepo;
        public SubscriptionController(SubscriptionRepo repo)
        {
            _subscriptionRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subscriptions = await _subscriptionRepo.GetAllAsync();
            return Ok(subscriptions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subscription = await _subscriptionRepo.GetByIdAsync(id);
            if (subscription == null) return NotFound();
            return Ok(subscription);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Subscription subscription)
        {
            var createdSubscription = await _subscriptionRepo.AddAsync(subscription);
            return CreatedAtAction(nameof(Create), new { id = createdSubscription.Id }, createdSubscription);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Subscription subscription)
        {
            var updatedSubscription = await _subscriptionRepo.UpdateAsync(subscription);
            return Ok(updatedSubscription);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _subscriptionRepo.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet("free/ended")]
        public async Task<IActionResult> CheckExpiredFreeSubscriptions()
        {
            var expiredFreeSubscriptions = await _subscriptionRepo.GetEndedFreeSubscriptionsAsync();
            return Ok(expiredFreeSubscriptions);
        }
        [HttpGet("count/bytype")]
        public async Task<IActionResult> GetSubscriptionCountByType()
        {
            var subscriptionCountByType = await _subscriptionRepo.GetSubscriptionCountByTypeAsync();
            return Ok(subscriptionCountByType);
        }
        [HttpGet("average-price")]
        public async Task<IActionResult> GetSubscriptionsAboveAveragePrice()
        {
            var subscriptionsAboveAveragePrice = await _subscriptionRepo.GetSubscriptionsAboveAveragePriceAsync();
            return Ok(subscriptionsAboveAveragePrice);
        }


    }
}
