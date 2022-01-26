using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperCRUDAPI.Model
{
    public class ProductRepository
    {
        private string connectionString;

        
        
        public ProductRepository()
        {
            connectionString = @"Persist Security Info=False; User ID=sa; password=Qwerty123; Initial Catalog=DapperDB; Data Source=LAPTOP-EDP-NEW;Connection Timeout=100000; ";

            //connectionString = "Data Source=LAPTOP-EDP-NEW;Initial Catalog=DapperDB;User ID=sa;Password=Qwerty123";
        }

        public IDbConnection connection
        {
            get 
            {
                return new SqlConnection(connectionString);
            }

        }


        public void Add(Product prod)
        {
            using (IDbConnection dbConnection = connection)
            {
                string sQuery = @"INSERT INTO Products (Name, Quantity, Price) VALUES(@Name, @Quantity, @Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, prod);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection dbConnection = connection)
            {
                string sQuery = @"SELECT * FROM Products";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery);
            }

        }

        public Product GetById(int id)
        {
            using (IDbConnection dbConnection = connection)
            {
                string sQuery = "SELECT * FROM Products WHERE ProductId=@Id";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new { Id = id }).FirstOrDefault();
            }
        
        }

        public void Delete (int id)
        {
            using (IDbConnection dbConnection = connection)
            {
                string sQuery = "DELETE FROM Products WHERE ProductId=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }

        }

        public void Update(Product prod)
        {
            using (IDbConnection dbConnection = connection)
            {
                string sQuery = "UPDATE SET Products Name=@Name,  Quantity=@Quantity, Price=@Price WHERE ProductId=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, prod);
            }

        }


    }
}
