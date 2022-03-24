using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;

public class BaseGridMovement : BaseGridObject
{
    public float MovementSpeed;
    protected IntVector2 targetGridPosition;
    protected float progressToTarget = 1f;
    protected IntVector2 currentInputDirection;
    private IntVector2 previousInputDirection;

    protected virtual void Update()
    {
        //what if we have some very important logic here, that we NEED to run
        //Create an extension method to help...
        //Debug.Log("overriding method...");
       if(transform.position == targetGridPosition.ToVector3())
        {
            progressToTarget = 0f;
            GridPosition = targetGridPosition;
        }
        //or  if(transform.position.ToIntVector2() == targetGridPosition)
        //or  if( ExtensionMethods.ToIntVector2(transform.position) )==  targetGridPosition) 

       //if we set a new target AND our current input is Valid
       if(GridPosition == targetGridPosition 
            && LevelGeneratorSystem.Grid[Mathf.Abs(targetGridPosition.y + currentInputDirection.y),targetGridPosition.x+currentInputDirection.x]!=1)
        {
            targetGridPosition += currentInputDirection; //custom type, 对于自定义的type需要定义运算符
            previousInputDirection = currentInputDirection;
        }
       //if we set a new target and our current input is NOT VALID -> IS A WALL
       else if (GridPosition == targetGridPosition
            && LevelGeneratorSystem.Grid[Mathf.Abs(GridPosition.y + previousInputDirection.y), GridPosition.x + previousInputDirection.x] != 1)
        {
            targetGridPosition += previousInputDirection;
        }
        if (GridPosition == targetGridPosition) return;
        progressToTarget += MovementSpeed * Time.deltaTime;
    }

}
