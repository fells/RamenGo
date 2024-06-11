using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using ramengo.Data;
using ramengo.Interfaces;
using ramengo.Models;

namespace ramengo.Repository
{
    public class BrothRepository : IBrothRepository
    {

        public async Task<IEnumerable<Broth>> GetAllBroths()
        {
            var localStorage = DataContext.localStorage.Where(pair => pair.Value is Broth).Select(pair => (Broth) pair.Value);
            return localStorage;
        }
    }
}