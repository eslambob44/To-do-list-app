using Bussiness_Layer;
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
    public partial class frmAddNewUpdateTask : Form
    {
        clsTask _Task = null;
        enum enMode { Update = 1 , AddNew=2};
        enMode _Mode;

        void _CloseForm()
        {
            MessageBox.Show("Invalid Task");
            this.Close();
        }

        bool _InitialTaskObject(int TaskID)
        {
            bool IsTaskCanInitial = true;
            if (TaskID == -1)
            {
                _Task = clsTask.GetAddNewTaskObject();
                _Mode = enMode.AddNew;
            }
            else if (clsTask.IsTaskExists(TaskID))
            {
                _Task = clsTask.Find(TaskID);
                _Mode = enMode.Update;
            }
            else 
                IsTaskCanInitial = false;

            return IsTaskCanInitial;

        }
        public frmAddNewUpdateTask(int TaskID)
        {
            InitializeComponent();
            
            if(!_InitialTaskObject(TaskID))
            {
                _CloseForm();
            }
            
                
            
                
        }

        void _LoadCategoriesInComboBox()
        {
            cbCategories.Items.Clear();

            DataTable dtCategories = clsCategory.ListCategories();
            foreach (DataRow rowCategory in dtCategories.Rows)
            {
                cbCategories.Items.Add(rowCategory["CategoryName"]);
            }
        }

        void _LoadForm()
        {
            lblAddEdit.Text = ((_Mode == enMode.AddNew)?"Add New":"Update") + " Task";
            this.Text = lblAddEdit.Text;
            _LoadCategoriesInComboBox();
            cbCategories.SelectedIndex = 0;
            dtpDeadLine.Value = DateTime.Now;
            if(_Mode  == enMode.Update)
            {
                txtTaskName.Text = _Task.TaskName;
                txtDescription.Text = _Task.TaskDescription;
                dtpDeadLine.Value = _Task.DeadLine;
                string Category = clsCategory.GetCategoryName(_Task.CategoryID);
                cbCategories.SelectedIndex = cbCategories.FindString(Category);

            }
            
        }

        private void frmAddNewUpdateTask_Load(object sender, EventArgs e)
        {
            _LoadForm();
        }

        private void txtTaskName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaskName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTaskName, "You must enter task");
                return;
            }
            else if (clsTask.IsTaskExists(txtTaskName.Text))
            {
                if (_Mode == enMode.AddNew || (txtTaskName.Text != _Task.TaskName))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtTaskName, "There is a task that have similar name");
                    return;
                }

            }
            e.Cancel = false;
            errorProvider1.SetError(txtTaskName, "");
            
        }

        private void dtpDeadLine_Validating(object sender, CancelEventArgs e)
        {
            if(_Mode==enMode.Update && dtpDeadLine.Value <= _Task.BeginningDate)
            {
                e.Cancel=true;
                errorProvider1.SetError(dtpDeadLine, "Cant make the dead line before beginning date which is " + _Task.BeginningDate);
            }
            else if(_Mode == enMode.AddNew && dtpDeadLine.Value <=DateTime.Now)
            {
                e.Cancel=true;
                errorProvider1.SetError(dtpDeadLine, "Cant make the dead line before now");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(dtpDeadLine, "");
            }
        }

        string _GetInvalidInputMessage()
        {
            if (txtTaskName.Text == "") return "Cant enter an empty task name";
            else if (_Mode == enMode.AddNew && clsTask.IsTaskExists(txtTaskName.Text))
                return "The task name already exists enter another one";
            else if (clsTask.IsTaskExists(txtTaskName.Text) && txtTaskName.Text != _Task.TaskName)
                return "The task name already exists enter another one";
            else if (dtpDeadLine.Value <= DateTime.Now) return "Dead line cant be before now";
            else return "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Task.TaskName = txtTaskName.Text;
             _Task.TaskDescription = txtDescription.Text;
            _Task.DeadLine = dtpDeadLine.Value;
            _Task.CategoryID = clsCategory.GetCategoryID(cbCategories.Text);
            _Task.IsCompleted = (_Mode == enMode.Update)?_Task.IsCompleted:false;

            if (_Task.Save())
            {
                MessageBox.Show("Task saved successfully","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if(_Mode==enMode.AddNew)
                {
                    _Mode = enMode.Update;
                    lblAddEdit.Text = ((_Mode == enMode.AddNew) ? "Add New" : "Update") + " Task";
                    this.Text = lblAddEdit.Text;
                }
            }
            else
            {
                string ErrorMessage = _GetInvalidInputMessage();
                MessageBox.Show(ErrorMessage,"Input error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
