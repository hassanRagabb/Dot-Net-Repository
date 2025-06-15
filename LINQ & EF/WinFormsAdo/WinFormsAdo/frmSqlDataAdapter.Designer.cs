
namespace WinFormsAdo
{
    partial class frmSqlDataAdapter
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
            this.lstProducts = new System.Windows.Forms.ListBox();
            this.btnExcute = new System.Windows.Forms.Button();
            this.grdViewProducts = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // lstProducts
            // 
            this.lstProducts.FormattingEnabled = true;
            this.lstProducts.ItemHeight = 15;
            this.lstProducts.Location = new System.Drawing.Point(699, 18);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(75, 364);
            this.lstProducts.TabIndex = 0;
            this.lstProducts.SelectedIndexChanged += new System.EventHandler(this.lstProducts_SelectedIndexChanged);
            // 
            // btnExcute
            // 
            this.btnExcute.Location = new System.Drawing.Point(699, 403);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(75, 23);
            this.btnExcute.TabIndex = 1;
            this.btnExcute.Text = "Excute";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // grdViewProducts
            // 
            this.grdViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdViewProducts.Location = new System.Drawing.Point(12, 32);
            this.grdViewProducts.Name = "grdViewProducts";
            this.grdViewProducts.RowTemplate.Height = 25;
            this.grdViewProducts.Size = new System.Drawing.Size(591, 333);
            this.grdViewProducts.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(86, 407);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSqlDataAdapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdViewProducts);
            this.Controls.Add(this.btnExcute);
            this.Controls.Add(this.lstProducts);
            this.Name = "frmSqlDataAdapter";
            this.Text = "frmSqlDataAdapter";
            this.Load += new System.EventHandler(this.frmSqlDataAdapter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdViewProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstProducts;
        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.DataGridView grdViewProducts;
        private System.Windows.Forms.Button btnSave;
    }
}