using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnit : CommandManager.ICommand
{
    private Tags.Currplayer thisPlayer;
    private Tags.Currplayer secondplayer;
    private int PrevHeath;
    private Tags.Currplayer PrevTransform;
    private BattleState PrevState;
    
    public MoveUnit(Tags.Currplayer currenplayer, Tags.Currplayer otherplayer)
    {
        thisPlayer = currenplayer;
        secondplayer = otherplayer;
        PrevState = Tags.state;
        
    }

    public void Execute()
    {
        if (Tags.attack == true)
        {
            PrevHeath = thisPlayer.health;
            thisPlayer.health -= 10;
            PrevTransform = thisPlayer;
            Tags.attack = false;

        }
        if(Tags.heal == true )
        {
            if (secondplayer.health < 100)
            {
                PrevHeath = secondplayer.health;
                secondplayer.health += 5;
                PrevTransform = secondplayer;
            }
            Tags.heal = false;
        }

        if (thisPlayer.health <= 0)
        {
            thisPlayer.health = 0;
            Tags.GameEnd = true;
        }
    }

    public void Undo()
    {
        PrevTransform.health = PrevHeath;
        Tags.state = PrevState;
    }
}
