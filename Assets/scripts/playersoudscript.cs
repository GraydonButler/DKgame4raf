using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersoudscript : MonoBehaviour
{

    [Header("Sound Sources")]
    public AudioClip jumpClip;

    public List<AudioClip> randomContainerHurt;
    public List<AudioClip> randomContainerLand;
    

    [Header("Sound Settings")]
    public float jumpVolume = 0.5f;
    public float hurtVolume= 0.5f;
    public float landVolume = 0.5f;
    private AudioSource _source;



    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.loop = false;
        _source.playOnAwake = false;



    }

    public void PlayerJumpSound()
    {
        _source.clip = jumpClip;
        _source.volume = jumpVolume;
        _source.Play();
    }

    public void PlayerRandomHurtSound()
    {
        int index = Random.Range(0, randomContainerHurt.Count);
        _source.clip =randomContainerHurt[index];
        _source.volume = hurtVolume; 
        _source.Play();
    }
    public void PlayerRandomLandSound()
    {
        int index = Random.Range(0, randomContainerHurt.Count);
        _source.clip = randomContainerLand[index];
        _source.volume = landVolume;
        _source.spatialBlend = 1.0f;
        _source.Play();
    }


}
