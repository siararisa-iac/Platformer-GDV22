using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth = 3;

    protected int currentHealth;

    private void Start()
    {
        GameManager.Instance.OnGameStarted += Initialize;
        Initialize();
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStarted -= Initialize;
    }

    private void Initialize()
    {
        currentHealth = maxHealth;
        OnHealthUpdated(currentHealth);
    }

    public void UpdateHealth(int amount)
    {
        currentHealth += amount;
        OnHealthUpdated(currentHealth);

        if (currentHealth == 0)
        {
            OnDeath();
        }
    }

    protected abstract void OnDeath();
    protected abstract void OnHealthUpdated(int currentHealth);
}