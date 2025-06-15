
namespace WinFormsAdo
{
    partial class frmCommand
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
            this.btnExcute = new System.Windows.Forms.Button();
            this.cmbProductIDs = new System.Windows.Forms.ComboBox();
            this.grdViewProducts = new System.Windows.Forms.DataGridView();
            this.btnLoadGrid = new System.Windows.Forms.Button();
            this.btnSaveGrid = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcute
            // 
            this.btnExcute.Location = new System.Drawing.Point(678, 403);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(75, 23);
            this.btnExcute.TabIndex = 0;
            this.btnExcute.Text = "Excute";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // cmbProductIDs
            // 
            this.cmbProductIDs.Location = new System.Drawing.Point(88, 12);
            this.cmbProductIDs.Name = "cmbProductIDs";
            this.cmbProductIDs.Size = new System.Drawing.Size(606, 23);
            this.cmbProductIDs.TabIndex = 0;
            this.cmbProductIDs.SelectedIndexChanged += new System.EventHandler(this.cmbProductIDs_SelectedIndexChanged);
            // 
            // grdViewProducts
            // 
            this.grdViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdViewProducts.Location = new System.Drawing.Point(22, 54);
            this.grdViewProducts.Name = "grdViewProducts";
            this.grdViewProducts.RowTemplate.Height = 25;
            this.grdViewProducts.Size = new System.Drawing.Size(742, 299);
            this.grdViewProducts.TabIndex = 1;
            // 
            // btnLoadGrid
            // 
            this.btnLoadGrid.Location = new System.Drawing.Point(45, 396);
            this.btnLoadGrid.Name = "btnLoadGrid";
            this.btnLoadGrid.Size = new System.Drawing.Size(75, 23);
            this.btnLoadGrid.TabIndex = 2;
            this.btnLoadGrid.Text = "Load Grid";
            this.btnLoadGrid.UseVisualStyleBackColor = true;
            this.btnLoadGrid.Click += new System.EventHandler(this.btnLoadGrid_Click);
            // 
            // btnSaveGrid
            // 
            this.btnSaveGrid.Location = new System.Drawing.Point(300, 402);
            this.btnSaveGrid.Name = "btnSaveGrid";
            this.btnSaveGrid.Size = new System.Drawing.Size(75, 23);
            this.btnSaveGrid.TabIndex = 3;
            this.btnSaveGrid.Text = "SaveGrid";
            this.btnSaveGrid.UseVisualStyleBackColor = true;
            this.btnSaveGrid.Click += new System.EventHandler(this.btnSaveGrid_Click);
            // 
            // frmCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSaveGrid);
            this.Controls.Add(this.btnLoadGrid);
            this.Controls.Add(this.grdViewProducts);
            this.Controls.Add(this.cmbProductIDs);
            this.Controls.Add(this.btnExcute);
            this.Name = "frmCommand";
            this.Text = "frmCommand";
            this.Load += new System.EventHandler(this.frmCommand_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdViewProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.ComboBox cmbProductIDs;
        private System.Windows.Forms.DataGridView grdViewProducts;
        private System.Windows.Forms.Button btnLoadGrid;
        private System.Windows.Forms.Button btnSaveGrid;
    }
}