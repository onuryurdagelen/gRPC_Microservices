namespace gRPC_WFormUI.Module.Products
{
    partial class ProductUpdateWForm
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
            this.txtUpdatedUnitPrice = new System.Windows.Forms.TextBox();
            this.txtUpdatedQuantityPerUnit = new System.Windows.Forms.TextBox();
            this.txtUpdatedProductName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtUpdatedUnitPrice
            // 
            this.txtUpdatedUnitPrice.Location = new System.Drawing.Point(129, 141);
            this.txtUpdatedUnitPrice.Name = "txtUpdatedUnitPrice";
            this.txtUpdatedUnitPrice.Size = new System.Drawing.Size(217, 23);
            this.txtUpdatedUnitPrice.TabIndex = 14;
            // 
            // txtUpdatedQuantityPerUnit
            // 
            this.txtUpdatedQuantityPerUnit.Location = new System.Drawing.Point(129, 93);
            this.txtUpdatedQuantityPerUnit.Name = "txtUpdatedQuantityPerUnit";
            this.txtUpdatedQuantityPerUnit.Size = new System.Drawing.Size(217, 23);
            this.txtUpdatedQuantityPerUnit.TabIndex = 13;
            // 
            // txtUpdatedProductName
            // 
            this.txtUpdatedProductName.Location = new System.Drawing.Point(129, 47);
            this.txtUpdatedProductName.Name = "txtUpdatedProductName";
            this.txtUpdatedProductName.Size = new System.Drawing.Size(217, 23);
            this.txtUpdatedProductName.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "UnitPrice";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "QuantityPerUnit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "ProductName";
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Location = new System.Drawing.Point(113, 200);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(142, 40);
            this.btnUpdateProduct.TabIndex = 8;
            this.btnUpdateProduct.Text = "Güncelle";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(139, 8);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(207, 23);
            this.txtProductId.TabIndex = 15;
            this.txtProductId.Visible = false;
            // 
            // ProductUpdateWForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 335);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.txtUpdatedUnitPrice);
            this.Controls.Add(this.txtUpdatedQuantityPerUnit);
            this.Controls.Add(this.txtUpdatedProductName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdateProduct);
            this.Name = "ProductUpdateWForm";
            this.Text = "ProductUpdateWForm";
            this.Load += new System.EventHandler(this.ProductUpdateWForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtUpdatedUnitPrice;
        private TextBox txtUpdatedQuantityPerUnit;
        private TextBox txtUpdatedProductName;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnUpdateProduct;
        private TextBox txtProductId;
    }
}