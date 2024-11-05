using Bussiness_Layer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmMain : Form
    {
        enum enStatus { Pending = 0 , Completed = 1 , All =-1}
        DataTable _TasksTable = new DataTable();
        DataView _TasksView = new DataView();
        string _Category = "Personal";
        enStatus _Status = enStatus.All;
        
        void _PrepareTasksTableColumns()
        {
            _TasksTable.Columns.Add("Name",typeof(string));
            _TasksTable.Columns.Add("Description",typeof(string));
            _TasksTable.Columns.Add("Beginning Date" , typeof(DateTime));
            _TasksTable.Columns.Add("Dead Line", typeof(DateTime));
            _TasksTable.Columns.Add("Category" ,  typeof(string));
            _TasksTable.Columns.Add("IsCompleted" , typeof(bool));
        }
        public frmMain()
        {
            InitializeComponent();
            _PrepareTasksTableColumns();
            _ConvertTasksTableIntodgvTable(clsTask.ListTasks());
            _TasksView = _TasksTable.DefaultView;
        }

        void _ConvertTasksTableIntodgvTable(DataTable dt)
        {
            if(dt !=null || dt.TableName == "Tasks")
            {
                _TasksTable.Rows.Clear();
                foreach(DataRow row in dt.Rows)
                {
                    string TaskName = row["TaskName"].ToString();
                    string Description = row["TaskDescription"].ToString();
                    DateTime BeginningDate = (DateTime)row["BegainingDate"];
                    DateTime DeadLine = (DateTime)row["DeadLine"];
                    string Category = clsCategory.GetCategoryName((int)row["CategoryID"]);
                    bool IsCompleted = (bool)row["IsComplete"];
                    _TasksTable.Rows.Add(TaskName, Description, BeginningDate, DeadLine, Category, IsCompleted);
                }
                
            }
        }

        

        void _LoadDataGridView()
        {
            dgvTasks.DataSource = _TasksView;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            _LoadDataGridView();
            btnShowAll.PerformClick();
        }

        void _ApplyFilterInDGV(string Name , string Category , enStatus Status)
        {
            string StatusFilter = (Status == enStatus.All)?"" : "and IsCompleted = " + (int)Status;
            string Filter = $"Name like '%{Name}%' and Category = '{Category}' {StatusFilter} ";
            _TasksView.RowFilter = Filter;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilterInDGV(txtSearch.Text,_Category,_Status);
        }

        void _ChangeStatusColor(Guna2Button btn)
        {
            btnShowAll.FillColor = Color.DarkGray;
            btnShowPending.FillColor = Color.DarkGray;
            btnShowCompleted.FillColor = Color.DarkGray;
            btn.FillColor = btn.FocusedColor;
        }

        private void btnShowByStatus_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            _ChangeStatusColor(btn);
            _Status = (enStatus)(int.Parse(btn.Tag.ToString()));
            _ApplyFilterInDGV(txtSearch.Text,_Category, _Status);
            
        }
    }
}
