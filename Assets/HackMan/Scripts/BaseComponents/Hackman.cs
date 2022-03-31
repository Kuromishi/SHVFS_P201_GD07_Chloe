using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;

public class Hackman : BaseGridMovement
{
    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    protected override void Update()
    {
        //calling 'base' calls the virtual method, first
        //we want to get player input first,BEFORE moving!
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentInputDirection = IntVector2.down;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentInputDirection = IntVector2.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentInputDirection = IntVector2.right;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentInputDirection = IntVector2.up;
        }
        

        Debug.Log($"X:{currentInputDirection.x}|y:{currentInputDirection.y}");
        base.Update();
        //Debug.Log("overriding method...");
        //it will print "base methods.." then "overriding methods..."

    }

}
