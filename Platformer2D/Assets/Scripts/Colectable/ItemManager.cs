using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public static ItemManager Instance;
    public int coins;
    //public TMP_Text coinsText;
    public TextMeshProUGUI uiTextCoin;
    

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
    }

    private void Start()
    {
        Reset();
        
    }

    private void Reset()
    {
        coins = 0;
        UpdateUI();
        
    }

    public void AddCoins(int amount = 1)
    {
        coins+= amount;
        //coinsText.text = coins.ToString();
        UpdateUI();
    }

    public void UpdateUI()
    {
       uiTextCoin.text = coins.ToString();
    }


}
