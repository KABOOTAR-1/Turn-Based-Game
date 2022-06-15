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
    
    private Transform Player;
    Transform Enemy;
    [SerializeField]
    GameObject PlayerPrefab;


    void Start()
    {
        Player=Instantiate(PlayerPrefab,Vector3.zero,Quaternion.identity).transform;
        Enemy = Instantiate(PlayerPrefab, Player.position + new Vector3(2, 0, -1.5f), Quaternion.Euler(new Vector3(180, 0, 0))).transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
