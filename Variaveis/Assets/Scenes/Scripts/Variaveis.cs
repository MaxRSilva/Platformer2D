using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variaveis : MonoBehaviour
{
    int lifePlayer = 100, attackEnemy = 10;
    int damagePlayer;
    int attackNumber;
    int nowLife = 40;

    void Start()
    {
        
    }

    void Update()
    {
        attackNumbers();
        Debug.Log("Número de ataques: " + attackNumber);  
    }

    int Sub(int lifePlayers, int nowLife)
    {
        damagePlayer = lifePlayer - nowLife;
        return damagePlayer;
    }

    void attackNumbers()
    {
        
        attackNumber = Sub(lifePlayer, nowLife) / attackEnemy;
    }
}

