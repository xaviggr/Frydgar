using System;
using System.Collections;
using UnityEngine;

public class StatsSystem : MonoBehaviour
{
    //Events
    public event Action<float> TriggerHealthHasBeenUpdated = delegate { };
    public event Action TriggerHurt = delegate { };
    public event Action TriggerNohealth = delegate { };

    [Range(0.0f, 100f)]
    public float current_health = 100;

    //Other Stats
    public String Name;

    [Range(0.0f, 5f)]
    public float Strengh;

    [Range(0.0f, 5f)]
    public float Armor;

    [Range(0.0f, 5f)]
    public float FallingDamage;

    public bool Dead;

    public float delayhit = 1f;

    public bool inmortal = false;

    //Health Functs
    public void AddHealth(float addhealth)
    {
        current_health += addhealth;
        if (current_health > 100) current_health = 100;
        TriggerHealthHasBeenUpdated(current_health);
    }

    public void TakeDamage(float damage)
    {
        if (!inmortal)
        {
            StartCoroutine(DelayHit());
            current_health -= damage;
            SoundController.Instance.PlaySound("HitSound");

            if (current_health <= 0)
            {
                TriggerNohealth();
                current_health = 0;
                Dead = true;
            }

            TriggerHurt();
            TriggerHealthHasBeenUpdated(current_health);
        }
    }

    private IEnumerator DelayHit()
    {
        inmortal = true;
        yield return new WaitForSeconds(delayhit);
        inmortal = false;
    }
}
