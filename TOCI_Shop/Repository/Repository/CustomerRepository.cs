using System.Collections.Generic;
using System.Data.Entity;
using Repository.IRepository;
using Repository.Models;

namespace Repository.Repository
{
    public class CustomerRepository : BaseRepository<CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<CustomerModel> GetCustomersFromRegion()
        {
            // implementation
        }


        public CustomerModel GetByName(string customerName)
        {
            //implementation
        }
    }
}