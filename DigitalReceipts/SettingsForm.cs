using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalReceipts
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            usernameBox.Text = Properties.Settings.Default.DatabaseUsername;
            ipBox.Text = Properties.Settings.Default.DatabaseIP;
            portBox.Text = Properties.Settings.Default.DatabasePort;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DatabaseUsername = usernameBox.Text;
            Properties.Settings.Default.DatabaseIP = ipBox.Text;
            Properties.Settings.Default.DatabasePort = portBox.Text;
            if (!string.IsNullOrEmpty(passwordBox.Text))
                Properties.Settings.Default.DatabasePassword = passwordBox.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
