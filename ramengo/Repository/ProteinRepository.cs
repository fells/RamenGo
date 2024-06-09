using Microsoft.EntityFrameworkCore;
using ramengo.Data;
using ramengo.Interfaces;
using ramengo.Models;

namespace ramengo.Repository
{
    public class ProteinRepository : IProteinRepository
    {
        private readonly DataContext _context;

        public ProteinRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Protein>> GetAllProteins()
        {
            return await _context.Proteins.ToListAsync();
        }

    }
}
