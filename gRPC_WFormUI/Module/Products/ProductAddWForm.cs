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

namespace gRPC_WFormUI.Module.Product
{
    public partial class ProductAddWForm : Form
    {
        public ProductService ProductService;
        public ProductAddWForm()
        {
            InitializeComponent();
            ProductService = new ProductService();
        }

        private void ProductAddWForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnAddProduct_Click(object sender, EventArgs e)
        {
           ProductModel productModel = await ProductService.AddProductAsync(new ProductGrpc.Models.Product()
            {
                ProductName= txtProductName.Text,
                QuantityPerUnit =txtQuantityPerUnit.Text,
                UnitPrice = Convert.ToInt32(txtUnitPrice.Text)
            });
            Form1.Products.Add(new ProductGrpc.Models.Product()
            {
                ProductId = productModel.ProductId,
                ProductName = productModel.ProductName,
                QuantityPerUnit = productModel.QuantityPerUnit,
                UnitPrice = Convert.ToInt32(productModel.UnitPrice),
            });
            Form1.instance.DataGridViewDbTable.DataSource = Form1.Products;
        }
    }
}
