using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionEvent : MonoBehaviour
{
    public CollectableComponent Collectable;
    public CollectionEvent(CollectableComponent collectable)
    {
        Collectable = collectable;
    }
}
