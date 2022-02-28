using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{
    private Transform player;
    Vector2 direction;
    private float distance;
    private bool travel = true;
    public AudioSource sound;
    public AudioClip clip;

    private void Start()
    {
        player = GameObject.Find("Enshimon").transform;
        transform.position = new Vector3(player.position.x, player.position.y, -1);
        sound = GameObject.Find("Bolt Audio").GetComponent<AudioSource>();
        Invoke("Destroy", 3f);
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if (distance < 2f && !travel)
        {
            player.GetComponent<Animator>().SetBool("paralisi", true);
            Destroy();
        }
    }

    public void soundPlay()
    {
        sound.PlayOneShot(clip);
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void checkDamage()
    {
        if (distance < 1.5f)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
            Destroy();
        }
    }

    public void stopTravel()
    {
        travel = false;
    }
}
