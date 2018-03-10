using System;
using System.Windows.Forms;

namespace EOSWallet
{
    public partial class FormVoteCancel : Form
    {
        private int SelectedNodeId;
        private long VotedVEOS;

        public FormVoteCancel(int nodeId)
        {
            InitializeComponent();
            SelectedNodeId = nodeId;
        }

        private void FormVoteCancel_Load(object sender, EventArgs e)
        {
            DB.Open();
            DB.RunReadQuery($"SELECT VEOS FROM Vote WHERE UserId = {Define.MyUserId} AND NodeId = {SelectedNodeId}", r =>
            {
                VotedVEOS = r.GetInt64(0);
            });
            DB.Close();

            if (0 == VotedVEOS)
            {
                Define.ErrorMessageBox("해당 노드에 투표철회할 VEOS가 없습니다.");
                Close();
            }

            textBox1.Text = Define.Convert(VotedVEOS);
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
            if (VotedVEOS < v)
            {
                Define.ErrorMessageBox("투표한 VEOS 양보다 더 많은 값이 입력되었습니다.");
                return;
            }

            DB.Open();
            if (VotedVEOS == v)
            {
                DB.RunQuery($"DELETE FROM Vote WHERE UserId = {Define.MyUserId} AND NodeId = {SelectedNodeId}");
            }
            else
            {
                DB.RunQuery($"UPDATE Vote SET VEOS = VEOS - {v} WHERE UserId = {Define.MyUserId} AND NodeId = {SelectedNodeId}");
            }
            DB.RunQuery($"UPDATE User SET VEOS = VEOS + {v} WHERE Id = {Define.MyUserId}");
            DB.Close();

            MessageBox.Show("투표철회되었습니다.");
            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK_Click(null, null);
        }
    }
}