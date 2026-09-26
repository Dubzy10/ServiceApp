namespace ServiceApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tbCreateARequest = new System.Windows.Forms.TabControl();
        tabPage1 = new System.Windows.Forms.TabPage();
        label1 = new System.Windows.Forms.Label();
        cbTechnicians = new System.Windows.Forms.ComboBox();
        lblClientEmailAddress = new System.Windows.Forms.Label();
        txtBoxClientEmailAddress = new System.Windows.Forms.TextBox();
        txtBoxClientPhoneNumber = new System.Windows.Forms.TextBox();
        lblClientPhoneNumber = new System.Windows.Forms.Label();
        btnCreateRepairRequest = new System.Windows.Forms.Button();
        txtBoxIssueDescription = new System.Windows.Forms.TextBox();
        txtBoxDeviceName = new System.Windows.Forms.TextBox();
        txtBoxClientName = new System.Windows.Forms.TextBox();
        lblDeviceIssue = new System.Windows.Forms.Label();
        lblClientName = new System.Windows.Forms.Label();
        lblDeviceForRepair = new System.Windows.Forms.Label();
        tabPage2 = new System.Windows.Forms.TabPage();
        btnUpdateStatus = new System.Windows.Forms.Button();
        cbNewStatus = new System.Windows.Forms.ComboBox();
        lblChangeStatus = new System.Windows.Forms.Label();
        btnClear = new System.Windows.Forms.Button();
        cbStatusFilter = new System.Windows.Forms.ComboBox();
        lblStatus = new System.Windows.Forms.Label();
        txtSearch = new System.Windows.Forms.TextBox();
        lblSearch = new System.Windows.Forms.Label();
        dgvRequestsList = new System.Windows.Forms.DataGridView();
        tabPage3 = new System.Windows.Forms.TabPage();
        btnExportToCSV = new System.Windows.Forms.Button();
        btnGenerateReport = new System.Windows.Forms.Button();
        dtpToDate = new System.Windows.Forms.DateTimePicker();
        lblTo = new System.Windows.Forms.Label();
        dtpFromDate = new System.Windows.Forms.DateTimePicker();
        lblFrom = new System.Windows.Forms.Label();
        dgvTechniciansList = new System.Windows.Forms.DataGridView();
        tabPage4 = new System.Windows.Forms.TabPage();
        lblTotalPrice = new System.Windows.Forms.Label();
        dgvPartsList = new System.Windows.Forms.DataGridView();
        btnAddItem = new System.Windows.Forms.Button();
        nudUnitPrice = new System.Windows.Forms.NumericUpDown();
        lblUnitPrice = new System.Windows.Forms.Label();
        nudQuantity = new System.Windows.Forms.NumericUpDown();
        lblQuantity = new System.Windows.Forms.Label();
        txtboxItemName = new System.Windows.Forms.TextBox();
        lblItemPart = new System.Windows.Forms.Label();
        cbPartsRequest = new System.Windows.Forms.ComboBox();
        lblSelectRequest = new System.Windows.Forms.Label();
        tabClients = new System.Windows.Forms.TabPage();
        dgvClientsList = new System.Windows.Forms.DataGridView();
        btnClearClient = new System.Windows.Forms.Button();
        btnDeleteClient = new System.Windows.Forms.Button();
        btnUpdateClient = new System.Windows.Forms.Button();
        btnAddClient = new System.Windows.Forms.Button();
        txtClientEmail = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        txtClientPhone = new System.Windows.Forms.TextBox();
        lblClientPhone = new System.Windows.Forms.Label();
        txtClientName = new System.Windows.Forms.TextBox();
        lblCleintName = new System.Windows.Forms.Label();
        lblTechnician = new System.Windows.Forms.Label();
        cbTechnicianFilter = new System.Windows.Forms.ComboBox();
        lbltechnicians = new System.Windows.Forms.Label();
        tbCreateARequest.SuspendLayout();
        tabPage1.SuspendLayout();
        tabPage2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvRequestsList).BeginInit();
        tabPage3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvTechniciansList).BeginInit();
        tabPage4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPartsList).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudUnitPrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
        tabClients.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvClientsList).BeginInit();
        SuspendLayout();
        // 
        // tbCreateARequest
        // 
        tbCreateARequest.Controls.Add(tabPage1);
        tbCreateARequest.Controls.Add(tabPage2);
        tbCreateARequest.Controls.Add(tabPage3);
        tbCreateARequest.Controls.Add(tabPage4);
        tbCreateARequest.Controls.Add(tabClients);
        tbCreateARequest.Dock = System.Windows.Forms.DockStyle.Fill;
        tbCreateARequest.Location = new System.Drawing.Point(0, 0);
        tbCreateARequest.Name = "tbCreateARequest";
        tbCreateARequest.SelectedIndex = 0;
        tbCreateARequest.Size = new System.Drawing.Size(1025, 729);
        tbCreateARequest.TabIndex = 0;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(label1);
        tabPage1.Controls.Add(cbTechnicians);
        tabPage1.Controls.Add(lblClientEmailAddress);
        tabPage1.Controls.Add(txtBoxClientEmailAddress);
        tabPage1.Controls.Add(txtBoxClientPhoneNumber);
        tabPage1.Controls.Add(lblClientPhoneNumber);
        tabPage1.Controls.Add(btnCreateRepairRequest);
        tabPage1.Controls.Add(txtBoxIssueDescription);
        tabPage1.Controls.Add(txtBoxDeviceName);
        tabPage1.Controls.Add(txtBoxClientName);
        tabPage1.Controls.Add(lblDeviceIssue);
        tabPage1.Controls.Add(lblClientName);
        tabPage1.Controls.Add(lblDeviceForRepair);
        tabPage1.Location = new System.Drawing.Point(4, 24);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new System.Windows.Forms.Padding(3);
        tabPage1.Size = new System.Drawing.Size(1017, 701);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Create a request";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 18F);
        label1.Location = new System.Drawing.Point(678, 47);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(228, 37);
        label1.TabIndex = 23;
        label1.Text = "Techicians: ";
        // 
        // cbTechnicians
        // 
        cbTechnicians.FormattingEnabled = true;
        cbTechnicians.Location = new System.Drawing.Point(678, 87);
        cbTechnicians.Name = "cbTechnicians";
        cbTechnicians.Size = new System.Drawing.Size(233, 23);
        cbTechnicians.TabIndex = 22;
        // 
        // lblClientEmailAddress
        // 
        lblClientEmailAddress.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblClientEmailAddress.Location = new System.Drawing.Point(104, 192);
        lblClientEmailAddress.Name = "lblClientEmailAddress";
        lblClientEmailAddress.Size = new System.Drawing.Size(254, 29);
        lblClientEmailAddress.TabIndex = 21;
        lblClientEmailAddress.Text = "Client Email Address:";
        // 
        // txtBoxClientEmailAddress
        // 
        txtBoxClientEmailAddress.Location = new System.Drawing.Point(360, 198);
        txtBoxClientEmailAddress.Name = "txtBoxClientEmailAddress";
        txtBoxClientEmailAddress.PlaceholderText = "name@email.com";
        txtBoxClientEmailAddress.Size = new System.Drawing.Size(168, 23);
        txtBoxClientEmailAddress.TabIndex = 20;
        // 
        // txtBoxClientPhoneNumber
        // 
        txtBoxClientPhoneNumber.Location = new System.Drawing.Point(360, 146);
        txtBoxClientPhoneNumber.Name = "txtBoxClientPhoneNumber";
        txtBoxClientPhoneNumber.PlaceholderText = "08XXXXXXXX";
        txtBoxClientPhoneNumber.Size = new System.Drawing.Size(229, 23);
        txtBoxClientPhoneNumber.TabIndex = 19;
        // 
        // lblClientPhoneNumber
        // 
        lblClientPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblClientPhoneNumber.Location = new System.Drawing.Point(104, 135);
        lblClientPhoneNumber.Name = "lblClientPhoneNumber";
        lblClientPhoneNumber.Size = new System.Drawing.Size(250, 47);
        lblClientPhoneNumber.TabIndex = 18;
        lblClientPhoneNumber.Text = "Client phone number:";
        // 
        // btnCreateRepairRequest
        // 
        btnCreateRepairRequest.Font = new System.Drawing.Font("Segoe UI", 12F);
        btnCreateRepairRequest.Location = new System.Drawing.Point(104, 560);
        btnCreateRepairRequest.Name = "btnCreateRepairRequest";
        btnCreateRepairRequest.Size = new System.Drawing.Size(181, 70);
        btnCreateRepairRequest.TabIndex = 17;
        btnCreateRepairRequest.Text = "Create repair request:";
        btnCreateRepairRequest.UseVisualStyleBackColor = true;
        btnCreateRepairRequest.Click += btnCreateRepairRequest_Click_1;
        // 
        // txtBoxIssueDescription
        // 
        txtBoxIssueDescription.Location = new System.Drawing.Point(104, 381);
        txtBoxIssueDescription.Multiline = true;
        txtBoxIssueDescription.Name = "txtBoxIssueDescription";
        txtBoxIssueDescription.PlaceholderText = "Give as much detail as possible";
        txtBoxIssueDescription.Size = new System.Drawing.Size(808, 130);
        txtBoxIssueDescription.TabIndex = 16;
        // 
        // txtBoxDeviceName
        // 
        txtBoxDeviceName.Location = new System.Drawing.Point(304, 264);
        txtBoxDeviceName.Name = "txtBoxDeviceName";
        txtBoxDeviceName.Size = new System.Drawing.Size(177, 23);
        txtBoxDeviceName.TabIndex = 15;
        // 
        // txtBoxClientName
        // 
        txtBoxClientName.Location = new System.Drawing.Point(255, 82);
        txtBoxClientName.Name = "txtBoxClientName";
        txtBoxClientName.PlaceholderText = "Georgi Georgiev";
        txtBoxClientName.Size = new System.Drawing.Size(191, 23);
        txtBoxClientName.TabIndex = 14;
        // 
        // lblDeviceIssue
        // 
        lblDeviceIssue.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblDeviceIssue.Location = new System.Drawing.Point(104, 327);
        lblDeviceIssue.Name = "lblDeviceIssue";
        lblDeviceIssue.Size = new System.Drawing.Size(377, 39);
        lblDeviceIssue.TabIndex = 13;
        lblDeviceIssue.Text = "Describe the issue of the device: ";
        // 
        // lblClientName
        // 
        lblClientName.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblClientName.Location = new System.Drawing.Point(104, 71);
        lblClientName.Name = "lblClientName";
        lblClientName.Size = new System.Drawing.Size(159, 39);
        lblClientName.TabIndex = 12;
        lblClientName.Text = "Client name:";
        // 
        // lblDeviceForRepair
        // 
        lblDeviceForRepair.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblDeviceForRepair.Location = new System.Drawing.Point(104, 253);
        lblDeviceForRepair.Name = "lblDeviceForRepair";
        lblDeviceForRepair.Size = new System.Drawing.Size(204, 44);
        lblDeviceForRepair.TabIndex = 11;
        lblDeviceForRepair.Text = "Device for repair:";
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(lbltechnicians);
        tabPage2.Controls.Add(cbTechnicianFilter);
        tabPage2.Controls.Add(lblTechnician);
        tabPage2.Controls.Add(btnUpdateStatus);
        tabPage2.Controls.Add(cbNewStatus);
        tabPage2.Controls.Add(lblChangeStatus);
        tabPage2.Controls.Add(btnClear);
        tabPage2.Controls.Add(cbStatusFilter);
        tabPage2.Controls.Add(lblStatus);
        tabPage2.Controls.Add(txtSearch);
        tabPage2.Controls.Add(lblSearch);
        tabPage2.Controls.Add(dgvRequestsList);
        tabPage2.Location = new System.Drawing.Point(4, 24);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new System.Windows.Forms.Padding(3);
        tabPage2.Size = new System.Drawing.Size(1017, 701);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Requests list";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // btnUpdateStatus
        // 
        btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 18F);
        btnUpdateStatus.Location = new System.Drawing.Point(406, 91);
        btnUpdateStatus.Name = "btnUpdateStatus";
        btnUpdateStatus.Size = new System.Drawing.Size(179, 47);
        btnUpdateStatus.TabIndex = 8;
        btnUpdateStatus.Text = "Update status";
        btnUpdateStatus.UseVisualStyleBackColor = true;
        btnUpdateStatus.Click += btnUpdateStatus_Click;
        // 
        // cbNewStatus
        // 
        cbNewStatus.FormattingEnabled = true;
        cbNewStatus.Location = new System.Drawing.Point(591, 58);
        cbNewStatus.Name = "cbNewStatus";
        cbNewStatus.Size = new System.Drawing.Size(200, 23);
        cbNewStatus.TabIndex = 7;
        // 
        // lblChangeStatus
        // 
        lblChangeStatus.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblChangeStatus.Location = new System.Drawing.Point(406, 47);
        lblChangeStatus.Name = "lblChangeStatus";
        lblChangeStatus.Size = new System.Drawing.Size(179, 50);
        lblChangeStatus.TabIndex = 6;
        lblChangeStatus.Text = "Change status: ";
        // 
        // btnClear
        // 
        btnClear.Font = new System.Drawing.Font("Segoe UI", 18F);
        btnClear.Location = new System.Drawing.Point(8, 51);
        btnClear.Name = "btnClear";
        btnClear.Size = new System.Drawing.Size(179, 46);
        btnClear.TabIndex = 5;
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += btnClear_Click;
        // 
        // cbStatusFilter
        // 
        cbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cbStatusFilter.FormattingEnabled = true;
        cbStatusFilter.Location = new System.Drawing.Point(496, 12);
        cbStatusFilter.Name = "cbStatusFilter";
        cbStatusFilter.Size = new System.Drawing.Size(231, 23);
        cbStatusFilter.TabIndex = 4;
        cbStatusFilter.SelectedIndexChanged += cbStatusFilter_SelectedIndexChanged;
        // 
        // lblStatus
        // 
        lblStatus.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblStatus.Location = new System.Drawing.Point(406, 6);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new System.Drawing.Size(110, 29);
        lblStatus.TabIndex = 3;
        lblStatus.Text = "Status: ";
        // 
        // txtSearch
        // 
        txtSearch.Location = new System.Drawing.Point(101, 12);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new System.Drawing.Size(285, 23);
        txtSearch.TabIndex = 2;
        txtSearch.TextChanged += txtSearch_TextChanged;
        // 
        // lblSearch
        // 
        lblSearch.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblSearch.Location = new System.Drawing.Point(8, 12);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new System.Drawing.Size(102, 43);
        lblSearch.TabIndex = 1;
        lblSearch.Text = "Search: ";
        // 
        // dgvRequestsList
        // 
        dgvRequestsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvRequestsList.Location = new System.Drawing.Point(3, 271);
        dgvRequestsList.Name = "dgvRequestsList";
        dgvRequestsList.Size = new System.Drawing.Size(1011, 427);
        dgvRequestsList.TabIndex = 0;
        dgvRequestsList.Text = "dataGridView1";
        // 
        // tabPage3
        // 
        tabPage3.Controls.Add(btnExportToCSV);
        tabPage3.Controls.Add(btnGenerateReport);
        tabPage3.Controls.Add(dtpToDate);
        tabPage3.Controls.Add(lblTo);
        tabPage3.Controls.Add(dtpFromDate);
        tabPage3.Controls.Add(lblFrom);
        tabPage3.Controls.Add(dgvTechniciansList);
        tabPage3.Location = new System.Drawing.Point(4, 24);
        tabPage3.Name = "tabPage3";
        tabPage3.Padding = new System.Windows.Forms.Padding(3);
        tabPage3.Size = new System.Drawing.Size(1017, 701);
        tabPage3.TabIndex = 2;
        tabPage3.Text = "Technicians";
        tabPage3.UseVisualStyleBackColor = true;
        // 
        // btnExportToCSV
        // 
        btnExportToCSV.Font = new System.Drawing.Font("Segoe UI", 18F);
        btnExportToCSV.Location = new System.Drawing.Point(250, 102);
        btnExportToCSV.Name = "btnExportToCSV";
        btnExportToCSV.Size = new System.Drawing.Size(225, 44);
        btnExportToCSV.TabIndex = 6;
        btnExportToCSV.Text = "Export to CSV";
        btnExportToCSV.UseVisualStyleBackColor = true;
        btnExportToCSV.Click += btnExportToCSV_Click;
        // 
        // btnGenerateReport
        // 
        btnGenerateReport.Font = new System.Drawing.Font("Segoe UI", 18F);
        btnGenerateReport.Location = new System.Drawing.Point(3, 102);
        btnGenerateReport.Name = "btnGenerateReport";
        btnGenerateReport.Size = new System.Drawing.Size(230, 45);
        btnGenerateReport.TabIndex = 5;
        btnGenerateReport.Text = "Generate report";
        btnGenerateReport.UseVisualStyleBackColor = true;
        btnGenerateReport.Click += btnGenerateReport_Click;
        // 
        // dtpToDate
        // 
        dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        dtpToDate.Location = new System.Drawing.Point(116, 47);
        dtpToDate.Name = "dtpToDate";
        dtpToDate.Size = new System.Drawing.Size(113, 23);
        dtpToDate.TabIndex = 4;
        // 
        // lblTo
        // 
        lblTo.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblTo.Location = new System.Drawing.Point(116, 3);
        lblTo.Name = "lblTo";
        lblTo.Size = new System.Drawing.Size(113, 32);
        lblTo.TabIndex = 3;
        lblTo.Text = "To:";
        // 
        // dtpFromDate
        // 
        dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        dtpFromDate.Location = new System.Drawing.Point(3, 47);
        dtpFromDate.Name = "dtpFromDate";
        dtpFromDate.Size = new System.Drawing.Size(107, 23);
        dtpFromDate.TabIndex = 2;
        // 
        // lblFrom
        // 
        lblFrom.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblFrom.Location = new System.Drawing.Point(6, 3);
        lblFrom.Name = "lblFrom";
        lblFrom.Size = new System.Drawing.Size(75, 32);
        lblFrom.TabIndex = 1;
        lblFrom.Text = "From: ";
        // 
        // dgvTechniciansList
        // 
        dgvTechniciansList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvTechniciansList.Location = new System.Drawing.Point(3, 189);
        dgvTechniciansList.Name = "dgvTechniciansList";
        dgvTechniciansList.Size = new System.Drawing.Size(1018, 515);
        dgvTechniciansList.TabIndex = 0;
        dgvTechniciansList.Text = "dataGridView1";
        // 
        // tabPage4
        // 
        tabPage4.Controls.Add(lblTotalPrice);
        tabPage4.Controls.Add(dgvPartsList);
        tabPage4.Controls.Add(btnAddItem);
        tabPage4.Controls.Add(nudUnitPrice);
        tabPage4.Controls.Add(lblUnitPrice);
        tabPage4.Controls.Add(nudQuantity);
        tabPage4.Controls.Add(lblQuantity);
        tabPage4.Controls.Add(txtboxItemName);
        tabPage4.Controls.Add(lblItemPart);
        tabPage4.Controls.Add(cbPartsRequest);
        tabPage4.Controls.Add(lblSelectRequest);
        tabPage4.Location = new System.Drawing.Point(4, 24);
        tabPage4.Name = "tabPage4";
        tabPage4.Padding = new System.Windows.Forms.Padding(3);
        tabPage4.Size = new System.Drawing.Size(1017, 701);
        tabPage4.TabIndex = 3;
        tabPage4.Text = "Parts";
        tabPage4.UseVisualStyleBackColor = true;
        // 
        // lblTotalPrice
        // 
        lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblTotalPrice.Location = new System.Drawing.Point(25, 605);
        lblTotalPrice.Name = "lblTotalPrice";
        lblTotalPrice.Size = new System.Drawing.Size(311, 76);
        lblTotalPrice.TabIndex = 10;
        lblTotalPrice.Text = "Total: 10.00 (including 10 euros diagnostic fee)";
        // 
        // dgvPartsList
        // 
        dgvPartsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPartsList.Location = new System.Drawing.Point(0, 264);
        dgvPartsList.Name = "dgvPartsList";
        dgvPartsList.Size = new System.Drawing.Size(1016, 326);
        dgvPartsList.TabIndex = 9;
        dgvPartsList.Text = "dataGridView1";
        // 
        // btnAddItem
        // 
        btnAddItem.Font = new System.Drawing.Font("Segoe UI", 18F);
        btnAddItem.Location = new System.Drawing.Point(25, 160);
        btnAddItem.Name = "btnAddItem";
        btnAddItem.Size = new System.Drawing.Size(210, 69);
        btnAddItem.TabIndex = 8;
        btnAddItem.Text = "Add Item";
        btnAddItem.UseVisualStyleBackColor = true;
        btnAddItem.Click += btnAddItem_Click;
        // 
        // nudUnitPrice
        // 
        nudUnitPrice.DecimalPlaces = 2;
        nudUnitPrice.Location = new System.Drawing.Point(626, 56);
        nudUnitPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        nudUnitPrice.Name = "nudUnitPrice";
        nudUnitPrice.Size = new System.Drawing.Size(167, 23);
        nudUnitPrice.TabIndex = 7;
        // 
        // lblUnitPrice
        // 
        lblUnitPrice.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblUnitPrice.Location = new System.Drawing.Point(627, 14);
        lblUnitPrice.Name = "lblUnitPrice";
        lblUnitPrice.Size = new System.Drawing.Size(166, 38);
        lblUnitPrice.TabIndex = 6;
        lblUnitPrice.Text = "Unit price: ";
        // 
        // nudQuantity
        // 
        nudQuantity.Location = new System.Drawing.Point(426, 57);
        nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudQuantity.Name = "nudQuantity";
        nudQuantity.Size = new System.Drawing.Size(179, 23);
        nudQuantity.TabIndex = 5;
        nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // lblQuantity
        // 
        lblQuantity.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblQuantity.Location = new System.Drawing.Point(425, 13);
        lblQuantity.Name = "lblQuantity";
        lblQuantity.Size = new System.Drawing.Size(167, 33);
        lblQuantity.TabIndex = 4;
        lblQuantity.Text = "Quantity: ";
        // 
        // txtboxItemName
        // 
        txtboxItemName.Location = new System.Drawing.Point(235, 56);
        txtboxItemName.Name = "txtboxItemName";
        txtboxItemName.Size = new System.Drawing.Size(168, 23);
        txtboxItemName.TabIndex = 3;
        // 
        // lblItemPart
        // 
        lblItemPart.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblItemPart.Location = new System.Drawing.Point(236, 14);
        lblItemPart.Name = "lblItemPart";
        lblItemPart.Size = new System.Drawing.Size(168, 33);
        lblItemPart.TabIndex = 2;
        lblItemPart.Text = "Item/Part: ";
        // 
        // cbPartsRequest
        // 
        cbPartsRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cbPartsRequest.FormattingEnabled = true;
        cbPartsRequest.Location = new System.Drawing.Point(8, 56);
        cbPartsRequest.Name = "cbPartsRequest";
        cbPartsRequest.Size = new System.Drawing.Size(187, 23);
        cbPartsRequest.TabIndex = 1;
        cbPartsRequest.SelectedIndexChanged += cbPartsRequest_SelectedIndexChanged;
        // 
        // lblSelectRequest
        // 
        lblSelectRequest.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblSelectRequest.Location = new System.Drawing.Point(8, 14);
        lblSelectRequest.Name = "lblSelectRequest";
        lblSelectRequest.Size = new System.Drawing.Size(192, 39);
        lblSelectRequest.TabIndex = 0;
        lblSelectRequest.Text = "Select Request: ";
        // 
        // tabClients
        // 
        tabClients.Controls.Add(dgvClientsList);
        tabClients.Controls.Add(btnClearClient);
        tabClients.Controls.Add(btnDeleteClient);
        tabClients.Controls.Add(btnUpdateClient);
        tabClients.Controls.Add(btnAddClient);
        tabClients.Controls.Add(txtClientEmail);
        tabClients.Controls.Add(label2);
        tabClients.Controls.Add(txtClientPhone);
        tabClients.Controls.Add(lblClientPhone);
        tabClients.Controls.Add(txtClientName);
        tabClients.Controls.Add(lblCleintName);
        tabClients.Location = new System.Drawing.Point(4, 24);
        tabClients.Name = "tabClients";
        tabClients.Padding = new System.Windows.Forms.Padding(3);
        tabClients.Size = new System.Drawing.Size(1017, 701);
        tabClients.TabIndex = 4;
        tabClients.Text = "Clients";
        tabClients.UseVisualStyleBackColor = true;
        // 
        // dgvClientsList
        // 
        dgvClientsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvClientsList.Location = new System.Drawing.Point(494, 1);
        dgvClientsList.Name = "dgvClientsList";
        dgvClientsList.ReadOnly = true;
        dgvClientsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvClientsList.Size = new System.Drawing.Size(526, 703);
        dgvClientsList.TabIndex = 10;
        dgvClientsList.Text = "dataGridView1";
        // 
        // btnClearClient
        // 
        btnClearClient.Font = new System.Drawing.Font("Segoe UI", 18F);
        btnClearClient.Location = new System.Drawing.Point(25, 451);
        btnClearClient.Name = "btnClearClient";
        btnClearClient.Size = new System.Drawing.Size(153, 62);
        btnClearClient.TabIndex = 9;
        btnClearClient.Text = "Clear";
        btnClearClient.UseVisualStyleBackColor = true;
        // 
        // btnDeleteClient
        // 
        btnDeleteClient.Font = new System.Drawing.Font("Segoe UI", 18F);
        btnDeleteClient.Location = new System.Drawing.Point(22, 350);
        btnDeleteClient.Name = "btnDeleteClient";
        btnDeleteClient.Size = new System.Drawing.Size(156, 73);
        btnDeleteClient.TabIndex = 8;
        btnDeleteClient.Text = "Delete client";
        btnDeleteClient.UseVisualStyleBackColor = true;
        // 
        // btnUpdateClient
        // 
        btnUpdateClient.Font = new System.Drawing.Font("Segoe UI", 18F);
        btnUpdateClient.Location = new System.Drawing.Point(22, 246);
        btnUpdateClient.Name = "btnUpdateClient";
        btnUpdateClient.Size = new System.Drawing.Size(157, 77);
        btnUpdateClient.TabIndex = 7;
        btnUpdateClient.Text = "Update client";
        btnUpdateClient.UseVisualStyleBackColor = true;
        btnUpdateClient.Click += button2_Click;
        // 
        // btnAddClient
        // 
        btnAddClient.Font = new System.Drawing.Font("Segoe UI", 18F);
        btnAddClient.Location = new System.Drawing.Point(20, 166);
        btnAddClient.Name = "btnAddClient";
        btnAddClient.Size = new System.Drawing.Size(159, 58);
        btnAddClient.TabIndex = 6;
        btnAddClient.Text = "Add client";
        btnAddClient.UseVisualStyleBackColor = true;
        // 
        // txtClientEmail
        // 
        txtClientEmail.Location = new System.Drawing.Point(215, 109);
        txtClientEmail.Name = "txtClientEmail";
        txtClientEmail.Size = new System.Drawing.Size(220, 23);
        txtClientEmail.TabIndex = 5;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 18F);
        label2.Location = new System.Drawing.Point(30, 102);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(179, 41);
        label2.TabIndex = 4;
        label2.Text = "E-mail address: ";
        // 
        // txtClientPhone
        // 
        txtClientPhone.Location = new System.Drawing.Point(215, 61);
        txtClientPhone.Name = "txtClientPhone";
        txtClientPhone.Size = new System.Drawing.Size(148, 23);
        txtClientPhone.TabIndex = 3;
        // 
        // lblClientPhone
        // 
        lblClientPhone.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblClientPhone.Location = new System.Drawing.Point(22, 61);
        lblClientPhone.Name = "lblClientPhone";
        lblClientPhone.Size = new System.Drawing.Size(187, 45);
        lblClientPhone.TabIndex = 2;
        lblClientPhone.Text = "Phone number:";
        // 
        // txtClientName
        // 
        txtClientName.Location = new System.Drawing.Point(175, 26);
        txtClientName.Name = "txtClientName";
        txtClientName.Size = new System.Drawing.Size(188, 23);
        txtClientName.TabIndex = 1;
        // 
        // lblCleintName
        // 
        lblCleintName.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblCleintName.Location = new System.Drawing.Point(18, 15);
        lblCleintName.Name = "lblCleintName";
        lblCleintName.Size = new System.Drawing.Size(161, 40);
        lblCleintName.TabIndex = 0;
        lblCleintName.Text = "Client Name: ";
        // 
        // lblTechnician
        // 
        lblTechnician.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblTechnician.Location = new System.Drawing.Point(10, 112);
        lblTechnician.Name = "lblTechnician";
        lblTechnician.Size = new System.Drawing.Size(135, 34);
        lblTechnician.TabIndex = 9;
        // 
        // cbTechnicianFilter
        // 
        cbTechnicianFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cbTechnicianFilter.FormattingEnabled = true;
        cbTechnicianFilter.Location = new System.Drawing.Point(166, 133);
        cbTechnicianFilter.Name = "cbTechnicianFilter";
        cbTechnicianFilter.Size = new System.Drawing.Size(156, 23);
        cbTechnicianFilter.TabIndex = 10;
        // 
        // lbltechnicians
        // 
        lbltechnicians.Font = new System.Drawing.Font("Segoe UI", 18F);
        lbltechnicians.Location = new System.Drawing.Point(11, 122);
        lbltechnicians.Name = "lbltechnicians";
        lbltechnicians.Size = new System.Drawing.Size(149, 34);
        lbltechnicians.TabIndex = 11;
        lbltechnicians.Text = "Technicians: ";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1025, 729);
        Controls.Add(tbCreateARequest);
        Text = "ServiceApp";
        tbCreateARequest.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        tabPage1.PerformLayout();
        tabPage2.ResumeLayout(false);
        tabPage2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvRequestsList).EndInit();
        tabPage3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvTechniciansList).EndInit();
        tabPage4.ResumeLayout(false);
        tabPage4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPartsList).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudUnitPrice).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
        tabClients.ResumeLayout(false);
        tabClients.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvClientsList).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label lbltechnicians;

    private System.Windows.Forms.ComboBox cbTechnicianFilter;

    private System.Windows.Forms.Label lblTechnician;

    private System.Windows.Forms.DataGridView dgvClientsList;

    private System.Windows.Forms.Button btnClearClient;

    private System.Windows.Forms.Button btnDeleteClient;

    private System.Windows.Forms.TextBox txtClientName;
    private System.Windows.Forms.Label lblClientPhone;
    private System.Windows.Forms.TextBox txtClientPhone;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtClientEmail;
    private System.Windows.Forms.Button btnAddClient;
    private System.Windows.Forms.Button btnUpdateClient;

    private System.Windows.Forms.Label lblCleintName;

    private System.Windows.Forms.TabPage tabClients;

    private System.Windows.Forms.Button btnGenerateReport;
    private System.Windows.Forms.Button btnExportToCSV;

    private System.Windows.Forms.DateTimePicker dtpToDate;

    private System.Windows.Forms.Label lblTo;

    private System.Windows.Forms.DateTimePicker dtpFromDate;

    private System.Windows.Forms.Label lblFrom;

    private System.Windows.Forms.DataGridView dgvTechniciansList;

    private System.Windows.Forms.Button btnUpdateStatus;

    private System.Windows.Forms.ComboBox cbNewStatus;

    private System.Windows.Forms.Label lblChangeStatus;

    private System.Windows.Forms.DataGridView dgvPartsList;
    private System.Windows.Forms.Label lblTotalPrice;

    private System.Windows.Forms.Label lblQuantity;
    private System.Windows.Forms.NumericUpDown nudQuantity;
    private System.Windows.Forms.Label lblUnitPrice;
    private System.Windows.Forms.NumericUpDown nudUnitPrice;
    private System.Windows.Forms.Button btnAddItem;

    private System.Windows.Forms.TextBox txtboxItemName;

    private System.Windows.Forms.Label lblItemPart;

    private System.Windows.Forms.ComboBox cbPartsRequest;

    private System.Windows.Forms.Label lblSelectRequest;

    private System.Windows.Forms.Button btnClear;

    private System.Windows.Forms.ComboBox cbStatusFilter;

    private System.Windows.Forms.Label lblStatus;

    private System.Windows.Forms.TextBox txtSearch;

    private System.Windows.Forms.ComboBox cbTechnicians;
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.DataGridView dgvRequestsList;

    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TabPage tabPage4;

    private System.Windows.Forms.Label lblClientEmailAddress;
    private System.Windows.Forms.TextBox txtBoxClientEmailAddress;
    private System.Windows.Forms.TextBox txtBoxClientPhoneNumber;
    private System.Windows.Forms.Label lblClientPhoneNumber;
    private System.Windows.Forms.Button btnCreateRepairRequest;
    private System.Windows.Forms.TextBox txtBoxIssueDescription;
    private System.Windows.Forms.TextBox txtBoxDeviceName;
    private System.Windows.Forms.TextBox txtBoxClientName;
    private System.Windows.Forms.Label lblDeviceIssue;
    private System.Windows.Forms.Label lblClientName;
    private System.Windows.Forms.Label lblDeviceForRepair;

    private System.Windows.Forms.TabControl tbCreateARequest;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;

    private System.Windows.Forms.Label lblSearch;

    #endregion
}