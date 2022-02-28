using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSoundManager : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip music;
    public PlayerManager player;
    private bool played;
    public GameObject aniki;
    private int monstersNumber;

    void Start()
    {
        sound = GameObject.Find("Music").GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "ArenaNormal")
        {
            monstersNumber = 62;
        }
        else
        {
            monstersNumber = 47;
        }
    }

    void Update()
    {
        if (player.nKill >= monstersNumber && !played)
        {
            sound.clip = music;
            sound.Play();
            played = true;
            aniki.SetActive(true);
        }
    }
}
