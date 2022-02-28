using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    private Transform player;
    private PlayerManager playerScript;
    private float distance;
    public AudioSource sound;
    public AudioClip pickup;

    void Start()
    {
        player = GameObject.Find("Enshimon").transform;
        playerScript = GameObject.Find("Enshimon").GetComponent<PlayerManager>();
        sound = GameObject.Find("Arahabaki Audio").GetComponent<AudioSource>();
    }


    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if (distance < 1.5f)
        {
            if (playerScript.hp < 5)
            {
                playerScript.hp++;
            }
            playSound();
            Destroy(this.gameObject);
        }
    }

    void playSound()
    {
        sound.PlayOneShot(pickup);
    }
}
