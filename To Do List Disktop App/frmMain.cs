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

        DataTable _TasksTable = new DataTable();
        DataView _TasksView = new DataView();
        void _PrepareTasksTableColumns()
        {
            _TasksTable.Columns.Add("Name",typeof(string));
            _TasksTable.Columns.Add("Description",typeof(string));
            _TasksTable.Columns.Add("Beginning Date" , typeof(DateTime));
            _TasksTable.Columns.Add("Dead Line", typeof(DateTime));
            _TasksTable.Columns.Add("Category" ,  typeof(string));
            _TasksTable.Columns.Add("Is Completed" , typeof(bool));
        }
        public frmMain()
        {
            InitializeComponent();
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
            _PrepareTasksTableColumns();
            _ConvertTasksTableIntodgvTable(clsTask.ListTasks());
            _TasksView = _TasksTable.DefaultView;
            _LoadDataGridView();
            btnShowAll.PerformClick();
        }

        void _ApplyFilterInDGV()
        {
            string Filter = "'%" + txtSearch.Text + "%'";
            _TasksView.RowFilter = "Name like " + Filter;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilterInDGV();
        }

        void _ChangeStatusColor(Guna2Button btn)
        {
            btnShowAll.FillColor = Color.DarkGray;
            btnShowPending.FillColor = Color.DarkGray;
            btnShowCompleted.FillColor = Color.DarkGray;
            btn.FillColor = btn.FocusedColor;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            _ChangeStatusColor(sender as Guna2Button);
            int CategoryID = 1;
            DataTable TempTable = clsTask.ListTasksByCategory(1);
            if (TempTable !=null)
            {
                _ConvertTasksTableIntodgvTable(TempTable);
                dgvTasks.Refresh();
            }
        }



        private void btnShowByStatus_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            _ChangeStatusColor(btn);
            bool Status = (int.Parse(btn.Tag.ToString()) ==0)?false:true;
            int CategoryID = 1;
            DataTable TempTable = clsTask.ListTasksByCategoryAndStatus(1,Status);
            if (TempTable != null)
            {
                 _ConvertTasksTableIntodgvTable(TempTable);
                dgvTasks.Refresh();
            }
        }
    }
}
