using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using ramengo.Data;
using ramengo.Interfaces;
using ramengo.Models;

namespace ramengo.Repository
{
    public class BrothRepository : IBrothRepository
    {
        private readonly DataContext _context;

        public BrothRepository(DataContext context) 
        {
            this._context = context;
        }

        public async Task<IEnumerable<Broth>> GetAllBroths()
        {
            return await _context.Broths.ToListAsync();
        }
    }
}
