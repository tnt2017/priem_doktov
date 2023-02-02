using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace test111
{
    class DBSqlite
    {
               
        public static SQLiteConnection Connect()
        {
            Logger.WriteLine("Connect start");

            SQLiteConnection m_dbConn = new SQLiteConnection();
            SQLiteCommand m_sqlCmd = new SQLiteCommand();
            String dbFileName = "test.db";

            if (!File.Exists(dbFileName))
                MessageBox.Show("Please, create DB and blank table (Push \"Create\" button)");

            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3; Pooling=True;Max Pool Size=100;");
                m_dbConn.Open();

                Logger.WriteLine("ServerVersion: {0}" + m_dbConn.ServerVersion);
                Logger.WriteLine("State: {0}" + m_dbConn.State);

                //   m_sqlCmd.Connection = m_dbConn;
                // lbStatusText.Text = "Connected";
            }
            catch (SQLiteException ex)
            {
                // lbStatusText.Text = "Disconnected";
                Logger.WriteLine("Error: " + ex.Message);
                MessageBox.Show("Error: " + ex.Message);
            }

            Logger.WriteLine("Connect end");

            return m_dbConn;

        }

       /* public static  SQLiteConnection Close(SQLiteConnection m_dbConn)
        {
            Logger.WriteLine("Close start");
            m_dbConn.Close();
            Logger.WriteLine("Close end");
        }*/


    }
}
