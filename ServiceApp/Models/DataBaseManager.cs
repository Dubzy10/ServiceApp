using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

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
}