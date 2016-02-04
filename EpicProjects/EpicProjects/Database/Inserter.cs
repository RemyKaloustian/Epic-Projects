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
                        _connectionString = connectionStr;

                        Debug.CW("\n\n---------------------------------------\n Dans le CTOR de Inserter, connectionStr vaut :" + connectionStr + "\n--------------------------------------\n\n");


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
                        
                }//InsertProject()

                public void InsertTask(string name, string deadline, string type, int priority, int projectid)
                {

                        Debug.CW("\n\n -------------------------------\n In InsertTask connectionString: " +_connection.ConnectionString.ToString() + "\n------------------------------\n\n");



                        _connection.Open();

                        SqlCommand command = new SqlCommand("insert into task(name, deadline, type, priority, projectid) values (@name , @deadline, @type, @priority, @projectid)", _connection);

                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@deadline", deadline);
                        command.Parameters.AddWithValue("@type", type);
                        command.Parameters.AddWithValue("@priority", priority);
                        command.Parameters.AddWithValue("@projectid", projectid);

                        command.ExecuteNonQuery();

                        _connection.Close();
                }//InsertTask
        }//class Inserter
}//ns
