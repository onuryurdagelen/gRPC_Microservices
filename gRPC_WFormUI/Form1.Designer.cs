namespace gRPC_WFormUI
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
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.cmbxDbTable = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dbTableGridView = new System.Windows.Forms.DataGridView();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbTableGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.Location = new System.Drawing.Point(20, 20);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(116, 39);
            this.btnAyarlar.TabIndex = 0;
            this.btnAyarlar.Text = "Ayarlar";
            this.btnAyarlar.UseVisualStyleBackColor = true;
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // cmbxDbTable
            // 
            this.cmbxDbTable.FormattingEnabled = true;
            this.cmbxDbTable.Location = new System.Drawing.Point(139, 94);
            this.cmbxDbTable.Name = "cmbxDbTable";
            this.cmbxDbTable.Size = new System.Drawing.Size(121, 23);
            this.cmbxDbTable.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Veritabanı Tabloları";
            // 
            // dbTableGridView
            // 
            this.dbTableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbTableGridView.Location = new System.Drawing.Point(20, 150);
            this.dbTableGridView.Name = "dbTableGridView";
            this.dbTableGridView.RowTemplate.Height = 25;
            this.dbTableGridView.Size = new System.Drawing.Size(752, 338);
            this.dbTableGridView.TabIndex = 3;
            this.dbTableGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbTableGridView_CellContentClick);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(164, 20);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(121, 39);
            this.btnAddProduct.TabIndex = 4;
            this.btnAddProduct.Text = "Ürün Ekle";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Location = new System.Drawing.Point(319, 20);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(121, 39);
            this.btnUpdateProduct.TabIndex = 5;
            this.btnUpdateProduct.Text = "Ürün Güncelle";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(471, 20);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(121, 39);
            this.btnDeleteProduct.TabIndex = 6;
            this.btnDeleteProduct.Text = "Ürün Sil";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnUpdateProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.dbTableGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbxDbTable);
            this.Controls.Add(this.btnAyarlar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbTableGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnAyarlar;
        private ComboBox cmbxDbTable;
        private Label label1;
        private DataGridView dbTableGridView;
        private Button btnAddProduct;
        private Button btnUpdateProduct;
        private Button btnDeleteProduct;
    }
}