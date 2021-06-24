
namespace libraryms
{
    partial class Form9
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
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.smView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.ss = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.smView)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(338, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 29);
            this.button2.TabIndex = 15;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, -47);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(736, 29);
            this.textBox1.TabIndex = 13;
            // 
            // smView
            // 
            this.smView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.smView.Location = new System.Drawing.Point(12, 62);
            this.smView.Name = "smView";
            this.smView.Size = new System.Drawing.Size(776, 438);
            this.smView.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::libraryms.Properties.Resources.cancel;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(754, -49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 31);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ss
            // 
            this.ss.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss.FormattingEnabled = true;
            this.ss.Items.AddRange(new object[] {
            "ActivityLog",
            "Author",
            "Book",
            "Book_History",
            "Borrower",
            "BorrowerTelephone",
            "BranchLibrary",
            "Contain",
            "Copy",
            "Loans",
            "MainLibrary",
            "ManagesBorrower",
            "ManagesCopy",
            "ManagesOverdue",
            "Overdue",
            "Returns",
            "Staff_Active",
            "Book_and_Copy_Details",
            "Book_Details",
            "Borrower_Details",
            "Library_Details",
            "View_HeadLibrarian",
            "View_Librarian",
            "Head_Librarians",
            "Librarians",
            "Staff_History"
            });
            this.ss.Location = new System.Drawing.Point(12, 30);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(320, 28);
            this.ss.TabIndex = 16;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::libraryms.Properties.Resources.cancel;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(754, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 31);
            this.button3.TabIndex = 17;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 510);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ss);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.smView);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form9";
            this.Text = "Form9";
            ((System.ComponentModel.ISupportInitialize)(this.smView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView smView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ss;
        private System.Windows.Forms.Button button3;
    }
}