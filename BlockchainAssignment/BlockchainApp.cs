using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockchainAssignment
{
    public partial class BlockchainApp : Form
    {
        Blockchain blockchain;
        public BlockchainApp()
        {
            InitializeComponent();
            blockchain = new Blockchain();
            miningMode.SelectedIndex = 0;
            blockchain.miningMode = miningMode.Text; 
            Block.useMultiThreadMining = multiThreadMining.Checked; 
            richTextBox1.Text = "New Blockchain Initialised!";

        }

        private void UpdateText(String text)
        {
            richTextBox1.Text = text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBox1.Text, out int index))
                UpdateText(blockchain.ReadBlock(index));
            else
                UpdateText("Invalid Block No.");
        }

        private void GenerateWallet_Click(object sender, EventArgs e)
        {
            Wallet.Wallet myNewWallet = new Wallet.Wallet(out String privKey);
            publicKey.Text = myNewWallet.publicID;
            privateKey.Text = privKey;
        }

        private void ValidateKeys_Click(object sender, EventArgs e)
        {
            if (Wallet.Wallet.ValidatePrivateKey(privateKey.Text, publicKey.Text))
                UpdateText("Keys are valid");
            else
                UpdateText("Keys are invalid");
        }

        private void CreateTransaction_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(receiver.Text))
            {
                UpdateText("Receiver key is required");
                return;
            }
            if (String.IsNullOrWhiteSpace(publicKey.Text) || String.IsNullOrWhiteSpace(privateKey.Text))
            {
                UpdateText("Sender wallet keys are required");
                return;
            }
            if (!Double.TryParse(amount.Text, out double transactionAmount))
            {
                UpdateText("Invalid amount");
                return;
            }
            if (!Double.TryParse(fee.Text, out double transactionFee))
            {
                UpdateText("Invalid fee");
                return;
            }
            if (blockchain.GetBalance(publicKey.Text) < transactionAmount + transactionFee)
            {
                UpdateText("Insufficient funds");
                return;
            }

            Transaction transaction = new Transaction(
                publicKey.Text,
                receiver.Text,
                transactionAmount,
                transactionFee,
                privateKey.Text
            );

            blockchain.transactionPool.Add(transaction);
            UpdateText(transaction.ToString());
        }

        private void GenerateBlock_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(publicKey.Text))
            {
                UpdateText("Miner public key is required");
                return;
            }
            blockchain.AddBlock(publicKey.Text);
            UpdateText("Selected Mining Mode: " + blockchain.miningMode +
                "\n\n" + blockchain.ReadBlock(blockchain.blocks.Count - 1) +
                "\nAverage Mining Time: " + blockchain.GetAverageMiningTime() +
                "\nAverage Block Time: " + blockchain.GetAverageBlockTime() +
                "\nNext Difficulty: " + blockchain.currentDifficulty);
        }

        private void ReadAll_Click(object sender, EventArgs e)
        {
            UpdateText(blockchain.ReadAllBlocks());
        }

        private void ReadPendingTransactions_Click(object sender, EventArgs e)
        {
            UpdateText("Selected Mining Mode: " + blockchain.miningMode +
                "\n\nPending Transactions:\n" +
                String.Join("\n", blockchain.transactionPool));
        }

        // Validates the blockchain by checking the hash and merkle root of each block, the link between blocks, and the validity of each transaction.
        private void Validate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < blockchain.blocks.Count; i++)
            {
                if (!Blockchain.ValidateHash(blockchain.blocks[i]))
                {
                    UpdateText("Blockchain is invalid");
                    return;
                }
                if (!Blockchain.ValidateMerkleRoot(blockchain.blocks[i]))
                {
                    UpdateText("Blockchain is invalid");
                    return;
                }
                if (i > 0 && blockchain.blocks[i].prevHash != blockchain.blocks[i - 1].hash)
                {
                    UpdateText("Blockchain is invalid");
                    return;
                }
                foreach (Transaction transaction in blockchain.blocks[i].transactionList)
                {
                    if (!Blockchain.ValidateTransaction(transaction))
                    {
                        UpdateText("Blockchain is invalid");
                        return;
                    }
                }
            }
            UpdateText("Blockchain is valid");
        }

        private void CheckBalance_Click(object sender, EventArgs e)
        {
            UpdateText(blockchain.GetBalance(publicKey.Text).ToString() + " Dravec Coin");
        }

        private void multiThreadMining_CheckedChanged(object sender, EventArgs e)
        {
            Block.useMultiThreadMining = multiThreadMining.Checked;
            if (multiThreadMining.Checked)
                UpdateText("Mining mode: Multi Thread");
            else
                UpdateText("Mining mode: Single Thread");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void miningMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            blockchain.miningMode = miningMode.Text;
            UpdateText("Mining mode:" + blockchain.miningMode);
        }
    }
}
