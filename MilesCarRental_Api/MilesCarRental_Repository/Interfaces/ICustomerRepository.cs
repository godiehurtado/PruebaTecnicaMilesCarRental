using MilesCarRental_Entities;

namespace MilesCarRental_Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<string> CreateAsync(Customer customer);
    }
}
