using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;

public class LevelGeneratorSystem : MonoBehaviour
{
    //0=pill,1=wall,2=player,3=ghost
    public BaseGridObject[] BaseGridObjectPrefabs;

    public static int[,] Grid = new int[,] 
    {
        {1,1,1,1,1,1,1,1,1,1 }, //y=0
        {1,0,1,0,0,0,1,3,0,1 }, //y=-1
        {1,0,2,0,1,0,0,0,1,1 }, //y=-2
        {1,0,1,0,0,0,0,0,0,1 },
        {1,0,1,0,1,0,1,1,0,1 },
        {1,0,0,0,0,0,0,3,0,1 },
        {1,1,1,1,1,1,1,1,1,1 }
    };

    //Instantiate/Generate our level

    private void Awake()
    {
        var gridSizeY = Grid.GetLength(0); //��
        var gridSizeX = Grid.GetLength(1); //��
        for (int y = 0; y < gridSizeY; y++)
        {
            for (int x = 0; x < gridSizeX; x++)
            {
                //This seems counter-intuitive
                //Normally with "math," x comes first, then y...
                var objectType = Grid[y, x]; //�ӵ�һ�п�ʼ������y
                var gridObjectPrefab = BaseGridObjectPrefabs[objectType];
                var gridObjectClone = Instantiate(gridObjectPrefab);
                gridObjectClone.GridPosition = new IntVector2(x, -y); //���y��Ϊ��������ͻ�ߵ�
                gridObjectClone.transform.position = new Vector3(gridObjectClone.GridPosition.x, gridObjectClone.GridPosition.y);

            }
        }
    }


}
