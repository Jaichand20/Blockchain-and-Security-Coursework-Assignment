using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    internal class Blockchain
    {
        public List<Block> blocks = new List<Block>();
        public List<Transaction> transactionPool = new List<Transaction>();
        private int transactionsPerBlock = 5;
        public double currentDifficulty = 5.0;
        private int targetBlockTime = 5000;
        public string miningMode = "Altruistic";

        public Blockchain()
        {
            blocks.Add(new Block());
        }
        public string ReadBlock(int index)
        {
            if (index >= 0 && index < blocks.Count)
                return blocks[index].ReadBlock();
            else
                return "No such block exists";
        }

        public Block GetLastBlock()
        {
            return blocks[blocks.Count - 1];
        }
        public void AddBlock(String minerAddress)
        {
            List<Transaction> transactions = GetPendingTransactions();
            Block lastBlock = GetLastBlock();
            blocks.Add(new Block(lastBlock.hash, lastBlock.index, transactions, minerAddress, currentDifficulty, miningMode));
            AdjustDifficulty();
        }

        public string ReadAllBlocks()
        {
            string output = "";
            foreach (Block block in blocks)
                output += block.ReadBlock() + "\n\n";
            return output;
        }

        public List<Transaction> GetPendingTransactions()
        {
            if (miningMode.Equals("Greedy"))
                return GetGreedyTransactions();
            if (miningMode.Equals("Random"))
                return GetRandomTransactions();
            if (miningMode.Equals("Address"))
                return GetAddressTransactions();
            return GetAltruisticTransactions();
        }

        public static bool ValidateHash(Block block)
        {
            String rehash = block.CreateHash();
            return rehash.Equals(block.hash);
        }

        public double GetBalance(String address)
        {
            double balance = 0;
            foreach (Block block in blocks)
            {
                foreach (Transaction transaction in block.transactionList)
                {
                    if (transaction.recipientAddress.Equals(address))
                    {
                        balance += transaction.amount;
                    }

                    if (transaction.senderAddress.Equals(address))
                    {
                        balance -= (transaction.amount + transaction.fee);
                    }
                }
            }
            return balance;
        }

        public static bool ValidateMerkleRoot(Block block)
        {
            String reMerkle = Block.MerkleRoot(block.transactionList);
            return reMerkle.Equals(block.merkleRoot);
        }

        public static bool ValidateTransaction(Transaction transaction)
        {
            return Wallet.Wallet.ValidateSignature(
                transaction.senderAddress,
                transaction.hash,
                transaction.signature
            );
        }

        // Get the average block time of the last 5 blocks, or fewer if there are not enough blocks
        public double GetAverageBlockTime()
        {
            int blocksToCheck = Math.Min(5, blocks.Count - 1);
            if (blocksToCheck <= 0)
                return targetBlockTime;
            double totalBlockTime = 0;
            for (int i = blocks.Count - blocksToCheck; i < blocks.Count; i++)
            {
                totalBlockTime += (blocks[i].timestamp - blocks[i - 1].timestamp).TotalMilliseconds;
            }
            return totalBlockTime / blocksToCheck;
        }

        // Adjust the difficulty based on the average block time compared to the target block time
        public void AdjustDifficulty()
        {
            double averageBlockTime = GetAverageBlockTime();
            if (averageBlockTime < targetBlockTime)
            {
                currentDifficulty = currentDifficulty + 0.25;
            }
            else if (averageBlockTime > targetBlockTime && currentDifficulty > 1)
            {
                currentDifficulty = currentDifficulty - 0.25;
            }
        }

        public double GetAverageMiningTime()
        {
            int blocksToCheck = Math.Min(5, blocks.Count - 1);
            if (blocksToCheck <= 0)
                return targetBlockTime; // Default to target time if not enough blocks
            double totalMiningTime = 0;
            for (int i = blocks.Count - blocksToCheck; i < blocks.Count; i++)
            {
                totalMiningTime += blocks[i].miningTime;
            }
            return totalMiningTime / blocksToCheck;
        }

        // Altruistic mode takes the oldest transactions in the pool, up to the maximum number of transactions per block
        public List<Transaction> GetAltruisticTransactions()
        {
            int n = Math.Min(transactionsPerBlock, transactionPool.Count); // Get the oldest transactions based on timestamp
            List<Transaction> transactions = transactionPool
                .OrderBy(t => t.timestamp)
                .Take(n)
                .ToList();
            foreach (Transaction transaction in transactions) // Remove the selected transactions from the pool
            {
                transactionPool.Remove(transaction);
            }
            return transactions; // Return the selected transactions
        }

        // Greedy mode takes the transactions with the highest fees in the pool, up to the maximum number of transactions per block
        public List<Transaction> GetGreedyTransactions()
        {
            int n = Math.Min(transactionsPerBlock, transactionPool.Count); // Get the transactions with the highest fees
            List<Transaction> transactions = transactionPool
                .OrderByDescending(t => t.fee)
                .Take(n)
                .ToList();
            foreach (Transaction transaction in transactions)
            {
                transactionPool.Remove(transaction);
            }
            return transactions;
        }

        // Random mode takes random transactions from the pool, up to the maximum number of transactions per block
        public List<Transaction> GetRandomTransactions()
        {
            Random random = new Random();
            int n = Math.Min(transactionsPerBlock, transactionPool.Count); // Take random transactions from the pool
            List<Transaction> transactions = transactionPool
                .OrderBy(t => random.Next())
                .Take(n)
                .ToList();
            foreach (Transaction transaction in transactions)
            {
                transactionPool.Remove(transaction);
            }
            return transactions;
        }

        // Address mode takes transactions from the pool that involve a specific address, up to the maximum number of transactions per block
        public List<Transaction> GetAddressTransactions()
        {
            int n = Math.Min(transactionsPerBlock, transactionPool.Count); // Get transactions from the pool that involve a specific address
            List<Transaction> transactions = transactionPool
                .OrderByDescending(t => t.senderAddress)
                .Take(n)
                .ToList();
            foreach (Transaction transaction in transactions)
            {
                transactionPool.Remove(transaction);
            }
            return transactions;
        }
    }
}
