using System;
using System.Windows.Forms;

namespace EOSWallet
{
    public partial class FormVEOS2EOS : Form
    {
        private long MyCurrentVEOS = 0;

        public FormVEOS2EOS()
        {
            InitializeComponent();
        }

        private void FormVEOS2EOS_Load(object sender, EventArgs e)
        {
            DB.Open();
            MyCurrentVEOS = 0;
            DB.RunReadQuery($"SELECT VEOS FROM User WHERE Id = {Define.MyUserId}", (r) =>
            {
                MyCurrentVEOS = r.GetInt64(0);
            });
            DB.Close();

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
            string time1 = Define.SecondsToMessage(Define.ConvertTimeSecond);
            string time2 = Define.SecondsToMessage(Define.ConvertStep * Define.ConvertTimeSecond);
            var dr = MessageBox.Show($"{Define.Convert(v)} VEOS 코인을 EOS 코인으로 전환하시겠습니까? 확인버튼을 누를경우 {time1} 경과시마다 1/{Define.ConvertStep}씩 전환되어 100% 전환되기까지 총 {time2}이(가) 소요됩니다.", "확인", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
                return;

            long divideAmount = v / Define.ConvertStep;
            int mod = (int)(v % Define.ConvertStep);
            DB.Open();
            DB.RunQuery($"UPDATE User SET VEOS = VEOS - {v} WHERE Id = {Define.MyUserId}");
            for (int i = 1; i <= Define.ConvertStep; i++, mod--)
            {
                DB.RunQuery($"INSERT INTO Me (EOS, VTIME) VALUES ({divideAmount + ((0 < mod) ? 1 : 0)}, '{DateTime.Now.AddSeconds(Define.ConvertTimeSecond * i).ToString("yyyy-MM-dd HH:mm:ss") }')");
            }
            DB.Close();

            MessageBox.Show("전환되었습니다.");
            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK_Click(null, null);
        }
    }
}