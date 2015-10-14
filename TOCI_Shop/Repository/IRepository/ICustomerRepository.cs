using Repository.Models;

namespace Repository.IRepository
{
    // jeżeli będzie trzeba, ten interfejs uzupełni się dodatkowymi metodami 
    public interface ICustomerRepository : IRepository<Customer>
    {
         
    }
}