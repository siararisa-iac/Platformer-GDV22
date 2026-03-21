using UnityEngine;
using UnityEngine.SceneManagement;

// This script handles the flow of the game
public class GameManager : Singleton<GameManager>
{ 
    public void StartGame()
    {
        ScoreManager.Instance.ResetScore();
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
