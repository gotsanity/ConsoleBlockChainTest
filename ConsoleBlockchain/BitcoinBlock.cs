using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlockchain
{
    public class BitcoinBlock
    {
        public byte[] MagicNumber { get; set; } // Identifies the block as a bitcoin block 4bytes
        public int BlockSize { get; set; } // tells how long the block is with all of the transactions
        public BitcoinHeader BlockHeader { get; set; } // the header of the transaction
        public int TransactionCounter { get; set; } // how many transactions the block has 
        public List<Transaction> Transactions { get; set; } // contains all of the transactions in the block
    }

    public class Transaction
    {
        // no real data on this, just putting here as placeholder
        public int Amount { get; set; }
    }

    public class BitcoinHeader
    {
        public string Version { get; set; } // the bitcoin protocol version
        public byte[] PrevBlockHash { get; set; } // the hash of the header of the previous block
        public byte[] MerkleRoot { get; set; } // hash of the root of the merkle tree
        public TimeOnly Time { get; set; }
        public int Target { get; set; }
        public int Nonce { get; set; }

        // Nonce/Target are how mining bitcoin works
        // The way mining works is that the miner will add a value into the nonce field and compute the hash using the
        // merkle root and the nonce value.
        // The miner than compares the resulting hash vs the target and if the computation is lower
        // than the target than they win the block reward.
        // If the miner misses the target than he repeats the process with
        // a new nonce value (and a resulting different hash) and compares again.
        // This makes lower target values extremely difficult to compute (resulting in longer computation times)
        // The bitcoin network automatically adjusts the target so that there is always a new block every 10 minutes


    }
}
