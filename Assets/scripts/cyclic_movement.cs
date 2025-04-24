using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class cyclic_movement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 10f;
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
