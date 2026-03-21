using UnityEngine;

public class CoinCollectable : MonoBehaviour, ICollectable
{
    [SerializeField]
    private int amountToAdd = 50;

    public void Collect(GameObject collector)
    {
        CurrencyManager.Instance.AddCurrency(CurrencyType.Coin, amountToAdd);
        Destroy(this.gameObject);
    }
}
