using UnityEngine;
using TMPro;

public class PopupBank : MonoBehaviour
{
    public GameObject depositPanel;
    public GameObject withdrawPanel;
    public GameObject buttonPanel;
    public GameObject errorPanel;
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
            GameManager.Instance.userData.cash -= amount;
            GameManager.Instance.UpdateBalance(amount);
        }
        else
        {
            errorPanel.SetActive(true);
        }
    }

    /*public void DepositInputAmount()
    {
        if (int.TryParse (depositInput.text, out int amount)) 
        {
            DepositAmount(amount);
        }
        else
        {
            depositInput.text = "";
        }

     }*/
    
    public void WithdrawAmount(int amount)
    {
        if (GameManager.Instance.userData.balance >= amount)
        {
            GameManager.Instance.userData.balance -= amount;
            GameManager.Instance.UpdateCash(amount);
        }
        else
        {
            errorPanel.SetActive(true);
        }
    }
    
    /*public void WithdrawInputAmount()
    {
        if (int.TryParse(withdrawInput.text, out int amount))
        {
            WithdrawAmount(amount);
        }
        else
        {
            withdrawInput.text = "";
        }
        
        withdrawInput.text = "";
    }*/
}
