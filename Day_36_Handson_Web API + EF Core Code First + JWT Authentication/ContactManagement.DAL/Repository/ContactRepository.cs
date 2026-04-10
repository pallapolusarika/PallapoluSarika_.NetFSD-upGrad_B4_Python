using Microsoft.EntityFrameworkCore;
using ContactManagement.DAL.Models;
using ContactManagement.DAL.DbContext;

namespace ContactManagement.DAL.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactInfo>> GetAllAsync()
        {
            return await _context.Contacts
                .Include(c => c.Company)
                .Include(d => d.Department)
                .ToListAsync();
        }

        public async Task<ContactInfo?> GetByIdAsync(int id)
        {
            return await _context.Contacts
                .Include(c => c.Company)
                .Include(d => d.Department)
                .FirstOrDefaultAsync(x => x.ContactId == id);
        }

        public async Task AddAsync(ContactInfo contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ContactInfo contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}
