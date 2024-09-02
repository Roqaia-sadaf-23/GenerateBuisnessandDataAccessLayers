namespace GenerateBuisnessandDataAccessLayers
{
    partial class Form1
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
            this.cbDatabase = new System.Windows.Forms.ComboBox();
            this.dgvListColumns = new System.Windows.Forms.DataGridView();
            this.txtCodeScript = new System.Windows.Forms.TextBox();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.cbFindBy = new System.Windows.Forms.ComboBox();
            this.btnGenerateBuisness = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateDataAccess = new System.Windows.Forms.Button();
            this.txtTableSingularName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnListColumns = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDatabase
            // 
            this.cbDatabase.FormattingEnabled = true;
            this.cbDatabase.Location = new System.Drawing.Point(266, 109);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(188, 21);
            this.cbDatabase.TabIndex = 0;
            this.cbDatabase.SelectedIndexChanged += new System.EventHandler(this.cbDatabase_SelectedIndexChanged);
            // 
            // dgvListColumns
            // 
            this.dgvListColumns.AllowUserToAddRows = false;
            this.dgvListColumns.AllowUserToDeleteRows = false;
            this.dgvListColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListColumns.Location = new System.Drawing.Point(5, 377);
            this.dgvListColumns.Name = "dgvListColumns";
            this.dgvListColumns.ReadOnly = true;
            this.dgvListColumns.Size = new System.Drawing.Size(415, 204);
            this.dgvListColumns.TabIndex = 1;
            // 
            // txtCodeScript
            // 
            this.txtCodeScript.Location = new System.Drawing.Point(480, 106);
            this.txtCodeScript.Multiline = true;
            this.txtCodeScript.Name = "txtCodeScript";
            this.txtCodeScript.Size = new System.Drawing.Size(591, 445);
            this.txtCodeScript.TabIndex = 2;
            // 
            // cbTable
            // 
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Location = new System.Drawing.Point(266, 161);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(188, 21);
            this.cbTable.TabIndex = 3;
            this.cbTable.SelectedIndexChanged += new System.EventHandler(this.cbTable_SelectedIndexChanged);
            // 
            // cbFindBy
            // 
            this.cbFindBy.FormattingEnabled = true;
            this.cbFindBy.Location = new System.Drawing.Point(266, 259);
            this.cbFindBy.Name = "cbFindBy";
            this.cbFindBy.Size = new System.Drawing.Size(188, 21);
            this.cbFindBy.TabIndex = 4;
            // 
            // btnGenerateBuisness
            // 
            this.btnGenerateBuisness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnGenerateBuisness.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateBuisness.ForeColor = System.Drawing.Color.Black;
            this.btnGenerateBuisness.Location = new System.Drawing.Point(480, 563);
            this.btnGenerateBuisness.Name = "btnGenerateBuisness";
            this.btnGenerateBuisness.Size = new System.Drawing.Size(275, 56);
            this.btnGenerateBuisness.TabIndex = 5;
            this.btnGenerateBuisness.Text = "GenerateBuisness";
            this.btnGenerateBuisness.UseVisualStyleBackColor = false;
            this.btnGenerateBuisness.Click += new System.EventHandler(this.btnGenerateBuisness_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Snap ITC", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(370, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 48);
            this.label1.TabIndex = 6;
            this.label1.Text = "Code Generator";
            // 
            // btnGenerateDataAccess
            // 
            this.btnGenerateDataAccess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnGenerateDataAccess.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateDataAccess.Location = new System.Drawing.Point(796, 563);
            this.btnGenerateDataAccess.Name = "btnGenerateDataAccess";
            this.btnGenerateDataAccess.Size = new System.Drawing.Size(275, 56);
            this.btnGenerateDataAccess.TabIndex = 7;
            this.btnGenerateDataAccess.Text = "GenerateDataAccess";
            this.btnGenerateDataAccess.UseVisualStyleBackColor = false;
            this.btnGenerateDataAccess.Click += new System.EventHandler(this.btnGenerateDataAccess_Click);
            // 
            // txtTableSingularName
            // 
            this.txtTableSingularName.Location = new System.Drawing.Point(266, 211);
            this.txtTableSingularName.Multiline = true;
            this.txtTableSingularName.Name = "txtTableSingularName";
            this.txtTableSingularName.Size = new System.Drawing.Size(191, 20);
            this.txtTableSingularName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Snap ITC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "DATABASE :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Snap ITC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(145, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "TABLE :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Snap ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "TABLE SINGULAR NAME :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Snap ITC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(121, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "FIND BY :";
            // 
            // btnListColumns
            // 
            this.btnListColumns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnListColumns.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListColumns.Location = new System.Drawing.Point(25, 325);
            this.btnListColumns.Name = "btnListColumns";
            this.btnListColumns.Size = new System.Drawing.Size(135, 46);
            this.btnListColumns.TabIndex = 13;
            this.btnListColumns.Text = "List Columns";
            this.btnListColumns.UseVisualStyleBackColor = false;
            this.btnListColumns.Click += new System.EventHandler(this.btnListColumns_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1083, 621);
            this.Controls.Add(this.btnListColumns);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTableSingularName);
            this.Controls.Add(this.btnGenerateDataAccess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerateBuisness);
            this.Controls.Add(this.cbFindBy);
            this.Controls.Add(this.cbTable);
            this.Controls.Add(this.txtCodeScript);
            this.Controls.Add(this.dgvListColumns);
            this.Controls.Add(this.cbDatabase);
            this.Name = "Form1";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDatabase;
        private System.Windows.Forms.DataGridView dgvListColumns;
        private System.Windows.Forms.TextBox txtCodeScript;
        private System.Windows.Forms.ComboBox cbTable;
        private System.Windows.Forms.ComboBox cbFindBy;
        private System.Windows.Forms.Button btnGenerateBuisness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerateDataAccess;
        private System.Windows.Forms.TextBox txtTableSingularName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnListColumns;
    }
}

