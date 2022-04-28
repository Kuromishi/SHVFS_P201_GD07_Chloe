using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionSystem : Singleton<CollectionSystem>
{
    public void OnEnable()
    {
        Evently.Instance.Subscribe<CollectionEvent>(OnCollected);
    }
    public void OnDisable()
    {
        Evently.Instance.Unsubscribe<CollectionEvent>(OnCollected);
    }
    private void OnCollected(CollectionEvent evt)
    {
        Destroy(evt.Collectable.gameObject);

        if(FindObjectsOfType<CollectableComponent>().Length <= 1)
        {
            Evently.Instance.Publish(new GameoverEvent(true)); //You win
        }

    }

}
//HW
//When all the pills are collected, fire an event to let another system know that the game is over, and the player has won
//Create components, events, and a system for managing damage. The system should also fire an event to let another system know that the game is over, and the player has lost
//Create a system that logs a message to the console, and reloads the level, when the game is over
