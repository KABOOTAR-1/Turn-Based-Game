using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnit : CommandManager.ICommand
{
    private Transform thistransform;
    BattleState tomove;
    Vector3 prev;

    public MoveUnit() { }
    public MoveUnit(Transform perform)
    {


        this.thistransform = perform;
 



    }

    public void Execute()
    {
        Debug.Log("This is " + thistransform.name);
    }

    public void Undo()
    {

        thistransform.Translate(-(this.thistransform.position - prev));


    }



}
