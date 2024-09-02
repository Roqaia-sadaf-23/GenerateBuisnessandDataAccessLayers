using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateBuisnessandDataAccessLayers.Buisness
{
    public class clsFind
    {
       public static string FindFunc(string TableName, string TableSingalName, object TableColumns, string FindBy)
        {
            DataTable dataTable = TableColumns as DataTable;
            string Script= "public static cls"+TableSingalName+ " FindBy"+FindBy+"(";
            GetColumnMatchFindBy(dataTable,FindBy,ref Script);
            Script += ")\n{\n\n";
            GetProparetyAndDataType(dataTable,FindBy,ref Script);
            Script += "\n bool IsFound = cls"+TableSingalName+ "Data.Get"+TableSingalName+ "InfoBy"+FindBy+"(\n";
            GetProparetyWithRef(dataTable,FindBy,ref Script);
            Script = Script.Substring(0, Script.Length - 1);
            Script += ");\n\n";

            Script += " if (IsFound)\r\n                //we return new object of that person with the right data\r\n      " +
                "          return new cls" + TableSingalName + "(";GetProparety(dataTable,ref Script);
            Script = Script.Substring(0, Script.Length - 1);
            Script += ");\r\n            else\r\n                return null;\r\n        }";



            return Script;
        }

     static string GetColumnMatchFindBy(DataTable dataTable, string FindBy,ref string Script)
        {

            if (dataTable.Rows.Count <= 0)
                return "";


            foreach (DataRow row in dataTable.Rows)
            {
                if (row["COLUMN_NAME"].ToString() == FindBy)

                    switch (row["DATA_TYPE"].ToString())
                    {

                        case "int":
                            Script += " int " + row["COLUMN_NAME"].ToString();
                            break;
                        case "varchar":
                        case "nvarchar":
                            Script += " string " + row["COLUMN_NAME"].ToString();
                            break;
                        case "bit":
                            Script += " bool " + row["COLUMN_NAME"].ToString();
                            break;
                        case "smalldatetime":
                        case "datetime":
                            Script += " DateTime " + row["COLUMN_NAME"].ToString();
                            break;
                        case "decimal":
                            Script += " decimal " + row["COLUMN_NAME"].ToString();
                            break;
                        case "float":
                            Script += " double " + row["COLUMN_NAME"].ToString();
                            break;
                        case "smallmoney":
                        case "money":
                            Script += " decimal " + row["COLUMN_NAME"].ToString();
                            break;
                        case "smallint":
                            Script += " short " + row["COLUMN_NAME"].ToString();
                            break;
                        case "tinyint":
                            Script += " byte " + row["COLUMN_NAME"].ToString();
                            break;
                        case "uniqueidentifier":
                            Script += " Guid " + row["COLUMN_NAME"].ToString();
                            break;
                    }

            }

            return Script.Substring(0, Script.Length - 1);

        }
    
    static string GetProparetyAndDataType(DataTable dataTable, string FindBy, ref string Script)
        {

            if (dataTable.Rows.Count <= 0)
                return "";

            
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["COLUMN_NAME"].ToString() != FindBy)

                    switch (row["DATA_TYPE"].ToString())
                    {

                        case "int":
                            Script += " int " + row["COLUMN_NAME"].ToString()+" =-1; ";
                            break;
                        case "varchar":
                        case "nvarchar":
                            Script += " string " + row["COLUMN_NAME"].ToString()+" =\"\";";
                            break;
                        case "bit":
                            Script += " bool " + row["COLUMN_NAME"].ToString()+" =true; ";
                            break;
                        case "smalldatetime":
                        case "datetime":
                            Script += " DateTime " + row["COLUMN_NAME"].ToString()+ " = DateTime.Now; ";
                            break;
                        case "decimal":
                            Script += " decimal " + row["COLUMN_NAME"].ToString() + " =0;";
                            break;
                        case "float":
                            Script += " double " + row["COLUMN_NAME"].ToString() + " =0;";
                            break;
                        case "smallmoney":
                        case "money":
                            Script += " decimal " + row["COLUMN_NAME"].ToString() + " =0;";
                            break;
                        case "smallint":
                            Script += " short " + row["COLUMN_NAME"].ToString() + " =0;";
                            break;
                        case "tinyint":
                            Script += " byte " + row["COLUMN_NAME"].ToString() + " =1;";
                            break;
                        case "uniqueidentifier":
                            Script += " Guid " + row["COLUMN_NAME"].ToString()+ " = Guid.NewGuid();";
                            break;
                    }

            }

            return Script.Substring(0, Script.Length - 1);

        }
  
    static string GetProparetyWithRef(DataTable dataTable, string FindBy, ref string Script)
        {
            if (dataTable.Rows.Count <= 0)
                return "";
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["COLUMN_NAME"].ToString() != FindBy)
                    Script += " ref ";

                Script += row["COLUMN_NAME"].ToString() + " ,";

            }


                return Script.Substring(0, Script.Length - 1);
        }



    static string GetProparety(DataTable dataTable,ref string Script)
        {
            if (dataTable.Rows.Count <= 0)
                return "";

            foreach (DataRow row in dataTable.Rows)
            {
                Script += row["COLUMN_NAME"].ToString() + " ,";

            }


            return Script.Substring(0, Script.Length - 1);
        }



    }

    }
