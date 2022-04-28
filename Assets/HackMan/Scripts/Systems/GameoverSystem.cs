using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameoverSystem : Singleton<GameoverSystem>
{
    public void OnEnable()
    {
        Evently.Instance.Subscribe<GameoverEvent>(OnGameOver);
    }
    public void OnDisable()
    {
        Evently.Instance.Unsubscribe<GameoverEvent>(OnGameOver);
    }
    private void OnGameOver(GameoverEvent evt)
    {
        Debug.Log(evt.WinOrLose? "You Win!":"You Lose!");
        SceneManager.LoadScene("Level");
    }
}
