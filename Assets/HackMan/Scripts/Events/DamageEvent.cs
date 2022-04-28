using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEvent : MonoBehaviour
{
    public DamageableComponent Damageable;
    public DamageEvent(DamageableComponent damageable)
    {
        Damageable = damageable;
    }
}
