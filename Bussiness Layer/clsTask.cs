using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Access_Layer;

namespace Bussiness_Layer
{
    public class clsTask
    {
        private enum enMode { Update=0 , AddNew=1};
        private enMode _Mode;
        private int _TaskID;
        public int TaskID { get { return _TaskID; } }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        private DateTime _BeginningDate;
        public DateTime BeginningDate { get { return _BeginningDate; } }
        public DateTime DeadLine { get; set;}
        public int CategoryID { get; set; }
        public bool IsCompleted { get; set; }

        private clsTask(int TaskID , string TaskName , string TaskDescription 
            , DateTime BeginningDate , DateTime DeadLIne ,  int CategoryID , bool IsCompleted )
        {
            _TaskID = TaskID;
            this.TaskName = TaskName;
            this.TaskDescription = TaskDescription;
            this._BeginningDate = BeginningDate;
            this.DeadLine = DeadLIne;
            this.CategoryID = CategoryID;
            this.IsCompleted = IsCompleted;
            this._Mode = enMode.Update;
        }

        public clsTask()
        {
            _TaskID = default( int );
            this.TaskName = default(string);
            this.TaskDescription = default(string);
            this._BeginningDate = default(DateTime);
            this.DeadLine = default(DateTime);
            this.CategoryID = default(int);
            this.IsCompleted = default(bool);
            this._Mode = enMode.AddNew;
        }

        public clsTask Find(int TaskID)
        {
            string TaskName=null , TaskDescription = null;
            DateTime BeginningDate = DateTime.Now, DeadLine = DateTime.Now;
            int CategoryID =-1 ;
            bool IsCompleted= false ;
            if (clsTaskDataAccess.FindTaskByID(TaskID, ref TaskName, ref TaskDescription,
                ref BeginningDate, ref DeadLine, ref CategoryID, ref IsCompleted))
            {
                return new clsTask(TaskID, TaskName, TaskDescription, BeginningDate, DeadLine, CategoryID, IsCompleted);
            }
            else return null;
        }

        public clsTask Find(string TaskName)
        {
            int TaskID = -1;
            string TaskDescription = null;
            DateTime BeginningDate = DateTime.Now, DeadLine = DateTime.Now;
            int CategoryID = -1;
            bool IsCompleted = false;
            if (clsTaskDataAccess.FindTaskByName(ref TaskID, TaskName, ref TaskDescription,
                ref BeginningDate, ref DeadLine, ref CategoryID, ref IsCompleted))
            {
                return new clsTask(TaskID, TaskName, TaskDescription, BeginningDate, DeadLine, CategoryID, IsCompleted);
            }
            else return null;
        }

        public clsTask GetAddNewTaskObject()
        { return new clsTask(); }

        static public bool Delete(int TaskID)
        {
            return clsTaskDataAccess.DeleteTask(TaskID);
        }

        static public DataTable ListTasks()
        {
            return clsTaskDataAccess.ListTasks();
        }
        
        static public DataTable ListTasksByCategory(int CategoryID)
        {
            if (clsCategoryDataAccess.IsCategoryExists(CategoryID))
            {
                return clsTaskDataAccess.ListTasksByCategory(CategoryID);
            }
            else return null;

        }

        static public DataTable ListTasksByStatus(bool IsCompleted)
        {
            return clsTaskDataAccess.ListTasksByStatus(IsCompleted);
        }

        public static DataTable ListTasksByCategoryAndLikeName(int CategoryID, string LikeName)
        {
            if (clsCategoryDataAccess.IsCategoryExists(CategoryID))
            {
                return clsTaskDataAccess.ListTasksByCategoryAndLikeName(LikeName, CategoryID);
            }
            else return null;
        }

        public static DataTable ListTasksByCategoryAndStatusAndLikeName(string LikeName, int CategoryID, bool IsCompleted)
        {
            if (clsCategoryDataAccess.IsCategoryExists(CategoryID))
            {
                return clsTaskDataAccess.ListTasksByCategoryAndStatusAndLikeName(LikeName, CategoryID, IsCompleted);
            }
            else return null;
        }

        private bool _Update()
        {
            return clsTaskDataAccess.ModifyTask(TaskID, TaskName, TaskDescription, DeadLine, CategoryID, IsCompleted);
        }

        private bool _AddNew()
        {
            int TempID = clsTaskDataAccess.AddTask(TaskName, TaskDescription, DeadLine, CategoryID);
            if(TempID!=-1)
            {
                this._TaskID = TempID;
                return true;

            }
            else
            {
                return false;
            }
            
        }

        public bool Save()
        {
            if(_Mode == enMode.Update)
            {
                return _Update();
            }
            else
            {
                if (_AddNew())
                {
                    _Mode = enMode.Update;
                    return true;
                }
                else return false;
            }
        }

        static public bool IsTaskExists(int TaskID)
        {
            return clsTaskDataAccess.IsTaskExists(TaskID);
        }

        static public bool IsTaskExists(string TaskName)
        {
            return clsTaskDataAccess.IsTaskExists(TaskName);
        }
    }
}
