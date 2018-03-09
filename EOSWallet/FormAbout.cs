using System;
using System.Windows.Forms;

namespace EOSWallet
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }
    }
}