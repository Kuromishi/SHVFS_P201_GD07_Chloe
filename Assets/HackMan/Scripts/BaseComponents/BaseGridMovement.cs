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

    private void Start()
    {
        targetGridPosition = GridPosition;
    }
    protected virtual void Update()
    {
        //what if we have some very important logic here, that we NEED to run
        //Create an extension method to help...
        //Debug.Log("overriding method...");
       
       if(transform.position == targetGridPosition.ToVector3()) //transform.position �ƶ�������
        {
            progressToTarget = 0f; //Lerp
            GridPosition = targetGridPosition; //GridPositionΪ��һ����
        }
        //or  if(transform.position.ToIntVector2() == targetGridPosition)
        //or  if( ExtensionMethods.ToIntVector2(transform.position) )==  targetGridPosition) 

       //if we set a new target AND our current input is Valid
       //�����������ǰû��ǽ���������뷽��û��ǽ������еĻ��Ͱ�ԭ��·��ǰ��
       if(GridPosition == targetGridPosition 
            && LevelGeneratorSystem.Grid[Mathf.Abs(targetGridPosition.y + currentInputDirection.y),targetGridPosition.x+currentInputDirection.x]!=1)
        {
            targetGridPosition += currentInputDirection; //custom type, �����Զ����type��Ҫ���������
            previousInputDirection = currentInputDirection;
        }
       //if we set a new target and our current input is NOT VALID -> IS A WALL
       else if (GridPosition == targetGridPosition
            && LevelGeneratorSystem.Grid[Mathf.Abs(GridPosition.y + previousInputDirection.y), GridPosition.x + previousInputDirection.x] != 1)
        {
            targetGridPosition += previousInputDirection; //ԭ����·��
        }
        if (GridPosition == targetGridPosition) return;
        progressToTarget += MovementSpeed * Time.deltaTime;

        transform.position = Vector3.Lerp(transform.position, targetGridPosition.ToVector3(), progressToTarget);
    }

}
