
namespace MilesCarRental_UoW.Interfaces
{
    public interface IUoWAdapter : IDisposable
    {
        IUoWRepository Repositories { get; }
        void SaveChange();
    }
}
