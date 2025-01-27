using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionShot;
    public float timeBetweenShoot = .3f;
    private Coroutine _currentCoroutine;
    public Transform playerSideReference;

    public KeyCode KeyCode= KeyCode.O;
    public AudioRandomPlayAudioClips randomShot; 


    private void Awake()
    {
        playerSideReference = GameObject.FindAnyObjectByType<Player>().transform;    
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
       
        }
        else if (Input.GetKeyUp(KeyCode.O))
        {
            if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);
        }
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot() ;
            yield return new WaitForSeconds(timeBetweenShoot);
        } 
    }


    public void Shoot()
    {
        if (randomShot != null) randomShot.PlayRandom();
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionShot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }

}
