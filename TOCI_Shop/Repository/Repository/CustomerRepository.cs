using System.Collections.Generic;
using System.Data.Entity;
using Repository.IRepository;
using TOCI_Shop.DAL;
using TOCI_Shop.Models;

namespace Repository.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Customer> GetCustomersFromRegion()
        {
            // implementation
            return null; // to change
        }


        public Customer GetByName(string customerName)
        {
            //implementation
            return null; // to change
        }
    }
}