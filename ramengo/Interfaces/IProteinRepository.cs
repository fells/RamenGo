using ramengo.Models;

namespace ramengo.Interfaces
{
    public interface IProteinRepository
    {
        ICollection<Protein> GetProtein();
    }
}
