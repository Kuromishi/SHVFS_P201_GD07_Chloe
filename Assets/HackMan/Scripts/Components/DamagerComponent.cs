using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DamageableComponent>() != null)
        {
            Evently.Instance.Publish(new DamageEvent(other.GetComponent<DamageableComponent>()));
        }
    }
}
