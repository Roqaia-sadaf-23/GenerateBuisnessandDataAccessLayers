using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateBuisnessandDataAccessLayers.Buisness
{
    public class clsConstructor
    {


        public static string GetConstructor(string TableName, string TableSingalName, object TableColumns, string FindBy)
        {
            string Script = "";
            GetMode(ref Script);

            DataTable dataTable = TableColumns as DataTable;

            GetProparety(dataTable, ref Script);
            Script += "public  cls" + TableSingalName + "()\n{\n";
            GetProparetyforConstructorEmpty(dataTable, ref Script);
            Script += "\n Mode = enMode.AddNew;\n\n}\n\n";

            Script += "private  cls" + TableSingalName + "(";
            GetProparetyandDataTypeinConstructor(dataTable,ref Script); 
            Script=Script.Substring(0,Script.Length-1);
            Script += ")\n{\n\n";
            GetProparetyinConstructor(dataTable, ref Script);
           // Script = Script.Substring(Script.Length - 1);
            Script += "\n Mode = enMode.Update;\n\n}\n";


            return Script;

        }

        static string GetProparetyforConstructorEmpty(DataTable dataTable, ref string Script)
        {

            if (dataTable.Rows.Count <= 0)
                return "";


            foreach (DataRow row in dataTable.Rows)
            {
              
                    switch (row["DATA_TYPE"].ToString())
                    {

                        case "int":
                            Script += "this." + row["COLUMN_NAME"].ToString() + " =-1;\n ";
                            break;
                        case "varchar":
                        case "nvarchar":
                            Script += "this." + row["COLUMN_NAME"].ToString() + " =\"\";\n";
                            break;
                        case "bit":
                            Script += "this." + row["COLUMN_NAME"].ToString() + " =true;\n";
                            break;
                        case "smalldatetime":
                        case "datetime":
                            Script += "this." + row["COLUMN_NAME"].ToString() + " = DateTime.Now;\n";
                            break;
                        case "decimal":
                            Script += "his." + row["COLUMN_NAME"].ToString() + " =0;\n";
                            break;
                        case "float":
                            Script += "this." + row["COLUMN_NAME"].ToString() + " =0;\n";
                            break;
                        case "smallmoney":
                        case "money":
                            Script += "this." + row["COLUMN_NAME"].ToString() + " =0;\n";
                            break;
                        case "smallint":
                            Script += "this." + row["COLUMN_NAME"].ToString() + " =0;\n";
                            break;
                        case "tinyint":
                            Script += "this." + row["COLUMN_NAME"].ToString() + " =1;\n";
                            break;
                        case "uniqueidentifier":
                            Script += "this." + row["COLUMN_NAME"].ToString() + " = Guid.NewGuid();\n";
                            break;
                    }

            }

            return Script.Substring(0, Script.Length - 1);

        }
   
        static string GetProparetyandDataTypeinConstructor(DataTable dataTable, ref string Script)
        {
            if (dataTable.Rows.Count <= 0)
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
        static string GetProparetyinConstructor(DataTable dataTable, ref string Script)
        {
            if (dataTable.Rows.Count <= 0)
                return "";


            foreach (DataRow row in dataTable.Rows)
            {
                Script += "this." + row["COLUMN_NAME"].ToString() + " = "+ row["COLUMN_NAME"].ToString()+";\n";

            }

            return Script.Substring(0, Script.Length - 1);
        }



        static string GetMode(ref string Script)
        {
            Script = " public enum enMode { AddNew = 0, Update = 1 };\r\n    " +
                "    public enMode Mode = enMode.AddNew;\n\n\n";
            return Script;
        }

      
        static string GetProparety(DataTable dataTable, ref string Script)
        {
                if (dataTable.Rows.Count <= 0)
                    return "";


            foreach (DataRow row in dataTable.Rows)
            {

                switch (row["DATA_TYPE"].ToString())
                {

                    case "int":
                        Script += " public int " + row["COLUMN_NAME"].ToString() + " { set; get; } \n";
                        break;
                    case "varchar":
                    case "nvarchar":
                        Script += " public string "+ row["COLUMN_NAME"].ToString() + " { set; get; }\n";
                        break;
                    case "bit":
                        Script += " public bool " + row["COLUMN_NAME"].ToString() + " { set; get; }\n";
                        break;
                    case "smalldatetime":
                    case "datetime":
                        Script += " public DateTime " +row["COLUMN_NAME"].ToString() + " { set; get; }\n";
                        break;
                    case "decimal":
                        Script += " public decimal " +row["COLUMN_NAME"].ToString() + " { set; get; }\n";
                        break;
                    case "float":
                        Script += "public double " + row["COLUMN_NAME"].ToString() + " { set; get; }\n";
                        break;
                    case "smallmoney":
                    case "money":
                        Script += "public decimal " + row["COLUMN_NAME"].ToString() + " { set; get; }\n";
                        break;
                    case "smallint":
                        Script += "public short " + row["COLUMN_NAME"].ToString() + " { set; get; }\n";
                        break;
                    case "tinyint":
                        Script += "public byte " + row["COLUMN_NAME"].ToString() + " { set; get; }\n";
                        break;
                    case "uniqueidentifier":
                        Script += "public Guid " + row["COLUMN_NAME"].ToString() + " { set; get; }\n";
                        break;
                }

             
            }

            return Script.Substring(0, Script.Length - 1);
        }
    }
}
