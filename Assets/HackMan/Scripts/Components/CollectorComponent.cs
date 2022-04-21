using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hackman_GD07;

public class CollectorComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CollectableComponent>()!=null)
        {
            Evently.Instance.Publish(new CollectionEvent(other.GetComponent<CollectableComponent>()));
        }
    }
}
