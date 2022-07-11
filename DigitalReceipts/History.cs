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
        private readonly AddReceipt parent;
        private List<Receipt> receipts = new();
        private readonly List<Receipt> org_receipts = new();
        public History(AddReceipt parentForm)
        {
            this.parent = parentForm;
            this.org_receipts = parentForm.receiptHistory;

            InitializeComponent();
            this.RefreshData();
        }

        public void RefreshData()
        {
            this.receipts = new(this.org_receipts);
            this.receipts.Reverse();
            this.dataGridView1.DataSource = this.receipts;
            this.dataGridView1.Refresh();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
                return;
            int index = this.dataGridView1.SelectedRows[0].Index;
            Receipt receipt = this.receipts[index];
            parent.LoadReceipt(receipt);
        }
    }
}
