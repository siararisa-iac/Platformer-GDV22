using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<ICollectable>(out var collectable))
        {
            collectable.Collect(this.gameObject);
        }
    }
}
