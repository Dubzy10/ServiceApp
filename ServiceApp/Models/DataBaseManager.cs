using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace ServiceApp.Models;

public class DataBaseManager
{
    private static readonly string connectionString = @"Server=.;Database=ServiceAppDB;Integrated Security=True;
    Encrypt = False;";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    public static void TestConnection()
    {
        try
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                MessageBox.Show("Successful connection with Database!", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        catch (Exception e)
        {
            MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static DataTable GetAllRequests()
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();

            string query = @"
            SELECT 
                r.ID AS [Number],
                c.Full_Name AS [Name],
                c.Phone_Number AS [Phone],
                r.Device_Name AS [Device],
                r.Issue_Description AS [Description],
                ISNULL(t.Technician_Name, 'Unassigned') AS [Technician],
                r.Status AS [Status]
            FROM REPAIR_REQUEST r
            INNER JOIN CLIENTS c ON r.Client_ID = c.ID
            LEFT JOIN TECHNICIANS t ON r.Technician_ID = t.ID;";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }

    public static int CreateRepairRequest(string clientName, string phone, string email, string device, string issue, 
        int technicianId)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();

            string insertClientQuery = @"
            INSERT INTO CLIENTS (Full_Name, Phone_Number, Email)
            OUTPUT INSERTED.ID
            VALUES (@Full_Name, @Phone_Number, @Email);";

            string insertRequestQuery = @"
            INSERT INTO REPAIR_REQUEST (Client_ID, Technician_ID, Device_Name, Issue_Description)
            VALUES (@Client_ID, @Technician_ID, @Device_Name, @Issue_Description);";

            int clientId = 0;

            using (SqlCommand cmd = new SqlCommand(insertClientQuery, conn))
            {
                cmd.Parameters.AddWithValue("@Full_Name", clientName);
                cmd.Parameters.AddWithValue("@Phone_Number", phone);
                cmd.Parameters.AddWithValue("@Email", email);

                clientId = (int)cmd.ExecuteScalar();
            }

            using (SqlCommand cmdReq = new SqlCommand(insertRequestQuery, conn))
            {
                cmdReq.Parameters.AddWithValue("@Client_ID", clientId);
                cmdReq.Parameters.AddWithValue("@Technician_ID", technicianId);
                cmdReq.Parameters.AddWithValue("@Device_Name", device);
                cmdReq.Parameters.AddWithValue("@Issue_Description", issue);

                cmdReq.ExecuteNonQuery();
            }

            return clientId;
        }
    }
    
    public static DataTable GetAllTechnicians()
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            string query = "SELECT ID, Technician_Name, Technician_Type FROM TECHNICIANS";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
    
    public static int GetActiveRequestsCountForTechnician(int technicianId)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            string query = @"
            SELECT COUNT(*) 
            FROM REPAIR_REQUEST 
            WHERE Technician_ID = @Technician_ID 
              AND Status NOT IN ('finished', 'rejected');";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Technician_ID", technicianId);
                return (int)cmd.ExecuteScalar();
            }
        }
    }
    
    public static DataTable GetRequestsForComboBox()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"
                SELECT r.ID, 
                       '#' + CAST(r.ID AS NVARCHAR(10)) + ' - ' + r.Device_Name + ' (' + c.Full_Name + ')' AS Display
                FROM REPAIR_REQUEST r
                INNER JOIN CLIENTS c ON r.Client_ID = c.ID
                ORDER BY r.ID DESC";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }

    public static void AddRequestItem(int requestId, string description, decimal quantity, decimal unitPrice)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"
                INSERT INTO Items_Request (Request_ID, Items_Description, Quantity, Unit_Price)
                VALUES (@RequestId, @Description, @Quantity, @UnitPrice)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@RequestId", requestId);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
    
    public static DataTable GetItemsForRequest(int requestId)
    {   
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"
                SELECT ID, 
                       Items_Description AS [Description], 
                       Quantity, 
                       Unit_Price AS [Unit Price (€)], 
                       CAST(Quantity * Unit_Price AS DECIMAL(10,2)) AS [Line Total (€)]
                FROM Items_Request
                WHERE Request_ID = @RequestId";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@RequestId", requestId);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}