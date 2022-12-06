using gRPC_Helper;

namespace gRPC_WFormUI
{
    public partial class Form1 : Form
    {
        SqlHelper SqlHelper;
        public static Form1 instance;
        public ComboBox ComboBoxDbTable;
        public Form1()
        {
            InitializeComponent();
            SqlHelper = new SqlHelper();
            cmbxDbTable.Items.Clear();
            ComboBoxDbTable = cmbxDbTable;
            instance = this;
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            Ayarlar ayarlar = new Ayarlar();
            ayarlar.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlHelper.SqlBaglantisiniGetir();
            IList<string> dbTableList = SqlHelper.ListTables();
            dbTableList.ToList().ForEach(dbTable =>
            {
                ComboBoxDbTable.Items.Add(dbTable);
            });

        }
    }
}