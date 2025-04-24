using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterguy : MonoBehaviour
{

    public GameObject fireballPrefab;
    public float shootInterval;
    public float fireballSpeed = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);
            ShootProjectile();
        }
       
    }

    private void ShootProjectile()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        if (Player != null)
        {
            Vector3 direction = (Player.transform.position - transform.position).normalized;
            GameObject projectile = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

            projectile.GetComponent<Rigidbody2D>().velocity = direction * fireballSpeed;

            
        }
    }


}
