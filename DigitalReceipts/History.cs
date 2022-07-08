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
    public partial class History : Form
    {
        private readonly List<string> data = new();
        private readonly List<Receipt> receipts = new();
        public History(List<Receipt> receipts)
        {
            InitializeComponent();
            this.receipts = receipts;
            this.dataGridView1.DataSource = receipts;
            this.RefreshData();
        }

        public void RefreshData()
        {
            data.Clear();
            foreach (Receipt item in receipts)
            {
                string[] row = { item.Id.ToString(), item.From, item.Amount.ToString("0.00"), item.Reference, item.Remarks };
                ListViewItem viewItem = new(row);
            }
        }
    }
}
