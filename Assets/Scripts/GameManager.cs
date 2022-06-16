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
    bool PlayerTurn;


    void Start()
    {
        Player=Instantiate(PlayerPrefab,Vector3.zero,Quaternion.identity).transform;Player.name = "Player";
        Enemy = Instantiate(PlayerPrefab, Player.position + new Vector3(2, 0, -1.5f), Quaternion.Euler(new Vector3(180, 0, 0))).transform;
        Enemy.name = "Enemy";
        StartCoroutine(PlayerMove());
    }

    public void SetPlayerTurn()
    {
        PlayerTurn = true;
    }

    public void DoUndo()
    {
        StartCoroutine(MoveBack());
    }
    
    IEnumerator PlayerMove()
    {
        if(state==BattleState.IDLE)
        state=BattleState.PLAYER;

        if(state==BattleState.PLAYER)
        {
            CommandManager.ICommand command = new MoveUnit(Player); 
            yield return new WaitUntil(() => PlayerTurn==true);
            CommandManager.Instance.AddCommand(command);
            PlayerTurn=false;
            state = BattleState.ENEMY;
        }
      
        else if (state == BattleState.ENEMY)
        {
            CommandManager.ICommand command = new MoveUnit(Enemy);
            yield return new WaitUntil(() => PlayerTurn == true);
            CommandManager.Instance.AddCommand(command);
            PlayerTurn = false;
            state = BattleState.PLAYER;
        }
        StartCoroutine(PlayerMove());
    }

    IEnumerator MoveBack()
    {       
        CommandManager.Instance.RemoveCommand();
        yield return new WaitForSeconds(3f);
    }
}
