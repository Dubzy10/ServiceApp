using ServiceApp.Models;
using System.Text.RegularExpressions;

namespace ServiceApp;

public partial class Form1 : Form
{
    public List<RepairRequest> fakeDataBase = new List<RepairRequest>();
    public Form1()
    {
        InitializeComponent();
    }
    
    private void lblDeviceIssue_Click(object sender, EventArgs e)
    {
    }

    private void lblDeviceForRepair_Click_1(object sender, EventArgs e)
    {
    }
    
    private void btnCreateRepairRequest_Click_1(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtBoxClientName.Text) ||
            string.IsNullOrEmpty(txtBoxDeviceName.Text) ||
            string.IsNullOrEmpty(txtBoxClientEmailAddress.Text) ||
            string.IsNullOrEmpty(txtBoxClientPhoneNumber.Text) ||
            string.IsNullOrEmpty(txtBoxIssueDescription.Text))
        {
            MessageBox.Show("Please make sure to fill in all the required fields, before making a request!",
                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return;
        }
        
        string clientName = txtBoxClientName.Text;
        string phone = txtBoxClientPhoneNumber.Text;
        string email = txtBoxClientEmailAddress.Text;

        if (!Regex.IsMatch(phone, @"^08\d{8}$"))
        {
            MessageBox.Show("Please put in a valid phone number!", "Invalid phone number",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$"))
        {
            MessageBox.Show("Please put in a valid email address!", "Invalid email address",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            return;
        }
        
        string device = txtBoxDeviceName.Text;
        string issue = txtBoxIssueDescription.Text;

        Client currentClient = new Client(clientName, phone, email);
        RepairRequest currentRequest = new RepairRequest(currentClient, device, issue);

        fakeDataBase.Add(currentRequest);

        MessageBox.Show($"Successful repair request!\n\nClient: {clientName} has a: {device} issue.");
    }

    private void txtBoxIssueDescription_TextChanged(object sender, EventArgs e)
    {
    }
    
    private void txtBoxDeviceName_TextChanged_1(object sender, EventArgs e)
    {
    }
}