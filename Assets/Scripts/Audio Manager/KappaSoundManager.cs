using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KappaSoundManager : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip meleeClip, deathClip;

    void Start()
    {
        sound = GameObject.Find("Kappa Audio").GetComponent<AudioSource>();
    }

    public void meleePlay()
    {
        sound.PlayOneShot(meleeClip);
    }

    public void deathPlay()
    {
        sound.PlayOneShot(deathClip);
    }
}
