using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnit : CommandManager.ICommand
{
    private Tags.Currplayer thisPlayer;
 
    public MoveUnit() { }
    public MoveUnit(Tags.Currplayer perform)
    {
       thisPlayer = perform;       
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
            thisPlayer.health += 5;
            Tags.heal = false;
        }
    }
}
