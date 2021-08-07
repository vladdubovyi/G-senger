using AutoMapper;
using DesktopApp.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class mainForm : Form
    {
        private readonly string _token;
        private readonly IMapper _mapper;
        private User _currentUser;

        public mainForm(string token, User currentUser)
        {
            InitializeComponent();
            panelMenu.Location = new Point(0, 0);
            _token = token;
            _currentUser = currentUser;
            _mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<UserGetDto, User>();
                cfg.CreateMap<User, UserGetDto>();
            }).CreateMapper();
        }

        private async void mainForm_Load(object sender, EventArgs e)
        {
            await GetSettings();
            await GetContacts();

            labelEmail.Text = _currentUser.Email;
            labelName.Text = _currentUser.FirstName + " " + _currentUser.LastName;
        }

        private async Task GetContacts()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _token);

                var response = await client.GetAsync(
                    $"http://localhost:60208/api/Users/GetContacts/{_currentUser.Email}");

                var responseJsonString = await response.Content.ReadAsStringAsync();
                var entities = JsonConvert.DeserializeObject<List<UserGetDto>>(responseJsonString);

                foreach(var entity in entities)
                {
                    await AddUserToContactList(_mapper.Map<User>(entity));
                }
            }
        }

        private async Task AddUserToContactList(User user)
        {
            await Task.Factory.StartNew(() => 
            {
                listBoxContacts.Items.Add(user);
            });
        }

        private async Task GetSettings()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _token);

                var response = await client.GetAsync(
                    $"http://localhost:60208/api/Users/{_currentUser.Email}");

                var responseJsonString = await response.Content.ReadAsStringAsync();
                var authResponse = JsonConvert.DeserializeObject<UserGetDto>(responseJsonString);

                var pass = _currentUser.Password;

                _currentUser = _mapper.Map<User>(authResponse);
                _currentUser.Password = pass; // TODO
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonShowMore_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = true;
            buttonCloseMore.Enabled = true;
        }

        private void buttonCloseMore_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            buttonShowMore.Enabled = true;
        }
    }
}
