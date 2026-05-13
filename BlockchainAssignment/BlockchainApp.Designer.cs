namespace BlockchainAssignment
{
    partial class BlockchainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.GenerateWallet = new System.Windows.Forms.Button();
            this.ValidateKeys = new System.Windows.Forms.Button();
            this.publicKey = new System.Windows.Forms.TextBox();
            this.privateKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateTransaction = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.TextBox();
            this.fee = new System.Windows.Forms.TextBox();
            this.receiver = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GenerateBlock = new System.Windows.Forms.Button();
            this.ReadAll = new System.Windows.Forms.Button();
            this.ReadPendingTransactions = new System.Windows.Forms.Button();
            this.Validate = new System.Windows.Forms.Button();
            this.CheckBalance = new System.Windows.Forms.Button();
            this.multiThreadMining = new System.Windows.Forms.CheckBox();
            this.miningMode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.blockchainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.blockchainBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(657, 314);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Print Block";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 334);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(24, 20);
            this.textBox1.TabIndex = 2;
            // 
            // GenerateWallet
            // 
            this.GenerateWallet.Location = new System.Drawing.Point(594, 332);
            this.GenerateWallet.Name = "GenerateWallet";
            this.GenerateWallet.Size = new System.Drawing.Size(75, 41);
            this.GenerateWallet.TabIndex = 3;
            this.GenerateWallet.Text = "Generate Wallet";
            this.GenerateWallet.UseVisualStyleBackColor = true;
            this.GenerateWallet.Click += new System.EventHandler(this.GenerateWallet_Click);
            // 
            // ValidateKeys
            // 
            this.ValidateKeys.Location = new System.Drawing.Point(571, 383);
            this.ValidateKeys.Name = "ValidateKeys";
            this.ValidateKeys.Size = new System.Drawing.Size(98, 23);
            this.ValidateKeys.TabIndex = 4;
            this.ValidateKeys.Text = "Validate Keys";
            this.ValidateKeys.UseVisualStyleBackColor = true;
            this.ValidateKeys.Click += new System.EventHandler(this.ValidateKeys_Click);
            // 
            // publicKey
            // 
            this.publicKey.Location = new System.Drawing.Point(314, 335);
            this.publicKey.Name = "publicKey";
            this.publicKey.Size = new System.Drawing.Size(274, 20);
            this.publicKey.TabIndex = 5;
            // 
            // privateKey
            // 
            this.privateKey.Location = new System.Drawing.Point(314, 361);
            this.privateKey.Name = "privateKey";
            this.privateKey.Size = new System.Drawing.Size(274, 20);
            this.privateKey.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Public Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Private Key";
            // 
            // CreateTransaction
            // 
            this.CreateTransaction.Location = new System.Drawing.Point(12, 420);
            this.CreateTransaction.Name = "CreateTransaction";
            this.CreateTransaction.Size = new System.Drawing.Size(75, 49);
            this.CreateTransaction.TabIndex = 9;
            this.CreateTransaction.Text = "Create Transaction";
            this.CreateTransaction.UseVisualStyleBackColor = true;
            this.CreateTransaction.Click += new System.EventHandler(this.CreateTransaction_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Fee";
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(155, 426);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(71, 20);
            this.amount.TabIndex = 12;
            // 
            // fee
            // 
            this.fee.Location = new System.Drawing.Point(155, 453);
            this.fee.Name = "fee";
            this.fee.Size = new System.Drawing.Size(71, 20);
            this.fee.TabIndex = 13;
            // 
            // receiver
            // 
            this.receiver.Location = new System.Drawing.Point(314, 456);
            this.receiver.Name = "receiver";
            this.receiver.Size = new System.Drawing.Size(304, 20);
            this.receiver.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 459);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Receiver Key";
            // 
            // GenerateBlock
            // 
            this.GenerateBlock.Location = new System.Drawing.Point(12, 364);
            this.GenerateBlock.Name = "GenerateBlock";
            this.GenerateBlock.Size = new System.Drawing.Size(75, 46);
            this.GenerateBlock.TabIndex = 16;
            this.GenerateBlock.Text = "Generate New Block";
            this.GenerateBlock.UseVisualStyleBackColor = true;
            this.GenerateBlock.Click += new System.EventHandler(this.GenerateBlock_Click);
            // 
            // ReadAll
            // 
            this.ReadAll.Location = new System.Drawing.Point(139, 334);
            this.ReadAll.Name = "ReadAll";
            this.ReadAll.Size = new System.Drawing.Size(62, 21);
            this.ReadAll.TabIndex = 17;
            this.ReadAll.Text = "Read All";
            this.ReadAll.UseVisualStyleBackColor = true;
            this.ReadAll.Click += new System.EventHandler(this.ReadAll_Click);
            // 
            // ReadPendingTransactions
            // 
            this.ReadPendingTransactions.Location = new System.Drawing.Point(109, 368);
            this.ReadPendingTransactions.Name = "ReadPendingTransactions";
            this.ReadPendingTransactions.Size = new System.Drawing.Size(100, 38);
            this.ReadPendingTransactions.TabIndex = 18;
            this.ReadPendingTransactions.Text = "Read Pending Transactions";
            this.ReadPendingTransactions.UseVisualStyleBackColor = true;
            this.ReadPendingTransactions.Click += new System.EventHandler(this.ReadPendingTransactions_Click);
            // 
            // Validate
            // 
            this.Validate.Location = new System.Drawing.Point(571, 412);
            this.Validate.Name = "Validate";
            this.Validate.Size = new System.Drawing.Size(98, 34);
            this.Validate.TabIndex = 19;
            this.Validate.Text = "Full Blockchain Validation";
            this.Validate.UseVisualStyleBackColor = true;
            this.Validate.Click += new System.EventHandler(this.Validate_Click);
            // 
            // CheckBalance
            // 
            this.CheckBalance.Location = new System.Drawing.Point(456, 383);
            this.CheckBalance.Name = "CheckBalance";
            this.CheckBalance.Size = new System.Drawing.Size(109, 23);
            this.CheckBalance.TabIndex = 20;
            this.CheckBalance.Text = "Check Balance";
            this.CheckBalance.UseVisualStyleBackColor = true;
            this.CheckBalance.Click += new System.EventHandler(this.CheckBalance_Click);
            // 
            // multiThreadMining
            // 
            this.multiThreadMining.AutoSize = true;
            this.multiThreadMining.Checked = true;
            this.multiThreadMining.CheckState = System.Windows.Forms.CheckState.Checked;
            this.multiThreadMining.Location = new System.Drawing.Point(240, 393);
            this.multiThreadMining.Name = "multiThreadMining";
            this.multiThreadMining.Size = new System.Drawing.Size(116, 17);
            this.multiThreadMining.TabIndex = 21;
            this.multiThreadMining.Text = "MultiThread Mining";
            this.multiThreadMining.UseVisualStyleBackColor = true;
            this.multiThreadMining.CheckedChanged += new System.EventHandler(this.multiThreadMining_CheckedChanged);
            // 
            // miningMode
            // 
            this.miningMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.miningMode.FormattingEnabled = true;
            this.miningMode.Items.AddRange(new object[] {
            "Altruistic",
            "Greedy",
            "Random",
            "Address"});
            this.miningMode.Location = new System.Drawing.Point(444, 420);
            this.miningMode.Name = "miningMode";
            this.miningMode.Size = new System.Drawing.Size(121, 21);
            this.miningMode.TabIndex = 22;
            this.miningMode.SelectedIndexChanged += new System.EventHandler(this.miningMode_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(361, 423);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Mining Method";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // blockchainBindingSource
            // 
            this.blockchainBindingSource.DataSource = typeof(BlockchainAssignment.Blockchain);
            // 
            // BlockchainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(681, 481);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.miningMode);
            this.Controls.Add(this.multiThreadMining);
            this.Controls.Add(this.CheckBalance);
            this.Controls.Add(this.Validate);
            this.Controls.Add(this.ReadPendingTransactions);
            this.Controls.Add(this.ReadAll);
            this.Controls.Add(this.GenerateBlock);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.receiver);
            this.Controls.Add(this.fee);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CreateTransaction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.privateKey);
            this.Controls.Add(this.publicKey);
            this.Controls.Add(this.ValidateKeys);
            this.Controls.Add(this.GenerateWallet);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "BlockchainApp";
            this.Text = "Blockchain App";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.blockchainBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button GenerateWallet;
        private System.Windows.Forms.Button ValidateKeys;
        private System.Windows.Forms.TextBox publicKey;
        private System.Windows.Forms.TextBox privateKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CreateTransaction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.TextBox fee;
        private System.Windows.Forms.TextBox receiver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button GenerateBlock;
        private System.Windows.Forms.Button ReadAll;
        private System.Windows.Forms.Button ReadPendingTransactions;
        private System.Windows.Forms.Button Validate;
        private System.Windows.Forms.Button CheckBalance;
        private System.Windows.Forms.CheckBox multiThreadMining;
        private System.Windows.Forms.ComboBox miningMode;
        private System.Windows.Forms.BindingSource blockchainBindingSource;
        private System.Windows.Forms.Label label6;
    }
}

