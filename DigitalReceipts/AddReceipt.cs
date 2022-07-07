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

        private void moneyBox_Leave(object sender, EventArgs e)
        {
            try
            {
                this.moneyAmount = decimal.Parse(moneyBox.Text);
            }
            catch (FormatException)
            {
                this.moneyAmount = 0m;
                this.moneyBox.Text = "0.00";
            }
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
            this.Index++;
            Receipt receipt = new(this.moneyAmount, this.dateTimePicker1.Value, this.fromBox.Text, this.addressBox.Text, this.remarksBox.Text, this.referenceBox.Text, this.paymentTypeBox.Text, "RW", this.forBox.Text);
            receiptHistory.Add(receipt);
            db.Add(receipt.GetDatabaseSet());
            db.SaveChanges();
            Clipboard.SetText($"{remarksBox.Text} {idLabel.Text}");
        }
    }
}