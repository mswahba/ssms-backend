using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public static class Ado
{

    static SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=true");
    static SqlCommand command = new SqlCommand();
    static SqlDataAdapter adapter = new SqlDataAdapter();
    static DataTable table = new DataTable();
    static Dictionary<string, object> obj;
    static List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
    public static List<Dictionary<string, object>> ExecuteQuery(string sqlQuery)
    {
        command.Connection = con;
        command.CommandText = sqlQuery;
        adapter.SelectCommand = command;

        adapter.Fill(table);
        foreach (DataRow row in table.Rows)
        {
            obj = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
                obj.Add(col.ColumnName, row[col]);
            result.Add(obj);
        }
        return result;
    }
}