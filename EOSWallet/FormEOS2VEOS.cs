using System;
using System.Windows.Forms;

namespace EOSWallet
{
    public partial class FormEOS2VEOS : Form
    {
        private long MyCurrentEOS = 0;

        public FormEOS2VEOS()
        {
            InitializeComponent();
        }

        private void FormEOS2VEOS_Load(object sender, EventArgs e)
        {
            DB.Open();
            MyCurrentEOS = 0;
            DB.RunReadQuery("SELECT EOS, VTIME FROM Me", (r) =>
            {
                long value = r.GetInt64(0);
                DateTime vtime = r.GetDateTime(1);

                if (vtime < DateTime.Now)
                {
                    MyCurrentEOS += value;
                }
            });
            DB.Close();

            textBox1.Text = Define.Convert(MyCurrentEOS);
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
            if (MyCurrentEOS < v)
            {
                Define.ErrorMessageBox("보유한 EOS 양보다 더 많은 값이 입력되었습니다.");
                return;
            }

            var dr = MessageBox.Show($"{Define.Convert(v)} EOS 코인을 VEOS 코인으로 전환하시겠습니까? 확인버튼을 누를경우 즉시 전환됩니다.", "확인", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
                return;

            DB.Open();

            DB.RunQuery($"UPDATE User SET VEOS = VEOS + {v} WHERE Id = {Define.MyUserId}");

            DB.Close();
            MessageBox.Show("전환되었습니다.");
        }
    }
}