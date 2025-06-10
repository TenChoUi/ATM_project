using TMPro;
using UnityEngine;

public class Cash : MonoBehaviour
{
    public TextMeshProUGUI cashText;
    public int cash;

    void Start()
    {
        cashText.text = cash.ToString("N0");
    }
}
