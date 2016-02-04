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
        public class Updater
        {
                public string _connectionString { get; set; }
                public SqlConnection _connection;

                public Updater(string connectionStr)
                {
                        //Setting up the connection settings
                        

                        this._connection = new SqlConnection(connectionStr);


                }//Selector()

                public void UpdateName(int id, string table,string newname)
                {
                        _connection.Open();

                        SqlCommand command = new SqlCommand("Update " + table + " set name = @newname where id = @id", _connection);

                        command.Parameters.AddWithValue("@newname", newname);
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();

                        _connection.Close();
                }//UpdateProjectName()
        }//class Updater()
}//ns
