using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateBuisnessandDataAccessLayers.DataAccess
{
    public class clsFindData
    {

        public static void GetTypeOfColumnAndColumnName(ref string Script, DataTable data, String FindBy = "")
        {


          Script=  ChangeDataTypeandColumn(ref Script, data,FindBy);

        }

        public static string ChangeDataType( string DataType)
        {
            
            
            
            switch (DataType)
             {

                case "int":
                    return "int";

                case "varchar":
                case "nvarchar":

                       return " string ";
                case "bit":
                            return " bool ";
                      
                case "datetime":
                case "smalldatetime":
                    return " DateTime ";
                    case "decimal":
                        return " decimal ";
                    case "float":
                         return" double";
                    case "money":
                case "smallmoney":
                        return " decimal ";
                    case "smallint":
                        return " short ";
                    case "tinyint":
                        return " byte ";
                    case "uniqueidentifier":
                        return " Guid ";

                       
                }
            
            MessageBox.Show("NO Execute Casting ","Erro",MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "";
        }

        public static string  GetColumnValue(ref string Script, DataTable dataTable, string FindBy)
        {


            if (dataTable.Rows.Count <= 0)
                return "";

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["COLUMN_NAME"].ToString() != FindBy)
                {
                    if (row["IS_NULLABLE"].ToString() == "YES")
                    {
                        Script += " \n if (reader[ \"" + row["COLUMN_NAME"].ToString() + "\"] " + " != DBNull.Value) \n  { \n\n " + row["COLUMN_NAME"].ToString() +
                      " = (" + ChangeDataType(row["DATA_TYPE"].ToString())+ ")reader[ \"" + row["COLUMN_NAME"] + "\" ];\n" + "  }\r\n                    else\r\n                    {\n" +

                        row["COLUMN_NAME"].ToString() + "= \"\"; \n }" ;



                    }
                    else
                    {
                        Script += row["COLUMN_NAME"] + "=(" + ChangeDataType(row["DATA_TYPE"].ToString()) + ")reader[ \"" + row["COLUMN_NAME"] + "\" ];\n";
                    }
                }
              
            }
            return Script.Substring(0, Script.Length - 1);
        }

      public  static string ChangeDataTypeandColumn(ref string Script, DataTable DataType, String FindBy)
        {
            if (DataType.Rows.Count <= 0)
                return "";



            foreach (DataRow row in DataType.Rows)
            {
                if (row["COLUMN_NAME"].ToString() != FindBy)
                    Script += "ref";

                switch (row["DATA_TYPE"].ToString())
                {

                    case "int":
                        Script+= " int "+ row["COLUMN_NAME"].ToString()+",";
                        break;
                    case "varchar":
                    case "nvarchar":
                      Script+= " string "+ row["COLUMN_NAME"].ToString() + ",";
                        break;
                    case "bit":
                      Script+= " bool "+ row["COLUMN_NAME"].ToString() + ",";
                        break;
                    case "smalldatetime":
                    case "datetime":
                     Script+= " DateTime " + row["COLUMN_NAME"].ToString() + ",";
                        break;
                    case "decimal":
                        Script+= " decimal "+ row["COLUMN_NAME"].ToString() + ",";
                        break;
                    case "float":
                       Script+= " double "+ row["COLUMN_NAME"].ToString() + ",";
                        break;
                    case "smallmoney":
                    case "money":
                        Script+= " decimal "+ row["COLUMN_NAME"].ToString() + ",";
                        break;
                    case "smallint":
                        Script+= " short "+ row["COLUMN_NAME"].ToString() + ",";
                        break;
                    case "tinyint":
                        Script+=" byte "+ row["COLUMN_NAME"].ToString() + ",";
                        break;
                    case "uniqueidentifier":
                       Script+=" Guid "+ row["COLUMN_NAME"].ToString() + ",";
                        break;
                }
               
         
            }

            return Script.Substring(0, Script.Length - 1);
        }
        
        public static string FindFunc(string TableName,string TableSingalName,object TableColumns,string FindBy)
        {

            DataTable dataTable = TableColumns as DataTable;

            String Script = "public static bool Get" + TableSingalName + "InfoBy" + FindBy + "(";
            GetTypeOfColumnAndColumnName(ref Script, dataTable, FindBy);

            Script += " )\n";
            Script += " {\n\n\n";
            Script += " bool isFound = false;  \n\n  SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);\n";
            Script += "\n string query = @\"SELECT * FROM " + TableName + " WHERE " + FindBy + " = @" + FindBy + "\" ;";
            Script += "\n   SqlCommand command = new SqlCommand(query, connection);\n ";
            Script += "\n command.Parameters.AddWithValue( \" @" + FindBy + "\" , " + FindBy + ");";
            Script += " \n   SqlDataReader reader = null;\n";
            Script += "\n try\r\n            {\r\n         connection.Open();\r\n     reader = command.ExecuteReader();     \n" + "\r\n                if (reader.Read())\r\n                {\r\n                " +
                "  isFound = true;\n ";
            GetColumnValue(ref Script, dataTable, FindBy);
            Script += "\n \r\n                }\r\n                else\r\n                {\r\n                    // The record was not found\r\n                    isFound = false;\r\n                }\r\n";
            Script += " \n   reader.Close();\r\n            }\r\n            catch (Exception ex)\r\n            {\r\n                //Console.WriteLine(\"Error: \" + ex.Message);\r\n                \r\n               \r\n            }\r\n            finally\r\n            {\r\n                connection.Close();\r\n            }\r\n";

            Script += "\n \r\n            return isFound;\r\n        }\r\n";

            return Script;
        }





    }
}
