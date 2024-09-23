using Admin_Management_of_Blacklisted_Items.Models;

namespace Admin_Management_of_Blacklisted_Items.Repositories
{
    public interface IBlacklistedItemRepository
    {
        Task<List<BlacklistedItem>> GetAllBlacklistedItemsAsync();
        Task<BlacklistedItem> GetBlacklistedItemByIdAsync(int itemId);
        Task<BlacklistedItem> AddBlacklistedItemAsync(BlacklistedItem item);
        Task UpdateBlacklistedItemAsync(BlacklistedItem item);
        Task DeleteBlacklistedItemAsync(int itemId);
    }
}
