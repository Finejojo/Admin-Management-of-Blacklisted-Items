using Admin_Management_of_Blacklisted_Items.Models;
using Admin_Management_of_Blacklisted_Items.Repositories;

namespace Admin_Management_of_Blacklisted_Items.Services
{
    public class BlacklistedItemService : IBlacklistedItemService
    {
        private readonly IBlacklistedItemRepository _repository;

        public BlacklistedItemService(IBlacklistedItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BlacklistedItem>> GetAllBlacklistedItemsAsync()
        {
            return await _repository.GetAllBlacklistedItemsAsync();
        }

        public async Task<BlacklistedItem> GetBlacklistedItemByIdAsync(int itemId)
        {
            return await _repository.GetBlacklistedItemByIdAsync(itemId);
        }

        public async Task<BlacklistedItem> AddBlacklistedItemAsync(string category, string value, string reason)
        {
            var item = new BlacklistedItem { Category = category, Value = value, Reason = reason };
            return await _repository.AddBlacklistedItemAsync(item);
        }

        public async Task UpdateBlacklistedItemAsync(int itemId, BlacklistedItem item)
        {
            var existingItem = await _repository.GetBlacklistedItemByIdAsync(itemId);
            if (existingItem != null)
            {
                existingItem.Category = item.Category;
                existingItem.Value = item.Value;
                existingItem.Reason = item.Reason;

                await _repository.UpdateBlacklistedItemAsync(existingItem);
            }
        }

        public async Task DeleteBlacklistedItemAsync(int itemId)
        {
            await _repository.DeleteBlacklistedItemAsync(itemId);
        }
    }
}
