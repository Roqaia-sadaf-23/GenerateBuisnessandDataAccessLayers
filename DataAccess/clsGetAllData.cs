using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateBuisnessandDataAccessLayers.DataAccess
{
    public class clsGetAllData
    {


      public  static string GetAllFunc(String TableName)
        {

            string Script = "  public static DataTable GetAll"+TableName+"()\n{";
            Script += "\n\n  \r\n                DataTable dt = new DataTable();\r\n          " +
                "      SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);\r\n\r\n          " +
                "      string query = \"SELECT * FROM " + TableName + "\";\n";
            Script += "\r\n                SqlCommand command = new SqlCommand(query, connection);\r\n\r\n                try\r\n                {\r\n                    connection.Open();\r\n\r\n                " +
                "    SqlDataReader reader = command.ExecuteReader();\r\n\r\n                    if (reader.HasRows)\r\n\r\n                    {\r\n                        dt.Load(reader);\r\n                    }\r\n\r\n                    reader.Close();\r\n\r\n\r\n                }\r\n\r\n               " +
                " catch (Exception ex)\r\n                {\r\n                    // Console.WriteLine(\"Error: \" + ex.Message);\r\n                }\r\n                finally\r\n                {\r\n           " +
                "         connection.Close();\r\n                }\r\n\r\n                return dt;\r\n\r\n            }";


            return Script;
        }
    }
}
