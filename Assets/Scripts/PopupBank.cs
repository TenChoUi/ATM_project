using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupBank : MonoBehaviour
{
    public GameObject depositPanel;
    public GameObject withdrawPanel;
    public GameObject buttonPanel;
    public GameObject errorPanel;
    public InputField input;
    public InputField output;
    
    [fleld: SerializeField] public string depositInput;
    [fleld: SerializeField] public string withdrawInput;

    public void DepositGruop()
    {
        buttonPanel.SetActive(false);
        depositPanel.SetActive(true);
    }

    public void WithdrawelGroup()
    {
        buttonPanel.SetActive(false);
        withdrawPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        depositPanel.SetActive(false);
        withdrawPanel.SetActive(false);
        buttonPanel.SetActive(true);
    }

    public void DepositAmount(int amount)
    {
        if (GameManager.Instance.userData.cash >= amount)
        {
            GameManager.Instance.userData.cash -= amount; // ATM 내부 값 변환
            GameManager.Instance.UpdateBalance(amount);
            GameManager.Instance.SaveUserData(); // ATM 값 저장
        }
        else
        {
            errorPanel.SetActive(true);
        }
    }
    
    public void WithdrawAmount(int amount)
    {
        if (GameManager.Instance.userData.balance >= amount)
        {
            GameManager.Instance.userData.balance -= amount; // 현금 값 변환
            GameManager.Instance.UpdateCash(amount);
            GameManager.Instance.SaveUserData(); // 현금 값 저장
        }
        else
        {
            errorPanel.SetActive(true);
        }
    }
    
    public void InputButton()
    {
        Debug.Log(input.text);
        int dep = int.Parse(input.text);
        DepositAmount(dep);
    }

    public void OutputButton()
    {
        Debug.Log(output.text);
        int wit = int.Parse(output.text);
        WithdrawAmount(wit);
    }
}
