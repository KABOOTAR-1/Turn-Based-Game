using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnit : CommandManager.ICommand
{
    private Tags.Currplayer thisPlayer;
    private Tags.Currplayer secondplayer;
 
    
    public MoveUnit(Tags.Currplayer currenplayer, Tags.Currplayer otherplayer)
    {
        thisPlayer = currenplayer;
        secondplayer = otherplayer;
    }

    public void Execute()
    {
        if (Tags.attack == true)
        {
            thisPlayer.health -= 10;
            Tags.attack = false;
        }
        if(Tags.heal == true)
        {
            secondplayer.health += 5;
            Tags.heal = false;
        }
    }
}
