using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EOSWallet
{
    public partial class FormEOS2VEOS : Form
    {
        public class EOSSplit
        {
            public int Id;
            public long Amount;
        }

        private long MyCurrentEOS = 0;
        private List<EOSSplit> EOSList = new List<EOSSplit>();

        public FormEOS2VEOS()
        {
            InitializeComponent();
        }

        private void FormEOS2VEOS_Load(object sender, EventArgs e)
        {
            DB.Open();
            DB.RunReadQuery("SELECT Id, EOS, VTIME FROM Me", (r) =>
            {
                int id = r.GetInt32(0);
                long value = r.GetInt64(1);
                DateTime vtime = r.GetDateTime(2);

                if (vtime < DateTime.Now)
                {
                    EOSList.Add(new EOSSplit()
                    {
                        Id = id,
                        Amount = value
                    });
                }
            });
            DB.Close();

            MyCurrentEOS = EOSList.Sum(eos => eos.Amount);
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

            long vv = v;
            DB.Open();
            foreach (var eos in EOSList)
            {
                if (vv < eos.Amount)
                {
                    DB.RunQuery($"UPDATE Me SET EOS = EOS - {vv} WHERE Id = {eos.Id}");
                    break;
                }
                else if (vv > eos.Amount)
                {
                    DB.RunQuery($"DELETE FROM Me WHERE Id = {eos.Id}");
                    vv -= eos.Amount;
                }
                else
                {
                    DB.RunQuery($"DELETE FROM Me WHERE Id = {eos.Id}");
                    break;
                }
            }
            DB.RunQuery($"UPDATE User SET VEOS = VEOS + {v} WHERE Id = {Define.MyUserId}");
            DB.Close();

            MessageBox.Show("전환되었습니다.");
            Close();
        }
    }
}