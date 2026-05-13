using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    class Transaction
    {
        public string hash;
        public string signature;
        public string senderAddress;
        public string recipientAddress;
        public DateTime timestamp;
        public double amount;
        public double fee;

        public Transaction(string from, string to, double amount, double fee, string privateKey)
        {
            this.senderAddress = from;
            this.recipientAddress = to;
            this.amount = amount;
            this.fee = fee;
            this.timestamp = DateTime.Now;
            this.hash = CreateHash();
            this.signature = Wallet.Wallet.CreateSignature(from, privateKey, hash);
        }

        public string CreateHash()
        {
            SHA256 hasher = SHA256Managed.Create();
            string input = timestamp.ToString() + senderAddress + recipientAddress + amount.ToString() + fee.ToString();
            byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            string hash = string.Empty;
            foreach (byte x in hashByte)
                hash += String.Format("{0:x2}", x);
            return hash;
        }
        public override string ToString()
        {
            return " [TRANSACTION START]"
                + "\n Timestamp: " + timestamp
                + "\n -- Verification --"
                + "\n Hash: " + hash
                + "\n Signature: " + signature
                + "\n -- Quantities --"
                + "\n Transferred: " + amount + " Dravec Coin"
                + "\t Fee: " + fee
                + "\n -- Participants --"
                + "\n Sender: " + senderAddress
                + "\n Reciever: " + recipientAddress
                + "\n [TRANSACTION END]";
        }

    }
}
