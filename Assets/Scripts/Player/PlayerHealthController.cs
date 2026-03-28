using UnityEngine;

public class PlayerHealthController : Health
{
    [SerializeField]
    private TextValueView healthView;

    protected override void OnDeath()
    {
        GameManager.Instance.SetGameEndedState(false);
    }

    protected override void OnHealthUpdated(int currentHealth)
    {
        healthView.SetValue(currentHealth);
    }
}
