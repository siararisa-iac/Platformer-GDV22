using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.TryGetComponent<Coin>(out var coin))
        {
            Debug.Log("We hit a coin");
            coin.AddCoins();
        }

        if (collider.gameObject.TryGetComponent<Life>(out var life))
        {
            Debug.Log("We hit a life");
            life.AddLife();
        }

        if (collider.gameObject.TryGetComponent<Gem>(out var gem))
        {
            Debug.Log("We hit a gem");
            gem.AddGems();
        }
    }
}
