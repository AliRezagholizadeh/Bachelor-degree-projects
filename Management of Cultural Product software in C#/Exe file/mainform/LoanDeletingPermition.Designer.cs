namespace mainform
{
    partial class LoanDeletingPermition
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
            this.LoanDeleteDataGrid = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.Ok = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.DeletionStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LoanDeleteDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // LoanDeleteDataGrid
            // 
            this.LoanDeleteDataGrid.DataMember = "";
            this.LoanDeleteDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.LoanDeleteDataGrid.Location = new System.Drawing.Point(57, 204);
            this.LoanDeleteDataGrid.Name = "LoanDeleteDataGrid";
            this.LoanDeleteDataGrid.Size = new System.Drawing.Size(682, 145);
            this.LoanDeleteDataGrid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(477, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "محصولات زیر  لازم است در ابتدا از جدول امانات حذف شود";
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(486, 107);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 3;
            this.Ok.Text = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(384, 107);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(549, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "آیا مایل هستید مراحل  حذف انجام شود ؟";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(602, 107);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // DeletionStatus
            // 
            this.DeletionStatus.AutoSize = true;
            this.DeletionStatus.Location = new System.Drawing.Point(54, 147);
            this.DeletionStatus.Name = "DeletionStatus";
            this.DeletionStatus.Size = new System.Drawing.Size(16, 13);
            this.DeletionStatus.TabIndex = 7;
            this.DeletionStatus.Text = "---";
            // 
            // LoanDeletingPermition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 396);
            this.Controls.Add(this.DeletionStatus);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoanDeleteDataGrid);
            this.Name = "LoanDeletingPermition";
            this.Text = "LoanDeletingPermition";
            this.Load += new System.EventHandler(this.LoanDeletingPermition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LoanDeleteDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGrid LoanDeleteDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label DeletionStatus;
    }
}