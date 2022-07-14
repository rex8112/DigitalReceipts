namespace DigitalReceipts
{
    public partial class AddReceipt : Form
    {
        public static ReceiptsContext db;
        public List<Receipt> receiptHistory = new();
        private decimal moneyAmount;
        private int index;
        private History? historyForm;
        private bool connected = false;

        public AddReceipt()
        {
            InitializeComponent();

            var AllowedPaymentTypes = new[]
            {
                "Cash",
                "Check",
                "Money Order"
            };
            this.paymentTypeBox.DataSource = AllowedPaymentTypes;
            this.moneyAmount = 0m;
            this.signBox.Text = Properties.Settings.Default.Signer;
            this.printStatus("Done Loading");
            this.updateWorker.RunWorkerAsync();
        }

        private void Connect()
        {
            db = new();
            this.RefreshData();
        }

        public AutoCompleteStringCollection GetNameAutoComplete()
        {
            List<string> names = new();
            foreach (Receipt receipt in this.receiptHistory)
                names.Add(receipt.From);
            AutoCompleteStringCollection collection = new();
            collection.AddRange(names.Distinct().ToArray());
            this.fromBox.AutoCompleteCustomSource = collection;
            return collection;
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

        public bool Connected
        {
            get
            {
                return connected;
            }
            set
            {
                connected = value;
                if (value)
                    this.statusSymbol.Text = "\u2714";
                else
                    this.statusSymbol.Text = "\u274C";
            }
        }

        public void SoftLoadReceipt(Receipt receipt)
        {
            this.addressBox.Text = receipt.Address;
            this.paymentTypeBox.Text = receipt.Type;
            this.fromBox.Text = receipt.From;
            if (receipt.Tenant != null && receipt.Tenant != "")
            {
                this.forBox.Text = receipt.Tenant;
                this.forCheck.Checked = true;
            }
            else
            {
                this.forBox.Text = "";
                this.forCheck.Checked = false;
            }
        }
        public void LoadReceipt(Receipt receipt)
        {
            this.SoftLoadReceipt(receipt);
            this.Index = receipt.Id;
            this.dateTimePicker1.Text = receipt.Date.ToString();
            this.moneyAmount = receipt.Amount;
            this.moneyBox.Text = this.moneyAmount.ToString();
            this.remarksBox.Text = receipt.Remarks;
            this.referenceBox.Text = receipt.Reference;
            
            this.SetFormState(false);
        }

        private void SetFormState(bool state)
        {
            this.dateTimePicker1.Enabled = state;
            this.moneyBox.Enabled = state;
            this.referenceBox.Enabled = state;
            this.fromBox.Enabled = state;
            this.forBox.Enabled = state;
            this.forCheck.Enabled = state;
            this.remarksBox.Enabled = state;
            this.paymentTypeBox.Enabled = state;
            this.addressBox.Enabled = state;
            this.saveButton.Enabled = state;
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

        private void ClearForm()
        {
            this.fromBox.Text = "";
            this.forBox.Text = "";
            this.forCheck.Checked = false;
            this.addressBox.Text = "";
            this.remarksBox.Text = "";
            this.NewForm();
        }

        private void NewForm()
        {
            try
            {
                var lastReceipt = db.Receipts.OrderBy(b => b.Id).Last();
                this.Index = lastReceipt.Id + 1;
            }
            catch (InvalidOperationException)
            {
                this.Index = 1;
            }
            catch (NullReferenceException)
            {
                this.Index = 1;
            }

            this.moneyAmount = 0m;
            this.moneyBox.Text = "0.00";
            this.referenceBox.Text = "";

            this.dateTimePicker1.Text = DateTime.Now.ToString();

            this.SetFormState(true);
        }

        private bool ValidateForm()
        {
            try
            {
                this.moneyAmount = decimal.Parse(moneyBox.Text);
                moneyBox.Text = this.moneyAmount.ToString("0.00");
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
            if (string.IsNullOrEmpty(this.signBox.Text))
            {
                this.validationError.SetError(this.signBox, "Initials can not be blanks.");
                return false;
            }
            this.validationError.SetError(this.signBox, "");

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
            if (this.ValidateForm())
            {
                this.Index++;
                Receipt receipt = new(this.moneyAmount, this.dateTimePicker1.Value, this.fromBox.Text, this.addressBox.Text, this.remarksBox.Text, this.referenceBox.Text, this.paymentTypeBox.Text, this.signBox.Text, this.forBox.Text);
                receiptHistory.Add(receipt);
                ReceiptRecord record = receipt.GetDatabaseSet();
                db.Add(record);
                db.SaveChanges();
                receipt.Id = record.Id;

                this.printStatus($"E-{this.Index - 1:D6}: Saved Successfully");
                this.NewForm();
                this.GetNameAutoComplete();
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
            this.ClearForm();
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            if (this.historyForm == null)
                this.historyForm = new History(this);
            else if (this.historyForm.IsDisposed)
                this.historyForm = new History(this);
            this.historyForm.Show();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            this.NewForm();
        }

        private void fromBox_Leave(object sender, EventArgs e)
        {
            if (this.GetNameAutoComplete().Contains(fromBox.Text))
            {
                var matchingReceipt = db.Receipts.Where(x => x.From == fromBox.Text).OrderBy(x => x.Id).Last();
                Receipt receipt = new(matchingReceipt);
                this.SoftLoadReceipt(receipt);
            }
        }

        private void AddReceipt_Load(object sender, EventArgs e)
        {
            this.printStatus("Attempting to connect to Database");
            this.backgroundConnectionWorker.RunWorkerAsync();
        }

        private void backgroundConnectionWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            System.ComponentModel.BackgroundWorker bw = (System.ComponentModel.BackgroundWorker) sender;

            try
            {
                this.Connect();
            }
            catch (Exception ex)
            {
                throw new Exception("Database Failure", ex);
            }
        }

        private void backgroundConnectionWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.printStatus($"Database Failed to Connect: {e.Error.Message}");
                this.Connected = false;
            }
            else
            {
                this.printStatus("Database Connected");
                this.Connected = true;
                this.GetNameAutoComplete();
                this.NewForm();
            }

        }

        private void settings_Closed(object sender, FormClosedEventArgs e)
        {
            this.printStatus("Attempting to connect to Database");
            this.backgroundConnectionWorker.RunWorkerAsync();
        }

        private void statusSymbol_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.FormClosed += new FormClosedEventHandler(this.settings_Closed);
            settingsForm.Show();
        }

        private async void updateWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            await Updater.UpdateMyApp();
        }

        private void signBox_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.Signer = this.signBox.Text;
            Properties.Settings.Default.Save();
        }
    }
}