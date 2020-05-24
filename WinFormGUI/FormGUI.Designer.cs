namespace WinFormGUI
{
    partial class FormGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGUI));
            this.myDataGridView = new System.Windows.Forms.DataGridView();
            this.textFilePath = new System.Windows.Forms.TextBox();
            this.Load_CSV = new System.Windows.Forms.Button();
            this.Delete_Books = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Exit_GUI = new System.Windows.Forms.Button();
            this.File_Loaded_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // myDataGridView
            // 
            this.myDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridView.Location = new System.Drawing.Point(0, 0);
            this.myDataGridView.Name = "myDataGridView";
            this.myDataGridView.RowHeadersVisible = false;
            this.myDataGridView.Size = new System.Drawing.Size(802, 412);
            this.myDataGridView.TabIndex = 0;
            this.myDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyGridCell_Clicked);
            // 
            // textFilePath
            // 
            this.textFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textFilePath.Location = new System.Drawing.Point(82, 422);
            this.textFilePath.Name = "textFilePath";
            this.textFilePath.ReadOnly = true;
            this.textFilePath.Size = new System.Drawing.Size(330, 20);
            this.textFilePath.TabIndex = 1;
            // 
            // Load_CSV
            // 
            this.Load_CSV.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Load_CSV.Location = new System.Drawing.Point(455, 420);
            this.Load_CSV.Name = "Load_CSV";
            this.Load_CSV.Size = new System.Drawing.Size(110, 23);
            this.Load_CSV.TabIndex = 2;
            this.Load_CSV.Text = "Load CSV";
            this.Load_CSV.UseVisualStyleBackColor = true;
            this.Load_CSV.Click += new System.EventHandler(this.Load_CSV_Click);
            // 
            // Delete_Books
            // 
            this.Delete_Books.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Delete_Books.Location = new System.Drawing.Point(571, 420);
            this.Delete_Books.Name = "Delete_Books";
            this.Delete_Books.Size = new System.Drawing.Size(110, 23);
            this.Delete_Books.TabIndex = 3;
            this.Delete_Books.Text = "Delete Books";
            this.Delete_Books.UseVisualStyleBackColor = true;
            this.Delete_Books.Click += new System.EventHandler(this.Delete_Books_Click);
            // 
            // Exit_GUI
            // 
            this.Exit_GUI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit_GUI.Location = new System.Drawing.Point(687, 420);
            this.Exit_GUI.Name = "Exit_GUI";
            this.Exit_GUI.Size = new System.Drawing.Size(110, 23);
            this.Exit_GUI.TabIndex = 4;
            this.Exit_GUI.Text = "Exit GUI";
            this.Exit_GUI.UseVisualStyleBackColor = true;
            this.Exit_GUI.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // File_Loaded_Label
            // 
            this.File_Loaded_Label.AutoSize = true;
            this.File_Loaded_Label.Location = new System.Drawing.Point(12, 425);
            this.File_Loaded_Label.Name = "File_Loaded_Label";
            this.File_Loaded_Label.Size = new System.Drawing.Size(64, 13);
            this.File_Loaded_Label.TabIndex = 5;
            this.File_Loaded_Label.Text = "File loaded :";
            // 
            // FormGUI
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.File_Loaded_Label);
            this.Controls.Add(this.Exit_GUI);
            this.Controls.Add(this.Delete_Books);
            this.Controls.Add(this.Load_CSV);
            this.Controls.Add(this.textFilePath);
            this.Controls.Add(this.myDataGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGUI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FormGUI";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView myDataGridView;
        private System.Windows.Forms.TextBox textFilePath;
        private System.Windows.Forms.Button Load_CSV;
        private System.Windows.Forms.Button Delete_Books;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button Exit_GUI;
        private System.Windows.Forms.Label File_Loaded_Label;

    }
}

