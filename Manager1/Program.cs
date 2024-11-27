using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "data source = srv2\\pupils;initial catalog=Manager_db;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";
            Product product = new Product();
            int rowAffected = product.AddNewProduct(connectionString);
            Console.WriteLine($"{rowAffected} rows are affected");
            product.GetData(connectionString);
            Console.ReadLine();
        }
    }
}
