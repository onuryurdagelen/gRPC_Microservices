using gRPC_WFormUI.Service;
using ProductGrpc.Protos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gRPC_WFormUI.Module.Products
{
    public partial class ProductUpdateWForm : Form
    {
        public static ProductUpdateWForm instance;
        public ProductService ProductService;
        public TextBox productName;
        public TextBox productQuantityPerUnit;
        public TextBox unitPrice;
        public TextBox productId;
        public ProductUpdateWForm()
        {
            InitializeComponent();

            instance = this;
            ProductService = new ProductService();
            productName = txtUpdatedProductName;
            productQuantityPerUnit = txtUpdatedQuantityPerUnit;
            unitPrice = txtUpdatedUnitPrice;
            productId = txtProductId;
        }

        private void ProductUpdateWForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            ProductModel productModel = await ProductService.UpdateProduct(new ProductGrpc.Models.Product()
            {
                ProductId = Convert.ToInt32(txtProductId.Text),
                ProductName = txtUpdatedProductName.Text,
                QuantityPerUnit = txtUpdatedQuantityPerUnit.Text,
                UnitPrice = Convert.ToInt32(txtUpdatedUnitPrice.Text)
            });
            for (int i = 0; i < Form1.instance.DataGridViewDbTable.Rows.Count; i++)
            {
                if(Form1.instance.DataGridViewDbTable.Rows[i].Cells["ProductId"].Value.ToString() == productModel.ProductId.ToString() &&
                    Form1.instance.DataGridViewDbTable.Rows[i].Cells["ProductId"].Value != null
                    )
                {
                    Form1.instance.DataGridViewDbTable.Rows[i].Cells[0].Value = productModel.ProductId;
                    Form1.instance.DataGridViewDbTable.Rows[i].Cells[1].Value = productModel.ProductName;
                    Form1.instance.DataGridViewDbTable.Rows[i].Cells[2].Value = productModel.QuantityPerUnit;
                    Form1.instance.DataGridViewDbTable.Rows[i].Cells[3].Value = productModel.UnitPrice;
                    MessageBox.Show("Ürün başarıyla güncellenmiştir.");
                    //break;
                }
            }
        }
    }
}
