using gRPC_Helper;
using gRPC_WFormUI.Service;
using ProductGrpc.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data;

namespace gRPC_WFormUI
{
    public partial class Form1 : Form
    {
        SqlHelper SqlHelper;
        public static Form1 instance;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //SqlHelper.ayarlarDosyasiniCalistir();
            SqlHelper.SetTxtFile();
            SqlHelper.SqlBaglantisiniGetir();
            IList<string> dbTableList = SqlHelper.ListTables();
            dbTableList.ToList().ForEach(dbTable =>
            {
                ComboBoxDbTable.Items.Add(dbTable);
            });
            List<Product> Products = ProductService.GetAllProductsAsync().GetAwaiter().GetResult();
            var bindingList = new BindingList<Product>(Products);
            var source = new BindingSource(bindingList, null);
            dbTableGridView.DataSource = source;
            //Product tablosunu grid view'da gösterme
            //DataTable dt = SqlHelper.ReturnDbTableWithoutParameters(SqlHelper.Baglanti, "SELECT * FROM Products", CommandType.Text);
           
        }

        private void dbTableGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}