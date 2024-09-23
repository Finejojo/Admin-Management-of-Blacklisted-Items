using Admin_Management_of_Blacklisted_Items.Models;

namespace Admin_Management_of_Blacklisted_Items.Services
{
    public interface IBlacklistedItemService
    {
        Task<List<BlacklistedItem>> GetAllBlacklistedItemsAsync();
        Task<BlacklistedItem> GetBlacklistedItemByIdAsync(int itemId);
        Task<BlacklistedItem> AddBlacklistedItemAsync(string category, string value, string reason);
        Task UpdateBlacklistedItemAsync(int itemId, BlacklistedItem item);
        Task DeleteBlacklistedItemAsync(int itemId);
    }
}
