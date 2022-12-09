using gRPC_Helper;
using gRPC_WFormUI.Service;
using ProductGrpc.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data;
using gRPC_WFormUI.Module.Product;
using gRPC_WFormUI.Module.Products;
using System.Windows.Forms;
using ProductGrpc.Protos;

namespace gRPC_WFormUI
{
    public partial class Form1 : Form
    {
        SqlHelper SqlHelper;
        public static Form1 instance;
        public static List<Product> Products;
        public ProductService ProductService;
        public ComboBox ComboBoxDbTable;
        public DataGridView DataGridViewDbTable;
        public Product Product;
        public Form1()
        {
            InitializeComponent();
            SqlHelper = new SqlHelper();
            ProductService = new ProductService();
            cmbxDbTable.Items.Clear();
            ComboBoxDbTable = cmbxDbTable;
            DataGridViewDbTable = dbTableGridView;
            instance = this;

        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            Ayarlar ayarlar = new Ayarlar();
            ayarlar.Show();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
           

            //SqlHelper.ayarlarDosyasiniCalistir();
            SqlHelper.SetTxtFile();
            SqlHelper.SqlBaglantisiniGetir();
            IList<string> dbTableList = SqlHelper.ListTables();
            dbTableList.ToList().ForEach(dbTable =>
            {
                ComboBoxDbTable.Items.Add(dbTable);
            });

            Products = await ProductService.GetAllProductsAsync();
            var bindingList = new BindingList<Product>(Products);
            var source = new BindingSource(bindingList, null);
            dbTableGridView.DataSource = source;
            dbTableGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Product tablosunu grid view'da gösterme
            //DataTable dt = SqlHelper.ReturnDbTableWithoutParameters(SqlHelper.Baglanti, "SELECT * FROM Products", CommandType.Text);

        }

        private void dbTableGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductAddWForm productAddWForm = new ProductAddWForm();
            productAddWForm.ShowDialog();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            ProductUpdateWForm productUpdateWForm = new ProductUpdateWForm();
            if (DataGridViewDbTable.CurrentRow.Selected)
            {
                productUpdateWForm.unitPrice.Text = DataGridViewDbTable.CurrentRow.Cells["UnitPrice"].Value.ToString();
                productUpdateWForm.productName.Text = DataGridViewDbTable.CurrentRow.Cells["ProductName"].Value.ToString();
                productUpdateWForm.productQuantityPerUnit.Text = DataGridViewDbTable.CurrentRow.Cells["QuantityPerUnit"].Value.ToString();
                productUpdateWForm.productId.Text = DataGridViewDbTable.CurrentRow.Cells["ProductId"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Ürünü güncellemek için lütfen bir satýr seçiniz!");
                return;
            }
            productUpdateWForm.ShowDialog();
        }

        private async void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (DataGridViewDbTable.CurrentRow.Selected)
            {
                var response = await ProductService.DeleteProductAsync(Convert.ToInt32(DataGridViewDbTable.CurrentRow.Cells["ProductId"].Value));

                if (response.IsSuccess)
                {
                   Products = Products.Where(s => s.ProductId != Convert.ToInt32(DataGridViewDbTable.CurrentRow.Cells["ProductId"].Value)).ToList();
                    Form1.instance.DataGridViewDbTable.DataSource = Products;
                    MessageBox.Show("Ürün baþarýyla silinmiþtir");
                }
                else
                    MessageBox.Show("Ürün silme iþlemi baþarýsýz");
            }
            else
            {
                MessageBox.Show("Ürünü silmek için lütfen bir satýr seçiniz!");
                return;
            }
        }
    }
}