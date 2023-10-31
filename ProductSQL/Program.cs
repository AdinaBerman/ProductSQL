// See https://aka.ms/new-console-template for more information
using ProductSQL;

//Console.WriteLine("Hello, World!");
//Data Source=SRV2\PUPILS;Initial Catalog=PruductsDB;Integrated Security=True
class Program
{
    static void Main(string[] args)
    {
        string dataConnectionString = "Data Source=SRV2\\PUPILS;Initial Catalog=PruductsDB;Integrated Security=True";

        DataAccess da = new DataAccess();
        //int category = da.InserCategoryData(dataConnectionString);
        //Console.WriteLine(category);

        for(int i=1; i<=30; i++)
        {
            int prod = da.InserProductData(dataConnectionString);
            Console.WriteLine(prod);
        }


        //da.readData(dataConnectionString);
    }
}