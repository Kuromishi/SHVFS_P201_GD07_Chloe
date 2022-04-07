using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;

public class MovementComponent : BaseGridObject
{
    public float MovementSpeed;
    protected IntVector2 targetGridPosition;
    protected float progressToTarget = 1f;
    protected IntVector2 currentInputDirection;
    private IntVector2 previousInputDirection;

    private void Start()
    {
        targetGridPosition = GridPosition;
        //IntVector2.zero=new IntVector2(-99,99);
    }
    protected virtual void Update()
    {
        //what if we have some very important logic here, that we NEED to run
        //Create an extension method to help...
        //Debug.Log("overriding method...");
       
       if(transform.position == targetGridPosition.ToVector3()) //transform.position 移动过程中
        {
            progressToTarget = 0f; //Lerp
            GridPosition = targetGridPosition; //GridPosition为上一个点
        }
        //or  if(transform.position.ToIntVector2() == targetGridPosition)
        //or  if( ExtensionMethods.ToIntVector2(transform.position) )==  targetGridPosition) 

        //if we set a new target AND our current input is Valid
        //两种情况，面前没有墙，或者输入方向没有墙，如果有的话就按原来路径前进
        if (GridPosition == targetGridPosition && !(GridPosition + currentInputDirection).IsWall())
           // && LevelGeneratorSystem.Grid[Mathf.Abs(targetGridPosition.y + currentInputDirection.y),targetGridPosition.x+currentInputDirection.x]!=1)
        {
            targetGridPosition += currentInputDirection; //custom type, 对于自定义的type需要定义运算符
            previousInputDirection = currentInputDirection;
        }

       //if we set a new target and our current input is NOT VALID -> IS A WALL
       else if (GridPosition == targetGridPosition && !(GridPosition + previousInputDirection).IsWall())
          //  && LevelGeneratorSystem.Grid[Mathf.Abs(GridPosition.y + previousInputDirection.y), GridPosition.x + previousInputDirection.x] != 1)
        {
            targetGridPosition += previousInputDirection; //原来的路径
        }
        if (GridPosition == targetGridPosition) return;
        progressToTarget += MovementSpeed * Time.deltaTime;

        transform.position = Vector3.Lerp(GridPosition.ToVector3(), targetGridPosition.ToVector3(), progressToTarget);
    }

}
