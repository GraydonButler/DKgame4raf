using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxhealth;
    public int playerhealth;
    public playersoudscript PlayerSoundSystem;
    public healthgetter healthgetter;

    private bool _canPlayHurtSoud = false;

    // Start is called before the first frame update
    void Start()
    {
        playerhealth = maxhealth;
        healthgetter.ChangeHealth(playerhealth.ToString());
    }




    public void takedamage(int damage)
    {
        playerhealth -= damage;
        
        healthgetter.ChangeHealth(playerhealth.ToString());
        PlayerSoundSystem.PlayerRandomHurtSound();
        if (playerhealth <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        Debug.Log("playerdiedlolXD");


    }

   
}
