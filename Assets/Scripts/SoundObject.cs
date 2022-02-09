using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObject : MonoBehaviour
{

    public AudioClip[] clips;

    private AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioClip c = clips[Random.Range(0, clips.Length)];
        source = GetComponent<AudioSource>();
        source.clip = c;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
