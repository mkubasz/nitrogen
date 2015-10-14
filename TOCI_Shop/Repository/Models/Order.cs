using System;


namespace Repository.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderStatusCode { get; set; }
        public DateTime DateOrderPlaced { get; set; }
        public string OrderDetails { get; set; }
       
    }
}