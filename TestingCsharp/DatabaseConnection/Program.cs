using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace DatabaseConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = null;
            OleDbConnection connect;
            ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hotel_ex2.accdb;";//access
            connect = new OleDbConnection(ConnectionString);

            try
            {
                connect.Open();
                Console.WriteLine("connection open !");
                

            }
            catch (Exception ex)
            {

                Console.WriteLine("cannot open database !" + ex.Message);

            }
            Console.ReadLine();
            connect.Close();
        }
    }
}
