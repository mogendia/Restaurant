namespace Restaurant.Domain.Models;

public class OrderDto
{
  
   public DateTime OrderDate { get; set; }
   public double TotalAmount { get; set; }
   public string OrderStatus { get; set; } = "Pending";
    
}