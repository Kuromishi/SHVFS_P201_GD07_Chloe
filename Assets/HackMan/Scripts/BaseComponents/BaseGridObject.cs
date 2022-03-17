using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseGridObject : MonoBehaviour
{
    // All of our objects will inherit from this...Our pills,walls,ghosts,and HackMan
    public IntVector2 GridPosition; 
    public Vector2Int GridPos;

    private void OnEnable()
    {
        //This essentially means -> var whatever = new Vector2Int(0,0);
        var whatever = Vector2Int.zero;

        var whateverAlso = new Vector2Int(0, 0); //the same with the above

        var whateverAgain = IntVector2.zero;
    }
}

[Serializable]
public struct IntVector2 //struct is value types
{
    public int x;
    public int y;

    public static IntVector2 zero => new IntVector2(0, 0);

    public IntVector2(int x,int y)
    {
        this.x = x;
        this.y = y;
    }
}