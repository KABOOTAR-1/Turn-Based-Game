using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{

    public TextMeshProUGUI Phealth;
    public TextMeshProUGUI Ehealth;
    public TextMeshProUGUI currenturn;

    private void Update()
    {
        Phealth.SetText(Tags.Player.health.ToString());
        Ehealth.SetText(Tags.Enemy.health.ToString());

        if (Tags.state == BattleState.PLAYER)
        {
            currenturn.SetText("PLAYER 1 TURN");
        }
        else if (Tags.state == BattleState.STOP)
        {
            currenturn.SetText("Game End");
        }
        else
        {
            currenturn.SetText("PLAYER 2 TURN");
        }

    }

}
