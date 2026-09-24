using ServiceApp.Models;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ServiceApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        DataBaseManager.TestConnection();
        LoadRequestData();
        LoadTechniciansComboBox();
    }

    private void LoadRequestData()
    {
        try
        {
            dgvRequestsList.DataSource = DataBaseManager.GetAllRequests();
            dgvRequestsList.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        catch (Exception e)
        {
            MessageBox.Show("Data loading unsuccessful: " + e.Message, "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
    
    private void lblDeviceIssue_Click(object sender, EventArgs e)
    {
    }

    private void lblDeviceForRepair_Click_1(object sender, EventArgs e)
    {
    }
    
   private void btnCreateRepairRequest_Click_1(object sender, EventArgs e)
    {
        string clientName = txtBoxClientName.Text.Trim();
        string phone = txtBoxClientPhoneNumber.Text.Trim();
        string email = txtBoxClientEmailAddress.Text.Trim();
        string device = txtBoxDeviceName.Text.Trim();
        string issue = txtBoxIssueDescription.Text.Trim();
    
        if (string.IsNullOrEmpty(clientName) ||
            string.IsNullOrEmpty(device) ||
            string.IsNullOrEmpty(email) ||
            string.IsNullOrEmpty(phone) ||
            string.IsNullOrEmpty(issue))
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
        
        if (cbTechnicians.SelectedValue == null)
        {
            MessageBox.Show("Please select a technician from the list!", "Warning", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }    

        int technicianId = Convert.ToInt32(cbTechnicians.SelectedValue);
        
        int activeCount = DataBaseManager.GetActiveRequestsCountForTechnician(technicianId);
        if (activeCount >= 5)
        {
            MessageBox.Show("This technician already has 5 active requests! Please assign another technician.", 
                "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        try
        {
            int clientID = DataBaseManager.CreateRepairRequest(clientName, phone, email, device, issue, technicianId);

            MessageBox.Show($"Successful client entry with ID: {clientID}!", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        
            LoadRequestData();
            ClearCreateRequestFields(); 
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error during client entry with {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void LoadTechniciansComboBox()
    {
        try
        {
            DataTable dt = DataBaseManager.GetAllTechnicians();
            cbTechnicians.DataSource = dt;
            cbTechnicians.DisplayMember = "Technician_Name"; 
            cbTechnicians.ValueMember = "ID";               
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error during technician entry: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void ClearCreateRequestFields()
    {
        txtBoxClientName.Clear();
        txtBoxClientPhoneNumber.Clear();
        txtBoxClientEmailAddress.Clear();
        txtBoxDeviceName.Clear();
        txtBoxIssueDescription.Clear();
        if (cbTechnicians.Items.Count > 0)
        {
            cbTechnicians.SelectedIndex = 0;
        }
    }

    private void txtBoxIssueDescription_TextChanged(object sender, EventArgs e)
    {
    }
    
    private void txtBoxDeviceName_TextChanged_1(object sender, EventArgs e)
    {
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }
}