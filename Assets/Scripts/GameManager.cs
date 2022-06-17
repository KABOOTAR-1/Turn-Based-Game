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
        Transform PlayerOne = Instantiate(PlayerPrefab, new Vector3(0,-0.74f,0.34f), Quaternion.Euler(0,90,0)).transform;
        Tags.Player.PlayerTransform = PlayerOne;
        Tags.Player.PlayerTransform.name = "Player";
        PlayerOne = Instantiate(PlayerPrefab, Tags.Player.PlayerTransform.position + new Vector3(1, 0, -1.5f), Quaternion.Euler(new Vector3(0, -90, 0))).transform;
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
    
    void Perform(Tags.Currplayer One,Tags.Currplayer two)
    {
        CommandManager.ICommand command = new MoveUnit(One, two);
        CommandManager.Instance.AddCommand(command);
        PlayerTurn = false;
    }
    IEnumerator PlayerMove()
    {
        if(Tags.state==BattleState.IDLE)
        Tags.state=BattleState.PLAYER;

        if (Tags.state == BattleState.STOP)
            yield return null;
 
        if(Tags.state==BattleState.PLAYER)
        {
            yield return new WaitUntil(() => PlayerTurn == true);
            Perform(Tags.Enemy, Tags.Player);
            Tags.state = BattleState.ENEMY;
        }
      
        else if (Tags.state == BattleState.ENEMY)
        {
            yield return new WaitUntil(() => PlayerTurn == true);
            Perform(Tags.Player, Tags.Enemy);
            Tags.state = BattleState.PLAYER;
        }

        if (Tags.GameEnd)
            Tags.state = BattleState.STOP;

       
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
        StartCoroutine(PlayerMove());   
    }

    public void Heal()
    {
        
        Tags.heal = true;
        SetPlayerTurn();
        StartCoroutine(PlayerMove());
    }

}
