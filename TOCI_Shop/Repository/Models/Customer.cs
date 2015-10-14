using System.Collections.Generic;


namespace Repository.Models
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