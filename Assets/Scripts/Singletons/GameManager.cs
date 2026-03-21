using UnityEngine;
using UnityEngine.SceneManagement;

// This script handles the flow of the game
public class GameManager : Singleton<GameManager>
{
    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        ScoreManager.Instance.ResetScore();
        CurrencyManager.Instance.Initialize();
        // Once scene setups are prepared, you can load game scene here
        // SceneManager.LoadScene()
    }

    public void PauseGame()
    {
        
    }

    public void ResumeGame()
    {

    }

    public void SetGameEndedState(bool isWin)
    {

    }
}
