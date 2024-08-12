using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    public Animator player;
    
    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float forcejump = 2;
    public float speedRun;

    [Header("Animation Setup")]

    public float JumpScaleY = 1.5f;
    public float JumpScaleX = 0.7f;
    public float AnimationDuration = 3f;


    public float DownScaleX = -0.7f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string boolSpeed = "Speed";
    public string triggerDeath = "Death";
    public string boolJump = "Jump";
    public float playerSwipeDuration = 0f;
    
}
