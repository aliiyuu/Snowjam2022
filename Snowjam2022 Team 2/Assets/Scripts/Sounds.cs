using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    [HideInInspector] public AudioSource source;
    public AudioClip clip;
    // public float volume;
    public bool loop;
    
}