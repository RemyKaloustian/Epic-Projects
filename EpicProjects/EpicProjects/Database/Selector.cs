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
        /// This Selector allows to select rows values in the database 
        /// </summary>
        public class Selector
        {
                public string _connectionString { get; set; }
                public SqlConnection _connection;

                public Selector(string connectionStr)
                {
                        //Setting up the connection settings

                        this._connection = new SqlConnection(connectionStr);


                }//Selector()


                public List<Object> Select( string attribute, string table)
                {
                        List<Object> results = new List<Object>();

                        //Opening connection and setting the query
                        _connection.Close();
                        _connection.Open();
                        SqlDataReader reader = null;
                        SqlCommand command = new SqlCommand("select " + attribute + " from " + table, _connection);

                        //Reading the results of the query
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                                results.Add(reader[attribute].ToString());
                        }

                        //Closing so that it doesn't explode
                        reader.Close();
                        _connection.Close();

                        return results;

                }//Select()

                public string SelectSingleByEquality(string attribute, string table, string condition, object value)
                {
                        string result = null;

                        //Setting  the query
                        _connection.Open();
                        SqlDataReader reader = null;
                        SqlCommand command;

                        //Creating the command
                        if (value is string)
                        {
                                 command = new SqlCommand("select " + attribute + " from " + table + " where " + condition + " = '" + value + "'", _connection);
                        }

                        else
                        {
                                 command = new SqlCommand("select " + attribute + " from " + table + " where " + condition + " = " + value + "", _connection);
                        }
                        
                        //Reading the results
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                                result = reader[attribute].ToString();
                        }

                        reader.Close();
                        _connection.Close();

                        return result;
                }//SelectByName()

                public List<string> SelectMultipleByEquality(string attribute, string table, string condition, object value)
                {
                        List<string> result = new List<string>();

                        //Setting  the query
                        _connection.Open();
                        SqlDataReader reader = null;
                        SqlCommand command;

                        //Creating the command
                        if (value is string)
                        {
                                command = new SqlCommand("select " + attribute + " from " + table + " where " + condition + " = '" + value + "'", _connection);
                        }

                        else
                        {
                                command = new SqlCommand("select " + attribute + " from " + table + " where " + condition + " = " + value + "", _connection);
                        }

                        //Reading the results
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                                result.Add(reader[attribute].ToString());
                        }

                        reader.Close();
                        _connection.Close();

                        return result;
                }//SelectMultipleByEquality()


                public List<string> SelectMultipleByEqualityWithProject(string attribute, string table, string condition, object value, int projectid)
                {
                        List<string> result = new List<string>();

                        //Setting  the query
                        _connection.Open();
                        SqlDataReader reader = null;
                        SqlCommand command;

                        //Creating the command
                        if (value is string)
                        {
                                command = new SqlCommand("select " + attribute + " from " + table + " where " + condition + " = '" + value + "' and projectid = " + projectid, _connection);
                        }

                        else
                        {
                                command = new SqlCommand("select " + attribute + " from " + table + " where " + condition + " = " + value + " and projectid =  " + projectid, _connection);
                        }

                        //Reading the results
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                                result.Add(reader[attribute].ToString());
                        }

                        reader.Close();
                        _connection.Close();

                        return result;
                }//SelectMultipleByEquality()

                public int SelectCount(string table)
                {
                        //Setting the query
                        _connection.Open();
                        SqlCommand command = new SqlCommand("select count(id) from " + table, _connection);

                        //We store the result of the query
                        Int32 count = (Int32)command.ExecuteScalar();

                        return count;
                }//SelectCount()

        }//class Selector
}//ns
