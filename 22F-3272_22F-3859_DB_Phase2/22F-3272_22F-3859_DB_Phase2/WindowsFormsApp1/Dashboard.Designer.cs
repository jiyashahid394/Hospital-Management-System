namespace WindowsFormsApp1
{
    partial class Dashboard
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
            this.checkprofilebttn = new System.Windows.Forms.Button();
            this.Manageemp = new System.Windows.Forms.Button();
            this.assignappointment = new System.Windows.Forms.Button();
            this.viewpatients = new System.Windows.Forms.Button();
            this.manageappointment = new System.Windows.Forms.Button();
            this.viewtask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkprofilebttn
            // 
            this.checkprofilebttn.BackColor = System.Drawing.Color.Transparent;
            this.checkprofilebttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkprofilebttn.ForeColor = System.Drawing.Color.Transparent;
            this.checkprofilebttn.Location = new System.Drawing.Point(205, 116);
            this.checkprofilebttn.Name = "checkprofilebttn";
            this.checkprofilebttn.Size = new System.Drawing.Size(227, 113);
            this.checkprofilebttn.TabIndex = 0;
            this.checkprofilebttn.UseVisualStyleBackColor = false;
            this.checkprofilebttn.Click += new System.EventHandler(this.checkprofilebttn_Click);
            // 
            // Manageemp
            // 
            this.Manageemp.BackColor = System.Drawing.Color.Transparent;
            this.Manageemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Manageemp.ForeColor = System.Drawing.Color.Transparent;
            this.Manageemp.Location = new System.Drawing.Point(695, 116);
            this.Manageemp.Name = "Manageemp";
            this.Manageemp.Size = new System.Drawing.Size(247, 113);
            this.Manageemp.TabIndex = 2;
            this.Manageemp.UseVisualStyleBackColor = false;
            this.Manageemp.Click += new System.EventHandler(this.Manageemp_Click);
            // 
            // assignappointment
            // 
            this.assignappointment.BackColor = System.Drawing.Color.Transparent;
            this.assignappointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.assignappointment.ForeColor = System.Drawing.Color.Transparent;
            this.assignappointment.Location = new System.Drawing.Point(205, 281);
            this.assignappointment.Name = "assignappointment";
            this.assignappointment.Size = new System.Drawing.Size(227, 113);
            this.assignappointment.TabIndex = 3;
            this.assignappointment.UseVisualStyleBackColor = false;
            this.assignappointment.Click += new System.EventHandler(this.assignappointment_Click);
            // 
            // viewpatients
            // 
            this.viewpatients.BackColor = System.Drawing.Color.Transparent;
            this.viewpatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewpatients.ForeColor = System.Drawing.Color.Transparent;
            this.viewpatients.Location = new System.Drawing.Point(447, 274);
            this.viewpatients.Name = "viewpatients";
            this.viewpatients.Size = new System.Drawing.Size(237, 120);
            this.viewpatients.TabIndex = 4;
            this.viewpatients.UseVisualStyleBackColor = false;
            this.viewpatients.Click += new System.EventHandler(this.viewpatients_Click);
            // 
            // manageappointment
            // 
            this.manageappointment.BackColor = System.Drawing.Color.Transparent;
            this.manageappointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageappointment.ForeColor = System.Drawing.Color.Transparent;
            this.manageappointment.Location = new System.Drawing.Point(690, 281);
            this.manageappointment.Name = "manageappointment";
            this.manageappointment.Size = new System.Drawing.Size(252, 122);
            this.manageappointment.TabIndex = 5;
            this.manageappointment.UseVisualStyleBackColor = false;
            this.manageappointment.Click += new System.EventHandler(this.manageappointment_Click);
            // 
            // viewtask
            // 
            this.viewtask.BackColor = System.Drawing.Color.Transparent;
            this.viewtask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewtask.ForeColor = System.Drawing.Color.Transparent;
            this.viewtask.Location = new System.Drawing.Point(432, 400);
            this.viewtask.Name = "viewtask";
            this.viewtask.Size = new System.Drawing.Size(252, 122);
            this.viewtask.TabIndex = 6;
            this.viewtask.UseVisualStyleBackColor = false;
            this.viewtask.Click += new System.EventHandler(this.viewtask_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Neutral_Beige_Minimalist_Online_Courses_Dashboard_Desktop_Prototype__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1014, 531);
            this.Controls.Add(this.viewtask);
            this.Controls.Add(this.manageappointment);
            this.Controls.Add(this.viewpatients);
            this.Controls.Add(this.assignappointment);
            this.Controls.Add(this.Manageemp);
            this.Controls.Add(this.checkprofilebttn);
            this.DoubleBuffered = true;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button checkprofilebttn;
        private System.Windows.Forms.Button Manageemp;
        private System.Windows.Forms.Button assignappointment;
        private System.Windows.Forms.Button viewpatients;
        private System.Windows.Forms.Button manageappointment;
        private System.Windows.Forms.Button viewtask;
    }
}