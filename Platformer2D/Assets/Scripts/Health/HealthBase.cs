using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;
    public float delayToKill = 0f;
    public bool destroyOnKill = false;

    private int _curretlife;
    private bool _isDead = false;



    private void Awake()
    {
        Init();   
    }

    private void Init()
    {
        _isDead = false;
        _curretlife = startLife;
    }

    public void Damage(int damage)
    {
        if(_isDead) return;
        _curretlife -= damage;
        
        if(_curretlife <= 0)
        {
            kill();
        }
        
    }
    
    private void kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
            
        } 
    }   
        
}
        
        
        
    
    

