using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    public Button RetryButton => retryButton;

    [SerializeField]
    private TextMeshProUGUI gameOverText;

    [SerializeField]
    private Button retryButton;

    public void SetGameOverText(string text)
    {
        gameOverText.text = text;
    }
}
