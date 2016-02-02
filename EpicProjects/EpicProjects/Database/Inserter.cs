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
        public class Inserter
        {
                public string _connectionString { get; set; }
                public SqlConnection _connection;

                public Inserter(string connectionStr)
                {
                        //Setting up the connection settings
                       

                        this._connection = new SqlConnection(connectionStr);


                }//Selector()

                public void InsertProject(string name, string startDate, string endDate)
                {
                        _connection.Open();

                        //Setting the query
                        SqlCommand command = new SqlCommand("insert into project (name, startdate,enddate) values(@name, @startdate, @enddate)", _connection);

                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@startdate", startDate);
                        command.Parameters.AddWithValue("@enddate", endDate);

                        Debug.CW("\n\n--------------------------\nINSERT COMMAND : " + command.CommandText + "\n-----------------------------------\n\n");

                        //Executing the query
                        command.ExecuteNonQuery();

                        _connection.Close();
                        _connection.Dispose();
                }//InsertProject()
        }//class Inserter
}//ns
