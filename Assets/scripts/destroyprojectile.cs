using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyprojectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyObj());
    }

 
       
    private IEnumerator DestroyObj()
    {
       
            yield return new WaitForSeconds(5);
            Destroy(this.gameObject);
        
    }
}
