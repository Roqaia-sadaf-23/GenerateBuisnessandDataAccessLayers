using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateBuisnessandDataAccessLayers.Buisness
{
    public  class clsAddNew
    {

        public static string AddFunc(string TableName, string TableSingalName, object TableColumns, string FindBy)
        {
            DataTable dataTable = TableColumns as DataTable;
            string Script = "  private bool _AddNew" + TableSingalName + "(){\r\n\n this."+FindBy+ " = cls"+TableSingalName+ "Data.AddNew"+ TableSingalName +"InfoBy" + FindBy + "(";

            GetProparety(dataTable,FindBy,ref Script);
            Script=Script.Substring(0,Script.Length-1);

            Script += ");\r\n\r\n            return (this." + FindBy + "!= -1);\r\n        }";

            return Script;


        }


        static string GetProparety(DataTable Table,string FindBy,ref string Script)
        {
            if (Table.Rows.Count <= 0)
                return "";


            foreach (DataRow row in Table.Rows)
            {
                if (row["COLUMN_NAME"].ToString() != FindBy) 

                Script += "this." + row["COLUMN_NAME"].ToString() +",";

            }

            return Script.Substring(0, Script.Length - 1);
        }


    }
}
