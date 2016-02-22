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


                /// <summary>
                /// Selects the values of a certain attribute in acertain table
                /// </summary>
                /// <param name="attribute">the attribute to select</param>
                /// <param name="table">the table to select</param>
                /// <returns>The list of the attributes' values</returns>
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


                /// <summary>
                /// Selects a single value from the database using a condition
                /// </summary>
                /// <param name="attribute">the attribute </param>
                /// <param name="table">the table</param>
                /// <param name="condition">the name of the field for the condition check</param>
                /// <param name="value">the value that must verify the condition</param>
                /// <returns>the value of the row that verifies the condition</returns>
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


                /// <summary>
                /// Selects multiple attributes' value with a condition
                /// </summary>
                /// <param name="attribute">the attribute to select</param>
                /// <param name="table">the table to select from</param>
                /// <param name="condition">the attribute tested in the condition</param>
                /// <param name="value">the value the tested attribute must have</param>
                /// <returns>A list of all the values</returns>
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

                /// <summary>
                /// Selects multiple attributes' value with a condition, and with the project id, this is for the tasks mainly
                /// </summary>
                /// <param name="attribute">the attribute to select</param>
                /// <param name="table">the table to select from</param>
                /// <param name="condition">the attribute tested in the condition</param>
                /// <param name="value">the value the tested attribute must have</param>
                /// <returns>A list of all the values</returns>
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

                /// <summary>
                /// Counts the number of rows
                /// </summary>
                /// <param name="table">The table to count</param>
                /// <returns>The number of rows</returns>
                public int SelectCount(string table)
                {
                        //Setting the query
                        _connection.Open();
                        SqlCommand command = new SqlCommand("select count(id) from " + table, _connection);

                        //We store the result of the query
                        Int32 count = (Int32)command.ExecuteScalar();

                        return count;
                }//SelectCount()


                /// <summary>
                /// Selects the latests projects on the database
                /// </summary>
                /// <returns>The names of the latest projects</returns>
                public List<string> SelectLatestProjects()
                {
                        List<string> result = new List<string>();

                        //Setting up the query
                        _connection.Open();

                        SqlDataReader reader = null;
                        SqlCommand command = new SqlCommand("select name from project order by lastchecked desc", _connection);

                        //Reading the results
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                                result.Add(reader["name"].ToString());
                        }

                        reader.Close();
                        _connection.Close();

                        return result;
                }//SelectLatestProjects()


                /// <summary>
                /// Selects the last project's id
                /// </summary>
                /// <param name="table">name of the table</param>
                /// <returns></returns>
                public int SelectLastId( string table)
                {
                        int res = 10000;

                        //Setting up the query
                        _connection.Open();

                        SqlDataReader reader = null;
                        SqlCommand command = new SqlCommand("select max(id)  from "+ table, _connection);

                        //Executing and closing
                        res = (int)command.ExecuteScalar()  ;
                        _connection.Close();

                        return res;
                }//SelectLastId()

        }//class Selector
}//ns
