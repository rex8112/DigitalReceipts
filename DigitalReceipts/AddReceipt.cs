namespace DigitalReceipts
{
    public partial class AddReceipt : Form
    {
        private decimal moneyAmount;

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
                this.forBox.Visible = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText($"{remarksBox.Text} {idLabel.Text}");
        }
    }
}