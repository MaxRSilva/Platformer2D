using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColors : MonoBehaviour
{
   public List<SpriteRenderer> renderers;
   public Color color = Color.red;
   public float duration = 0.5f;
    private Tween _currentTween;

    private void OnValidate()
    {
        renderers = new List<SpriteRenderer> ();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>()) 
        {
            renderers.Add(child);
        } 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
          Flash();
         
        }
         
    }

    public void Flash()
    {
        if (_currentTween != null)
        {
            _currentTween.Kill();
            renderers.ForEach(i => i.color = Color.white);

        }

        foreach (var s in renderers)
        {
            _currentTween = s.DOColor(color, duration).SetLoops(2, LoopType.Yoyo);
        }
    }



}
