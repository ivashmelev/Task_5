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

namespace Task_4
{
    public partial class MainForm : Form
    {
        ServiceController[] services;

        public MainForm()
        {
            InitializeComponent();
            services = ServiceController.GetServices();
            
            for (int i = 0; i < services.Length; i++)
            {
                var count = services.Length;
                checkedListBox1.Items.Add(services[i].ServiceName);
                if (services[i].Status == ServiceControllerStatus.Running)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
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
    } 
}
