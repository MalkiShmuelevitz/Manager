using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Manager1
{
    internal class Product
    {

        public int AddNewProduct(string connectionString)
        {
            int rowsAffected = 0;
            string category_id, product_name, description, price, picture,toContinue="";
            while (toContinue != "n")
            {

            
            Console.WriteLine("enter category id ");
            category_id = Console.ReadLine();
            Console.WriteLine("enter product_name ");
            product_name = Console.ReadLine();
            Console.WriteLine("enter description ");
            description = Console.ReadLine();
            Console.WriteLine("enter price ");
            price = Console.ReadLine();
            Console.WriteLine("enter picture url ");
            picture = Console.ReadLine();

            string query = "INSERT INTO Products(category_id, product_name, description, price, picture)" +
                    "VALUES (@category_id, @product_name, @description, @price, @picture)";
            using(SqlConnection cn = new SqlConnection(connectionString))
            using(SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@category_id", SqlDbType.Int).Value =int.Parse(category_id);
                cmd.Parameters.Add("@product_name", SqlDbType.NVarChar).Value = product_name;
                cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = description;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = int.Parse(price);
                cmd.Parameters.Add("@picture", SqlDbType.NVarChar).Value = picture;
                cn.Open();
                rowsAffected  += cmd.ExecuteNonQuery();
                    cn.Close();
            }
                Console.WriteLine("Are you want to continue? (y/n)");
                toContinue = Console.ReadLine();
            }
            return rowsAffected;
        }
        public void GetData(string connectionString)
        {
            string queryString = "select p.id,p.product_name,p.description,p.price,p.picture,c.category_name\r\nfrom Products p join Category c\r\non p.category_id = c.id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString,connection))
            {
               
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", reader[0], reader[1], reader[2], reader[3], reader[4]);
                        
                    }
                    reader.Close();
                connection.Close();


            }
 
        }
    }
}
