using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class registerForm : Form
    {
        private loginForm _lf;
        public registerForm(loginForm lf)
        {
            _lf = lf;
            InitializeComponent();
        }

        private void registerForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // USE VALIDATION 
        }
 
        private void registerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _lf.Show();
        }
    }
}
