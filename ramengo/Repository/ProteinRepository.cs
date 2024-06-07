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

        public ICollection<Protein> GetProtein()
        {
            return _context.Proteins.OrderBy(p => p.Id).ToList();
        }

}
