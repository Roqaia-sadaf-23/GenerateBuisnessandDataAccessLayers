using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateBuisnessandDataAccessLayers.Buisness
{
    public class clsSaveDeleteIsExistEvent
    {

       public static string SaveFunc( string TableSingalName)
        {


            string Script = " public bool Save()\r\n        {\r\n            switch (Mode)\r\n      " +
                "      {\r\n                case enMode.AddNew:\r\n                    if (_AddNew" + TableSingalName + "())" +
                " {\r\n\r\n                        Mode = enMode.Update;\r\n                        return true;\r\n                    }\r\n      " +
                "              else\r\n                    {\r\n                        return false;\r\n                    }\r\n\r\n                case enMode.Update:\r\n\r\n               " +
                "     return _Update" + TableSingalName + "();\r\n\r\n            }   return false;\r\n        }";


            return Script;
        }


         public static string DeleteFunc(string TableSingalName,string FindBy)
        {
            string Script = " public  bool Delete()\r\n        {\r\n            return cls" + TableSingalName + "Data.Delete" + TableSingalName + "(this." + FindBy + "); \r\n        }";

            return Script;
        
        }


        public static string GetAll(string TableName, string TableSingalName)
        {
            string Script = " public static DataTable GetAll" + TableName + "()\r\n        {\r\n            return cls" + TableSingalName + "Data.GetAll" + TableName + "();\r\n        }";
            return Script;
        }



        public static string IsExitFunc(string TableSingalName, string FindBy, object TableColumns)
        {
            DataTable dataTable = TableColumns as DataTable;

            string Script = " public static bool Is"+TableSingalName+ "Exist(";
            GetProparetyAndDataType(dataTable, FindBy, ref Script);
          //  Script=Script.Substring(0,Script.Length-1);
            Script += ")\r\n        {\r\n           return cls" + TableSingalName + "Data.Is" + TableSingalName + "Exist(" + FindBy + ");\r\n        }";





             return Script;
        }


        static string GetProparetyAndDataType(DataTable dataTable, string FindBy, ref string Script)
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
    }
}
