// See https://aka.ms/new-console-template for more information

using ConsoleBlockchain;

Payload payload = new Payload(DateTime.Now, 100.00m, "jesse", "mike", "birthday");
Payload payload2 = new Payload(DateTime.Now, 100.00m, "sarah", "bob", "games");
Payload payload3 = new Payload(DateTime.Now, 50.00m, "tim", "bob", "games");
Payload payload4 = new Payload(DateTime.Now, 50.00m, "travis", "bob", "games");

BlockChain chain = new BlockChain(100.0m);

chain.AddBlock(payload);
chain.AddBlock(payload2);
chain.AddBlock(payload3);
chain.AddBlock(payload4);

for (int i = 0; i < chain.Chain.Count; i++)
{
    Console.WriteLine(chain.Chain[i].ToString());
}


Console.WriteLine("Mike deposits: " + chain.FindDeposits("mike")); // 100
Console.WriteLine("Bob deposits: " + chain.FindDeposits("bob")); // 200
Console.WriteLine("Jesse withdrew: " + chain.FindWithdrawls("jesse"));
Console.WriteLine("Jesse balance: " + chain.FindBalance("jesse"));






























/*
 * 
 * ledger
 * 
 * 99 btc pays alice 100
 * 1 bob pays alice 100
 * 2 alice pays sam 50 <alice signature>
 * 3 alice pays sam 50 <alice signature>
 * sam pay alice 100
 * 4 btc pays sam 1btc <sig>
 */


// cryptographic hash function

// math function accepts an input and spits out a "randomized" output

/*
 * f(x) = x + 1
 * f(1) = 2
 * f(3) = 4
 * 
 * SHA256("TEXT TO fILES") = <insert 2^256 bits has code here>
 * 
 * 2^256 = (2^32)(2^32)(2^32)(2^32)(2^32)(2^32)(2^32)(2^32) = (4billion)(4billion)(4billion)(4billion)(4billion)(4billion)(4billion)(4billion)
 * 
 * public key: 1234
 * private key: 5678
 * 
 * hash(5678) = 1234
 * 
 * 
 * message("hi mom", 1234) = 000000000000132136541321654321
 * 
 */

/*
 * Blockchain
 * 
 * current data + previous hash + index = new hash
 */