using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

using EpicProjects.Constants;

namespace EpicProjects.Database
{
        public class Deleter
        {
                public string _connectionString { get; set; }
                public SqlConnection _connection;

                public Deleter(string connectionStr)
                {
                        //Setting up the connection settings

                        this._connection = new SqlConnection(connectionStr);


                }//Selector()

        public void DeleteOnId(int id, string table)
        {
                _connection.Open();
                SqlCommand command = new SqlCommand("delete from " + table +  " where id = " + id, _connection);

                command.ExecuteNonQuery();

                _connection.Close();
        }//DeleteOnId()

              

        }//class Deleter
}//ns
