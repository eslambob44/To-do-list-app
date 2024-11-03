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
        static public int AddTask( string TaskName ,  string TaskDescription ,
             DateTime DeadLine , int CategoryID = 1)
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

        static public bool FindTaskByID(int TaskID , ref string TaskName , ref string TaskDescription , ref DateTime BegainingDate 
            , ref DateTime DeadLine ,ref int CategoryID ,ref bool IsCompleted)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessLayerSettings._ConnectionString);
            string Query = @"Select * From Tasks
                            Where TaskID = @TaskID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TaskID", TaskID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if(Reader.Read())
                {
                    IsFound = true;
                    TaskName = (string)Reader["TaskName"];
                    if (Reader["TaskDescription"] == DBNull.Value)
                    {
                        TaskDescription = null;
                    }
                    else
                    {
                        TaskDescription = (string)Reader["TaskDescription"];
                    }
                    BegainingDate = (DateTime)Reader["BegainingDate"];
                    DeadLine = (DateTime)Reader["DeadLine"];
                    CategoryID = (int)Reader["CategoryID"];
                    IsCompleted=((int)Reader["IsComplete"]==1) ? true : false;
                }
                Reader.Close();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }
            return IsFound;
        }

        static public DataTable ListTasks()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessLayerSettings._ConnectionString);
            string Query = "Select * From Tasks";
            SqlCommand command = new SqlCommand(Query,Connection);
            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if(Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }

        public static DataTable ListTasksByStatus(bool IsCompleted) 
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessLayerSettings._ConnectionString);
            byte IsComplete = (byte)((IsCompleted) ? 1 : 0);
            string Query = @"Select * From Tasks
                            Where IsComplete = @IsComplete";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@IsComplete" , IsComplete);
            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }

        public static DataTable ListTasksByCategory(int CategoryID)
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessLayerSettings._ConnectionString);
            
            string Query = @"Select * From Tasks
                            Where CategoryID = @CategoryID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@CategoryID", CategoryID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }

        public static DataTable ListTasksByCategoryAndStatusAndLikeName(string TaskName
            , int CategoryID , bool IsCompleted)
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessLayerSettings._ConnectionString);
            byte IsComplete = (byte)((IsCompleted) ? 1 : 0);
            string Query = @"Select * From Tasks
                            Where IsComplete = @IsComplete
                            And TaskName like '%'+@TaskName+'%'
                            And CategoryID = @CategoryID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@IsComplete", IsComplete);
            command.Parameters.AddWithValue("@TaskName", TaskName);
            command.Parameters.AddWithValue("@CategoryID", CategoryID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            catch
            {

            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
    }
}
