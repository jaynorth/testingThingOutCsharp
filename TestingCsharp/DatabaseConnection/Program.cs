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

            OleDbCommand cmd = connect.CreateCommand();


            string sql = "SELECT * FROM Client ";
            cmd.CommandText = sql;

            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                Console.WriteLine("There is data");
            }
            else {
                Console.WriteLine("No Data");
            }



            do
            {
                string nom = (string)reader["Nom"];
                string prenom = (string)reader["Prenom"];
                string adresse = (string)reader["Adresse"];
                int clientNPA = (int)reader["clientNPA"];
                Console.WriteLine("{0} , {1}\n adresse:{2}, {3} ", nom, prenom, adresse, clientNPA);

            } while (reader.Read());
            reader.Close();
            // NOW WITH PARAMETERS


            sql = "INSERT INTO FemmeChambre (NomFemme) VALUES (@nom)";
            cmd.CommandText = sql;

            string nomF = "Paula";
            OleDbParameter paramNom = new OleDbParameter("@nom", nomF);
            cmd.Parameters.Add(paramNom);


            int n = cmd.ExecuteNonQuery();
            Console.WriteLine("record:" + n);

            sql = "SELECT * FROM FemmeChambre";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            

            while (reader.Read()) {
                string nomFemme = (string)reader["NomFemme"];
                int codeFemme = (int)reader["CodeFemmeChambre"];
                Console.WriteLine("{0} , {1} ", nomFemme, codeFemme);
            }
            
           



           
            connect.Close();


            /////USING DataSet

            OleDbDataAdapter adapteur = new OleDbDataAdapter();
            OleDbCommand commande = connect.CreateCommand();
            commande.CommandText = "SELECT * FROM Listechambre";
            adapteur.SelectCommand = commande;

            DataSet1 ds = new DataSet1();
            adapteur.Fill(ds, "Chambres");
            int nbLignes = adapteur.Fill(ds);
            Console.WriteLine("Nombre lignes: " + nbLignes);
            

            Console.ReadKey();

        }
    }
}
