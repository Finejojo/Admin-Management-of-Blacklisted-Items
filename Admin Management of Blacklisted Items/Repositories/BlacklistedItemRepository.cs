using Admin_Management_of_Blacklisted_Items.Data;
using Admin_Management_of_Blacklisted_Items.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin_Management_of_Blacklisted_Items.Repositories
{
    public class BlacklistedItemRepository : IBlacklistedItemRepository
    {
        private readonly ApplicationDbContext _context;

        public BlacklistedItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BlacklistedItem>> GetAllBlacklistedItemsAsync()
        {
            return await _context.BlacklistedItems.ToListAsync();
        }

        public async Task<BlacklistedItem> GetBlacklistedItemByIdAsync(int itemId)
        {
            return await _context.BlacklistedItems.FindAsync(itemId);
        }

        public async Task<BlacklistedItem> AddBlacklistedItemAsync(BlacklistedItem item)
        {
            _context.BlacklistedItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateBlacklistedItemAsync(BlacklistedItem item)
        {
            _context.BlacklistedItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBlacklistedItemAsync(int itemId)
        {
            var item = await _context.BlacklistedItems.FindAsync(itemId);
            if (item != null)
            {
                _context.BlacklistedItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
