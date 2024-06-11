using Microsoft.EntityFrameworkCore;
using ramengo.Data;
using ramengo.Interfaces;
using ramengo.Models;

namespace ramengo.Repository
{
    public class ProteinRepository : IProteinRepository
    {
        public async Task<IEnumerable<Protein>> GetAllProteins()
        {
            var localStorage = DataContext.localStorage.Where(pair => pair.Value is Protein).Select(pair => (Protein)pair.Value);
            return localStorage;
        }

    }
}