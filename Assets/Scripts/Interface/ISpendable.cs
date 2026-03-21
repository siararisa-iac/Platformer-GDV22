using UnityEngine;

public interface ISpendable
{
    bool CanPurchase(string productId);
    void TryPurchase(string productId);
}
