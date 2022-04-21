using UnityEngine;
using System;

namespace Hackman_GD07
{
    [Serializable]
    public struct IntVector2 //struct is value types
    {
        public int x;
        public int y;

        //Auto-properties
        //Nobody else can change that
        public static IntVector2 zero => new IntVector2(0, 0); // => LINQ
        public static IntVector2 up => new IntVector2(0, 1);
        public static IntVector2 down => new IntVector2(0, -1);
        public static IntVector2 left => new IntVector2(-1, 0);
        public static IntVector2 right => new IntVector2(1, 0);


        public IntVector2(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }
        public static IntVector2 operator + (IntVector2 v1, IntVector2 v2)
        {
            return new IntVector2(v1.x + v2.x, v1.y + v2.y);
        }
        public static IntVector2 operator -(IntVector2 v)
        {
            return new IntVector2(-v.x,-v.y);
        }
        public static bool operator == (IntVector2 v1, IntVector2 v2)
        {
            return(v1.x ==v2.x && v1.y ==v2.y);
        }
        public static bool operator != (IntVector2 v1, IntVector2 v2)
        {
            return (v1.x != v2.x || v1.y != v2.y);
        }
        public bool Equals (IntVector2 other)
        {
            return x == other.x && y == other.y;
        }
    }
}