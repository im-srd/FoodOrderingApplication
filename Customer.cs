using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApplication
{
    class Customer
    {
        //public int CustomerID;
        //string Name;
        //string Email;
        //string Phone;
        //string Address;
        
        // -----------------------------------------------------------------------------------------------------------------------------------------
        public void InsertIntoCustomer(SqlConnection conn)
        {
            Console.WriteLine("Enter (CustomerID, Name, Email, Phone, Address)");
            int CustomerID = int.Parse(Console.ReadLine());
            string Name = Console.ReadLine();
            string Email = Console.ReadLine();
            string Phone = Console.ReadLine();
            string Address = Console.ReadLine();
            
            string query = "insert into Customer (CustomerID, Name, Email, Phone, Address) values (@CustomerID, @Name, @Email, @Phone, @Address)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("CustomerID", CustomerID);
            cmd.Parameters.AddWithValue("Name", Name);
            cmd.Parameters.AddWithValue("Email", Email);
            cmd.Parameters.AddWithValue("Phone", Phone);
            cmd.Parameters.AddWithValue("Address", Address);
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
        public void UpdateIntoCustomer(SqlConnection conn)
        {
            Console.WriteLine("Name, Email, Phone, Address ??");
            string column = Console.ReadLine();
            int CusID;
            if (column == "Name")
            {
                Console.WriteLine("Enter the CustomerID");
                CusID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new Name:");
                string name = Console.ReadLine();

                string query = "update Customer set Name = @name where CustomerID = @CusID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("CusID", CusID);

                try
                {
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Console.WriteLine("RECORD UPDATED SUCCESSFULLY");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message) ;
                }
                


            } 

            else if (column == "Email")
            {
                Console.WriteLine("Enter the CustomerID");
                CusID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new Email:");
                string email = Console.ReadLine();

                string query = "update Customer set Email = @email where CustomerID = @CusID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("CusID", CusID);

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

            else if (column == "Phone")
            {
                Console.WriteLine("Enter the CustomerID");
                CusID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new Phone:");
                string phone = Console.ReadLine();

                string query = "update Customer set Phone = @phone where CustomerID = @CusID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("phone", phone);
                cmd.Parameters.AddWithValue("CusID", CusID);

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

            else if (column == "Address") 
            {
                Console.WriteLine("Enter the CustomerID");
                CusID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new Address:");
                string address = Console.ReadLine();

                string query = "update Customer set Address = @address where CustomerID = @CusID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("address", address);
                cmd.Parameters.AddWithValue("CusID", CusID);

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
