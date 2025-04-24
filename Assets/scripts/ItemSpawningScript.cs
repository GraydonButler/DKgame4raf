using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEditor;
using System;

public class ItemSpawningScript : MonoBehaviour
{

    public GameObject prefabbanana;
    public GameObject prefabcoconut;

    
    


    // Start is called before the first frame update
    void Start()
    {
        //System.Timers.Timer timer1 = new System.Timers.Timer();
        //timer1.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        //timer1.Interval = 1000;
        //timer1.Enabled = true;

        // prefabbanana = GetComponent<GameObject>();

        StartCoroutine(Spawnbananaprefab());
        
        StartCoroutine(Spawncoconutprefab());


        

    }

    private IEnumerator Spawnbananaprefab()
    {
        while (true)
        {
          yield return new WaitForSeconds(2.8f);
         GameObject Player = GameObject.FindWithTag("Player");
         float randomValue = UnityEngine.Random.Range(-20f, 20f);
         Vector2 randomPos = new Vector2(Player.transform.position.x + randomValue, Player.transform.position.y + 45f);
         Instantiate(prefabbanana, randomPos, Quaternion.identity);
        }
        
    }
    private IEnumerator Spawncoconutprefab()
    {
        while (true)
        {
          yield return new WaitForSeconds(4.6f);
         GameObject Player = GameObject.FindWithTag("Player");
         float randomValue = UnityEngine.Random.Range(-10f, 10f);
         Vector2 randomPos = new Vector2(Player.transform.position.x + randomValue, Player.transform.position.y + 50f);
         Instantiate(prefabcoconut, randomPos, Quaternion.identity);
        }
        
    }

   
}


    
