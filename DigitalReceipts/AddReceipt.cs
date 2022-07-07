namespace DigitalReceipts
{
    public partial class AddReceipt : Form
    {
        public static ReceiptsContext db = new();
        private decimal moneyAmount;
        private int index;
        private List<Receipt> receiptHistory = new();

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

        private void moneyBox_Leave(object sender, EventArgs e)
        {
            
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
                db.Add(receipt.GetDatabaseSet());
                db.SaveChanges();

                this.moneyAmount = 0m;
                this.moneyBox.Text = "0.00";
            }
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
            Clipboard.SetText($"{prefix}{this.referenceBox.Text}");
        }

        private void remarksLabel_Click(object sender, EventArgs e)
        {
            Clipboard.SetText($"{remarksBox.Text} {idLabel.Text}");
        }

        private void moneyLabel_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.moneyAmount.ToString("0.00"));
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }
    }
}