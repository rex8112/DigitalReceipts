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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddReceipt));
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
            this.idLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.validationError = new System.Windows.Forms.ErrorProvider(this.components);
            this.clearButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.validationError)).BeginInit();
            this.statusStrip1.SuspendLayout();
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
            this.fromBox.TabIndex = 2;
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(94, 70);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(231, 23);
            this.addressBox.TabIndex = 4;
            // 
            // remarksBox
            // 
            this.remarksBox.Location = new System.Drawing.Point(94, 99);
            this.remarksBox.Name = "remarksBox";
            this.remarksBox.Size = new System.Drawing.Size(231, 23);
            this.remarksBox.TabIndex = 5;
            // 
            // paymentTypeBox
            // 
            this.paymentTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paymentTypeBox.FormattingEnabled = true;
            this.paymentTypeBox.Location = new System.Drawing.Point(94, 128);
            this.paymentTypeBox.Name = "paymentTypeBox";
            this.paymentTypeBox.Size = new System.Drawing.Size(121, 23);
            this.paymentTypeBox.TabIndex = 6;
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
            this.remarksLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.remarksLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.remarksLabel.Location = new System.Drawing.Point(36, 102);
            this.remarksLabel.Name = "remarksLabel";
            this.remarksLabel.Size = new System.Drawing.Size(52, 15);
            this.remarksLabel.TabIndex = 8;
            this.remarksLabel.Text = "Remarks";
            this.remarksLabel.Click += new System.EventHandler(this.remarksLabel_Click);
            // 
            // moneyBox
            // 
            this.moneyBox.Location = new System.Drawing.Point(345, 41);
            this.moneyBox.Name = "moneyBox";
            this.moneyBox.PlaceholderText = "Ex: 123.00";
            this.moneyBox.Size = new System.Drawing.Size(100, 23);
            this.moneyBox.TabIndex = 3;
            // 
            // moneyLabel
            // 
            this.moneyLabel.AllowDrop = true;
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.moneyLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.moneyLabel.Location = new System.Drawing.Point(331, 44);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(13, 15);
            this.moneyLabel.TabIndex = 2;
            this.moneyLabel.Text = "$";
            this.moneyLabel.Click += new System.EventHandler(this.moneyLabel_Click);
            // 
            // referenceBox
            // 
            this.referenceBox.Location = new System.Drawing.Point(286, 128);
            this.referenceBox.Name = "referenceBox";
            this.referenceBox.PlaceholderText = "Ex: 123";
            this.referenceBox.Size = new System.Drawing.Size(159, 23);
            this.referenceBox.TabIndex = 7;
            // 
            // referenceLabel
            // 
            this.referenceLabel.AutoSize = true;
            this.referenceLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.referenceLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.referenceLabel.Location = new System.Drawing.Point(221, 131);
            this.referenceLabel.Name = "referenceLabel";
            this.referenceLabel.Size = new System.Drawing.Size(59, 15);
            this.referenceLabel.TabIndex = 11;
            this.referenceLabel.Text = "Reference";
            this.forTip.SetToolTip(this.referenceLabel, "Click to copy the reference number with a prefix based on the payment type.");
            this.referenceLabel.Click += new System.EventHandler(this.referenceLabel_Click);
            // 
            // forCheck
            // 
            this.forCheck.AutoSize = true;
            this.forCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.forCheck.Location = new System.Drawing.Point(7, 171);
            this.forCheck.Name = "forCheck";
            this.forCheck.Size = new System.Drawing.Size(81, 19);
            this.forCheck.TabIndex = 8;
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
            this.forBox.TabIndex = 9;
            this.forBox.Visible = false;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.idLabel.Location = new System.Drawing.Point(367, 9);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(78, 21);
            this.idLabel.TabIndex = 14;
            this.idLabel.Text = "E-000001";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 207);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // validationError
            // 
            this.validationError.ContainerControl = this;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(93, 207);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 11;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 237);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(470, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(69, 17);
            this.statusLabel.Text = "Placeholder";
            // 
            // AddReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 259);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.idLabel);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(486, 281);
            this.Name = "AddReceipt";
            this.Text = "Add Receipt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddReceipt_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.validationError)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private Label idLabel;
        private Button saveButton;
        private ErrorProvider validationError;
        private Button clearButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
    }
}