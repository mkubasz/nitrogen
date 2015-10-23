using System.Collections.Generic;
using TOCI_Shop.DAL;


namespace TOCI_Shop.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLoginName { get; set; }
        public string CustomerGender { get; set; }
        public virtual ICollection<Order> CustomerOrders { get; set; }
        // and so on...
    }
}