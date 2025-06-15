namespace ui
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuIManage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuILoad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuISave = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2Prev = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuINext = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(803, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuIManage,
            this.toolStripMenuItem2Prev,
            this.toolStripMenuINext});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(803, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuIManage
            // 
            this.toolStripMenuIManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuILoad,
            this.toolStripMenuISave,
            this.manageToolStripMenuItem});
            this.toolStripMenuIManage.Name = "toolStripMenuIManage";
            this.toolStripMenuIManage.Size = new System.Drawing.Size(62, 20);
            this.toolStripMenuIManage.Text = "Manage";
            this.toolStripMenuIManage.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // toolStripMenuILoad
            // 
            this.toolStripMenuILoad.Name = "toolStripMenuILoad";
            this.toolStripMenuILoad.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuILoad.Text = "Load";
            this.toolStripMenuILoad.Click += new System.EventHandler(this.toolStripMenuILoad_Click);
            // 
            // toolStripMenuISave
            // 
            this.toolStripMenuISave.Name = "toolStripMenuISave";
            this.toolStripMenuISave.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuISave.Text = "Save";
            this.toolStripMenuISave.Click += new System.EventHandler(this.toolStripMenuISave_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.manageToolStripMenuItem.Text = "Manage";
            // 
            // toolStripMenuItem2Prev
            // 
            this.toolStripMenuItem2Prev.Name = "toolStripMenuItem2Prev";
            this.toolStripMenuItem2Prev.Size = new System.Drawing.Size(27, 20);
            this.toolStripMenuItem2Prev.Text = "<";
            // 
            // toolStripMenuINext
            // 
            this.toolStripMenuINext.Name = "toolStripMenuINext";
            this.toolStripMenuINext.Size = new System.Drawing.Size(27, 20);
            this.toolStripMenuINext.Text = ">";
            this.toolStripMenuINext.Click += new System.EventHandler(this.toolStripMenuINext_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuILoad;
        private ToolStripMenuItem toolStripMenuISave;
        private ToolStripMenuItem toolStripMenuIManage;
        private ToolStripMenuItem manageToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2Prev;
        private ToolStripMenuItem toolStripMenuINext;
    }
}