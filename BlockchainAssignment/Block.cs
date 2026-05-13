using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;
using System.Threading;

namespace BlockchainAssignment
{
    class Block
    {
        public DateTime timestamp;
        public int index;
        public string hash;
        public string prevHash;
        public List<Transaction> transactionList;
        public double difficulty = 5.0; // Number of leading zeros required in the hash for it to be valid, can be adjusted to increase mining difficulty.
        public long nonce;
        public string minerAddress;
        public double reward;
        public double fees;
        public string merkleRoot;
        public long miningTime; // Used to store the time taken to mine the block, for performance comparison between single and multi-threaded mining.
        public int threadsUsed; // Used to store the number of threads used for mining, for performance comparison between single and multi-threaded mining.
        private volatile bool hashFound;
        private readonly object miningLock = new object();
        public string miningMode; // Used to indicate the mining mode

        public static bool useMultiThreadMining = true; // Switch between single and multi-threaded mining. 

        // Constructor 
        public Block(string lastHash, int lastIndex, List<Transaction> transactions, string minerAddress, double difficulty, string miningMode)
        {
            timestamp = DateTime.Now;
            index = lastIndex + 1;
            prevHash = lastHash;
            this.minerAddress = minerAddress;
            this.reward = 20.0; 
            transactions.Add(createRewardTransaction(transactions)); 
            transactionList = new List<Transaction>(transactions);
            this.merkleRoot = MerkleRoot(transactionList);
            this.difficulty = difficulty; // Set the difficulty level for this block.
            this.miningMode = miningMode;
            if (useMultiThreadMining)
                hash = MineMultiThread();
            else
                hash = MineSingleThread();
        }

        // Creates a hash of the block's contents, including the nonce. If a nonce value is provided, it uses that instead of the block's current nonce. If a hasher is provided, it uses that for hashing; otherwise, it creates a new SHA256 hasher.
        public String CreateHash(long nonceValue = -1, SHA256 hasher = null)
        {
            if (nonceValue == -1)
                nonceValue = nonce;
            bool createdHasher = false;
            if (hasher == null)
            {
                hasher = SHA256Managed.Create();
                createdHasher = true;
            }
            String input = timestamp.ToString() + index + prevHash + nonceValue + reward + merkleRoot;
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            String hash = string.Empty;
            foreach (byte x in hashByte)
                hash += String.Format("{0:x2}", x);
            if (createdHasher)
                hasher.Dispose();
            return hash;
        }

        // Constructor for the genesis block.
        public Block() 
        {
            timestamp = DateTime.Now;
            index = 0;
            prevHash = string.Empty;
            transactionList = new List<Transaction>();
            reward = 0;
            fees = 0;
            minerAddress = "Genesis";
            miningMode = "Genesis";
            merkleRoot = MerkleRoot(transactionList);
            hash = Mine();
        }

        // Returns a string representation of the block, including all its transactions.
        public string ReadBlock()
        {
            string output = "Block Index: " + index + "          " + "Timestamp: " + timestamp + "\n" +
                            "Hash: " + hash + "\n" +
                            "Previous Hash: " + prevHash + "\n" +
                            "Difficulty Level: " + difficulty + "\n" +
                            "Nonce: " + nonce + "\n" +
                            "Reward: " + reward + "\n" + "          " + "Fees: " + fees + "\n" +
                            "Mining Mode: " + miningMode + "\n" +
                            "Threads Used: " + threadsUsed + "\n" +
                            "Mining Time (ms): " + miningTime + "\n" +
                            "Miners Address: " + minerAddress + "\n" +
                            "Merkle Root: " + merkleRoot;
            foreach (Transaction t in transactionList)
            {
                output += "\n" + t.ToString();
            }
            return output;
        }

        // Mines the block using a single thread and returns the valid hash found.
        public String Mine()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            nonce = 0;
            String hash = CreateHash();
            while (!ValidDifficulty(hash))
            {
                nonce++;
                hash = CreateHash();
            }
            stopwatch.Stop();
            miningTime = stopwatch.ElapsedMilliseconds;
            threadsUsed = 1;
            return hash;
        }
        public Transaction createRewardTransaction(List<Transaction> transactions)
        {
            fees = transactions.Aggregate(0.0, (acc, t) => acc + t.fee);
            return new Transaction("Mine Rewards", minerAddress, (reward + fees), 0, "");
        }

