using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverEvent : MonoBehaviour
{
    public bool WinOrLose;
    public GameoverEvent(bool winOrLose)
    {
        WinOrLose = winOrLose;
    }

}
