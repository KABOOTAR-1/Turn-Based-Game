using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{ 
   
    [SerializeField]
    GameObject PlayerPrefab;
    bool PlayerTurn;

    

    void Start()
    {
        Transform PlayerOne = Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity).transform;
        Tags.Player.PlayerTransform = PlayerOne;
        Tags.Player.PlayerTransform.name = "Player";
        PlayerOne = Instantiate(PlayerPrefab, Tags.Player.PlayerTransform.position + new Vector3(2, 0, -1.5f), Quaternion.Euler(new Vector3(180, 0, 0))).transform;
        Tags.Enemy.PlayerTransform = PlayerOne;
        Tags.Enemy.PlayerTransform.name = "Enemy";
        StartCoroutine(PlayerMove());
    }

    void SetPlayerTurn()
    {
        PlayerTurn = true;
    }

    public void DoUndo()
    {
        StartCoroutine(MoveBack());
    }
    
    IEnumerator PlayerMove()
    {
        if(Tags.state==BattleState.IDLE)
        Tags.state=BattleState.PLAYER;

        if(Tags.state==BattleState.PLAYER)
        {
            CommandManager.ICommand command = new MoveUnit(Tags.Enemy,Tags.Player);
            yield return new WaitUntil(() => PlayerTurn==true);           
            CommandManager.Instance.AddCommand(command);
            PlayerTurn=false;
            Tags.state = BattleState.ENEMY;
        }
      
        else if (Tags.state == BattleState.ENEMY)
        {
            CommandManager.ICommand command = new MoveUnit(Tags.Player,Tags.Enemy);
            yield return new WaitUntil(() => PlayerTurn == true);
            CommandManager.Instance.AddCommand(command);
            PlayerTurn = false;
            Tags.state = BattleState.PLAYER;
        }
        StartCoroutine(PlayerMove());
    }

    IEnumerator MoveBack()
    {       
        CommandManager.Instance.RemoveCommand();
        yield return new WaitForSeconds(3f);
    }

    public void Attack()
    {
        Tags.attack = true;
        SetPlayerTurn();
    }

    public void Heal()
    {
        Tags.heal = true;
        SetPlayerTurn();
    }

}
