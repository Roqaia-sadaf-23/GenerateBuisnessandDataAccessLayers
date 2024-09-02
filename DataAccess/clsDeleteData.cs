using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateBuisnessandDataAccessLayers.DataAccess
{
    public class clsDeleteData
    {
        


       public static string DeleteFunc(string TableName, string TableSingalName, object TableColumns, string FindBy)
        {
            DataTable dataTable = TableColumns as DataTable;


            string Script = " public static bool Delete" + TableSingalName + "(";
            clsIsExistData.GetColumnMatchFindBy(dataTable,FindBy,ref  Script);
             Script=Script.Substring(0,Script.Length-1);
            Script += ")\n{\n\n";
            Script += "\r\n            int rowsAffected = 0;\r\n\r\n            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);";
            Script += "\n\n string query = @\"Delete " + TableName + "\n Where " + FindBy + " = @" + FindBy + "\";\n\n";
            Script += "SqlCommand command = new SqlCommand(query, connection);\n\n";
            Script += " command.Parameters.AddWithValue(\"@" + FindBy + "\"," + FindBy + ");\n";
            Script += " try\r\n            {\r\n                connection.Open();\r\n\r\n             " +
                "   rowsAffected = command.ExecuteNonQuery();\r\n\r\n            }\r\n            " +
                "catch (Exception ex)\r\n            {\r\n                // Console.WriteLine(\"Error: \" + ex.Message);\r\n            }\r\n         " +
                "   finally\r\n            {\r\n\r\n                connection.Close();\r\n\r\n            }\r\n\r\n           " +
                " return (rowsAffected > 0);\r\n\r\n        }";

            return Script;
        }
    }
}
