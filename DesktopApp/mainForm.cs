using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "Your Oauth token");
    public partial class mainForm : Form
    {
        private readonly string _token;
        public mainForm(string token)
        {
            InitializeComponent();
            _token = token;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            
        }

        
        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonShowMore_Click(object sender, EventArgs e)
        {

        }
    }
}
