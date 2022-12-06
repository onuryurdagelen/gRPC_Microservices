using System.Data;
using System.Data.SqlClient;

namespace gRPC_Helper
{
    public class SqlHelper
    {
        static string conString;
        static string server = "DESKTOP-OKIVNDG";
        static string database = "Northwind";
        static string userId = "onur";
        static string password = "12345onur";
        public static ref readonly string ConString { get => ref conString; }
        public static ref readonly string Server { get => ref server; }
        public static ref readonly string Database { get => ref database; }
        public static ref readonly string UserId { get => ref userId; }
        public static ref readonly string Password { get => ref password; }
        public SqlConnection Baglanti { get; set; }


        public void ayarlarDosyasiniCalistir()
        {
            //using (streamReader = File.OpenText(@"C:\adisyon.txt"))
            //{
            //    conString = streamReader.ReadLine();
            //}

            //server
            //database
            //userId
            //password

            conString = $"Data Source={Server};Initial Catalog={Database};User ID={UserId};Password={Password};Encrypt=False;MultipleActiveResultSets=True;TrustServerCertificate=False;";
        }

        public SqlConnection SqlBaglantisiniGetir()
        {
            ayarlarDosyasiniCalistir();
            ref readonly string ConnectionStr = ref ConString;
            Baglanti = new SqlConnection(ConnectionStr);
            if (Baglanti.State == ConnectionState.Closed)
                Baglanti.Open();

            return Baglanti;
        }
        //İlgili database'teki tüm tablo adlarını getirir.
        public IList<string> ListTables()
        {
            List<string> tables = new List<string>();
            DataTable dt = Baglanti.GetSchema("Tables");
            foreach (DataRow row in dt.Rows)
            {
                string tablename = (string)row[2];
                tables.Add(tablename);
            }
            return tables;
        }

        //Tüm sistemdeki tüm database adlarını almamızı sağlar
        public void GetAllDatabaseNames()
        {
            string connectionString = $"Data Source=${server};User ID={UserId};Password={Password};Encrypt=False;MultipleActiveResultSets=True;TrustServerCertificate=False;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine(dr[0].ToString());
                        }
                    }
                }
            }
        }
    }
}