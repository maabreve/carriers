using Carriers.Model;

namespace Carriers.Data.Contract
{
    public interface IUow
    {
        void Commit();
        IRepository<Carrier> Carriers { get; }
        IRepository<Rating> Ratings { get; }
    }
}