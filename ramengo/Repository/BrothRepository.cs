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

        public BrothRepository(DataContext context)   // Created a constructor that receives a ConnectionContext parameter
        {
            this._context = context;
        }

        public ICollection<Broth> GetBroths()
        {
            return _context.Broths.OrderBy(b => b.Id).ToList();
        }
    }
}
