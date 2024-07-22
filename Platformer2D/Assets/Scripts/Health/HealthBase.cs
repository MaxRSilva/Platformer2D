using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public Action OnKill;
    public int startLife = 10;
    public float delayToKill = 0f;
    public bool destroyOnKill = false;
    [SerializeField] private FlashColors _flashColor;

    private int _curretlife;
    private bool _isDead = false;



    private void Awake()
    {
        Init(); 
        if (_flashColor == null)
        {
            _flashColor = GetComponent<FlashColors>();
        }
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
        if (_flashColor != null)
        {
            _flashColor.Flash();
        }
    }
    
    private void kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);

            
        }

        OnKill?.Invoke();
    
    }   
        
}
        
        
        
    
    

