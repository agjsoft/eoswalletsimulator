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
    }
}