namespace TestApp.Forms
{
    partial class BaseSalaryForm
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
            this.lblPosition = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblBaseSalary = new System.Windows.Forms.Label();
            this.txtBaseSalary = new System.Windows.Forms.TextBox();
            this.lblCoeffDate = new System.Windows.Forms.Label();
            this.txtCoeffDate = new System.Windows.Forms.TextBox();
            this.lblCoeffSub = new System.Windows.Forms.Label();
            this.txtCoeffSub = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxCoeff = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblChanged = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(19, 26);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(200, 26);
            this.lblPosition.TabIndex = 0;
            this.lblPosition.Text = "Выберите должность";
            // 
            // cmbRole
            // 
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "Employee",
            "Manager",
            "Salesman"});
            this.cmbRole.Location = new System.Drawing.Point(265, 26);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(197, 34);
            this.cmbRole.TabIndex = 1;
            // 
            // lblBaseSalary
            // 
            this.lblBaseSalary.AutoSize = true;
            this.lblBaseSalary.Location = new System.Drawing.Point(19, 103);
            this.lblBaseSalary.Name = "lblBaseSalary";
            this.lblBaseSalary.Size = new System.Drawing.Size(168, 26);
            this.lblBaseSalary.TabIndex = 2;
            this.lblBaseSalary.Text = "Базовая зарплата";
            // 
            // txtBaseSalary
            // 
            this.txtBaseSalary.Location = new System.Drawing.Point(265, 100);
            this.txtBaseSalary.Name = "txtBaseSalary";
            this.txtBaseSalary.Size = new System.Drawing.Size(197, 33);
            this.txtBaseSalary.TabIndex = 3;
            // 
            // lblCoeffDate
            // 
            this.lblCoeffDate.AutoSize = true;
            this.lblCoeffDate.Location = new System.Drawing.Point(19, 187);
            this.lblCoeffDate.Name = "lblCoeffDate";
            this.lblCoeffDate.Size = new System.Drawing.Size(167, 26);
            this.lblCoeffDate.TabIndex = 4;
            this.lblCoeffDate.Text = "Процент от стажа";
            // 
            // txtCoeffDate
            // 
            this.txtCoeffDate.Location = new System.Drawing.Point(265, 187);
            this.txtCoeffDate.Name = "txtCoeffDate";
            this.txtCoeffDate.Size = new System.Drawing.Size(197, 33);
            this.txtCoeffDate.TabIndex = 5;
            // 
            // lblCoeffSub
            // 
            this.lblCoeffSub.AutoSize = true;
            this.lblCoeffSub.Location = new System.Drawing.Point(19, 267);
            this.lblCoeffSub.Name = "lblCoeffSub";
            this.lblCoeffSub.Size = new System.Drawing.Size(226, 26);
            this.lblCoeffSub.TabIndex = 6;
            this.lblCoeffSub.Text = "Процент с подчиненных";
            // 
            // txtCoeffSub
            // 
            this.txtCoeffSub.Location = new System.Drawing.Point(265, 264);
            this.txtCoeffSub.Name = "txtCoeffSub";
            this.txtCoeffSub.Size = new System.Drawing.Size(197, 33);
            this.txtCoeffSub.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Макс. процент от стажа";
            // 
            // txtMaxCoeff
            // 
            this.txtMaxCoeff.Location = new System.Drawing.Point(265, 335);
            this.txtMaxCoeff.Name = "txtMaxCoeff";
            this.txtMaxCoeff.Size = new System.Drawing.Size(197, 33);
            this.txtMaxCoeff.TabIndex = 9;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(331, 426);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(131, 40);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblChanged
            // 
            this.lblChanged.AutoSize = true;
            this.lblChanged.Location = new System.Drawing.Point(29, 407);
            this.lblChanged.Name = "lblChanged";
            this.lblChanged.Size = new System.Drawing.Size(0, 26);
            this.lblChanged.TabIndex = 11;
            // 
            // BaseSalaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 498);
            this.Controls.Add(this.lblChanged);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtMaxCoeff);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCoeffSub);
            this.Controls.Add(this.lblCoeffSub);
            this.Controls.Add(this.txtCoeffDate);
            this.Controls.Add(this.lblCoeffDate);
            this.Controls.Add(this.txtBaseSalary);
            this.Controls.Add(this.lblBaseSalary);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.lblPosition);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "BaseSalaryForm";
            this.Text = "BaseSalaryForm";
            this.Load += new System.EventHandler(this.BaseSalaryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblBaseSalary;
        private System.Windows.Forms.TextBox txtBaseSalary;
        private System.Windows.Forms.Label lblCoeffDate;
        private System.Windows.Forms.TextBox txtCoeffDate;
        private System.Windows.Forms.Label lblCoeffSub;
        private System.Windows.Forms.TextBox txtCoeffSub;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxCoeff;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblChanged;
    }
}