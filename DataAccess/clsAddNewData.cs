using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateBuisnessandDataAccessLayers.DataAccess
{
  public class clsAddNewData
    {



        public static string AddNewFunc(string TableName, string TableSingalName, object TableColumns, string FindBy)
        {

            DataTable dataTable = TableColumns as DataTable;

            string Script = "public static int AddNew" + TableSingalName + "InfoBy" + FindBy + "(";
            GetCulomnAndDataTypeWithOutFindBy(ref Script, dataTable, FindBy);

            Script=Script.Substring(0, Script.Length - 1);

            Script += " )\n";
            Script += " {\r\n  \r\n        int "   +  FindBy +
                "= -1;\r\n\r\n            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);\r\n";
            Script += "\n string query = @\"INSERT INTO "+TableName+" (";
            GetPropreties(ref Script, dataTable, FindBy);
            Script += ")\n   VALUES (";
           GetPropretiesWithAt(ref Script, dataTable, FindBy);
            Script += ");\n     SELECT SCOPE_IDENTITY();\";\n\n";
            Script += " SqlCommand command = new SqlCommand(query, connection);\n";
            GetColumnsAddToCommand(ref Script, dataTable, FindBy);
            Script += "try\r\n            {\r\n                connection.Open();\r\n\r\n                object result = command.ExecuteScalar();\r\n\r\n                if (result != null && int.TryParse(result.ToString(), out int insertedID))\r\n                {\r\n                  " +
                 FindBy + "= insertedID;\r\n                }\r\n            }\r\n\r\n            catch (Exception ex)\r\n            {\r\n                //Console.WriteLine(\"Error: \" + ex.Message);\r\n\r\n            }\r\n\r\n            finally\r\n            {\r\n           " +
                "     connection.Close();\r\n            }\r\n\r\n            return " +
                FindBy+";\r\n        }\r\n";

            return Script;
        }

        static string GetPropreties(ref string Script,DataTable table, string FindBy)
        {
            foreach(DataRow row in table.Rows)
            {
                if (row["COLUMN_NAME"].ToString() != FindBy)
                Script += row["COLUMN_NAME"] + ",";
                
            }
           
            return Script.Substring(0, Script.Length - 1);
        }

        static string GetPropretiesWithAt(ref string Script, DataTable table, string FindBy)
        {
            foreach (DataRow row in table.Rows)
            {
                if (row["COLUMN_NAME"].ToString() != FindBy)
                {

                Script +="@"+ row["COLUMN_NAME"] + ",";

                }
                 
            }

            return Script.Substring(0, Script.Length - 1);
        }
        static string GetCulomnAndDataTypeWithOutFindBy(ref string Script, DataTable dataTable,string FindBy)
        {

            if (dataTable.Rows.Count <= 0)
                return "";



            foreach (DataRow row in dataTable.Rows) 
            {
                if (row["COLUMN_NAME"].ToString() != FindBy) 
                     

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

       public static string GetColumnsAddToCommand(ref string Script, DataTable dataTable, string FindBy)
        {
            if (dataTable.Rows.Count <= 0)
                return "";

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["COLUMN_NAME"].ToString() != FindBy)
                {
                    if (row["IS_NULLABLE"].ToString() == "YES")
                    {
                        Script += "\n if(" + row["COLUMN_NAME"].ToString() + "!= \"\"" + "&&" + row["COLUMN_NAME"].ToString() + "!= null)\n" +
                            " command.Parameters.AddWithValue(\"@" + row["COLUMN_NAME"].ToString() + "\"," + row["COLUMN_NAME"].ToString() + ");\n" +
                            "else\n" + " command.Parameters.AddWithValue(\"@" + row["COLUMN_NAME"].ToString() + "\", System.DBNull.Value);\n";


                    }
                    else
                        Script += "command.Parameters.AddWithValue(\"@" + row["COLUMN_NAME"].ToString() + "\"," + row["COLUMN_NAME"].ToString() + ");\n";
                }
            }
       
        return Script.Substring(0,Script.Length - 1);
        
        }
    }
}
