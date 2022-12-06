using gRPC_Helper.Extensions;
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

        public static SqlConnection Baglanti { get; set; }

        public static SqlDataReader DataReader { get; set; }

        public static StreamReader StreamReader { get; set; }


        #region AyarlarDosyasiniCalistir
        public static void ayarlarDosyasiniCalistir()
        {
            string filePath = DirectoryExtension.GetTxtFilePath();
            //directory.

            IEnumerable<string> lines = File.ReadLines(filePath);
            Console.WriteLine(String.Join(Environment.NewLine, lines));

            //server
            server = lines.ToArray()[0].Split("=")[1];
            database = lines.ToArray()[1].Split("=")[1];
            userId = lines.ToArray()[2].Split("=")[1];
            password = lines.ToArray()[3].Split("=")[1];
            //database
            //userId
            //password

            conString = $"Data Source={Server};Initial Catalog={Database};User ID={UserId};Password={Password};Encrypt=False;MultipleActiveResultSets=True;TrustServerCertificate=False;";
        }
        #endregion

        #region SqlBaglantisiniGetir
        public static SqlConnection SqlBaglantisiniGetir()
        {
            ayarlarDosyasiniCalistir();
            ref readonly string ConnectionStr = ref ConString;
            Baglanti = new SqlConnection(ConnectionStr);
            if (Baglanti.State == ConnectionState.Closed)
                Baglanti.Open();

            return Baglanti;
        }
        #endregion

        #region DatabaseTablolarınıGetirenMetot
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
        #endregion

        #region TümDatabaseAdlarınıGetirenMetot
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
        #endregion

        #region ExecuteQueryWithParameters
        public SqlDataReader ExecuteQueryWithParameters(SqlConnection con, string query, CommandType cmdType, Dictionary<string, object> sqlParams)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = cmdType;

            foreach (var item in sqlParams)
            {
                cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            }
            return cmd.ExecuteReader();

        }
        #endregion

        #region ExecuteQueryWithoutParameters
        public SqlDataReader ExecuteQueryWithoutParameters(SqlConnection con, string query, CommandType cmdType)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = cmdType;

            return cmd.ExecuteReader();
        }
        #endregion

        #region ReturnDbSetWithParameters
        public DataSet ReturnDbSetWithParameters(SqlConnection con, string query, CommandType cmdType, Dictionary<string, object> sqlParams)
        {
            DataSet dt = new DataSet();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = cmdType;

            try
            {
                foreach (var item in sqlParams)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;
        }
        #endregion

        #region ReturnDbSetWithoutParameters
        //Birden fazla tablo çağırdığımızda DataSet sayesinde tabloları indek'e göre çağırabiliriz.
        public DataSet ReturnDbSetWithoutParameters(SqlConnection con, string query, CommandType cmdType)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = cmdType;

            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ds;
        }
        #endregion

        #region ReturnDbTableWithParameters
        public DataTable ReturnDbTableWithParameters(SqlConnection con, string query, CommandType cmdType, Dictionary<string, object> sqlParams)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = cmdType;
            try
            {

                foreach (var item in sqlParams)
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;

        }
        #endregion

        #region ReturnDbTableWithoutParameters
        public DataTable ReturnDbTableWithoutParameters(SqlConnection con, string query, CommandType cmdType)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = cmdType;

            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dt;

        }
        #endregion
    }
}