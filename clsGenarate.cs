using GenerateBuisnessandDataAccessLayers.Sitting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateBuisnessandDataAccessLayers
{
    public static class clsGenarateData
    {

        public static DataTable GetDataBase()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsGeneratorSettungs.ConnectionString);

            string query = @"Select name FROM master.sys.databases WHERE name not in ('master','tempdb','model','msdb')";
        
        SqlCommand command=new SqlCommand(query, connection);

            try
            {
                connection.Open();

               SqlDataReader reader = command.ExecuteReader();
               if(reader.HasRows)
                {

                    dataTable.Load(reader);
                }

               reader.Close();

            }catch (Exception ex)
            {
                Console.WriteLine("Error : {0}",ex.Message); 


            }finally
            {
                connection.Close();
            }
        return dataTable;   
        
        }

        public static DataTable GetTable()
        {


            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsGeneratorSettungs.ConnectionString);

            try
            {
                //sysdiagrams
                connection.Open();
                dataTable = connection.GetSchema("Tables");
            }catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }
        public static DataTable GetColumnProprety(string TableName)
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsGeneratorSettungs.ConnectionString);

            string query = @"SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE 
                                            FROM INFORMATION_SCHEMA.COLUMNS
                                                   WHERE TABLE_NAME =@TableName";

            SqlCommand command =new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TableName",TableName);

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();


                if(reader.HasRows)
                {
                    dataTable.Load(reader);
                }

                reader.Close();
            }catch(Exception ex)
            {

            }
            finally
            {

                connection.Close() ;    
            }
            return dataTable;
        }

        public static DataTable GetColumn(string TableName)
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsGeneratorSettungs.ConnectionString);

            //string query = @"SELECT COLUMN_NAME from INFOMATION_SCHEMA.COLUMNS
            //              where Table_Name =@TableName";
            string Query = @"SELECT COLUMN_NAME 
                               FROM INFORMATION_SCHEMA.COLUMNS
                               WHERE TABLE_NAME = @TableName";



          SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TableName",TableName);

            SqlDataReader reader = null;

            try
            {
                connection.Open();
                reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {

                connection.Close();
            }
            return dataTable;
        }



    }
}
