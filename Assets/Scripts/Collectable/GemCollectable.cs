using UnityEngine;

public class GemCollectable : MonoBehaviour, ICollectable
{
    [SerializeField]
    private int amountToAdd = 1;

    public void Collect(GameObject collector)
    {
        CurrencyManager.Instance.AddCurrency(CurrencyType.Gem, amountToAdd);
        Destroy(this.gameObject);
    }
}
