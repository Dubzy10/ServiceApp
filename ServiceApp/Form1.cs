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
        SetupStatusFilter();
        this.Load += Form1_Loaded;
    }

    private void Form1_Loaded(object sender, EventArgs e)
    {
        try
        {
            DataBaseManager.TestConnection();
            LoadRequestData();
            LoadTechniciansComboBox();
            LoadPartsRequestsComboBox();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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
            MessageBox.Show("Error during technician entry: " + ex.Message, "Error", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
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

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void textBox1_TextChanged_1(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void cbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        ApplyFilters();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        txtSearch.Clear();
        cbStatusFilter.SelectedIndex = 0;
        ApplyFilters();
    }

    private void SetupStatusFilter()
    {
        cbStatusFilter.Items.Clear();
        cbStatusFilter.Items.Add("All");
        cbStatusFilter.Items.Add("accepted");
        cbStatusFilter.Items.Add("worked on");
        cbStatusFilter.Items.Add("awaiting replacement parts");
        cbStatusFilter.Items.Add("finished");
        cbStatusFilter.Items.Add("rejected");
        cbStatusFilter.SelectedIndex = 0;
    }

    private void ApplyFilters()
    {
        if (dgvRequestsList.DataSource is not DataTable dt)
            return;

        List<string> filters = new List<string>();
        
        string search = txtSearch.Text.Trim().Replace("'", "''");
        if (!string.IsNullOrEmpty(search))
        {
            filters.Add($"([Name] LIKE '%{search}%' OR [Phone] LIKE '%{search}%' OR [Device] LIKE '%{search}%')");
        }
        
        if (cbStatusFilter.SelectedItem != null && cbStatusFilter.SelectedItem.ToString() != "All")
        {
            string selectedStatus = cbStatusFilter.SelectedItem.ToString().Replace("'", "''");
            filters.Add($"[Status] = '{selectedStatus}'");
        }
        
        dt.DefaultView.RowFilter = string.Join(" AND ", filters);
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        ApplyFilters();
    }
    
    private void LoadPartsRequestsComboBox()
    {
        try
        {
            DataTable dt = DataBaseManager.GetRequestsForComboBox();
            cbPartsRequest.DataSource = dt;
            cbPartsRequest.DisplayMember = "Display";
            cbPartsRequest.ValueMember = "ID";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error loading requests list: " + ex.Message, "Error", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }
    }

    private void RefreshPartsList()
    {
        if (cbPartsRequest.SelectedValue == null || !int.TryParse(cbPartsRequest.SelectedValue.ToString(), 
                out int requestId))
            return;

        try
        {
            DataTable dt = DataBaseManager.GetItemsForRequest(requestId);
            dgvPartsList.DataSource = dt;
            decimal total = 10.00m;
            foreach (DataRow row in dt.Rows)
            {
                total += Convert.ToDecimal(row["Line Total (€)"]);
            }

            lblTotalPrice.Text = $"Total: {total:F2} € (including 10 euros diagnostic fee)";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error loading parts: " + ex.Message, "Error", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }
    }

    private void cbPartsRequest_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshPartsList();
    }

    private void btnAddItem_Click(object sender, EventArgs e)
    {
        if (cbPartsRequest.SelectedValue == null || !int.TryParse(cbPartsRequest.SelectedValue.ToString(), out int requestId))
        {
            MessageBox.Show("Please select a request.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string itemName = txtboxItemName.Text.Trim();
        if (string.IsNullOrWhiteSpace(itemName))
        {
            MessageBox.Show("Please enter an item or part name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtboxItemName.Focus();
            return;
        }

        decimal quantity = nudQuantity.Value;
        decimal unitPrice = nudUnitPrice.Value;

        try
        {
            DataBaseManager.AddRequestItem(requestId, itemName, quantity, unitPrice);
            
            txtboxItemName.Clear();
            nudQuantity.Value = 1;
            nudUnitPrice.Value = 0.00m;
            
            RefreshPartsList();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error adding item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}