namespace TestApp.Forms
{
    partial class AdminProfileForm
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
            this.listWorkers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblDeleteUser = new System.Windows.Forms.Label();
            this.lblShowList = new System.Windows.Forms.Label();
            this.btnShowList = new System.Windows.Forms.Button();
            this.groupBoxTop = new System.Windows.Forms.GroupBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.lblCalc = new System.Windows.Forms.Label();
            this.btnChangeSalary = new System.Windows.Forms.Button();
            this.lblBaseSalary = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.listSub = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxMid = new System.Windows.Forms.GroupBox();
            this.groupBoxTop.SuspendLayout();
            this.groupBoxMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // listWorkers
            // 
            this.listWorkers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listWorkers.FullRowSelect = true;
            this.listWorkers.Location = new System.Drawing.Point(6, 10);
            this.listWorkers.Name = "listWorkers";
            this.listWorkers.Size = new System.Drawing.Size(1095, 354);
            this.listWorkers.TabIndex = 0;
            this.listWorkers.UseCompatibleStateImageBehavior = false;
            this.listWorkers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 55;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Логин";
            this.columnHeader2.Width = 93;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Пароль";
            this.columnHeader3.Width = 82;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Имя";
            this.columnHeader4.Width = 84;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Фамилия";
            this.columnHeader5.Width = 104;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Дата";
            this.columnHeader6.Width = 104;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Должность";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Зарплата за стаж";
            this.columnHeader8.Width = 201;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Зарплата за подчиненных";
            this.columnHeader9.Width = 250;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(571, 376);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(137, 33);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblDeleteUser
            // 
            this.lblDeleteUser.AutoSize = true;
            this.lblDeleteUser.Location = new System.Drawing.Point(355, 379);
            this.lblDeleteUser.Name = "lblDeleteUser";
            this.lblDeleteUser.Size = new System.Drawing.Size(210, 26);
            this.lblDeleteUser.TabIndex = 2;
            this.lblDeleteUser.Text = "Удалить пользователя";
            // 
            // lblShowList
            // 
            this.lblShowList.AutoSize = true;
            this.lblShowList.Location = new System.Drawing.Point(6, 379);
            this.lblShowList.Name = "lblShowList";
            this.lblShowList.Size = new System.Drawing.Size(200, 26);
            this.lblShowList.TabIndex = 4;
            this.lblShowList.Text = "Список подчиненных";
            // 
            // btnShowList
            // 
            this.btnShowList.Location = new System.Drawing.Point(212, 376);
            this.btnShowList.Name = "btnShowList";
            this.btnShowList.Size = new System.Drawing.Size(137, 33);
            this.btnShowList.TabIndex = 5;
            this.btnShowList.Text = "Показать";
            this.btnShowList.UseVisualStyleBackColor = true;
            this.btnShowList.Click += new System.EventHandler(this.btnShowList_Click);
            // 
            // groupBoxTop
            // 
            this.groupBoxTop.Controls.Add(this.btnCalc);
            this.groupBoxTop.Controls.Add(this.lblCalc);
            this.groupBoxTop.Controls.Add(this.btnChangeSalary);
            this.groupBoxTop.Controls.Add(this.lblBaseSalary);
            this.groupBoxTop.Controls.Add(this.lblError);
            this.groupBoxTop.Controls.Add(this.listWorkers);
            this.groupBoxTop.Controls.Add(this.btnDelete);
            this.groupBoxTop.Controls.Add(this.lblDeleteUser);
            this.groupBoxTop.Controls.Add(this.lblShowList);
            this.groupBoxTop.Controls.Add(this.btnShowList);
            this.groupBoxTop.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTop.Name = "groupBoxTop";
            this.groupBoxTop.Size = new System.Drawing.Size(1122, 467);
            this.groupBoxTop.TabIndex = 6;
            this.groupBoxTop.TabStop = false;
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(955, 420);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(140, 33);
            this.btnCalc.TabIndex = 11;
            this.btnCalc.Text = "Пересчитать";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // lblCalc
            // 
            this.lblCalc.AutoSize = true;
            this.lblCalc.Location = new System.Drawing.Point(432, 427);
            this.lblCalc.Name = "lblCalc";
            this.lblCalc.Size = new System.Drawing.Size(497, 26);
            this.lblCalc.TabIndex = 10;
            this.lblCalc.Text = "Пересчитать зарплаты после удаления или изменения";
            // 
            // btnChangeSalary
            // 
            this.btnChangeSalary.Location = new System.Drawing.Point(955, 376);
            this.btnChangeSalary.Name = "btnChangeSalary";
            this.btnChangeSalary.Size = new System.Drawing.Size(140, 33);
            this.btnChangeSalary.TabIndex = 9;
            this.btnChangeSalary.Text = "Изменить";
            this.btnChangeSalary.UseVisualStyleBackColor = true;
            this.btnChangeSalary.Click += new System.EventHandler(this.btnChangeSalary_Click);
            // 
            // lblBaseSalary
            // 
            this.lblBaseSalary.AutoSize = true;
            this.lblBaseSalary.Location = new System.Drawing.Point(714, 379);
            this.lblBaseSalary.Name = "lblBaseSalary";
            this.lblBaseSalary.Size = new System.Drawing.Size(246, 26);
            this.lblBaseSalary.TabIndex = 8;
            this.lblBaseSalary.Text = "Изменить базовую ставку ";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(11, 414);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 26);
            this.lblError.TabIndex = 6;
            // 
            // listSub
            // 
            this.listSub.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18});
            this.listSub.FullRowSelect = true;
            this.listSub.Location = new System.Drawing.Point(11, 32);
            this.listSub.Name = "listSub";
            this.listSub.Size = new System.Drawing.Size(1084, 191);
            this.listSub.TabIndex = 6;
            this.listSub.UseCompatibleStateImageBehavior = false;
            this.listSub.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "ID";
            this.columnHeader10.Width = 55;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Логин";
            this.columnHeader11.Width = 93;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Пароль";
            this.columnHeader12.Width = 82;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Имя";
            this.columnHeader13.Width = 84;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Фамилия";
            this.columnHeader14.Width = 104;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Дата";
            this.columnHeader15.Width = 104;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Должность";
            this.columnHeader16.Width = 120;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Зарплата за стаж";
            this.columnHeader17.Width = 195;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Зарплата за подчиненных";
            this.columnHeader18.Width = 250;
            // 
            // groupBoxMid
            // 
            this.groupBoxMid.Controls.Add(this.listSub);
            this.groupBoxMid.Location = new System.Drawing.Point(12, 468);
            this.groupBoxMid.Name = "groupBoxMid";
            this.groupBoxMid.Size = new System.Drawing.Size(1116, 244);
            this.groupBoxMid.TabIndex = 7;
            this.groupBoxMid.TabStop = false;
            // 
            // AdminProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1161, 826);
            this.Controls.Add(this.groupBoxMid);
            this.Controls.Add(this.groupBoxTop);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "AdminProfileForm";
            this.Text = "AdminProfileForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminProfileForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminProfileForm_Load);
            this.groupBoxTop.ResumeLayout(false);
            this.groupBoxTop.PerformLayout();
            this.groupBoxMid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listWorkers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblDeleteUser;
        private System.Windows.Forms.Label lblShowList;
        private System.Windows.Forms.Button btnShowList;
        private System.Windows.Forms.GroupBox groupBoxTop;
        private System.Windows.Forms.ListView listSub;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.GroupBox groupBoxMid;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblBaseSalary;
        private System.Windows.Forms.Button btnChangeSalary;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Label lblCalc;
    }
}