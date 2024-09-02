using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateBuisnessandDataAccessLayers.DataAccess
{
    public class clsIsExistData
    {

        public static string IsExistFunc(string TableName, string TableSingalName, object TableColumns, string FindBy)
        {


            DataTable dataTable = TableColumns as DataTable;

            string Script = "public static bool Is" + TableSingalName + "Exist(";
            GetColumnMatchFindBy(dataTable, FindBy,ref Script);
            Script=Script.Substring(0,Script.Length - 1);
            Script += ")\n {\n\n";
            Script += " bool isFound = false;\r\n\r\n            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);\r\n\r\n  " +
                "          string query = \"SELECT Found=1 FROM " + TableName + " Where " + FindBy + " = @" + FindBy+"\";\n\n";
            Script += "\r\n            SqlCommand command = new SqlCommand(query, connection);\r\n\r\n           " +
                " command.Parameters.AddWithValue(\"@" + FindBy + "\"," + FindBy + ");\n\n";
            Script += "  try\r\n            {\r\n                connection.Open();\r\n               " +
                " SqlDataReader reader = command.ExecuteReader();\r\n\r\n                isFound = reader.HasRows;\r\n\r\n                reader.Close();\r\n            }\r\n          " +
                "  catch (Exception ex)\r\n            {\r\n                //Console.WriteLine(\"Error: \" + ex.Message);\r\n                isFound = false;\r\n            }\r\n      " +
                "      finally\r\n            {\r\n                connection.Close();\r\n            }\r\n\r\n            return isFound;\r\n        }\n\n";



            return Script;
        }

       public static string GetColumnMatchFindBy(DataTable dataTable,string FindBy,ref string Script)
        {

            if (dataTable.Rows.Count <= 0)
                return "";
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["COLUMN_NAME"].ToString() == FindBy)

                    switch (row["DATA_TYPE"].ToString())
                    {

                        case "int":
                            Script += " int " + row["COLUMN_NAME"].ToString() + ",";
                            break;
                        case "varchar":
                        case "nvarchar":
                            Script += " string " + row["COLUMN_NAME"].ToString() + ",";
                            break;
                        case "bit":
                            Script += " bool " + row["COLUMN_NAME"].ToString() + ",";
                            break;
                        case "smalldatetime":
                        case "datetime":
                            Script += " DateTime " + row["COLUMN_NAME"].ToString() + ",";
                            break;
                        case "decimal":
                            Script += " decimal " + row["COLUMN_NAME"].ToString() + ",";
                            break;
                        case "float":
                            Script += " double " + row["COLUMN_NAME"].ToString() + ",";
                            break;
                        case "smallmoney":
                        case "money":
                            Script += " decimal " + row["COLUMN_NAME"].ToString() + ",";
                            break;
                        case "smallint":
                            Script += " short " + row["COLUMN_NAME"].ToString() + ",";
                            break;
                        case "tinyint":
                            Script += " byte " + row["COLUMN_NAME"].ToString() + ",";
                            break;
                        case "uniqueidentifier":
                            Script += " Guid " + row["COLUMN_NAME"].ToString() + ",";
                            break;
                    }

            }

            return Script.Substring(0, Script.Length - 1);

        }
    }
}