        // Static method to calculate the Merkle Root of a list of transactions.
        public static String MerkleRoot(List<Transaction> transactionList)
        {
            List<String> hashes = transactionList.Select(t => t.hash).ToList();
            if (hashes.Count == 0)
            {
                return String.Empty;
            }
            if (hashes.Count == 1)
            {
                return HashCode.HashTools.CombineHash(hashes[0], hashes[0]);
            }
            while (hashes.Count != 1)
            {
                List<String> merkleLeaves = new List<String>();
                for (int i = 0; i < hashes.Count; i += 2)
                {
                    if (i == hashes.Count - 1)
                    {
                        merkleLeaves.Add(HashCode.HashTools.CombineHash(hashes[i], hashes[i]));
                    }
                    else
                    {
                        merkleLeaves.Add(HashCode.HashTools.CombineHash(hashes[i], hashes[i + 1]));
                    }
                }
                hashes = merkleLeaves;
            }
            return hashes[0];
        }

        // Mines the block using a single thread and returns the valid hash found. 
        public String MineSingleThread()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            nonce = 0;
            threadsUsed = 1;
            SHA256 hasher = SHA256Managed.Create();
            String hash = CreateHash(nonce, hasher);
            while (!ValidDifficulty(hash))
            {
                nonce++;
                hash = CreateHash(nonce, hasher);
            }
            hasher.Dispose();
            stopwatch.Stop();
            miningTime = stopwatch.ElapsedMilliseconds;
            return hash;
        }

        // Mines the block using multiple threads and returns the valid hash found. Each thread tests different nonce values in parallel to find a valid hash faster.
        public String MineMultiThread()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            hashFound = false;
            String finalHash = String.Empty;
            long finalNonce = 0;
            int threadCount = Environment.ProcessorCount; // Use the number of available processor cores for mining threads.
            threadsUsed = threadCount; 
            Thread[] threads = new Thread[threadCount]; // Array to hold the mining threads.
            for (int i = 0; i < threadCount; i++) // Start a thread for each processor core to mine in parallel.
            {
                int threadNumber = i;
                threads[i] = new Thread(() =>
                {
                    long testNonce = threadNumber; 
                    SHA256 hasher = SHA256Managed.Create(); // Each thread creates its own hasher to avoid contention.
                    while (!hashFound) // Each thread continues to test nonce values until a valid hash is found by any thread.
                    {
                        String testHash = CreateHash(testNonce, hasher); // Generate a hash for the current nonce value being tested by this thread.
                        if (ValidDifficulty(testHash)) // If the generated hash meets the difficulty requirement, attempt to set it as the final hash if no other thread has found a valid hash yet.
                        {
                            lock (miningLock)
                            {
                                if (!hashFound)
                                {
                                    hashFound = true;
                                    finalNonce = testNonce;
                                    finalHash = testHash;
                                }
                            }
                        }
                        testNonce += threadCount;
                    }
                    hasher.Dispose(); // Dispose of the hasher after mining is complete to free resources.
                });
                threads[i].Start(); // Start the mining thread.
            }
            foreach (Thread thread in threads) 
            {
                thread.Join(); 
            }
            nonce = finalNonce; 
            stopwatch.Stop();
            miningTime = stopwatch.ElapsedMilliseconds;
            return finalHash; 
        }

        // Validates whether a given hash meets the difficulty requirement by checking for the required number of leading zeros and, if necessary, the value of the next hexadecimal character based on the fractional part of the difficulty.
        public bool ValidDifficulty(String hash)
        {
            int wholeZeros = (int)Math.Floor(difficulty); 
            double fraction = difficulty - wholeZeros; 
            String requiredZeros = new string('0', wholeZeros); 
            if (!hash.StartsWith(requiredZeros)) 
                return false;
            if (fraction == 0) 
                return true;
            if (hash.Length <= wholeZeros) 
                return false;
            int nextHexValue = Convert.ToInt32(hash.Substring(wholeZeros, 1), 16); // Get the next hexadecimal character after the required leading zeros and convert it to an integer value.
            int allowedValues = (int)Math.Ceiling(Math.Pow(16, 1 - fraction)); // Calculate the maximum allowed value for the next hexadecimal character based on the fractional part of the difficulty.
            return nextHexValue < allowedValues; // The hash is valid if the next hexadecimal character's value is less than the calculated allowed values.

        }

    }

    }
