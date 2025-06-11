using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [field: SerializeField] public UserData userData;
    public UserInfo userInfo;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
    }

    public void Start()
    {
        if (userInfo == null)
        {
            userInfo = GetComponent<UserInfo>();
        }
        
        LoadUserData();
    }

    public void UpdateName(string newName)
    {
        userData.userName = newName;
        userInfo.Refresh();
    }

    public void UpdateCash(int amount)
    {
        userData.cash += amount;
        userInfo.Refresh();
    }
    
    public void UpdateBalance(int amount)
    {
        userData.balance += amount;
        userInfo.Refresh();
    }

    public void SaveUserData()
    {
        PlayerPrefs.SetString("Name", userData.userName);
        PlayerPrefs.SetInt("Cash", userData.cash);
        PlayerPrefs.SetInt("Balance", userData.balance);
        PlayerPrefs.Save();
    }

    public void LoadUserData()
    {
        if (PlayerPrefs.HasKey("Name"))
        {
            string name = PlayerPrefs.GetString("Name");
            int cash = PlayerPrefs.GetInt("Cash");
            int balance = PlayerPrefs.GetInt("Balance");
            userData = new  UserData(name, cash, balance);
        }
        else
        {
            userData = new UserData("조경현", 300000, 500000);
            // 로드 할 userdata 값이 없을 시 부르는 기본 변수 값
        }
        userInfo.Refresh();
    }
}




