using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : Singleton<DamageSystem>
{
    public void OnEnable()
    {
        Evently.Instance.Subscribe<DamageEvent>(OnDamaged);
    }
    public void OnDisable()
    {
        Evently.Instance.Unsubscribe<DamageEvent>(OnDamaged);
    }
    private void OnDamaged(DamageEvent evt)
    {
        Destroy(evt.Damageable.gameObject);
        Evently.Instance.Publish(new GameoverEvent(false)); //You Lose
    }
}
