// This script handles the flow of the game
public class GameManager : Singleton<GameManager>
{
    // A delegate acts like a variable for functions
    public delegate void GameEventDelegate();
    public GameEventDelegate OnGameStarted;

    // You can store any function as long as it follows the same signature (return type, parameters)
    public delegate void GameEventEndedDelegate(bool isWin);
    public GameEventEndedDelegate OnGameEnded;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        ScoreManager.Instance.ResetScore();
        CurrencyManager.Instance.Initialize();
        OnGameStarted?.Invoke();
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
        // You can call functions with this:
        OnGameEnded?.Invoke(isWin);


        // ?. is the same as:
        //if(OnGameEnded != null)
        //{
        //    OnGameEnded(isWin);
        //}
    }
}
