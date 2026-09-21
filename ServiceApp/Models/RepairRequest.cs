namespace ServiceApp.Models;

public class RepairRequest
{
    public Client Client { get; set; }
    public string Device { get; set; }
    public string Issue { get; set; }

    public RepairRequest(Client client, string device, string issue)
    {
        Client = client;
        Device = device;
        Issue = issue;
    }
}