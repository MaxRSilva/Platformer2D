using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    public Animator animator;
    public string trigerAttack = "Attack";
    public string trigerDeath = "Death";
    public HealthBase healthBase;
    public float timeToDestroy = 1f;
    public AudioSource audioSourceKill;



    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill += OnEnemyKill;
        PlayDeathAnimation();
        Destroy(gameObject, timeToDestroy);
        if (audioSourceKill !=null)audioSourceKill.Play();
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if(health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(trigerAttack);
    }

    private void PlayDeathAnimation()
    {
        animator.SetTrigger(trigerDeath);
    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }
}
