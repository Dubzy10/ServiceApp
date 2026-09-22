using ServiceApp.Models;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace ServiceApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        DataBaseManager.TestConnection();
    }
    
    private void lblDeviceIssue_Click(object sender, EventArgs e)
    {
    }

    private void lblDeviceForRepair_Click_1(object sender, EventArgs e)
    {
    }
    
    private void btnCreateRepairRequest_Click_1(object sender, EventArgs e)
    {
        string clientName = txtBoxClientName.Text;
        string phone = txtBoxClientPhoneNumber.Text;
        string email = txtBoxClientEmailAddress.Text;
        string device = txtBoxDeviceName.Text;
        string issue = txtBoxIssueDescription.Text;
        
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

        try
        {
            using (SqlConnection conn = DataBaseManager.GetConnection())
            {
                conn.Open();

                string insertClientQuery = @"
                    INSERT INTO  Clients (Full_Name, Phone_Number, Email)
                    OUTPUT INSERTED.ID
                    VALUES (@Full_Name, @Phone_Number, @Email);";
                
                string insertRequestQuery = @"
                    INSERT INTO REPAIR_REQUEST (Client_ID, Device_Name, Issue_Description)
                    VALUES (@Client_ID, @Device_Name, @Issue_Description);";

                int clientID = 0;

                using (SqlCommand cmd = new SqlCommand(insertClientQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Full_Name", clientName);
                    cmd.Parameters.AddWithValue("@Phone_Number", phone);
                    cmd.Parameters.AddWithValue("@Email", email);

                    clientID = (int)cmd.ExecuteScalar();
                }
                
                using (SqlCommand cmdReq = new SqlCommand(insertRequestQuery, conn))
                {
                    cmdReq.Parameters.AddWithValue("@Client_ID", clientID);
                    cmdReq.Parameters.AddWithValue("@Device_Name", device);
                    cmdReq.Parameters.AddWithValue("Issue_Description", issue);

                    cmdReq.ExecuteNonQuery();
                } 

                MessageBox.Show($"Successful client entry with ID: {clientID}!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error during client entry with {ex.Message}", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void txtBoxIssueDescription_TextChanged(object sender, EventArgs e)
    {
    }
    
    private void txtBoxDeviceName_TextChanged_1(object sender, EventArgs e)
    {
    }
}