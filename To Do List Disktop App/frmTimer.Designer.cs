namespace WindowsFormsApp1
{
    partial class frmTimer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimer));
            this.lblTimer = new System.Windows.Forms.Label();
            this.cbTasks = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblTask = new System.Windows.Forms.Label();
            this.gpChooseTime = new System.Windows.Forms.GroupBox();
            this.nudHours = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.nudMinutes = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.pbTimePercentage = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.btnStart = new Guna.UI2.WinForms.Guna2Button();
            this.lblReamingTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStopOrContinue = new Guna.UI2.WinForms.Guna2Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.gpChooseTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).BeginInit();
            this.pbTimePercentage.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.White;
            this.lblTimer.Location = new System.Drawing.Point(259, 9);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(59, 24);
            this.lblTimer.TabIndex = 7;
            this.lblTimer.Text = "Timer";
            // 
            // cbTasks
            // 
            this.cbTasks.AutoRoundedCorners = true;
            this.cbTasks.BackColor = System.Drawing.Color.Transparent;
            this.cbTasks.BorderRadius = 17;
            this.cbTasks.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTasks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTasks.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTasks.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTasks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbTasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbTasks.ItemHeight = 30;
            this.cbTasks.Location = new System.Drawing.Point(80, 126);
            this.cbTasks.Name = "cbTasks";
            this.cbTasks.Size = new System.Drawing.Size(140, 36);
            this.cbTasks.TabIndex = 8;
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTask.ForeColor = System.Drawing.Color.White;
            this.lblTask.Location = new System.Drawing.Point(76, 77);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(50, 24);
            this.lblTask.TabIndex = 9;
            this.lblTask.Text = "Task";
            // 
            // gpChooseTime
            // 
            this.gpChooseTime.Controls.Add(this.lblMinutes);
            this.gpChooseTime.Controls.Add(this.lblHours);
            this.gpChooseTime.Controls.Add(this.nudMinutes);
            this.gpChooseTime.Controls.Add(this.nudHours);
            this.gpChooseTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpChooseTime.ForeColor = System.Drawing.Color.White;
            this.gpChooseTime.Location = new System.Drawing.Point(311, 59);
            this.gpChooseTime.Name = "gpChooseTime";
            this.gpChooseTime.Size = new System.Drawing.Size(249, 152);
            this.gpChooseTime.TabIndex = 10;
            this.gpChooseTime.TabStop = false;
            this.gpChooseTime.Text = "Choose time";
            // 
            // nudHours
            // 
            this.nudHours.BackColor = System.Drawing.Color.Transparent;
            this.nudHours.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudHours.FillColor = System.Drawing.Color.Gray;
            this.nudHours.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHours.ForeColor = System.Drawing.Color.White;
            this.nudHours.Location = new System.Drawing.Point(41, 83);
            this.nudHours.Name = "nudHours";
            this.nudHours.Size = new System.Drawing.Size(70, 36);
            this.nudHours.TabIndex = 14;
            this.nudHours.UpDownButtonFillColor = System.Drawing.Color.Black;
            this.nudHours.UpDownButtonForeColor = System.Drawing.Color.White;
            // 
            // nudMinutes
            // 
            this.nudMinutes.BackColor = System.Drawing.Color.Transparent;
            this.nudMinutes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudMinutes.FillColor = System.Drawing.Color.Gray;
            this.nudMinutes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinutes.ForeColor = System.Drawing.Color.White;
            this.nudMinutes.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMinutes.Location = new System.Drawing.Point(138, 83);
            this.nudMinutes.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.nudMinutes.Name = "nudMinutes";
            this.nudMinutes.Size = new System.Drawing.Size(70, 36);
            this.nudMinutes.TabIndex = 15;
            this.nudMinutes.UpDownButtonFillColor = System.Drawing.Color.Black;
            this.nudMinutes.UpDownButtonForeColor = System.Drawing.Color.White;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.ForeColor = System.Drawing.Color.White;
            this.lblHours.Location = new System.Drawing.Point(52, 50);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(49, 18);
            this.lblHours.TabIndex = 11;
            this.lblHours.Text = "Hours";
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.ForeColor = System.Drawing.Color.White;
            this.lblMinutes.Location = new System.Drawing.Point(143, 50);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(60, 18);
            this.lblMinutes.TabIndex = 16;
            this.lblMinutes.Text = "Minutes";
            // 
            // pbTimePercentage
            // 
            this.pbTimePercentage.Controls.Add(this.lblReamingTime);
            this.pbTimePercentage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.pbTimePercentage.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.pbTimePercentage.ForeColor = System.Drawing.Color.White;
            this.pbTimePercentage.Location = new System.Drawing.Point(48, 191);
            this.pbTimePercentage.Minimum = 0;
            this.pbTimePercentage.Name = "pbTimePercentage";
            this.pbTimePercentage.ProgressColor = System.Drawing.Color.Silver;
            this.pbTimePercentage.ProgressColor2 = System.Drawing.Color.Gray;
            this.pbTimePercentage.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbTimePercentage.Size = new System.Drawing.Size(196, 196);
            this.pbTimePercentage.TabIndex = 11;
            this.pbTimePercentage.Text = "guna2CircleProgressBar1";
            this.pbTimePercentage.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.AutoRoundedCorners = true;
            this.btnStart.BorderRadius = 21;
            this.btnStart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStart.FillColor = System.Drawing.Color.DarkGray;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(377, 235);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(108, 45);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblReamingTime
            // 
            this.lblReamingTime.AutoSize = true;
            this.lblReamingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReamingTime.ForeColor = System.Drawing.Color.White;
            this.lblReamingTime.Location = new System.Drawing.Point(41, 79);
            this.lblReamingTime.Name = "lblReamingTime";
            this.lblReamingTime.Size = new System.Drawing.Size(120, 31);
            this.lblReamingTime.TabIndex = 18;
            this.lblReamingTime.Text = "00:00:00";
            this.lblReamingTime.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStopOrContinue
            // 
            this.btnStopOrContinue.AutoRoundedCorners = true;
            this.btnStopOrContinue.BorderRadius = 21;
            this.btnStopOrContinue.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStopOrContinue.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStopOrContinue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStopOrContinue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStopOrContinue.FillColor = System.Drawing.Color.DarkGray;
            this.btnStopOrContinue.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopOrContinue.ForeColor = System.Drawing.Color.White;
            this.btnStopOrContinue.Location = new System.Drawing.Point(92, 402);
            this.btnStopOrContinue.Name = "btnStopOrContinue";
            this.btnStopOrContinue.Size = new System.Drawing.Size(108, 45);
            this.btnStopOrContinue.TabIndex = 18;
            this.btnStopOrContinue.Text = "StopOrContinue";
            this.btnStopOrContinue.Visible = false;
            this.btnStopOrContinue.Click += new System.EventHandler(this.btnStopOrContinue_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipTitle = "Time end";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // frmTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(608, 498);
            this.Controls.Add(this.btnStopOrContinue);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbTimePercentage);
            this.Controls.Add(this.gpChooseTime);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.cbTasks);
            this.Controls.Add(this.lblTimer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmTimer";
            this.Text = "Timer";
            this.Load += new System.EventHandler(this.frmTimer_Load);
            this.gpChooseTime.ResumeLayout(false);
            this.gpChooseTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).EndInit();
            this.pbTimePercentage.ResumeLayout(false);
            this.pbTimePercentage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTimer;
        private Guna.UI2.WinForms.Guna2ComboBox cbTasks;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.GroupBox gpChooseTime;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblHours;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudMinutes;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudHours;
        private Guna.UI2.WinForms.Guna2CircleProgressBar pbTimePercentage;
        private Guna.UI2.WinForms.Guna2Button btnStart;
        private System.Windows.Forms.Label lblReamingTime;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Button btnStopOrContinue;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}