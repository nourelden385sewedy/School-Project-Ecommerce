using Microsoft.EntityFrameworkCore;
using School_ECommerce.Data;
using School_ECommerce.Data.Models;
using School_ECommerce.Repos.Interfaces;

namespace School_ECommerce.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly MyAppDbContext _context;
        public CustomerRepo(MyAppDbContext context) { _context = context; }

        public async Task<ICollection<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task<ICollection<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
