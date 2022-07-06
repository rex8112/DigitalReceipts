namespace DigitalReceipts
{
    partial class AddReceipt
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.fromBox = new System.Windows.Forms.TextBox();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.remarksBox = new System.Windows.Forms.TextBox();
            this.paymentTypeBox = new System.Windows.Forms.ComboBox();
            this.fromLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.remarksLabel = new System.Windows.Forms.Label();
            this.moneyBox = new System.Windows.Forms.TextBox();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.referenceBox = new System.Windows.Forms.TextBox();
            this.referenceLabel = new System.Windows.Forms.Label();
            this.forCheck = new System.Windows.Forms.CheckBox();
            this.forBox = new System.Windows.Forms.TextBox();
            this.forTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(94, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(123, 23);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // fromBox
            // 
            this.fromBox.Location = new System.Drawing.Point(94, 41);
            this.fromBox.Name = "fromBox";
            this.fromBox.Size = new System.Drawing.Size(231, 23);
            this.fromBox.TabIndex = 1;
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(94, 70);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(231, 23);
            this.addressBox.TabIndex = 2;
            // 
            // remarksBox
            // 
            this.remarksBox.Location = new System.Drawing.Point(94, 99);
            this.remarksBox.Name = "remarksBox";
            this.remarksBox.Size = new System.Drawing.Size(231, 23);
            this.remarksBox.TabIndex = 3;
            // 
            // paymentTypeBox
            // 
            this.paymentTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paymentTypeBox.FormattingEnabled = true;
            this.paymentTypeBox.Location = new System.Drawing.Point(94, 128);
            this.paymentTypeBox.Name = "paymentTypeBox";
            this.paymentTypeBox.Size = new System.Drawing.Size(121, 23);
            this.paymentTypeBox.TabIndex = 5;
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(53, 44);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(35, 15);
            this.fromLabel.TabIndex = 6;
            this.fromLabel.Text = "From";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(39, 73);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(49, 15);
            this.addressLabel.TabIndex = 7;
            this.addressLabel.Text = "Address";
            // 
            // remarksLabel
            // 
            this.remarksLabel.AutoSize = true;
            this.remarksLabel.Location = new System.Drawing.Point(36, 102);
            this.remarksLabel.Name = "remarksLabel";
            this.remarksLabel.Size = new System.Drawing.Size(52, 15);
            this.remarksLabel.TabIndex = 8;
            this.remarksLabel.Text = "Remarks";
            // 
            // moneyBox
            // 
            this.moneyBox.Location = new System.Drawing.Point(345, 41);
            this.moneyBox.Name = "moneyBox";
            this.moneyBox.Size = new System.Drawing.Size(100, 23);
            this.moneyBox.TabIndex = 9;
            this.moneyBox.Leave += new System.EventHandler(this.moneyBox_Leave);
            // 
            // moneyLabel
            // 
            this.moneyLabel.AllowDrop = true;
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Location = new System.Drawing.Point(331, 44);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(13, 15);
            this.moneyLabel.TabIndex = 2;
            this.moneyLabel.Text = "$";
            // 
            // referenceBox
            // 
            this.referenceBox.Location = new System.Drawing.Point(286, 128);
            this.referenceBox.Name = "referenceBox";
            this.referenceBox.PlaceholderText = "Ex: Check #123";
            this.referenceBox.Size = new System.Drawing.Size(159, 23);
            this.referenceBox.TabIndex = 10;
            // 
            // referenceLabel
            // 
            this.referenceLabel.AutoSize = true;
            this.referenceLabel.Location = new System.Drawing.Point(221, 131);
            this.referenceLabel.Name = "referenceLabel";
            this.referenceLabel.Size = new System.Drawing.Size(59, 15);
            this.referenceLabel.TabIndex = 11;
            this.referenceLabel.Text = "Reference";
            // 
            // forCheck
            // 
            this.forCheck.AutoSize = true;
            this.forCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.forCheck.Location = new System.Drawing.Point(7, 171);
            this.forCheck.Name = "forCheck";
            this.forCheck.Size = new System.Drawing.Size(81, 19);
            this.forCheck.TabIndex = 12;
            this.forCheck.Text = "For Tenant";
            this.forTip.SetToolTip(this.forCheck, "Check if the payer in From is not the Tenant\r\nin Appfolio.");
            this.forCheck.UseVisualStyleBackColor = true;
            this.forCheck.CheckedChanged += new System.EventHandler(this.forCheck_CheckedChanged);
            // 
            // forBox
            // 
            this.forBox.Location = new System.Drawing.Point(94, 169);
            this.forBox.Name = "forBox";
            this.forBox.Size = new System.Drawing.Size(231, 23);
            this.forBox.TabIndex = 13;
            this.forBox.Visible = false;
            // 
            // AddReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.forBox);
            this.Controls.Add(this.forCheck);
            this.Controls.Add(this.referenceLabel);
            this.Controls.Add(this.referenceBox);
            this.Controls.Add(this.moneyLabel);
            this.Controls.Add(this.moneyBox);
            this.Controls.Add(this.remarksLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.paymentTypeBox);
            this.Controls.Add(this.remarksBox);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.fromBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "AddReceipt";
            this.Text = "Add Receipt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private TextBox fromBox;
        private TextBox addressBox;
        private TextBox remarksBox;
        private ComboBox paymentTypeBox;
        private Label fromLabel;
        private Label addressLabel;
        private Label remarksLabel;
        private TextBox moneyBox;
        private Label moneyLabel;
        private TextBox referenceBox;
        private Label referenceLabel;
        private CheckBox forCheck;
        private TextBox forBox;
        private ToolTip forTip;
    }
}