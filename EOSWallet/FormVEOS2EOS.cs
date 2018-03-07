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
            int idx = input.IndexOf('.');
            long v = 0;
            if (0 <= idx)
            {
                v = long.Parse(input.Substring(0, idx)) * 100000000;
                string ky = input.Substring(idx + 1);
                if (8 < ky.Length)
                {
                    MessageBox.Show("소수점은 8자리까지 입력가능합니다.");
                    return;
                }
                long v2 = long.Parse(ky);
                switch (ky.Length)
                {
                    case 1:
                        v2 *= 10000000;
                        break;
                    case 2:
                        v2 *= 1000000;
                        break;
                    case 3:
                        v2 *= 100000;
                        break;
                    case 4:
                        v2 *= 10000;
                        break;
                    case 5:
                        v2 *= 1000;
                        break;
                    case 6:
                        v2 *= 100;
                        break;
                    case 7:
                        v2 *= 10;
                        break;
                }
                v += v2;
            }
            else
            {
                v = long.Parse(input) * 100000000;
            }

            string time1 = Define.SecondsToMessage(Define.ConvertTimeSecond);
            string time2 = Define.SecondsToMessage(Define.ConvertStep * Define.ConvertTimeSecond);
            var dr = MessageBox.Show($"{Define.Convert(v)} VEOS 코인을 EOS 코인으로 전환하시겠습니까? 확인버튼을 누를경우 {time1} 경과시마다 1/{Define.ConvertStep}씩 전환되어 100% 전환되기까지 총 {time2}이(가) 소요됩니다.", "확인", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
                return;
        }
    }
}