using UnityEngine;
using System.Collections.Generic;

public class CurrencyManager : Singleton<CurrencyManager>
{
    // collection of all the balance in game
    private List<Currency> currencies;

    public void Initialize()
    {
        currencies = new List<Currency>()
        {
            new (CurrencyType.Coin, 100),
            new (CurrencyType.Gem, 0)
        };
    }

    public void AddCurrency(CurrencyType currencyType, int addedAmount)
    {
        foreach (var currency in currencies)
        {
            if (currency.CurrencyType == currencyType)
            {
                currency.Balance += addedAmount;
                Debug.Log($"New {currency.CurrencyType} Balance = {currency.Balance}");
            }
        }
    }
}
