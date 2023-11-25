using System;

namespace StoreMS
{
    public class TransactionData
    {
        public string ProductsList { get; set; }
        public string CustomerEmail { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal GiftCardDiscount { get; set; }
        public int LoyaltyDiscount { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime DateTime { get; set; }

        public TransactionData(string productsList, string customerEmail, decimal totalAmount, decimal giftCardDiscount, int loyaltyDiscount, decimal paidAmount, DateTime transactionDate)
        {
            ProductsList = productsList;
            CustomerEmail = customerEmail;
            TotalAmount = totalAmount;
            GiftCardDiscount = giftCardDiscount;
            LoyaltyDiscount = loyaltyDiscount;
            PaidAmount = paidAmount;
            this.DateTime = transactionDate;
        }
    }
}
