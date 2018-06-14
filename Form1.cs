using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.ServiceProcess;
using System.Net;

namespace Task_4
{
    public partial class MainForm : Form
    {
        ServiceController[] services;

        public MainForm()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox ch = sender as CheckedListBox;
            
            int id = ch.SelectedIndex;
                if(checkedListBox1.GetItemChecked(id))
                {
                    services[id].Start();
                }
                else
                {
                    services[id].Stop();
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            services = ServiceController.GetServices();
            string ipadress = textBox1.Text;
            IPAddress ip = IPAddress.Parse($"{ipadress}");

            for (int i = 0; i < services.Length; i++)
            {
                var count = services.Length;
                services[i].MachineName = Convert.ToString(ip);
                checkedListBox1.Items.Add(services[i].ServiceName);
                if (services[i].Status == ServiceControllerStatus.Running)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
        }
    } 
}