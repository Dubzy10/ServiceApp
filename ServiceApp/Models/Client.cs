namespace ServiceApp.Models;

public class Client
{
    public string ClientName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public Client(string clientName, string phoneNumber, string emailAddress)
    {
        ClientName = clientName;
        PhoneNumber = phoneNumber;
        Email = emailAddress;
    }
}