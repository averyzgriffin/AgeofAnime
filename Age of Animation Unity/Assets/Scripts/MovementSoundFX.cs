﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSoundFX : MonoBehaviour {

    private AudioSource unitSounds;

    public AudioClip walkSound;
    public AudioClip meleeSound;
    public AudioClip rangeSound;
    public AudioClip deathSound;


    private void Start()
    {
        unitSounds = gameObject.GetComponent<AudioSource>();
    }


    public void PlayMeleeSound()
    {
        unitSounds.Stop();
        unitSounds.clip = meleeSound;
        unitSounds.Play();
    }

}
