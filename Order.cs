using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApplication
{
    class Order
    {
        //public int OrderID;
        ////int CustomerID;
        //DateTime OrderDate;
        //int TotalAmount;

        public void InsertIntoOrder(SqlConnection conn)
        {
            Console.WriteLine("Enter (OrderID, CustomerID, OrderDate(MM/DD/YYYY), TotalAmount)");
            int OrderID = int.Parse(Console.ReadLine());
            int CustomerID = int.Parse(Console.ReadLine());
            DateTime OrderDate = DateTime.Parse(Console.ReadLine());
            int TotalAmount = int.Parse(Console.ReadLine());
            
            string query = "insert into Order (OrderID, CustomerID, OrderDate, TotalAmount) values (@OrderID, @CustomerID, @OrderDate, @TotalAmount)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("OrderID", OrderID);
            cmd.Parameters.AddWithValue("CustomerID", CustomerID);
            cmd.Parameters.AddWithValue("OrderDate", OrderDate);
            cmd.Parameters.AddWithValue("TotalAmount", TotalAmount);
            try
            {
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    Console.WriteLine("RECORD ADDED SUCCESSFULLY");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }

        // -----------------------------------------------------------------------------------------------------------------------------------------
        public void UpdateIntoOrder(SqlConnection conn)
        {
            Console.WriteLine("CustomerID, OrderDate, TotalAmount ??");
            string column = Console.ReadLine();
            int OrderID;
            if (column == "CustomerID")
            {
                Console.WriteLine("Enter the OrderID");
                OrderID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new Customer ID:");
                int CusID = int.Parse(Console.ReadLine());

                string query = "update Order set CustomerID = @CusID where OrderID = @OrderID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("CusID", CusID);
                cmd.Parameters.AddWithValue("OrderID", OrderID);

                try
                {
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("RECORD UPDATED SUCCESSFULLY");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            else if (column == "OrderDate")
            {
                Console.WriteLine("Enter the OrderID");
                OrderID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new Order Date:");
                DateTime OrderDate = DateTime.Parse(Console.ReadLine());

                string query = "update Order set OrderDate = @OrderDate where OrderID = @OrderID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("OrderDate", OrderDate);
                cmd.Parameters.AddWithValue("OrderID", OrderID);

                try
                {
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("RECORD UPDATED SUCCESSFULLY");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            else if (column == "TotalAmount")
            {
                Console.WriteLine("Enter the OrderID");
                OrderID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new Amount:");
                int TotalAmount = int.Parse(Console.ReadLine());

                string query = "update Order set TotalAmount = @TotalAmount where OrderID = @OrderID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("TotalAmount", TotalAmount);
                cmd.Parameters.AddWithValue("OrderID", OrderID);

                try
                {
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("RECORD UPDATED SUCCESSFULLY");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        // -----------------------------------------------------------------------------------------------------------------------------------------
        public void DeleteIntoCustomer(SqlConnection conn)
        {
            Console.WriteLine("Enter the CustomerID");
            int CusID = int.Parse(Console.ReadLine());

            string query = "delete from Customer where CustomerID = @CusID";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("CusID", CusID);

            try
            {
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    Console.WriteLine("RECORD DELETED SUCCESSFULLY");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        // -----------------------------------------------------------------------------------------------------------------------------------------
        public void DisplayCustomer(SqlConnection conn)
        {
            string query = "select * from Customer";
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("***********************************************************");
            while (reader.Read())
            {
                Console.WriteLine($"CustomerID: {reader["CustomerID"]}\nName: {reader["Name"]}\nEmail: {reader["Email"]}\nPhone: {reader["Phone"]}\nAddress: {reader["Address"]}");
                Console.WriteLine("***********************************************************");
            }
            Console.WriteLine("***********************************************************");
            reader.Close();
        }

    }
}
