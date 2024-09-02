using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateBuisnessandDataAccessLayers.Buisness
{
    public class clsUpdate
    {

       public static string updateFunc(string TableName, string TableSingalName, object TableColumns, string FindBy)
        {
            DataTable dataTable = TableColumns as DataTable;

            string Script = " private bool _Update" + TableSingalName + "(){" +
                "   //call DataAccess Layer \r\n\r\n            return cls" + TableSingalName + "Data.Update" + TableSingalName + "(";
            GetProparety(dataTable,ref Script);
            Script =Script.Substring(0, Script.Length - 1);
            Script += ");  \r\n        }";

            return Script;
        }

        static string GetProparety(DataTable Table,ref string Script)
        {
            if (Table.Rows.Count <= 0)
                return "";


            foreach (DataRow row in Table.Rows)
            {
                

                    Script += "this." + row["COLUMN_NAME"].ToString() + ",";

            }

            return Script.Substring(0, Script.Length - 1);
        }
    }
}
