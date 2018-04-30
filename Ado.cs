using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace SSMS
{
    public class Ado
    {
        static SqlConnection con;
        static SqlCommand command;
        static SqlDataAdapter adapter;
        static DataTable table;
        //Dictionary > represents a row , string is the [ColumnName] , Object is [ColumnValue]
        // Values are defined as objects to hold any data type 
        static Dictionary<string, object> obj;
        // List of Dictionary > represents table which is a list of (Dictionary of Rows)
        static List<Dictionary<string, object>> result;
        static string filePath;

        //initiaize fields inside class constructor
        public Ado(IHostingEnvironment env)
        {
            filePath = Path.Combine(env.ContentRootPath, "appsettings.json");
            con = new SqlConnection(filePath.GetJsonValue());
            //con = new SqlConnection(@"Server=DESKTOP-8GK916E;Database=ssms;Trusted_Connection=True;");
            command = new SqlCommand();
            adapter = new SqlDataAdapter();
            table = new DataTable();
            command.Connection = con;
            result = new List<Dictionary<string, object>>();
        }
        public List<Dictionary<string, object>> ExecuteQuery(string sqlQuery)
        {
            //Clear List of Dictionary if there is any previous Data 
            result.Clear();
            //Clear table rows and Columns before filling it. 
            table.Rows.Clear();
            table.Columns.Clear();
            command.CommandText = sqlQuery;
            adapter.SelectCommand = command;
            //use incoming SQL Query to select data from DB and fill the table using Adapter
            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                //dynamically Create an object to hold row data (columnNames, ColValues) 
                obj = new Dictionary<string, object>();
                //Iterate each column in the table and add its name and Val into row [obj]
                foreach (DataColumn col in table.Columns)
                {
                    //First Check if the column has null value, set it to null 
                    //(otherwise an anonymoys type will be created for column value instead of direct Value)
                    // If 
                    if (row[col] is DBNull)
                        obj.Add(col.ColumnName, null);
                    else
                        obj.Add(col.ColumnName, row[col]);
                }
                result.Add(obj);
            }
            return result;
        }
    }
}