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
        private readonly BindingSource bindingSource = new();
        public History(AddReceipt parentForm)
        {
            this.parent = parentForm;
            this.org_receipts = parentForm.receiptHistory;

            InitializeComponent();
            this.RefreshData();
            this.dataGridView1.DataSource = bindingSource;
        }

        public void RefreshData()
        {
            this.receipts = new(this.org_receipts);
            this.receipts.Reverse();
            this.bindingSource.DataSource = this.receipts;
            this.dataGridView1.Refresh();
        }

        private List<Receipt> Filter(string filter)
        {
            List<Receipt> newList = new();
            foreach(Receipt r in this.org_receipts)
            {
                if (
                    r.Id.ToString().ToLower().Contains(filter) ||
                    r.From.ToLower().Contains(filter) ||
                    r.Address.ToLower().Contains(filter) ||
                    r.Amount.ToString().ToLower().Contains(filter) ||
                    r.Remarks.ToLower().Contains(filter) ||
                    r.Date.ToString().ToLower().Contains(filter) ||
                    (r.Reference != null && r.Reference.ToLower().Contains(filter)) ||
                    (r.Tenant != null && r.Tenant.ToLower().Contains(filter))
                    )
                {
                    newList.Add(r);
                }
            }
            return newList;
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

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string t = this.searchBox.Text;
            if (!string.IsNullOrEmpty(t))
                this.bindingSource.DataSource = this.Filter(t);
            else
                this.RefreshData();
        }
    }
}
