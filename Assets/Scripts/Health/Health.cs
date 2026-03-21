using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth = 3;

    protected int currentHealth;

    private void Start()
    {
        Initialize();
    }

    // TODO: This needs to be called when GameManager starts the game
    public void Initialize()
    {
        currentHealth = maxHealth;
        LogStatus();
    }

    public void UpdateHealth(int amount)
    {
        currentHealth += amount;
        LogStatus();

        if (currentHealth == 0)
        {
            GameManager.Instance.SetGameEndedState(false);
        }
    }

    private void LogStatus()
    {
        Debug.Log($"{this.gameObject.name}'s health = {currentHealth}/{maxHealth}");
    }
}