using Admin_Management_of_Blacklisted_Items.DTOs.BlacklistedItemDTO;
using Admin_Management_of_Blacklisted_Items.Models;
using Admin_Management_of_Blacklisted_Items.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Management_of_Blacklisted_Items.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistedItemController : ControllerBase
    {
        private readonly IBlacklistedItemService _service;

        public BlacklistedItemController(IBlacklistedItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlacklistedItems()
        {
            var items = await _service.GetAllBlacklistedItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlacklistedItemById(int id)
        {
            var item = await _service.GetBlacklistedItemByIdAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> AddBlacklistedItem([FromBody] CreateBlacklistedItemDTO model)
        {
            var item = await _service.AddBlacklistedItemAsync(model.Category, model.Value, model.Reason);
            return CreatedAtAction(nameof(GetBlacklistedItemById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlacklistedItem(int id, [FromBody] UpdateBlacklistedItemDTO model)
        {
            var item = new BlacklistedItem { Category = model.Category, Value = model.Value, Reason = model.Reason };
            await _service.UpdateBlacklistedItemAsync(id, item);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlacklistedItem(int id)
        {
            await _service.DeleteBlacklistedItemAsync(id);
            return NoContent();
        }
    }
}
