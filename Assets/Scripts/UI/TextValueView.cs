using TMPro;
using UnityEngine;

public class TextValueView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI balanceText;

    public void SetValue(int newValue)
    {
        balanceText.text = newValue.ToString("000");
    }
}
