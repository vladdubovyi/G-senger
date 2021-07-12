using System;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class mailCodeCheck : Form
    {
        private readonly string _code;
        public mailCodeCheck(string code)
        {
            _code = code;
            InitializeComponent();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(textBoxCode.Text))
            {
                MessageBox.Show(this, "You must write code here!", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_code == textBoxCode.Text)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }

            this.Close();
        }
    }
}
