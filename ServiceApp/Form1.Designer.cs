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
        lblDeviceForRepair = new System.Windows.Forms.Label();
        lblClientName = new System.Windows.Forms.Label();
        lblDeviceIssue = new System.Windows.Forms.Label();
        txtBoxClientName = new System.Windows.Forms.TextBox();
        txtBoxDeviceName = new System.Windows.Forms.TextBox();
        txtBoxIssueDescription = new System.Windows.Forms.TextBox();
        btnCreateRepairRequest = new System.Windows.Forms.Button();
        lblClientPhoneNumber = new System.Windows.Forms.Label();
        txtBoxClientPhoneNumber = new System.Windows.Forms.TextBox();
        txtBoxClientEmailAddress = new System.Windows.Forms.TextBox();
        lblClientEmailAddress = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // lblDeviceForRepair
        // 
        lblDeviceForRepair.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblDeviceForRepair.Location = new System.Drawing.Point(12, 206);
        lblDeviceForRepair.Name = "lblDeviceForRepair";
        lblDeviceForRepair.Size = new System.Drawing.Size(204, 44);
        lblDeviceForRepair.TabIndex = 0;
        lblDeviceForRepair.Text = "Device for repair:";
        lblDeviceForRepair.Click += lblDeviceForRepair_Click_1;
        // 
        // lblClientName
        // 
        lblClientName.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblClientName.Location = new System.Drawing.Point(12, 24);
        lblClientName.Name = "lblClientName";
        lblClientName.Size = new System.Drawing.Size(159, 39);
        lblClientName.TabIndex = 1;
        lblClientName.Text = "Client name:";
        // 
        // lblDeviceIssue
        // 
        lblDeviceIssue.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblDeviceIssue.Location = new System.Drawing.Point(12, 280);
        lblDeviceIssue.Name = "lblDeviceIssue";
        lblDeviceIssue.Size = new System.Drawing.Size(377, 39);
        lblDeviceIssue.TabIndex = 2;
        lblDeviceIssue.Text = "Describe the issue of the device: ";
        // 
        // txtBoxClientName
        // 
        txtBoxClientName.Location = new System.Drawing.Point(163, 35);
        txtBoxClientName.Name = "txtBoxClientName";
        txtBoxClientName.PlaceholderText = "Georgi Georgiev";
        txtBoxClientName.Size = new System.Drawing.Size(191, 23);
        txtBoxClientName.TabIndex = 3;
        // 
        // txtBoxDeviceName
        // 
        txtBoxDeviceName.Location = new System.Drawing.Point(212, 217);
        txtBoxDeviceName.Name = "txtBoxDeviceName";
        txtBoxDeviceName.Size = new System.Drawing.Size(177, 23);
        txtBoxDeviceName.TabIndex = 4;
        txtBoxDeviceName.TextChanged += txtBoxDeviceName_TextChanged_1;
        // 
        // txtBoxIssueDescription
        // 
        txtBoxIssueDescription.Location = new System.Drawing.Point(12, 334);
        txtBoxIssueDescription.Multiline = true;
        txtBoxIssueDescription.Name = "txtBoxIssueDescription";
        txtBoxIssueDescription.PlaceholderText = "Give as much detail as possible";
        txtBoxIssueDescription.Size = new System.Drawing.Size(808, 130);
        txtBoxIssueDescription.TabIndex = 5;
        txtBoxIssueDescription.TextChanged += txtBoxIssueDescription_TextChanged;
        // 
        // btnCreateRepairRequest
        // 
        btnCreateRepairRequest.Font = new System.Drawing.Font("Segoe UI", 12F);
        btnCreateRepairRequest.Location = new System.Drawing.Point(12, 513);
        btnCreateRepairRequest.Name = "btnCreateRepairRequest";
        btnCreateRepairRequest.Size = new System.Drawing.Size(181, 70);
        btnCreateRepairRequest.TabIndex = 6;
        btnCreateRepairRequest.Text = "Create repair request:";
        btnCreateRepairRequest.UseVisualStyleBackColor = true;
        btnCreateRepairRequest.Click += btnCreateRepairRequest_Click_1;
        // 
        // lblClientPhoneNumber
        // 
        lblClientPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblClientPhoneNumber.Location = new System.Drawing.Point(12, 88);
        lblClientPhoneNumber.Name = "lblClientPhoneNumber";
        lblClientPhoneNumber.Size = new System.Drawing.Size(250, 47);
        lblClientPhoneNumber.TabIndex = 7;
        lblClientPhoneNumber.Text = "Client phone number:";
        // 
        // txtBoxClientPhoneNumber
        // 
        txtBoxClientPhoneNumber.Location = new System.Drawing.Point(268, 99);
        txtBoxClientPhoneNumber.Name = "txtBoxClientPhoneNumber";
        txtBoxClientPhoneNumber.PlaceholderText = "08XXXXXXXX";
        txtBoxClientPhoneNumber.Size = new System.Drawing.Size(229, 23);
        txtBoxClientPhoneNumber.TabIndex = 8;
        // 
        // txtBoxClientEmailAddress
        // 
        txtBoxClientEmailAddress.Location = new System.Drawing.Point(268, 151);
        txtBoxClientEmailAddress.Name = "txtBoxClientEmailAddress";
        txtBoxClientEmailAddress.PlaceholderText = "name@email.com";
        txtBoxClientEmailAddress.Size = new System.Drawing.Size(168, 23);
        txtBoxClientEmailAddress.TabIndex = 9;
        // 
        // lblClientEmailAddress
        // 
        lblClientEmailAddress.Font = new System.Drawing.Font("Segoe UI", 18F);
        lblClientEmailAddress.Location = new System.Drawing.Point(12, 145);
        lblClientEmailAddress.Name = "lblClientEmailAddress";
        lblClientEmailAddress.Size = new System.Drawing.Size(254, 29);
        lblClientEmailAddress.TabIndex = 10;
        lblClientEmailAddress.Text = "Client Email Address:";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1025, 729);
        Controls.Add(lblClientEmailAddress);
        Controls.Add(txtBoxClientEmailAddress);
        Controls.Add(txtBoxClientPhoneNumber);
        Controls.Add(lblClientPhoneNumber);
        Controls.Add(btnCreateRepairRequest);
        Controls.Add(txtBoxIssueDescription);
        Controls.Add(txtBoxDeviceName);
        Controls.Add(txtBoxClientName);
        Controls.Add(lblDeviceIssue);
        Controls.Add(lblClientName);
        Controls.Add(lblDeviceForRepair);
        Text = "ServiceApp";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label lblClientEmailAddress;

    private System.Windows.Forms.TextBox txtBoxClientPhoneNumber;
    private System.Windows.Forms.TextBox txtBoxClientEmailAddress;

    private System.Windows.Forms.Label lblClientPhoneNumber;

    private System.Windows.Forms.Button btnCreateRepairRequest;

    private System.Windows.Forms.TextBox txtBoxClientName;
    private System.Windows.Forms.TextBox txtBoxDeviceName;
    private System.Windows.Forms.TextBox txtBoxIssueDescription;

    private System.Windows.Forms.Label lblClientName;
    private System.Windows.Forms.Label lblDeviceForRepair;

    private System.Windows.Forms.Label lblDeviceIssue;
    private System.Windows.Forms.Label label2;

    #endregion
}