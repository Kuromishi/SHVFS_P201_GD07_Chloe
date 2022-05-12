using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;

public static class ExtensionMethods
{
    //Extension Methods allow us to EXTEND the functionality of our classes,without MODIFYING the class itself
    //This follows one of our principles, that classes should be CLOSED to modification, but OPEN to extension
    //不能修改，但是可以延申
    public static Vector3 ToVector3(this IntVector2 vector2)
    {
        return new Vector3(vector2.x, vector2.y);
    }
    public static IntVector2 ToIntVector2(this Vector3 vector3)
    {
        return new IntVector2((int)vector3.x, (int)vector3.y);
    }
    public static bool IsWall(this IntVector2 vector2)//Is that position a wall...
    {
        return LevelGeneratorSystem.CurrentLevel.Grid[Mathf.Abs(vector2.y),Mathf.Abs(vector2.x)] == 1;
    }
}
