using System;
using System.Data.SqlClient;
using FoodOrderingApplication;
class MainMethod
{
    static void Main(string[] args)
    {
        // ****************************************************************
        Console.WriteLine("Connection Establishment...");
        
        var server_name = @"LAPTOP-KHQNTK3T";
        var database_name = "FoodOrderingApplication";

        // Creating the Connection String (Without Username and Password)
        string connString = @"Data Source=" + server_name + ";\nInitial Catalog=" + database_name + ";\nTrusted_Connection=True;\n\n";

        SqlConnection conn = new SqlConnection(connString);

        try
        {
            Console.WriteLine("Opening Connection...");
            conn.Open();
            Console.WriteLine("Connection Successful");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        // ****************************************************************

        Customer customer = new Customer();
        //customer.InsertIntoCustomer(conn);
        //customer.InsertIntoCustomer(conn);
        //customer.DisplayCustomer(conn);
        customer.UpdateIntoCustomer(conn);
        //customer.DeleteIntoCustomer(conn);

        //while (true)
        //{
        //    Console.WriteLine("********************************************");
        //    Console.WriteLine("FOOD ORDERING SYSTEM" +
        //        "");
        //    Console.WriteLine("********************************************");
        //}


        // ****************************************************************
        // CLosing the Connection
        Console.WriteLine("Closing the Connection...");
        conn.Close();
        // ****************************************************************
    }
}