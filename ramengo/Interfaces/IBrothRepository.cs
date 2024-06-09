using ramengo.Models;

namespace ramengo.Interfaces
{
    public interface IBrothRepository
    {
        Task<IEnumerable<Broth>> GetAllBroths();
    }
}
