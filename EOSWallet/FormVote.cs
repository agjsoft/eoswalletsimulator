using System;
using System.Windows.Forms;

namespace EOSWallet
{
    public partial class FormVote : Form
    {
        private long MyCurrentVEOS = 0;
        private int SelectedNodeId;

        public FormVote(int nodeId)
        {
            InitializeComponent();
            SelectedNodeId = nodeId;
        }

        private void FormVote_Load(object sender, EventArgs e)
        {
            DB.Open();
            MyCurrentVEOS = 0;
            DB.RunReadQuery($"SELECT VEOS FROM User WHERE Id = {Define.MyUserId}", (r) =>
            {
                MyCurrentVEOS = r.GetInt64(0);
            });
            DB.Close();
            if (0 == MyCurrentVEOS)
            {
                Define.ErrorMessageBox("투표가능한 VEOS가 없습니다.");
                Close();
            }

            textBox1.Text = Define.Convert(MyCurrentVEOS);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            long v = Define.Convert(input);
            if (-1 == v)
            {
                Define.ErrorMessageBox("소수점은 8자리까지 입력할 수 있습니다.");
                return;
            }
            if (MyCurrentVEOS < v)
            {
                Define.ErrorMessageBox("보유한 VEOS 양보다 더 많은 값이 입력되었습니다.");
                return;
            }

            DB.Open();
            DB.RunQuery($"UPDATE User SET VEOS = VEOS - {v} WHERE Id = {Define.MyUserId}");
            int rowCount = 0;
            DB.RunReadQuery($"SELECT COUNT(*) FROM Vote WHERE UserId = {Define.MyUserId} AND NodeId = {SelectedNodeId}", r =>
            {
                rowCount = r.GetInt32(0);
            });
            if (0 == rowCount)
            {
                DB.RunQuery($"INSERT INTO Vote (UserId, NodeId, VEOS) VALUES ({Define.MyUserId}, {SelectedNodeId}, {v})");
            }
            else
            {
                DB.RunQuery($"UPDATE Vote SET VEOS = VEOS + {v} WHERE UserId = {Define.MyUserId} AND NodeId = {SelectedNodeId}");
            }
            DB.Close();

            MessageBox.Show("투표되었습니다.");
            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK_Click(null, null);
        }
    }
}