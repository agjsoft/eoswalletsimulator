using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EOSWallet
{
    public partial class FormMain : Form
    {
        private Random Rn = new Random();

        public FormMain()
        {
            InitializeComponent();
            Text += Define.ApplicationVersion;
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
            if (false == File.Exists(DB.SqliteFileName))
            {
                var map = new Dictionary<string, bool>();

                DB.Open();

                DB.RunQuery(
                    "CREATE TABLE Me (" +
                        "Id INTEGER PRIMARY KEY," +
                        "EOS INTEGER NOT NULL," +
                        "VTIME DATETIME NOT NULL" +
                    ")");

                DB.RunQuery($"INSERT INTO Me (EOS, VTIME) VALUES ({Define.InitEOS * Define.SosuConvertValue}, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')");

                DB.RunQuery(
                    "CREATE TABLE User (" +
                        "Id INTEGER PRIMARY KEY," +
                        "Name TEXT NOT NULL," +
                        "VEOS INTEGER NOT NULL" +
                    ")");

                DB.RunQuery($"INSERT INTO User (Id, Name, VEOS) VALUES ({Define.MyUserId}, '나자신', 0)");

                map.Clear();
                for (int i = 0; i < Define.AIUserCount;)
                {
                    string name = Define.GetRandomName();
                    if (map.ContainsKey(name))
                        continue;

                    map.Add(name, true);
                    i++;
                    DB.RunQuery($"INSERT INTO User (Id, Name, VEOS) VALUES ({100 + i}, '{name}', {Rn.Next(15000, 150000) * Define.SosuConvertValue})");
                }

                DB.RunQuery(
                    "CREATE TABLE Node (" +
                        "Id INTEGER PRIMARY KEY," +
                        "BP INTEGER NOT NULL," +
                        "Name TEXT NOT NULL," +
                        "Intro TEXT NOT NULL" +
                    ")");

                map.Clear();
                for (int i = 0; i < Define.NodeCount;)
                {
                    string name = Define.GetRandomName();
                    if (map.ContainsKey(name))
                        continue;

                    map.Add(name, true);
                    i++;
                    DB.RunQuery($"INSERT INTO Node (Id, BP, Name, Intro) VALUES ({2000 + i}, 0, '{name}', '{name} 노드입니다. 잘 부탁드립니다.')");
                }

                DB.RunQuery(
                    "CREATE TABLE Vote (" +
                        "UserId INTEGER NOT NULL," +
                        "NodeId INTEGER NOT NULL," +
                        "VEOS INTEGER NOT NULL" +
                    ")");

                DB.Close();
            }

            RefreshTabPage(0);
            timer1.Start();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTabPage(tabControl1.SelectedIndex);
        }

        public class Node
        {
            public int Id;
            public bool BP;
            public string Name;
            public string Intro;
            public long Score;
            public long MyVote;
        }

        private void btnEOS2VEOS_Click(object sender, EventArgs e)
        {
            new FormEOS2VEOS().ShowDialog();
        }

        private void btnVEOS2EOS_Click(object sender, EventArgs e)
        {
            new FormVEOS2EOS().ShowDialog();
        }

        private void miVote_Click(object sender, EventArgs e)
        {
            if (1 != lvNodeList.SelectedItems.Count)
                return;

            var node = lvNodeList.SelectedItems[0];
            new FormVote((int)node.Tag).ShowDialog();
            RefreshTabPage(3);
        }

        private void miVoteCancel_Click(object sender, EventArgs e)
        {
            if (1 != lvNodeList.SelectedItems.Count)
                return;

            var node = lvNodeList.SelectedItems[0];
            new FormVoteCancel((int)node.Tag).ShowDialog();
            RefreshTabPage(3);
        }

        private void cbViewOnlyMyVoted_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTabPage(3);
        }

        public class EOSSplit
        {
            public int Id;
            public DateTime CompleteTime;
            public long Amount;
        }

        private void RefreshTabPage(int page)
        {
            switch (page)
            {
                case 0: // 개요
                    {
                        long EOS = 0;
                        long EOSing = 0;
                        long VEOS = 0;
                        long VEOSing = 0;
                        var list = new List<EOSSplit>();

                        DB.Open();
                        DB.RunReadQuery("SELECT Id, EOS, VTIME FROM Me", (r) =>
                        {
                            int id = r.GetInt32(0);
                            long value = r.GetInt64(1);
                            DateTime vtime = r.GetDateTime(2);
                            
                            if (DateTime.Now < vtime)
                            {
                                EOSing += value;
                                list.Add(new EOSSplit()
                                {
                                    Id = id,
                                    Amount = value,
                                    CompleteTime = vtime
                                });
                            }
                            else
                            {
                                EOS += value;
                            }
                        });

                        DB.RunReadQuery($"SELECT VEOS FROM Vote WHERE UserId = {Define.MyUserId}", (r) =>
                        {
                            VEOSing += r.GetInt64(0);
                        });

                        DB.RunReadQuery($"SELECT VEOS FROM User WHERE Id = {Define.MyUserId}", (r) =>
                        {
                            VEOS = r.GetInt64(0);
                        });
                        DB.Close();

                        lbEOS.Text = Define.Convert(EOS);
                        lbEOSing.Text = Define.Convert(EOSing);
                        lbVEOS.Text = Define.Convert(VEOS);
                        lbVEOSing.Text = Define.Convert(VEOSing);
                        lbTotal.Text = Define.Convert(EOS + EOSing + VEOS + VEOSing);

                        lvEOSing.Items.Clear();

                        if (0 < list.Count)
                        {
                            label5.Visible = true;
                            lvEOSing.Visible = true;

                            foreach (var data in list)
                            {
                                var lvi = new ListViewItem(Define.Convert(data.Amount));
                                lvi.SubItems.Add(data.CompleteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                lvi.Tag = data.Id;
                                lvEOSing.Items.Add(lvi);
                            }
                        }
                        else
                        {
                            label5.Visible = false;
                            lvEOSing.Visible = false;
                        }
                    }
                    break;
                case 3: // BP 투표
                    {
                        var rankList = GetNodeRankList();

                        lvNodeList.Items.Clear();

                        int rank = 1;
                        foreach (var node in rankList)
                        {
                            if (cbViewOnlyMyVoted.Checked && 0 == node.MyVote)
                            {
                                rank++;
                                continue;
                            }

                            var lvi = new ListViewItem(rank.ToString());
                            lvi.SubItems.Add(node.Name);
                            lvi.SubItems.Add(Define.Convert(node.Score));
                            lvi.SubItems.Add(Define.Convert(node.MyVote));
                            lvi.SubItems.Add(node.Intro);
                            lvi.Tag = node.Id;
                            if (node.BP)
                            {
                                lvi.BackColor = Color.Yellow;
                                lvi.Font = new Font(lvi.Font, FontStyle.Bold);
                            }
                            lvNodeList.Items.Add(lvi);
                            rank++;
                        }
                    }
                    break;
            }
        }

        private List<Node> GetNodeRankList()
        {
            var nodeMap = new Dictionary<int, Node>();

            DB.Open();
            DB.RunReadQuery("SELECT Id, BP, Name, Intro FROM Node", (r) =>
            {
                int id = r.GetInt32(0);
                int bp = r.GetInt32(1);
                string name = r.GetString(2);
                string intro = r.GetString(3);
                nodeMap.Add(id, new Node()
                {
                    Id = id,
                    BP = (1 == bp),
                    Name = name,
                    Intro = intro,
                    Score = 0,
                    MyVote = 0
                });
            });

            DB.RunReadQuery("SELECT NodeId, SUM(VEOS) FROM Vote GROUP BY NodeId", (r) =>
            {
                int id = r.GetInt32(0);
                long score = r.GetInt64(1);
                nodeMap[id].Score = score;
            });

            DB.RunReadQuery($"SELECT NodeId, VEOS FROM Vote WHERE UserId = {Define.MyUserId}", (r) =>
            {
                int id = r.GetInt32(0);
                long score = r.GetInt64(1);
                nodeMap[id].MyVote = score;
            });
            DB.Close();

            var rankList = nodeMap.Values.ToList();
            rankList.Sort(Comparer<Node>.Create((a, b) =>
            {
                if (a.Score == b.Score)
                    return a.Name.CompareTo(b.Name);
                else
                    return b.Score.CompareTo(a.Score);
            }));
            return rankList;
        }

        private DateTime RoundStandTime = new DateTime(2018, 1, 1, 0, 0, 0);
        private int LastRoundId = 0;
        private int LastRemainSec = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            int totalSec = (int)(DateTime.Now - RoundStandTime).TotalSeconds;
            int roundId = totalSec / Define.OneRoundSeconds;
            if (LastRoundId != roundId)
            {
                var rankList = GetNodeRankList();
                string nodeIdList = "";
                for (int i = 0; i < Define.BlockProcedureCount; i++)
                {
                    nodeIdList += rankList[i].Id + ", ";
                }
                nodeIdList = nodeIdList.Substring(0, nodeIdList.Length - 2);

                DB.Open();
                DB.RunQuery("UPDATE Node SET BP = 0");
                DB.RunQuery($"UPDATE Node SET BP = 1 WHERE Id IN ({nodeIdList})");
                DB.Close();

                RefreshTabPage(3);

                LastRoundId = roundId;
            }

            int remainSec = Define.OneRoundSeconds - (totalSec % Define.OneRoundSeconds);
            if (LastRemainSec != remainSec)
            {
                label12.Text = remainSec.ToString();
                LastRemainSec = remainSec;
            }
        }

        private void miBuildEOSCancel_Click(object sender, EventArgs e)
        {
            if (0 == lvEOSing.SelectedItems.Count)
                return;

            string ids = "";
            foreach (ListViewItem item in lvEOSing.SelectedItems)
            {
                ids += (int)item.Tag + ", ";
            }
            ids = ids.Substring(0, ids.Length - 2);

            long getVEOS = 0;
            DB.Open();
            DB.RunReadQuery($"SELECT SUM(EOS) FROM Me WHERE Id IN ({ids})", r =>
            {
                getVEOS = r.GetInt64(0);
            });
            DB.RunQuery($"DELETE FROM Me WHERE Id IN ({ids})");
            DB.RunQuery($"UPDATE User SET VEOS = VEOS + {getVEOS} WHERE Id = {Define.MyUserId}");
            DB.Close();

            RefreshTabPage(0);
        }
    }
}