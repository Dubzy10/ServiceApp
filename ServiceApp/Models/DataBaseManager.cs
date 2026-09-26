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
    
    public static void UpdateRequestStatus(int requestId, string newStatus)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"
            UPDATE REPAIR_REQUEST
            SET Status = @Status,
                Completion_Date = CASE 
                    WHEN @Status IN ('finished', 'rejected') THEN GETDATE()
                    ELSE NULL 
                END
            WHERE ID = @RequestId";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@RequestId", requestId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
    
    public static DataTable GetTechniciansOverview()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"
            SELECT 
                t.ID,
                t.Technician_Name AS [Name],
                t.Technician_Type AS [Specialty],
                COUNT(r.ID) AS [Active Requests]
            FROM TECHNICIANS t
            LEFT JOIN REPAIR_REQUEST r 
                ON t.ID = r.Technician_ID 
                AND r.Status NOT IN ('finished', 'rejected')
            GROUP BY t.ID, t.Technician_Name, t.Technician_Type
            ORDER BY t.ID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
    
    public static DataTable GetTechniciansReport(DateTime fromDate, DateTime toDate)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"
            SELECT 
                t.Technician_Name AS [Technician],
                r.Status AS [Status],
                COUNT(r.ID) AS [Requests Count],
                CAST(
                    ISNULL(SUM(it.PartsSum), 0) + 
                    SUM(CASE WHEN r.Status = 'finished' THEN 10.00 ELSE 0.00 END)
                    AS DECIMAL(10, 2)
                ) AS [Total Revenue (€)]
            FROM REPAIR_REQUEST r
            INNER JOIN TECHNICIANS t ON r.Technician_ID = t.ID
            LEFT JOIN (
                SELECT Request_ID, SUM(Quantity * Unit_Price) AS PartsSum
                FROM Items_Request
                GROUP BY Request_ID
            ) it ON r.ID = it.Request_ID
            WHERE CAST(r.Acceptance_Date AS DATE) >= @FromDate 
              AND CAST(r.Acceptance_Date AS DATE) <= @ToDate
            GROUP BY t.Technician_Name, r.Status
            ORDER BY t.Technician_Name, r.Status";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FromDate", fromDate.Date);
                cmd.Parameters.AddWithValue("@ToDate", toDate.Date);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
    
public static DataTable GetAllClients()
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        string query = "SELECT ID, Full_Name AS [Name], Phone_Number AS [Phone], Email FROM CLIENTS ORDER BY ID DESC";
        using (SqlCommand cmd = new SqlCommand(query, conn))
        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        {
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}

public static void AddClient(string name, string phone, string email)
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        string query = "INSERT INTO CLIENTS (Full_Name, Phone_Number, Email) VALUES (@Name, @Phone, @Email)";
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Email", email);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}

public static void UpdateClient(int clientId, string name, string phone, string email)
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        string query = "UPDATE CLIENTS SET Full_Name = @Name, Phone_Number = @Phone, Email = @Email WHERE ID = @ID";
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@ID", clientId);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Email", email);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}

public static bool DeleteClient(int clientId, out string errorMessage)
{
    errorMessage = string.Empty;
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();
        
        string checkQuery = "SELECT COUNT(*) FROM REPAIR_REQUEST WHERE Client_ID = @ID";
        using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
        {
            checkCmd.Parameters.AddWithValue("@ID", clientId);
            int count = (int)checkCmd.ExecuteScalar();
            if (count > 0)
            {
                errorMessage = "Cannot delete this client because they have existing repair requests!";
                return false;
            }
        }
        
        string deleteQuery = "DELETE FROM CLIENTS WHERE ID = @ID";
        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
        {
            deleteCmd.Parameters.AddWithValue("@ID", clientId);
            deleteCmd.ExecuteNonQuery();
        }
    }
    return true;
    }

public static int GetRequestItemsCount(int requestId)
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        string query = "SELECT COUNT(*) FROM Items_Request WHERE Request_ID = @RequestID";
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@RequestID", requestId);
            conn.Open();
            return (int)cmd.ExecuteScalar();
        }
    }
}
}