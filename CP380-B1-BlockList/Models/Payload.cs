
namespace CP380_B1_BlockList.Models
{
    public enum TransactionTypes
    {
        BUY, SELL, GRANT
    }

    public class Payload
    {
        public string user { get; set; }
        public TransactionTypes transactiontype { get; set; }
        public int amount { get; set; }
        public string items { get; set; }


        public Payload(string username, TransactionTypes transactiontypee, int amount, string items)
        {
            this.user = username;
            this.transactiontype = transactiontypee;
            this.amount = amount;
            this.items = items;
        }
    }
}
