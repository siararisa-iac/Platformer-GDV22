using UnityEngine;

public class Currency 
{
    public CurrencyType CurrencyType;
    public int Balance;

    public Currency(CurrencyType currencyType, int balance)
    {
        CurrencyType = currencyType;
        Balance = balance;
    }
}
