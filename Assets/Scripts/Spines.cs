using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spines : MonoBehaviour
{
    private Transform player;
    private float distance;
    private bool check = false;
    private void Start()
    {
        Invoke("despawn", 3f);
        player = GameObject.Find("Enshimon").transform;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if (distance < 2.8f && check)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
    }

    private void OnEnable()
    {
        Invoke("despawn", 3f);
        check = false;
    }

    void despawn()
    {
        GetComponent<Animator>().SetTrigger("despawn");
    }

    void checkDamage()
    {
        check = true;
    }
    void Destroy()
    {
        gameObject.SetActive(false);
    }
}
