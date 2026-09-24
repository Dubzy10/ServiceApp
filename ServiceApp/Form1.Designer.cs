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
        dgvRequestsList = new System.Windows.Forms.DataGridView();
        tabPage3 = new System.Windows.Forms.TabPage();
        tabPage4 = new System.Windows.Forms.TabPage();
        cbTechnicians = new System.Windows.Forms.ComboBox();
        label1 = new System.Windows.Forms.Label();
        tbCreateARequest.SuspendLayout();
        tabPage1.SuspendLayout();
        tabPage2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvRequestsList).BeginInit();
        SuspendLayout();
        // 
        // tbCreateARequest
        // 
        tbCreateARequest.Controls.Add(tabPage1);
        tbCreateARequest.Controls.Add(tabPage2);
        tbCreateARequest.Controls.Add(tabPage3);
        tbCreateARequest.Controls.Add(tabPage4);
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
        tabPage2.Controls.Add(dgvRequestsList);
        tabPage2.Location = new System.Drawing.Point(4, 24);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new System.Windows.Forms.Padding(3);
        tabPage2.Size = new System.Drawing.Size(1017, 701);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Requests list";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // dgvRequestsList
        // 
        dgvRequestsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvRequestsList.Dock = System.Windows.Forms.DockStyle.Fill;
        dgvRequestsList.Location = new System.Drawing.Point(3, 3);
        dgvRequestsList.Name = "dgvRequestsList";
        dgvRequestsList.Size = new System.Drawing.Size(1011, 695);
        dgvRequestsList.TabIndex = 0;
        dgvRequestsList.Text = "dataGridView1";
        // 
        // tabPage3
        // 
        tabPage3.Location = new System.Drawing.Point(4, 24);
        tabPage3.Name = "tabPage3";
        tabPage3.Padding = new System.Windows.Forms.Padding(3);
        tabPage3.Size = new System.Drawing.Size(1017, 701);
        tabPage3.TabIndex = 2;
        tabPage3.Text = "Technicians";
        tabPage3.UseVisualStyleBackColor = true;
        // 
        // tabPage4
        // 
        tabPage4.Location = new System.Drawing.Point(4, 24);
        tabPage4.Name = "tabPage4";
        tabPage4.Padding = new System.Windows.Forms.Padding(3);
        tabPage4.Size = new System.Drawing.Size(1017, 701);
        tabPage4.TabIndex = 3;
        tabPage4.Text = "Parts";
        tabPage4.UseVisualStyleBackColor = true;
        // 
        // cbTechnicians
        // 
        cbTechnicians.FormattingEnabled = true;
        cbTechnicians.Location = new System.Drawing.Point(678, 87);
        cbTechnicians.Name = "cbTechnicians";
        cbTechnicians.Size = new System.Drawing.Size(233, 23);
        cbTechnicians.TabIndex = 22;
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
        ((System.ComponentModel.ISupportInitialize)dgvRequestsList).EndInit();
        ResumeLayout(false);
    }

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

    private System.Windows.Forms.Label label2;

    #endregion
}