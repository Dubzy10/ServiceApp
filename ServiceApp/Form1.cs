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
            SetupNewStatusOptions();
            LoadTechniciansOverview();
            LoadClientsData();
            
            cbTechnicianFilter.Items.Clear();
            cbTechnicianFilter.Items.Add("All");

            DataTable dtTechs = DataBaseManager.GetAllTechnicians(); 
            foreach (DataRow row in dtTechs.Rows)
            {
                cbTechnicianFilter.Items.Add(row["Name"].ToString());
            }

            cbTechnicianFilter.SelectedIndex = 0;
            
            dgvRequestsList.SelectionChanged += dgvRequestsList_SelectionChanged;
            dgvClientsList.SelectionChanged += dgvClientsList_SelectionChanged;
            btnDeleteClient.Click += btnDeleteClient_Click;
            btnClearClient.Click += btnClearClient_Click;
            btnAddClient.Click += btnAddClient_Click;
            cbTechnicianFilter.SelectedIndexChanged += (s, ev) => ApplyFilters();
            cbStatusFilter.SelectedIndexChanged += (s, ev) => ApplyFilters();
            txtSearch.TextChanged += (s, ev) => ApplyFilters();
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
            LoadPartsRequestsComboBox(); 
            LoadTechniciansOverview();
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
    
    private void SetupNewStatusOptions()
    {
        cbNewStatus.Items.Clear();
        cbNewStatus.Items.Add("accepted");
        cbNewStatus.Items.Add("worked on");
        cbNewStatus.Items.Add("awaiting replacement parts");
        cbNewStatus.Items.Add("finished");
        cbNewStatus.Items.Add("rejected");
        cbNewStatus.SelectedIndex = 0;
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
        
        if (cbTechnicianFilter.SelectedItem != null && cbTechnicianFilter.SelectedItem.ToString() != "All")
        {
            string selectedTech = cbTechnicianFilter.SelectedItem.ToString().Replace("'", "''");
            filters.Add($"[Technician] = '{selectedTech}'");
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
        if (cbPartsRequest.SelectedValue == null || !int.TryParse(cbPartsRequest.SelectedValue.ToString(), 
                out int requestId))
        {
            MessageBox.Show("Please select a request.", "Validation", MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
            return;
        }

        string itemName = txtboxItemName.Text.Trim();
        if (string.IsNullOrWhiteSpace(itemName))
        {
            MessageBox.Show("Please enter an item or part name.", "Validation", MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
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
            MessageBox.Show("Error adding item: " + ex.Message, "Error", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }
    }
    
    private void dgvRequestsList_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvRequestsList.SelectedRows.Count > 0)
        {
            var row = dgvRequestsList.SelectedRows[0];
            if (row.Cells["Status"].Value != null)
            {
                string currentStatus = row.Cells["Status"].Value.ToString().Trim();
                cbNewStatus.SelectedItem = currentStatus;
                bool isFinished = currentStatus.Equals("finished", StringComparison.OrdinalIgnoreCase);
                btnUpdateStatus.Enabled = !isFinished;
                cbNewStatus.Enabled = !isFinished;
            }
        }
        else
        {
            btnUpdateStatus.Enabled = false;
            cbNewStatus.Enabled = false;
        }
    }

    private void btnUpdateStatus_Click(object sender, EventArgs e)
    {
        if (dgvRequestsList.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select a request from the table first.", "Info", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        int requestId = Convert.ToInt32(dgvRequestsList.SelectedRows[0].Cells["Number"].Value);
        string newStatus = cbNewStatus.SelectedItem?.ToString();

        if (string.IsNullOrEmpty(newStatus))
        {
            MessageBox.Show("Please select a status from the dropdown!", "Warning", MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
            return;
        }    
        
        if (newStatus == "finished")
        {
            int itemsCount = DataBaseManager.GetRequestItemsCount(requestId);
            if (itemsCount == 0)
            {
                MessageBox.Show("The request cannot be finished because no parts or services have been added to it!"
                    , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        try
        {
            DataBaseManager.UpdateRequestStatus(requestId, newStatus);
            LoadRequestData(); 
            LoadTechniciansOverview();
            MessageBox.Show("Status updated successfully!", "Success", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error updating status: " + ex.Message, "Error", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }    
    }
    
    private void LoadTechniciansOverview()
    {
        try
        {
            DataTable dt = DataBaseManager.GetTechniciansOverview();
            dgvTechniciansList.DataSource = dt;
            dgvTechniciansList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error loading technicians: " + ex.Message, "Error", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }
    }

    private void btnGenerateReport_Click(object sender, EventArgs e)
    {
        DateTime fromDate = dtpFromDate.Value.Date;
        DateTime toDate = dtpToDate.Value.Date;

        if (fromDate > toDate)
        {
            MessageBox.Show("Start date cannot be after end date.", "Validation", MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
            return;
        }

        try
        {
            DataTable dt = DataBaseManager.GetTechniciansReport(fromDate, toDate);
            dgvTechniciansList.DataSource = dt;
            dgvTechniciansList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No records found for the selected period.", "Info", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error generating report: " + ex.Message, "Error", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }
    }

    private void btnExportToCSV_Click(object sender, EventArgs e)
    {
        if (dgvTechniciansList.Rows.Count == 0)
        {
            MessageBox.Show("There is no data to export. Please generate a report first.", "Warning", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using (SaveFileDialog sfd = new SaveFileDialog())
        {
            sfd.Filter = "CSV Files (*.csv)|*.csv";
            sfd.FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmm}.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, 
                               System.Text.Encoding.UTF8))
                    {
                        string[] columnNames = dgvTechniciansList.Columns
                            .Cast<DataGridViewColumn>()
                            .Select(column => $"\"{column.HeaderText}\"")
                            .ToArray();
                        sw.WriteLine(string.Join(";", columnNames));
                        
                        foreach (DataGridViewRow row in dgvTechniciansList.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string[] fields = row.Cells
                                    .Cast<DataGridViewCell>()
                                    .Select(cell => $"\"{cell.Value?.ToString() ?? ""}\"")
                                    .ToArray();
                                sw.WriteLine(string.Join(";", fields));
                            }
                        }
                    }

                    MessageBox.Show("Report exported successfully to CSV!", "Success", MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting CSV: " + ex.Message, "Error", MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
        }
    }
    
    private void LoadClientsData()
    {
        try
        {
            DataTable dt = DataBaseManager.GetAllClients();
            dgvClientsList.DataSource = dt;
            dgvClientsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error loading clients: " + ex.Message, "Error", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }
    }

    private void ClearClientFields()
    {
        txtClientName.Clear();
        txtClientPhone.Clear();
        txtClientEmail.Clear();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        if (dgvClientsList.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select a client from the table to edit.", "Warning", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int clientId = Convert.ToInt32(dgvClientsList.SelectedRows[0].Cells["ID"].Value);
        string name = txtClientName.Text.Trim();
        string phone = txtClientPhone.Text.Trim();
        string email = txtClientEmail.Text.Trim();

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
        {
            MessageBox.Show("Fields cannot be empty!", "Warning", MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
            return;
        }

        if (!Regex.IsMatch(phone, @"^08\d{8}$"))
        {
            MessageBox.Show("Please enter a valid phone number (e.g. 08xxxxxxxx)!", "Warning", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$"))
        {
            MessageBox.Show("Please enter a valid email address!", "Warning", MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
            return;
        }

        try
        {
            DataBaseManager.UpdateClient(clientId, name, phone, email);
            LoadClientsData();
            LoadRequestData(); 
            MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error updating client: " + ex.Message, "Error", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }
    }
    
    private void dgvClientsList_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvClientsList.SelectedRows.Count > 0)
        {
            var row = dgvClientsList.SelectedRows[0];
            txtClientName.Text = row.Cells["Name"].Value?.ToString() ?? "";
            txtClientPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
            txtClientEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
        }
    }
    
    private void btnAddClient_Click(object sender, EventArgs e)
    {
        string name = txtClientName.Text.Trim();
        string phone = txtClientPhone.Text.Trim();
        string email = txtClientEmail.Text.Trim();

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
        {
            MessageBox.Show("Please fill in all client fields!", "Warning", MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
            return;
        }

        if (!Regex.IsMatch(phone, @"^08\d{8}$"))
        {
            MessageBox.Show("Please enter a valid phone number (e.g. 08xxxxxxxx)!", "Warning", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$"))
        {
            MessageBox.Show("Please enter a valid email address!", "Warning", MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
            return;
        }

        try
        {
            DataBaseManager.AddClient(name, phone, email);
            LoadClientsData();
            ClearClientFields();
            MessageBox.Show("Client added successfully!", "Success", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error adding client: " + ex.Message, "Error", MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }
    }
    
   private void btnUpdateClient_Click(object sender, EventArgs e)
{
    if (dgvClientsList.SelectedRows.Count == 0)
    {
        MessageBox.Show("Please select a client from the table to edit.", "Warning", 
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    int clientId = Convert.ToInt32(dgvClientsList.SelectedRows[0].Cells["ID"].Value);
    string name = txtClientName.Text.Trim();
    string phone = txtClientPhone.Text.Trim();
    string email = txtClientEmail.Text.Trim();

    if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
    {
        MessageBox.Show("Fields cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    if (!Regex.IsMatch(phone, @"^08\d{8}$"))
    {
        MessageBox.Show("Please enter a valid phone number (e.g. 08xxxxxxxx)!", "Warning", 
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$"))
    {
        MessageBox.Show("Please enter a valid email address!", "Warning", MessageBoxButtons.OK, 
            MessageBoxIcon.Warning);
        return;
    }

    try
    {
        DataBaseManager.UpdateClient(clientId, name, phone, email);
        LoadClientsData();
        LoadRequestData(); 
        MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, 
            MessageBoxIcon.Information);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error updating client: " + ex.Message, "Error", MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}

private void btnDeleteClient_Click(object sender, EventArgs e)
{
    if (dgvClientsList.SelectedRows.Count == 0)
    {
        MessageBox.Show("Please select a client to delete.", "Warning", MessageBoxButtons.OK, 
            MessageBoxIcon.Warning);
        return;
    }

    int clientId = Convert.ToInt32(dgvClientsList.SelectedRows[0].Cells["ID"].Value);
    string clientName = dgvClientsList.SelectedRows[0].Cells["Name"].Value.ToString();

    var confirm = MessageBox.Show($"Are you sure you want to delete client '{clientName}'?", 
        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    if (confirm != DialogResult.Yes) return;

    try
    {
        if (DataBaseManager.DeleteClient(clientId, out string errorMsg))
        {
            LoadClientsData();
            ClearClientFields();
            MessageBox.Show("Client deleted successfully!", "Success", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show(errorMsg, "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error deleting client: " + ex.Message, "Error", MessageBoxButtons.OK, 
            MessageBoxIcon.Error);
    }
}
    
    private void btnClearClient_Click(object sender, EventArgs e)
    {
        ClearClientFields();
    }
    
    private void LoadTechniciansFilter()
    {
        cbTechnicianFilter.Items.Clear();
        cbTechnicianFilter.Items.Add("All");
        
        DataTable dtTechnicians = DataBaseManager.GetAllTechnicians(); 
        foreach (DataRow row in dtTechnicians.Rows)
        {
            cbTechnicianFilter.Items.Add(row["Name"].ToString());
        }

        cbTechnicianFilter.SelectedIndex = 0; 
    }
}