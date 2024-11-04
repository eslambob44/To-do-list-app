using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Data_Access_Layer
{
    static public class clsCategoryDataAccess
    {
        static public int InsertCategory(string CategoryName )
        {
            int CategoryID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessLayerSettings._ConnectionString);
            string Query = @"Insert Into Categories (CategoryName)
                            values
                            (@CategoryName);
                            Select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query,Connection);
            Command.Parameters.AddWithValue("@CategoryName", CategoryName);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if(Result!=null && int.TryParse(Result.ToString(),out int TempID))
                {
                    CategoryID = TempID;
                }
            }
            catch 
            {

            }
            finally
            {
                Connection.Close();
            }
            return CategoryID;
        }
    }
}
