using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    private AudioSource _audioSource;

    private AudioClip _audioClip;
    // Update is called once per frame

    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioClip = (AudioClip) Resources.Load("fire");
    }

    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            
        }
    }

    void Shoot ()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        _audioSource.PlayOneShot(_audioClip);
    }
}
