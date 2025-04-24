using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

         public Transform[] waypoints;
    public float speed = 7f;
    private int currentwaypointindex = 0;



    private void Update()
    {
        if (waypoints.Length > 0)
        {
            Vector2 TargetPosition = waypoints[currentwaypointindex].position;
            transform.position = Vector2.MoveTowards(transform.position, TargetPosition, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, TargetPosition) < 0.1f)
            {
                currentwaypointindex = (currentwaypointindex + 1) % waypoints.Length;
            }

        }
    }
}
