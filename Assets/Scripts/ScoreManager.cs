using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    // property, meaning, CurrentScore is a value that other classes
    // can "get" or "read" the value, but they cannot set its value since it is private;
    public int CurrentScore { get; private set; }

    public void AddScore(int points)
    {
        CurrentScore += points;
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }
}