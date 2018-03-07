using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace EOSWallet
{
    public partial class FormMain : Form
    {
        private string SqliteFileName = "eos.db";
        private Random Rn = new Random();
        private string[] FirstWord = new string[] { "큰", "작은", "늦은", "늙은", "파란", "빨간", "적은",
            "짧은", "긴", "노란", "검은", "재미있는", "재미없는", "밝은", "어두운", "얇은", "두꺼운", "젊은",
            "빠른", "능숙한", "어수룩한", "매력있는", "매력없는", "착한", "나쁜"};
        private string[] SecondWord = new string[] { "하늘", "돈", "사람", "컴퓨터", "서리", "이오스", "비트코인",
            "스트라티스", "라이트코인", "리플", "모네로", "인터넷", "스마트폰", "모니터", "대한민국", "스페인",
            "미국", "일본", "러시아", "중국", "태국", "영국", "서울", "런던", "도쿄", "뉴욕", "워싱턴", "오사카",
            "북경", "남경", "상하이", "파리", "프랑스", "독일", "베를린", "마드리드", "바다", "육지", "무덤",
            "언어", "직업", "자전거", "자동차", "데이터", "블록원", "댄라이머" };

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

        private string GetRandomName()
        {
            return FirstWord[Rn.Next(0, FirstWord.Length - 1)] + SecondWord[Rn.Next(0, SecondWord.Length - 1)];
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            string sql;
            var map = new Dictionary<string, bool>();
            bool fileExist = File.Exists(SqliteFileName);

            var con = new SQLiteConnection($"Data Source={SqliteFileName}");
            con.Open();

            if (false == fileExist)
            {
                sql =
                    "CREATE TABLE user" +
                    "(" +
                        "Name TEXT PRIMARY KEY," +
                        "EOS INTEGER NOT NULL," +
                        "VEOS INTEGER NOT NULL" +
                    ")";
                new SQLiteCommand(sql, con).ExecuteNonQuery();

                map.Clear();
                for (int i = 0; i < 300;)
                {
                    string name = GetRandomName();
                    if (map.ContainsKey(name))
                        continue;

                    map.Add(name, true);
                    i++;
                    sql = $"INSERT INTO user (Name, EOS, VEOS) VALUES ('{name}', {Rn.Next(10, 150000)}, {Rn.Next(10, 60000)})";
                    new SQLiteCommand(sql, con).ExecuteNonQuery();
                }

                sql =
                    "CREATE TABLE node" +
                    "(" +
                        "Name TEXT PRIMARY KEY," +
                        "Intro TEXT NOT NULL" +
                    ")";
                new SQLiteCommand(sql, con).ExecuteNonQuery();

                map.Clear();
                for (int i = 0; i < 100;)
                {
                    string name = GetRandomName();
                    if (map.ContainsKey(name))
                        continue;

                    map.Add(name, true);
                    i++;
                    sql = $"INSERT INTO node (Name, Intro) VALUES ('{name}', '{name} 노드입니다. 잘 부탁드립니다.')";
                    new SQLiteCommand(sql, con).ExecuteNonQuery();
                }

                sql =
                    "CREATE TABLE vote" +
                    "(" +
                        "UserName TEXT NOT NULL," +
                        "NodeName TEXT NOT NULL," +
                        "VEOS INTEGER NOT NULL" +
                    ")";
                new SQLiteCommand(sql, con).ExecuteNonQuery();
            }

            sql = "";
            new SQLiteCommand(sql, con).ExecuteNonQuery();

            con.Close();
        }
    }
}