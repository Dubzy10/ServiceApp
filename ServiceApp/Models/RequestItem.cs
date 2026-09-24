namespace ServiceApp.Models;

public class RequestItem
{
    public int ID { get; set; }
    public int Request_ID { get; set; }
    public string Items_Description { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal Unit_Price { get; set; }
}