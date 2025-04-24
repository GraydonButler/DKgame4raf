using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createaudiosource : MonoBehaviour
{
    public AudioClip audioClip;


    // Start is called before the first frame update
    void Start()
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = audioClip;
        source.Play();
        Destroy(source, audioClip.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
