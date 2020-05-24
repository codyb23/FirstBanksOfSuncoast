using System;

public class Transaction
{
    public Guid Id { get; set; }
    public int AccountId { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }


}