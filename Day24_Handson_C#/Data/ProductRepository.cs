using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using ProductApp.Models;

namespace ProductApp.Data
{
    public class ProductRepository
    {
        private string? connectionString;

        public ProductRepository()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        // INSERT
        public void Insert(Product p)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = p.ProductName;
                cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = p.Category;
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = p.Price;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // GET ALL
        public void GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductId"]} - {reader["ProductName"]} - {reader["Category"]} - {reader["Price"]}");
                }

                reader.Close();
            }
        }

        // UPDATE
        public void Update(Product p)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = p.ProductId;
                cmd.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = p.ProductName;
                cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = p.Category;
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = p.Price;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = id;

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}