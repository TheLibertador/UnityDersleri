using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else 
        {
            Destroy(this);
        }
    }

    void Start()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        AudioClip audioClip = (AudioClip) Resources.Load("music");
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
