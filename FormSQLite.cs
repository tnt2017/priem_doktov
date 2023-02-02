using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SQLite;
using System.IO;
using System.Data;


namespace test111
{
    public partial class FormSQLite : Form
    {
        private String dbFileName;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;

        public FormSQLite()
        {
            InitializeComponent();
        }

        private void FormSQLite_Load(object sender, EventArgs e)
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();

            dbFileName = "sample.sqlite";
            //lbStatusText.Text = "Disconnected";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dbFileName = "test.db";

            if (!File.Exists(dbFileName))
                MessageBox.Show("Please, create DB and blank table (Push \"Create\" button)");

            try
            {
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                //   m_sqlCmd.Connection = m_dbConn;
                // lbStatusText.Text = "Connected";
            }
            catch (SQLiteException ex)
            {
                // lbStatusText.Text = "Disconnected";
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /*
        public static DataTable ExecuteReader(string sqlitefn, string command, List<SqliteParam> parameters, out string errorMessage)
        {
            DataTable dt = null;
            try
            {
                errorMessage = "";
                using (var conn = new SQLiteConnection(sqlitefn))
                {
                    conn.Open();
                    var commandSql = new SQLiteCommand(command, conn);
                    if (parameters != null && parameters.Count > 0)
                    {
                        foreach (SqliteParam param in parameters)
                        {
                            commandSql.Parameters.Add(param.Name, param.Type).Value = param.Value;
                        }

                    }
                    dt = new DataTable();
                    var sqlDa = new SQLiteDataAdapter(commandSql);
                    sqlDa.Fill(dt);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.ToString();
                dt = null;
            }
            return dt;
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dTable = new DataTable();
            String sqlQuery;

            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("Open connection with database");
                return;
            }

            try
            {
                sqlQuery = "SELECT ID FROM KATMC";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);

                if (dTable.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();

                    for (int i = 0; i < dTable.Rows.Count; i++)
                        dataGridView1.Rows.Add(dTable.Rows[i].ItemArray);
                }
                else
                    MessageBox.Show("Database is empty");
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
