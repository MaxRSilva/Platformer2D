using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public GameObject PlayerPrefab;

    [Header("Enemy")]
    public List<GameObject> enemies;

    [Header("References")]

    public Transform startPoint;

    private GameObject _currentPlayer;


    [Header("Animation")]
    public float duration = .2f;
    public float delay = 0.5f;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();

    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(PlayerPrefab);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From().SetDelay(delay);
     }
}
