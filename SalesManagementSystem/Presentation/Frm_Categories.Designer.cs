namespace SalesManagementSystem.Presentation
{
    partial class Frm_Categories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Categories));
            this.grpboxCategories = new System.Windows.Forms.GroupBox();
            this.dgvCategoryList = new System.Windows.Forms.DataGridView();
            this.lblPosition = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtCategoryID = new System.Windows.Forms.TextBox();
            this.lblDesceiption = new System.Windows.Forms.Label();
            this.lblCategoryID = new System.Windows.Forms.Label();
            this.grpboxTransactions = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveProductstoPDF = new System.Windows.Forms.Button();
            this.btnSavePDF = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.grpboxCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryList)).BeginInit();
            this.grpboxTransactions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpboxCategories
            // 
            this.grpboxCategories.Controls.Add(this.dgvCategoryList);
            this.grpboxCategories.Controls.Add(this.lblPosition);
            this.grpboxCategories.Controls.Add(this.btnLast);
            this.grpboxCategories.Controls.Add(this.btnNext);
            this.grpboxCategories.Controls.Add(this.btnPrevious);
            this.grpboxCategories.Controls.Add(this.btnFirst);
            this.grpboxCategories.Controls.Add(this.txtDescription);
            this.grpboxCategories.Controls.Add(this.txtCategoryID);
            this.grpboxCategories.Controls.Add(this.lblDesceiption);
            this.grpboxCategories.Controls.Add(this.lblCategoryID);
            this.grpboxCategories.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpboxCategories.Location = new System.Drawing.Point(22, 12);
            this.grpboxCategories.Name = "grpboxCategories";
            this.grpboxCategories.Size = new System.Drawing.Size(858, 222);
            this.grpboxCategories.TabIndex = 0;
            this.grpboxCategories.TabStop = false;
            this.grpboxCategories.Text = "Category Details";
            // 
            // dgvCategoryList
            // 
            this.dgvCategoryList.AllowUserToAddRows = false;
            this.dgvCategoryList.AllowUserToDeleteRows = false;
            this.dgvCategoryList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategoryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoryList.Location = new System.Drawing.Point(438, 18);
            this.dgvCategoryList.Name = "dgvCategoryList";
            this.dgvCategoryList.Size = new System.Drawing.Size(414, 198);
            this.dgvCategoryList.TabIndex = 9;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(196, 179);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(47, 12);
            this.lblPosition.TabIndex = 8;
            this.lblPosition.Text = "label1";
            // 
            // btnLast
            // 
            this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
            this.btnLast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLast.Location = new System.Drawing.Point(34, 174);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 23);
            this.btnLast.TabIndex = 7;
            this.btnLast.Text = "Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(115, 174);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevious.Location = new System.Drawing.Point(249, 174);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(87, 23);
            this.btnPrevious.TabIndex = 5;
            this.btnPrevious.Text = "      Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFirst.Location = new System.Drawing.Point(342, 174);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 23);
            this.btnFirst.TabIndex = 4;
            this.btnFirst.Text = "First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(158, 102);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(188, 52);
            this.txtDescription.TabIndex = 3;
            // 
            // txtCategoryID
            // 
            this.txtCategoryID.Location = new System.Drawing.Point(158, 46);
            this.txtCategoryID.Name = "txtCategoryID";
            this.txtCategoryID.ReadOnly = true;
            this.txtCategoryID.Size = new System.Drawing.Size(188, 19);
            this.txtCategoryID.TabIndex = 2;
            // 
            // lblDesceiption
            // 
            this.lblDesceiption.AutoSize = true;
            this.lblDesceiption.Location = new System.Drawing.Point(9, 105);
            this.lblDesceiption.Name = "lblDesceiption";
            this.lblDesceiption.Size = new System.Drawing.Size(152, 12);
            this.lblDesceiption.TabIndex = 1;
            this.lblDesceiption.Text = "Category-Description:";
            // 
            // lblCategoryID
            // 
            this.lblCategoryID.AutoSize = true;
            this.lblCategoryID.Location = new System.Drawing.Point(72, 49);
            this.lblCategoryID.Name = "lblCategoryID";
            this.lblCategoryID.Size = new System.Drawing.Size(89, 12);
            this.lblCategoryID.TabIndex = 0;
            this.lblCategoryID.Text = "Category-ID:";
            // 
            // grpboxTransactions
            // 
            this.grpboxTransactions.Controls.Add(this.btnExit);
            this.grpboxTransactions.Controls.Add(this.btnSaveProductstoPDF);
            this.grpboxTransactions.Controls.Add(this.btnSavePDF);
            this.grpboxTransactions.Controls.Add(this.btnPrint);
            this.grpboxTransactions.Controls.Add(this.btnPrintAll);
            this.grpboxTransactions.Controls.Add(this.btnUpdate);
            this.grpboxTransactions.Controls.Add(this.btnDelete);
            this.grpboxTransactions.Controls.Add(this.btnAdd);
            this.grpboxTransactions.Controls.Add(this.btnNew);
            this.grpboxTransactions.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpboxTransactions.Location = new System.Drawing.Point(22, 250);
            this.grpboxTransactions.Name = "grpboxTransactions";
            this.grpboxTransactions.Size = new System.Drawing.Size(858, 96);
            this.grpboxTransactions.TabIndex = 1;
            this.grpboxTransactions.TabStop = false;
            this.grpboxTransactions.Text = "Available Transactions";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(614, 67);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveProductstoPDF
            // 
            this.btnSaveProductstoPDF.Location = new System.Drawing.Point(241, 67);
            this.btnSaveProductstoPDF.Name = "btnSaveProductstoPDF";
            this.btnSaveProductstoPDF.Size = new System.Drawing.Size(352, 23);
            this.btnSaveProductstoPDF.TabIndex = 7;
            this.btnSaveProductstoPDF.Text = "Save selected Category with its products to PDF file";
            this.btnSaveProductstoPDF.UseVisualStyleBackColor = true;
            // 
            // btnSavePDF
            // 
            this.btnSavePDF.Location = new System.Drawing.Point(24, 67);
            this.btnSavePDF.Name = "btnSavePDF";
            this.btnSavePDF.Size = new System.Drawing.Size(195, 23);
            this.btnSavePDF.TabIndex = 6;
            this.btnSavePDF.Text = "Save Category List to PDF file";
            this.btnSavePDF.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(448, 18);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 37);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "     Print ";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.Location = new System.Drawing.Point(554, 18);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(97, 37);
            this.btnPrintAll.TabIndex = 4;
            this.btnPrintAll.Text = "Print All";
            this.btnPrintAll.UseVisualStyleBackColor = true;
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(342, 18);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 37);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "  Edit";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(236, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 37);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "  Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(130, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 37);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "  Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(24, 18);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 37);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // Frm_Categories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 521);
            this.Controls.Add(this.grpboxTransactions);
            this.Controls.Add(this.grpboxCategories);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Categories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Category Management";
            this.grpboxCategories.ResumeLayout(false);
            this.grpboxCategories.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryList)).EndInit();
            this.grpboxTransactions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpboxCategories;
        private System.Windows.Forms.TextBox txtCategoryID;
        private System.Windows.Forms.Label lblDesceiption;
        private System.Windows.Forms.Label lblCategoryID;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.GroupBox grpboxTransactions;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveProductstoPDF;
        private System.Windows.Forms.Button btnSavePDF;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPrintAll;
        private System.Windows.Forms.DataGridView dgvCategoryList;
    }
}