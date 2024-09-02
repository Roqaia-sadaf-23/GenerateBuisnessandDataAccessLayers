using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateBuisnessandDataAccessLayers.DataAccess
{
    public class clsUpdateData
    {
        static public string UpdateFunc(string TableName, string TableSingalName, object TableColumns, string FindBy)
        {
            DataTable dataTable = TableColumns as DataTable;

            string Script = "public static bool Update" + TableSingalName + "(";
            GetColumnAndDataType(dataTable, ref Script);
            Script = Script.Substring(0, Script.Length - 1);
            Script += ")\n{\n\n" + "int rowsAffected = 0;\r\n            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);\r\n";
            Script += " string query = @\"Update " + TableName + "\r\n                            set ";
            GetColumnInQuery(dataTable, ref Script,FindBy);
            Script += "Where " + FindBy + " = @" + FindBy + "\";\n\n ";
            Script += " SqlCommand command = new SqlCommand(query, connection);\n\n";
            clsAddNewData.GetColumnsAddToCommand(ref Script,dataTable,FindBy);
            Script += "\r\n            try{\r\n                connection.Open();\r\n                rowsAffected = command.ExecuteNonQuery();\r\n\r\n            }\r\n            catch (Exception ex)\r\n            {\r\n                //Console.WriteLine(\"Error: \" + ex.Message);\r\n      " +
                "   return false;\r\n            }\r\n\r\n            finally\r\n            {\r\n                connection.Close();\r\n            }\r\n\r\n            return (rowsAffected > 0);\r\n        }\r\n";



            return Script;
        }



        static string GetColumnAndDataType(DataTable dataTable, ref string Script)
        {
            if (dataTable.Rows.Count < 0)
                return "";

            foreach (DataRow row in dataTable.Rows)
            {
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


        static string GetColumnInQuery(DataTable dataTable, ref string Script,string FindBy)
        {

            if (dataTable.Rows.Count <= 0)
                return "";

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["COLUMN_NAME"].ToString()!=FindBy)
                {
                Script += row["COLUMN_NAME"].ToString() + " = @" + row["COLUMN_NAME"].ToString() + ",\n";

                }
            }


            return Script.Substring(0, Script.Length - 1);

        }


    }
}
