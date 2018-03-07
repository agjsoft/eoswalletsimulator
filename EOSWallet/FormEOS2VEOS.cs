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
    }
}