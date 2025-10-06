using School_ECommerce.Data.Models;

namespace School_ECommerce.Repos.Interfaces
{
    public interface ICustomerRepo
    {
        public Task<ICollection<Customer>> GetAllAsync();
        public Task<Customer> GetByIdAsync(int id);
        public void AddCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);
        public void DeleteCustomer(Customer customer);
        public Task SaveChangesAsync();
    }
}
