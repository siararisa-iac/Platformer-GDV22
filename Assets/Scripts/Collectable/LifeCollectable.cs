using UnityEngine;

public class LifeCollectable : MonoBehaviour, ICollectable
{
    public void Collect(GameObject collector)
    {
        if (collector.TryGetComponent<Health>(out var health))
        {
            health.UpdateHealth(1);
        }
        
        Destroy(this.gameObject);
    }
}
