using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Data_Access_Layer
{
    static public class clsTaskDataAccess
    {
        static public int AddTask( ref string TaskName , ref string TaskDescription ,
            ref DateTime DeadLine , int CategoryID = 1)
        {
            int TaskID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessLayerSettings._ConnectionString);
            string Query = @"Insert Into Tasks (TaskName , TaskDescription 
                            , DeadLine , CategoryID )
                             values
                             (@TaskName , @TaskDescription , @DeadLine , @CategoryID);
                              SELECT SCOPE_IDENTITY();      ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TaskName", TaskName);
            if(string .IsNullOrEmpty(TaskDescription) )
            {
                Command.Parameters.AddWithValue("@TaskDescription", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@TaskDescription", TaskDescription);
            }
            
            Command.Parameters.AddWithValue("@DeadLine", DeadLine);
            Command.Parameters.AddWithValue("@CategoryID", CategoryID);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString() , out int TempID))
                {
                    TaskID = TempID;
                }
            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }
            return TaskID;
        }

        static public bool DeleteTask(int TaskID) 
        {
            bool IsDeleted = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessLayerSettings._ConnectionString);
            string Query = @"Delete From Tasks 
                            Where TaskID = @TaskID";
            SqlCommand Command = new SqlCommand(Query,Connection);
            Command.Parameters.AddWithValue("@TaskID", TaskID);
            try
            {
                Connection.Open();
                int RowsAffected = Command.ExecuteNonQuery();
                IsDeleted=(RowsAffected > 0 );
            }
            catch
            {
        
            }
            finally
            {
                Connection.Close();
            }
            return IsDeleted;
        }

        static public bool ModifyTask(int TaskID, string TaskName, string TaskDescription,
             DateTime DeadLine, int CategoryID , bool IsCompleted)
        {
            bool IsUpdated = false;
            
            SqlConnection Connection = new SqlConnection(clsDataAccessLayerSettings._ConnectionString);
            string Query = @"Update Tasks
                            set
                            TaskName = @TaskName , 
                            TaskDescription = @TaskDescription , 
                            DeadLine = @DeadLine , 
                            CategoryID = @CategoryID , 
                            IsComplete = @IsCompleted  
                            Where TaskID = @TaskID";

                              
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TaskID", TaskID);
            Command.Parameters.AddWithValue("@TaskName", TaskName);
            if (string.IsNullOrEmpty(TaskDescription))
            {
                Command.Parameters.AddWithValue("@TaskDescription", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@TaskDescription", TaskDescription);
            }

            Command.Parameters.AddWithValue("@DeadLine", DeadLine);
            Command.Parameters.AddWithValue("@CategoryID", CategoryID);
            byte IsComplete = (byte) ((IsCompleted) ? 1 : 0);
            Command.Parameters.AddWithValue("@IsCompleted", IsComplete);
            try
            {
                Connection.Open();
                int RowsAffected = Command.ExecuteNonQuery();
                IsUpdated = (RowsAffected > 0);
            }
            catch
            {

            }
            finally
            {
                Connection.Close();

            }
            return IsUpdated;
        }
    }
}
