namespace DigitalReceipts
{
    public partial class AddReceipt : Form
    {
        public static ReceiptsContext db = new();
        private decimal moneyAmount;
        private int index;
        public List<Receipt> receiptHistory = new();

        public AddReceipt()
        {
            InitializeComponent();

            try
            {
                var lastReceipt = db.Receipts.OrderBy(b => b.Id).Last();
                this.Index = lastReceipt.Id + 1;
            }
            catch (InvalidOperationException)
            {
                this.Index = 1;
            }

            var AllowedPaymentTypes = new[]
            {
                "Cash",
                "Check",
                "Money Order"
            };
            this.paymentTypeBox.DataSource = AllowedPaymentTypes;
            this.moneyAmount = 0m;
            this.RefreshData();
            this.printStatus("Done Loading");
        }

        public int Index 
        { 
            get { return index; }
            set
            {
                index = value;
                this.idLabel.Text = $"E-{this.index:D6}";
            }
        }

        private void RefreshData()
        {
            var receipts = db.Receipts.OrderBy(x => x.Id);
            this.receiptHistory.Clear();
            foreach(ReceiptRecord rec in receipts)
            {
                Receipt receipt = new(rec);
                this.receiptHistory.Add(receipt);
            }
        }

        private void printStatus(string status)
        {
            this.statusLabel.Text = status;
        }

        private void clearForm()
        {
            this.moneyAmount = 0m;
            this.moneyBox.Text = "0.00";
            this.fromBox.Text = "";
            this.forBox.Text = "";
            this.forCheck.Checked = false;
            this.addressBox.Text = "";
            this.remarksBox.Text = "";
            this.referenceBox.Text = "";
        }

        private bool validateForm()
        {
            try
            {
                this.moneyAmount = decimal.Parse(moneyBox.Text);
                if (this.moneyAmount == 0m)
                {
                    this.validationError.SetError(this.moneyBox, "Must be larger than 0.");
                    return false;
                }
            }
            catch (FormatException)
            {
                this.validationError.SetError(this.moneyBox, "Must be a valid decimal number. Ex: 12.34");
                return false;
            }
            this.validationError.SetError(this.moneyBox, "");

            if (this.fromBox.Text == "")
            {
                this.validationError.SetError(this.fromBox, "Value must not be empty.");
                return false;
            }
            this.validationError.SetError(this.fromBox, "");

            if (this.addressBox.Text == "")
            {
                this.validationError.SetError(this.addressBox, "Value must not be empty");
                return false;
            }
            this.validationError.SetError(this.addressBox, "");

            if (this.paymentTypeBox.Text != "Cash" && this.referenceBox.Text == "")
            {
                this.validationError.SetError(this.referenceBox, "Value must not be empty for non cash receipts.");
                return false;
            }
            this.validationError.SetError(this.referenceBox, "");

            if (this.forCheck.Checked == true && this.forBox.Text == "")
            {
                this.validationError.SetError(this.forBox, "Value must not be empty if box is checked.");
                return false;
            }
            this.validationError.SetError(this.forBox, "");

            return true;
        }

        private void forCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (this.forCheck.Checked == true)
                this.forBox.Visible = true;
            else
            {
                this.forBox.Visible = false;

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.validateForm())
            {
                this.Index++;
                Receipt receipt = new(this.moneyAmount, this.dateTimePicker1.Value, this.fromBox.Text, this.addressBox.Text, this.remarksBox.Text, this.referenceBox.Text, this.paymentTypeBox.Text, "RW", this.forBox.Text);
                receiptHistory.Add(receipt);
                ReceiptRecord record = receipt.GetDatabaseSet();
                db.Add(record);
                db.SaveChanges();
                receipt.Id = record.Id;

                this.moneyAmount = 0m;
                this.moneyBox.Text = "0.00";
                this.printStatus($"E-{this.Index - 1:D6}: Saved Successfully");
            }
            else
                this.printStatus("Validation Error");
        }

        private void AddReceipt_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void referenceLabel_Click(object sender, EventArgs e)
        {
            string prefix = "";
            if (this.paymentTypeBox.Text == "Check")
            {
                prefix = "Check #";
            }
            else if (this.paymentTypeBox.Text == "Money Order")
            {
                prefix = "Serial #";
            }
            this.referenceBox.Focus();
            this.referenceBox.SelectAll();
            Clipboard.SetText($"{prefix}{this.referenceBox.Text}");
            this.printStatus("Reference Copied to Clipboard");
        }

        private void remarksLabel_Click(object sender, EventArgs e)
        {
            this.remarksBox.Focus();
            this.remarksBox.SelectAll();
            Clipboard.SetText($"{remarksBox.Text} {idLabel.Text}");
            this.printStatus("Remarks Copied to Clipboard");
        }

        private void moneyLabel_Click(object sender, EventArgs e)
        {
            this.moneyBox.Focus();
            this.moneyBox.SelectAll();
            Clipboard.SetText(this.moneyAmount.ToString("0.00"));
            this.printStatus("Money Amount Copied to Clipboard");
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            var historyForm = new History(this.receiptHistory);
            historyForm.Show();
        }
    }
}