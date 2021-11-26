using Microsoft.Extensions.Configuration;
using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace ShopBridge.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly string _connectionString;
        private readonly string _insertProductSP;
        private readonly string _getAllProductSP;
        private readonly string _deleteProductSP;
        private readonly string _updateProductSP;
        public InventoryService(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionString");
            _insertProductSP = configuration.GetValue<string>("insertsp");
            _getAllProductSP = configuration.GetValue<string>("getallsp");
            _updateProductSP = configuration.GetValue<string>("updatesp");
            _deleteProductSP = configuration.GetValue<string>("deletesp");
        }

        /// <summary>
        /// Add a product into the database.
        /// </summary>
        /// <param name="product">Object of product to be inserted.</param>
        /// <returns>return true for success, otherwise false</returns>
        public bool AddProduct(Product product)
        {
            bool flag = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(_insertProductSP, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = product.ProductName;
                        cmd.Parameters.Add("@ProductDescription", SqlDbType.NVarChar).Value = product.ProductDescription;
                        cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = product.Price;
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            flag = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        /// <summary>
        /// Remove a product from the database.
        /// </summary>
        /// <param name="id">id of product that needs to be deleted.</param>
        /// <returns>return true for success, otherwise false</returns>
        public bool DeleteProduct(int id)
        {
            bool flag = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(_deleteProductSP, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            flag = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        /// <summary>
        /// To Get List of all the products.
        /// </summary>
        /// <returns>IEnumerable of the Products present in the database.</returns>
        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(_getAllProductSP, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.Id = reader.GetInt32("Id");
                            product.ProductName = reader.GetString("ProductName");
                            product.ProductDescription = reader.GetString("ProductDescription");
                            product.Price = reader.GetDecimal("Price");
                            products.Add(product);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return products;
        }

        /// <summary>
        /// update an existing product into the database.
        /// </summary>
        /// <param name="product">Object of product that needs to be updated</param>
        /// <returns>return true for success, otherwise false</returns>
        public bool UpdateProduct(Product product)
        {
            bool flag = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(_updateProductSP, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = product.Id;
                        cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = product.ProductName;
                        cmd.Parameters.Add("@ProductDescription", SqlDbType.NVarChar).Value = product.ProductDescription;
                        cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = product.Price;
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            flag = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }
    }
}
