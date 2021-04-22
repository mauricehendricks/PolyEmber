using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damage = 25f;
    private static PlayerHealth pHealth;
    public GameObject player;

    private void Start()
    {
        pHealth = player.GetComponent<PlayerHealth>();
    }

    public void setDamage(float damageToDeal)
    {
        damage = damageToDeal;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            pHealth.descreaseHealth(damage);
        }
    }
}
