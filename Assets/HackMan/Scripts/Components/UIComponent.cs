using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIComponent : MonoBehaviour
{
    public Text uiShow;

    private void OnEnable()
    {
        Evently.Instance.Subscribe<GameoverEvent>(ConditionUI);
    }

    private void OnDisable()
    {
        Evently.Instance.Unsubscribe<GameoverEvent>(ConditionUI);
    }

    private void ConditionUI(GameoverEvent evt)
    {
        uiShow.text = evt.WinOrLose ? "You Win!!" : "You Lose!!";
    }
}
