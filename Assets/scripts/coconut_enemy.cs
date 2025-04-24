using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coconut_enemy : MonoBehaviour
{

    public bool destroyOnCollision = false;
    public int damageToPlayer = 10;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            DealDamageToPlayer(collision);
        }
    }

    private void DealDamageToPlayer(Collider2D player)
    {
        PlayerHealth playerHealth = 
            player.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.takedamage(damageToPlayer);
        }

        if (destroyOnCollision)
        {
            Destroy(this.gameObject);
        }
    }
}
