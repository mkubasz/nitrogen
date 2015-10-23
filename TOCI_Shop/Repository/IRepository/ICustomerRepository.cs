using Repository.Models;
using TOCI_Shop.DAL;
using TOCI_Shop.Models;

namespace Repository.IRepository
{
    // jeżeli będzie trzeba, ten interfejs uzupełni się dodatkowymi metodami 
    public interface ICustomerRepository : IRepository<Customer>
    {
         
    }
}