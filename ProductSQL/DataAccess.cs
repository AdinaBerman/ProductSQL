using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSQL
{
    internal class DataAccess
    {
        public int InserCategoryData(string connectionString)
        {
            string categoryName;

            Console.WriteLine("Insert category name");
            categoryName = Console.ReadLine();

            string query = "INSERT INTO Category(categoryName)" +
                "VALUES(@categoryName)";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@categoryName", SqlDbType.VarChar, 15).Value = categoryName;
                cn.Open();
                int rowEffected = cmd.ExecuteNonQuery();
                cn.Close();

                return rowEffected;
            }
        }

        public int InserProductData(string connectionString)
        {
            string prodName, prodDescription, categoryId, prodPrice, image;

            Console.WriteLine("Insert categoryId");
            categoryId = Console.ReadLine();

            Console.WriteLine("Insert prodName");
            prodName = Console.ReadLine();

            Console.WriteLine("Insert prodPrice");
            prodPrice = Console.ReadLine();

            Console.WriteLine("Insert prodDescription");
            prodDescription = Console.ReadLine();

            Console.WriteLine("Insert image");
            image = Console.ReadLine();

            string query = "INSERT INTO Product(categoryId, prodName, prodPrice, prodDescription, image)" +
                "VALUES(@categoryId, @prodName, @prodPrice, @prodDescription, @image)";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@categoryId", SqlDbType.Int, 15).Value = categoryId;
                cmd.Parameters.Add("@prodName", SqlDbType.VarChar, 15).Value = prodName;
                cmd.Parameters.Add("@prodPrice", SqlDbType.Int, 15).Value = prodPrice;
                cmd.Parameters.Add("@prodDescription", SqlDbType.VarChar, 15).Value = prodDescription;
                cmd.Parameters.Add("@image", SqlDbType.VarChar, 20).Value = image;

                cn.Open();
                int rowEffected = cmd.ExecuteNonQuery();
                cn.Close();

                return rowEffected;
            }
        }

        public void readData(string connectionString)
        {
            string queryString = "select * from Product";
            using(SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, cn);

                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", 
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                    cn.Close();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadLine();
            }
        }



    }
}
