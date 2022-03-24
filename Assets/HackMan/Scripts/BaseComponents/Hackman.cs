using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;

public class Hackman : BaseGridMovement
{
     protected override void Update()
    {
        //calling 'base' calls the virtual method, first
        //we want to get player input first,BEFORE moving!
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentInputDirection = new IntVector2(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentInputDirection = new IntVector2(-1,0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentInputDirection = new IntVector2(1,0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentInputDirection = new IntVector2(0,1);
        }

        Debug.Log($"X:{currentInputDirection.x}|y:{currentInputDirection.y}");
        base.Update();
        //Debug.Log("overriding method...");
        //it will print "base methods.." then "overriding methods..."
    }
}
