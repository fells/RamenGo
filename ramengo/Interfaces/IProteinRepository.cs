using ramengo.Models;

namespace ramengo.Interfaces
{
    public interface IProteinRepository
    {
        Task<IEnumerable<Protein>> GetAllProteins();
    }
}
