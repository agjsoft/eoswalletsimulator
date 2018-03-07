using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace EOSWallet
{
    public partial class FormMain : Form
    {
        private int MyUserId = 50;
        private string SqliteFileName = "eos.db";
        private SQLiteConnection SqlCon = new SQLiteConnection("Data Source=eos.db");
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

        private void RunQuery(string qry)
        {
            new SQLiteCommand(qry, SqlCon).ExecuteNonQuery();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (false == File.Exists(SqliteFileName))
            {
                var map = new Dictionary<string, bool>();

                SqlCon.Open();

                RunQuery(
                    "CREATE TABLE Me (" +
                        "EOS INTEGER NOT NULL," +
                        "VTIME DATETIME NOT NULL" +
                    ")");

                RunQuery($"INSERT INTO Me (EOS, VTIME) VALUES (45000000000000, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')");

                RunQuery(
                    "CREATE TABLE User (" +
                        "Id INTEGER PRIMARY KEY," +
                        "Name TEXT NOT NULL," +
                        "VEOS INTEGER NOT NULL" +
                    ")");

                RunQuery($"INSERT INTO User (Id, Name, VEOS) VALUES ({MyUserId}, '나자신', 0)");

                map.Clear();
                for (int i = 0; i < 300;)
                {
                    string name = GetRandomName();
                    if (map.ContainsKey(name))
                        continue;

                    map.Add(name, true);
                    i++;
                    RunQuery($"INSERT INTO User (Id, Name, VEOS) VALUES ({100 + i}, '{name}', {Rn.Next(15000, 150000)})");
                }

                RunQuery(
                    "CREATE TABLE Node (" +
                        "Id INTEGER PRIMARY KEY," +
                        "Name TEXT NOT NULL," +
                        "Intro TEXT NOT NULL" +
                    ")");

                map.Clear();
                for (int i = 0; i < 100;)
                {
                    string name = GetRandomName();
                    if (map.ContainsKey(name))
                        continue;

                    map.Add(name, true);
                    i++;
                    RunQuery($"INSERT INTO Node (Id, Name, Intro) VALUES ({2000 + i}, '{name}', '{name} 노드입니다. 잘 부탁드립니다.')");
                }

                RunQuery(
                    "CREATE TABLE Vote (" +
                        "UserId INTEGER NOT NULL," +
                        "NodeId INTEGER NOT NULL," +
                        "VEOS INTEGER NOT NULL" +
                    ")");

                SqlCon.Close();
            }

            tabControl1_SelectedIndexChanged(null, null);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCon.Open();
            switch (tabControl1.SelectedIndex)
            {
                case 0: // 개요
                    {
                        long EOS = 0;
                        long EOSing = 0;
                        long VEOS = 0;
                        long VEOSing = 0;

                        var rdr = new SQLiteCommand("SELECT EOS, VTIME FROM Me", SqlCon).ExecuteReader();
                        while (rdr.Read())
                        {
                            long value = rdr.GetInt64(0);
                            DateTime vtime = rdr.GetDateTime(1);

                            if (DateTime.Now < vtime)
                            {
                                EOSing += value;
                            }
                            else
                            {
                                EOS += value;
                            }
                        }
                        rdr.Close();

                        rdr = new SQLiteCommand($"SELECT VEOS FROM Vote WHERE UserId = {MyUserId}", SqlCon).ExecuteReader();
                        while (rdr.Read())
                        {
                            VEOSing += rdr.GetInt64(0);
                        }
                        rdr.Close();

                        rdr = new SQLiteCommand($"SELECT VEOS FROM User WHERE Id = {MyUserId}", SqlCon).ExecuteReader();
                        rdr.Read();
                        VEOS = rdr.GetInt64(0);
                        rdr.Close();

                        lbEOS.Text = Convert(EOS);
                        lbEOSing.Text = Convert(EOSing);
                        lbVEOS.Text = Convert(VEOS);
                        lbVEOSing.Text = Convert(VEOSing);
                        lbTotal.Text = Convert(EOS + EOSing + VEOS + VEOSing);
                    }
                    break;
                case 3: // BP 투표
                    {
                        var nodeMap = new Dictionary<int, Node>();
                        var rdr = new SQLiteCommand("SELECT Id, Name, Intro FROM Node", SqlCon).ExecuteReader();
                        while (rdr.Read())
                        {
                            int id = rdr.GetInt32(0);
                            string name = rdr.GetString(1);
                            string intro = rdr.GetString(2);
                            nodeMap.Add(id, new Node()
                            {
                                Name = name,
                                Intro = intro,
                                Score = 0
                            });
                        }
                        rdr.Close();

                        rdr = new SQLiteCommand("SELECT NodeId, SUM(VEOS) FROM Vote GROUP BY NodeId", SqlCon).ExecuteReader();
                        while (rdr.Read())
                        {
                            int id = rdr.GetInt32(0);
                            long score = rdr.GetInt64(1);
                            nodeMap[id].Score = score;
                        }
                        rdr.Close();

                        lvNodeList.Items.Clear();

                        int rank = 1;
                        foreach (var node in nodeMap)
                        {
                            var lvi = new ListViewItem(rank.ToString());
                            lvi.SubItems.Add(node.Value.Name);
                            lvi.SubItems.Add(Convert(node.Value.Score));
                            lvi.SubItems.Add(Convert(0));
                            lvi.SubItems.Add(node.Value.Intro);
                            lvi.Tag = node.Key;
                            lvNodeList.Items.Add(lvi);
                            rank++;
                        }
                    }
                    break;
            }
            SqlCon.Close();
        }

        public class Node
        {
            public string Name;
            public string Intro;
            public long Score;
        }

        private string Convert(long val)
        {
            var chArr = val.ToString().ToCharArray();
            string ret = "";
            int cnt = 0;
            for (int i = chArr.Length - 1; i >= 0; i--, cnt++)
            {
                if (cnt == 8)
                    ret = "." + ret;
                ret = chArr[i] + ret;
            }
            int v = 9 - ret.Length;
            for (int i = 0; i < v; i++)
            {
                if (i == v - 1)
                    ret = "." + ret;
                ret = "0" + ret;
            }
            return ret;
        }
    }
}