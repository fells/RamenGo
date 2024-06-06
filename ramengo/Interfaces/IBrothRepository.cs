using ramengo.Models;

namespace ramengo.Interfaces
{
    public interface IBrothRepository
    {
        ICollection<Broth> GetBroths();
    }
}
