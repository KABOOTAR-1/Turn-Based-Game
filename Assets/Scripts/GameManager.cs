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
    
    Transform Player;
    Transform Enemy;
    [SerializeField]
    GameObject PlayerPrefab;
    BattleState state=BattleState.IDLE;


    void Start()
    {
        Player=Instantiate(PlayerPrefab,Vector3.zero,Quaternion.identity).transform;Player.name = "Player";
        Enemy = Instantiate(PlayerPrefab, Player.position + new Vector3(2, 0, -1.5f), Quaternion.Euler(new Vector3(180, 0, 0))).transform;
        Enemy.name = "Enemy";
        StartCoroutine(PlayerMove());
    }

    
    void Update()
    {
        
    }

    
    IEnumerator PlayerMove()
    {
        if(state==BattleState.IDLE)
        state=BattleState.PLAYER;

        if(state==BattleState.PLAYER)
        {
            CommandManager.ICommand command = new MoveUnit(Player);
            command.Execute();
            yield return new WaitForSeconds(2f);
            state = BattleState.ENEMY;
        }
        else if (state == BattleState.ENEMY)
        {
            CommandManager.ICommand command = new MoveUnit(Enemy);
            command.Execute();
            yield return new WaitForSeconds(2f);
            state = BattleState.PLAYER;
        }
        StartCoroutine(PlayerMove());
    }
}
