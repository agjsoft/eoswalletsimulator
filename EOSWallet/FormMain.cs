using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EOSWallet
{
    public partial class FormMain : Form
    {
        private string SqliteFileName = "eos.db";

        public FormMain()
        {
            InitializeComponent();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            new FormAbout().ShowDialog();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void miOption_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_MouseEnter(object sender, EventArgs e)
        {
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            string sql;
            bool fileExist = File.Exists(SqliteFileName);

            var con = new SQLiteConnection($"Data Source={SqliteFileName}");
            con.Open();

            if (false == fileExist)
            {
                sql =
                    "CREATE TABLE wallet" +
                    "(" +
                        "Name TEXT PRIMARY KEY," +
                        "Coin INTEGER NOT NULL" +
                    ")";
                new SQLiteCommand(sql, con).ExecuteNonQuery();
            }

            sql = "";
            new SQLiteCommand(sql, con).ExecuteNonQuery();

            con.Close();
        }
    }
}