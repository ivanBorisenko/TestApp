namespace TestApp.Forms
{
    partial class UserProfileForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.boxUp = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnLook = new System.Windows.Forms.Button();
            this.lblLook = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.boxBot = new System.Windows.Forms.GroupBox();
            this.listWorkers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblConfirm = new System.Windows.Forms.Label();
            this.btnRemoveConfirm = new System.Windows.Forms.Button();
            this.btnAddConfirm = new System.Windows.Forms.Button();
            this.boxMid = new System.Windows.Forms.GroupBox();
            this.boxUp.SuspendLayout();
            this.boxBot.SuspendLayout();
            this.boxMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(35, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 26);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Имя: ";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(35, 93);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(105, 26);
            this.lblSurname.TabIndex = 1;
            this.lblSurname.Text = "Фамилия: ";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(267, 29);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(70, 26);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Дата:  ";
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(267, 93);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(104, 26);
            this.lblSalary.TabIndex = 3;
            this.lblSalary.Text = "Зарплата: ";
            // 
            // boxUp
            // 
            this.boxUp.Controls.Add(this.lblName);
            this.boxUp.Controls.Add(this.lblSurname);
            this.boxUp.Controls.Add(this.lblDate);
            this.boxUp.Controls.Add(this.lblSalary);
            this.boxUp.Location = new System.Drawing.Point(17, 12);
            this.boxUp.Name = "boxUp";
            this.boxUp.Size = new System.Drawing.Size(579, 143);
            this.boxUp.TabIndex = 5;
            this.boxUp.TabStop = false;
            this.boxUp.Enter += new System.EventHandler(this.boxUp_Enter);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(17, 91);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(240, 37);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Добавить подчиненного";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnLook
            // 
            this.btnLook.Location = new System.Drawing.Point(288, 32);
            this.btnLook.Name = "btnLook";
            this.btnLook.Size = new System.Drawing.Size(145, 35);
            this.btnLook.TabIndex = 4;
            this.btnLook.Text = "Просмотр";
            this.btnLook.UseVisualStyleBackColor = true;
            this.btnLook.Click += new System.EventHandler(this.btnLook_Click);
            // 
            // lblLook
            // 
            this.lblLook.AutoSize = true;
            this.lblLook.Location = new System.Drawing.Point(15, 36);
            this.lblLook.Name = "lblLook";
            this.lblLook.Size = new System.Drawing.Size(253, 26);
            this.lblLook.TabIndex = 6;
            this.lblLook.Text = "Просмотреть подчиненных";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(288, 91);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(257, 37);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Удалить подчиненного";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // boxBot
            // 
            this.boxBot.Controls.Add(this.listWorkers);
            this.boxBot.Controls.Add(this.lblConfirm);
            this.boxBot.Controls.Add(this.btnRemoveConfirm);
            this.boxBot.Controls.Add(this.btnAddConfirm);
            this.boxBot.Location = new System.Drawing.Point(17, 313);
            this.boxBot.Name = "boxBot";
            this.boxBot.Size = new System.Drawing.Size(579, 316);
            this.boxBot.TabIndex = 6;
            this.boxBot.TabStop = false;
            // 
            // listWorkers
            // 
            this.listWorkers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listWorkers.FullRowSelect = true;
            this.listWorkers.Location = new System.Drawing.Point(7, 21);
            this.listWorkers.Name = "listWorkers";
            this.listWorkers.Size = new System.Drawing.Size(566, 239);
            this.listWorkers.TabIndex = 9;
            this.listWorkers.UseCompatibleStateImageBehavior = false;
            this.listWorkers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "hidden";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Имя";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Фамилия";
            this.columnHeader3.Width = 112;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Дата";
            this.columnHeader4.Width = 109;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Должность";
            this.columnHeader5.Width = 122;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Зарплата";
            this.columnHeader6.Width = 116;
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(17, 275);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(0, 26);
            this.lblConfirm.TabIndex = 8;
            // 
            // btnRemoveConfirm
            // 
            this.btnRemoveConfirm.Location = new System.Drawing.Point(315, 275);
            this.btnRemoveConfirm.Name = "btnRemoveConfirm";
            this.btnRemoveConfirm.Size = new System.Drawing.Size(158, 35);
            this.btnRemoveConfirm.TabIndex = 7;
            this.btnRemoveConfirm.Text = "Подтвердить";
            this.btnRemoveConfirm.UseVisualStyleBackColor = true;
            this.btnRemoveConfirm.Click += new System.EventHandler(this.btnRemoveConfirm_Click);
            // 
            // btnAddConfirm
            // 
            this.btnAddConfirm.Location = new System.Drawing.Point(315, 275);
            this.btnAddConfirm.Name = "btnAddConfirm";
            this.btnAddConfirm.Size = new System.Drawing.Size(158, 35);
            this.btnAddConfirm.TabIndex = 6;
            this.btnAddConfirm.Text = "Подтвердить";
            this.btnAddConfirm.UseVisualStyleBackColor = true;
            this.btnAddConfirm.Click += new System.EventHandler(this.btnAddConfirm_Click);
            // 
            // boxMid
            // 
            this.boxMid.Controls.Add(this.lblLook);
            this.boxMid.Controls.Add(this.btnRemove);
            this.boxMid.Controls.Add(this.btnLook);
            this.boxMid.Controls.Add(this.btnAdd);
            this.boxMid.Location = new System.Drawing.Point(17, 161);
            this.boxMid.Name = "boxMid";
            this.boxMid.Size = new System.Drawing.Size(579, 146);
            this.boxMid.TabIndex = 10;
            this.boxMid.TabStop = false;
            // 
            // UserProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(625, 697);
            this.Controls.Add(this.boxMid);
            this.Controls.Add(this.boxBot);
            this.Controls.Add(this.boxUp);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UserProfileForm";
            this.Text = "Профиль пользователя";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserProfileForm_FormClosing);
            this.Load += new System.EventHandler(this.UserProfileForm_Load);
            this.boxUp.ResumeLayout(false);
            this.boxUp.PerformLayout();
            this.boxBot.ResumeLayout(false);
            this.boxBot.PerformLayout();
            this.boxMid.ResumeLayout(false);
            this.boxMid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.GroupBox boxUp;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblLook;
        private System.Windows.Forms.Button btnLook;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox boxBot;
        private System.Windows.Forms.GroupBox boxMid;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.Button btnRemoveConfirm;
        private System.Windows.Forms.Button btnAddConfirm;
        private System.Windows.Forms.ListView listWorkers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}