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
        /// <summary>
        /// This class inserts values in the database
        /// </summary>
        public class Inserter
        {
                public string _connectionString { get; set; }
                public SqlConnection _connection;

                public Inserter(string connectionStr)
                {
                        //Setting up the connection settings      
                        this._connection = new SqlConnection(connectionStr);
                        _connectionString = connectionStr;
                }//Selector()


                /// <summary>
                /// Insert a project in the database
                /// </summary>
                /// <param name="name">Name of the project</param>
                /// <param name="startDate">start date of the project</param>
                /// <param name="endDate">end date of the project</param>
                public void InsertProject(string name, string startDate, string endDate)
                {
                        _connection.Open();

                        //Setting the query
                        SqlCommand command = new SqlCommand("insert into project (name, startdate,enddate) values(@name, @startdate, @enddate)", _connection);

                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@startdate", startDate);
                        command.Parameters.AddWithValue("@enddate", endDate);                 

                        //Executing the query
                        command.ExecuteNonQuery();
                        _connection.Close();
                        
                }//InsertProject()


                /// <summary>
                /// Insert a task in the database
                /// </summary>
                /// <param name="name">Name of the task</param>
                /// <param name="deadline">deadline of the task</param>
                /// <param name="type">type of the task</param>
                /// <param name="priority">priority of the task</param>
                /// <param name="projectid">id of the dedicated project</param>
                public void InsertTask(string name, string deadline, string type, int priority, int projectid)
                {
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
