using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

using EpicProjects.Constants;

/*
 * @Author : Rémy Kaloustian
 * */

namespace EpicProjects.Database
{
        /// <summary>
        /// This class deletes values from the database
        /// </summary>
        public class Deleter
        {
                public string _connectionString { get; set; }
                public SqlConnection _connection;

                public Deleter(string connectionStr)
                {
                        //Setting up the connection settings

                        this._connection = new SqlConnection(connectionStr);


                }//Selector()

                /// <summary>
                /// Deletes avalue based on an id
                /// </summary>
                /// <param name="id">the id</param>
                /// <param name="table">the table</param>
                public void DeleteOnId(int id, string table)
                {
                        _connection.Open();
                        SqlCommand command = new SqlCommand("delete from " + table + " where id = " + id, _connection);

                        command.ExecuteNonQuery();

                        _connection.Close();
                }//DeleteOnId()

                /// <summary>
                /// Deletes a value based on the name
                /// </summary>
                /// <param name="name">the name</param>
                /// <param name="table"> teh table</param>
                public void DeleteOnName(string name, string table)
                {
                        _connection.Open();
                        SqlCommand command = new SqlCommand("delete from " + table + " where name = '" + name + "'", _connection);

                        command.ExecuteNonQuery();

                        _connection.Close();
                }//DeleteOnId()

        }//class Deleter
}//ns
