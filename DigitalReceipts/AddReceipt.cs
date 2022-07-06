namespace DigitalReceipts
{
    public partial class AddReceipt : Form
    {
        private float moneyAmount;

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
            this.moneyAmount = 0f;
        }

        private void moneyBox_Leave(object sender, EventArgs e)
        {
            this.moneyAmount = float.Parse(moneyBox.Text);
        }

        private void forCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (this.forCheck.Checked == true)
                this.forBox.Visible = true;
            else
                this.forBox.Visible = false;
        }
    }
}