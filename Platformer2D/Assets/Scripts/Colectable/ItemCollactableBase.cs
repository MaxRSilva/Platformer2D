using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    public float timeToHide = 1f;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
            
        }

        
    }


    protected virtual void Collect()
    {
       if(graphicItem!=null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
        OnCollect();
    }

    protected virtual void OnCollect()
    {
        if(particleSystem != null) particleSystem.Play();
        if (audioSource != null) audioSource.Play();

    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

}

/*public class ItemCollactableCoin : ItemCollactableBase

{
    protected override void collected()
    {
        base.collected();
    }
}*/