using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlockchain
{
    public class Block
    {
        public int BlockID { get; set; }
        public DateTime Timestamp { get; set; }
        public byte[] BlockHash { get; set; }
        public byte[] PrevHash { get; set; }
        public Payload Data { get; set; }

        public Block(int blockID, byte[] prevHash, Payload data)
        {
            BlockID = blockID;
            Timestamp = DateTime.Now;
            PrevHash = prevHash;
            Data = data;

            this.BlockHash = this.GetHash();
        }

        public byte[] GetHash()
        {
            SHA256 sha256hash = SHA256.Create();

            string rawData = this.BlockID.ToString() +
                this.Timestamp.ToString() +
                Block.getHashString(this.PrevHash) +
                this.Data.ToString();

            byte[] bytes = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            return bytes;
        }

        public static string getHashString(byte[] hash)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("x2"));
            }

            return builder.ToString();
        }

        public override string? ToString()
        {
            return this.BlockID.ToString() + "\t" +
                this.Timestamp.ToString() + "\t" +
                Block.getHashString(this.BlockHash) + "\t" +
                Block.getHashString(this.PrevHash) + "\t" +
                this.Data.ToString();
        }
    }

    public class BlockChain
    {
        public List<Block> Chain { get; set; }

        public BlockChain()
        {
            this.Chain = new List<Block>();
        }

        public void AddBlock(Payload payload)
        {
            int blockID = this.Chain.Count;
            byte[] prevHash = this.Chain.Count != 0 ? this.Chain[this.Chain.Count - 1].BlockHash : new byte[0];

            Block block = new Block(blockID, prevHash, payload);

            this.Chain.Add(block);
        }

        public decimal FindBalance(string person)
        {

            return 0.0m;
        }
    }

    public class Payload
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Payee { get; set; }
        public string Payer { get; set; }
        public string Reason { get; set; }

        public Payload(DateTime transactionDate, decimal amount, string payee, string payer, string reason)
        {
            TransactionDate = transactionDate;
            Amount = amount;
            Payee = payee;
            Payer = payer;
            Reason = reason;
        }

        public override string? ToString()
        {
            return TransactionDate.ToString() + "\t" + Payee + "\t" + Payer + "\t" + Reason + "\t" + Amount;
        }
    }
}
