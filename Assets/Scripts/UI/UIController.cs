using System;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameOverView gameOverScreen;

    [SerializeField]
    private GameBalanceView gameStatsScreen;

    private void Start()
    {
        GameManager.Instance.OnGameEnded += HandleGameEnded;
        GameManager.Instance.OnGameStarted += HandleGameStarted;
        CurrencyManager.Instance.OnCurrencyBalanceUpdated += HandleCurrencyUpdated;

        gameOverScreen.RetryButton.onClick.AddListener(OnRetryButtonClicked);

        HandleGameStarted();
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnGameEnded -= HandleGameEnded;
            GameManager.Instance.OnGameStarted -= HandleGameStarted;
        }

        if (CurrencyManager.Instance != null)
        {
            CurrencyManager.Instance.OnCurrencyBalanceUpdated -= HandleCurrencyUpdated;
        }

        gameOverScreen.RetryButton.onClick.RemoveListener(OnRetryButtonClicked);
    }

    private void HandleGameStarted()
    {
        gameOverScreen.gameObject.SetActive(false);
    }

    private void HandleCurrencyUpdated(CurrencyType type, int newBalance)
    {
        gameStatsScreen.GetCurrencyUI(type)?.textValueView.SetValue(newBalance);
    }


    private void HandleGameEnded(bool isWin)
    {
        gameOverScreen.gameObject.SetActive(true);
        if (!isWin)
        {
            gameOverScreen.SetGameOverText("Game Over");
        }
        else
        {
            gameOverScreen.SetGameOverText("You Win!");
        }
    }

    private void OnRetryButtonClicked()
    {
        GameManager.Instance.StartGame();
    }
}
