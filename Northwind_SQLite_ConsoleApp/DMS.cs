using System.Data;
using System.Data.SQLite;
using System.IO;


namespace Northwind_SQLite_ConsoleApp
{
    public static class DMS
    {
        public static SQLiteConnection conn;
        static DMS()
        {
            // "@" İşaretini kaldırarak ters slashları çiftleyebiliriz
            // conn = new SQLiteConnection("Data Source=C:\\Users\\pc\\sqlite3\\Northwind\\Northwind.db");


            // "/" Sanal bir yol
            // conn = new SQLiteConnection("Data Source=C:/Northwind.db");

            // Fiziksel bir yol tanımı
            conn = new SQLiteConnection(@"Data Source = C:\Northwind.db;Version=3;");

            if (!File.Exists(@"Data Source = C:\Northwind.db;Version=3;"))
            {
                SQLiteConnection.CreateFile(@"Data Source = C:\Northwind.db;Version=3;");
                System.Console.WriteLine("The Northwind Database Has Been Created.");
            }
        }

        /// <summary>
        /// Use this method on Insert , Update or Delete operations.
        /// </summary>
        /// <param name="cmd">SQLiteCommand parametre</param>
        /// <returns>int: Number of affected rows.</returns>
        public static int SQLiteExecuteNonQuery(SQLiteCommand cmd)
        {
            try
            {
                cmd.Connection = conn;
                cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                // close benzeri
                cmd.Dispose();
                return result;
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

        }

        /// <summary>
        /// Return a Dataset including tables.
        /// </summary>
        /// <param name="cmd">SQLiteCommand type</param>
        /// <returns>This method returns a dataset.</returns>
        public static DataSet SQLiteExecuteReader(SQLiteCommand cmd)
        {
            try
            {
                cmd.Connection = conn;
                cmd.Connection.Open();
                var sda = new SQLiteDataAdapter(cmd);
                var ds = new DataSet();

                sda.Fill(ds);
                cmd.Connection.Close();
                cmd.Dispose();
                return ds;
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
        }

        public static object SQLiteExecuteScalar(SQLiteCommand cmd)
        {
            throw new System.NotImplementedException();
        }

    }
}
