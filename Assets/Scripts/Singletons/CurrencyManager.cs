using UnityEngine;
using System.Collections.Generic;
using System;

public class CurrencyManager : Singleton<CurrencyManager>
{
    // collection of all the balance in game
    private List<Currency> currencies;

    // Acts like a delegate event but doesnt need an instance. Can be used directly
    public Action<CurrencyType, int> OnCurrencyBalanceUpdated;

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
                OnCurrencyBalanceUpdated?.Invoke(currencyType, currency.Balance);
            }
        }
    }
}
