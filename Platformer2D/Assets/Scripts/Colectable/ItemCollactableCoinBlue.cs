using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoinBlue : ItemCollactableBase  
{
   protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoinsBlue();
    
    }
}
