using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnshimonSoundManager : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip meleeClip, dashClip, skill1Clip, skill2Clip, skill3Clip, skill4Clip, hitClip, selfHitClip;

    public void meleePlay()
    {
        sound.PlayOneShot(meleeClip);
    }

    public void hitPlay()
    {
        sound.PlayOneShot(hitClip);
    }

    public void selfhitPlay()
    {
        sound.PlayOneShot(selfHitClip);
    }

    public void dashPlay()
    {
        sound.PlayOneShot(dashClip);
    }

    public void skill1Play()
    {
        sound.PlayOneShot(skill1Clip);
    }

    public void skill2Play()
    {
        sound.PlayOneShot(skill2Clip);
    }
    public void skill3Play()
    {
        sound.PlayOneShot(skill3Clip);
    }
    public void skill4Play()
    {
        sound.PlayOneShot(skill4Clip);
    }
}
