using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class coconut_enemy : MonoBehaviour
{

    public bool destroyOnCollision = true;
    public int damageToPlayer = 10;
    private BoxCollider2D _cldr2d;
    
    public GameObject coconutprefab;

    private void Start()
    {
        
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            DealDamageToPlayer(collision);

            Destroy(this.gameObject);

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

      
    }
}
