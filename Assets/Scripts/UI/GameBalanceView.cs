using System.Collections.Generic;
using UnityEngine;

public class GameBalanceView : MonoBehaviour
{
    [SerializeField]
    private List<CurrencyUI> currenciesUI;

    public CurrencyUI GetCurrencyUI(CurrencyType currencyType)
    {
        foreach(CurrencyUI currencyUI in currenciesUI)
        {
            if(currencyUI.currencyType == currencyType)
            {
                return currencyUI;
            }
        }
        return null;
    }
}
