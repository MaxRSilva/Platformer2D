using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;
using UnityEngine.UI;

public class ItemManager : Singleton<ItemManager>
{
    //public static ItemManager Instance;
    //public TMP_Text coinsText;
    public int coins;
    public TextMeshProUGUI uiTextCoins;
    

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
        //coinsText.text = coins.ToString();
        coins+= amount;
        UpdateUI();
    }

    public void UpdateUI()
    {
        //uiTextCoins.text = coins.ToString();
        UIInGameManager.UpdateTextCoins(coins.ToString());
    }


}
