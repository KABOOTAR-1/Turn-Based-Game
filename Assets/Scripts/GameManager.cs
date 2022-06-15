using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    IDLE,
    PLAYER,
    ENEMY,
    STOP
}
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform Player;
    [SerializeField]
    GameObject PlayerPrefab;
    void Start()
    {
        Instantiate(PlayerPrefab,Vector3.zero,Quaternion.identity);     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
