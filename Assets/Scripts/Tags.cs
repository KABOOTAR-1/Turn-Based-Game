using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags 
{
    public static bool attack = false;
    public static bool heal = false;

    public class Currplayer
    {
        public Transform PlayerTransform;
        public int health = 100;
    }

    public static Currplayer Player=new Currplayer();
    public static Currplayer Enemy = new Currplayer();
}
