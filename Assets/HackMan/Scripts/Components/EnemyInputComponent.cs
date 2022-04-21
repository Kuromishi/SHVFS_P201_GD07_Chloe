using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;
using System.Linq;

public class EnemyInputComponent : MovementComponent
{
    //This is basically the "controller" or gamepad for our ghost
    private IntVector2[] movementDirections = new IntVector2[]
    {
        IntVector2.up,
        IntVector2.down,
        IntVector2.left,
        IntVector2.right,
     };

    protected override void Update()
    {
   
        //Similar to HackMan, we check if we've arrived...
        if(transform.position == targetGridPosition.ToVector3())
        {
            //-----------Normal way--------------
            var possibleDirections = new List<IntVector2>();

            foreach ( var movementDirection in movementDirections)
            {
                var potentialTargetPosition = targetGridPosition + movementDirection;

                if (potentialTargetPosition.IsWall()) continue;
                  
                //��ֹ�������ƶ��������ƶ�����������ǰ����ķ���������Ķ�����List��
                if (movementDirection != -currentInputDirection) //not equal to the negative
                {
                    possibleDirections.Add(movementDirection);
                }
            }

            //-----------Using LINQ--------------
            //var possibleDirections = movementDirections.Where(movmentDirection => 
            //          !((targetGridPosition + movementDirection).IsWall()) 
            //          && movementDirection != -currentInputDirection)
            //    .ToList();


            //If we're at a dead end...
            if (possibleDirections.Count < 1)
            {
                possibleDirections.Add(-currentInputDirection); //����������ǣ���ֻ�ܵ�ͷ����
            }

            var direction = Random.Range(0, possibleDirections.Count);

            currentInputDirection = possibleDirections[direction];
        }

        base.Update();

    }

    //2 walls, keep going
    //3 walls, turn back
    //1, intersection, keep walking or different way
}