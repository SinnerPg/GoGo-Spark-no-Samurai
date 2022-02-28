using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : MonoBehaviour
{
    private Transform player;
    Vector2 direction;
    private float distance, arenaDistance;
    private bool travel = true;
    RaycastHit2D hitDown;

    private void Start()
    {
        player = GameObject.Find("Enshimon").transform;
    }
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        hitDown = Physics2D.Raycast(transform.position, new Vector3(0, -1, -2), 2f, 1 << 11);
        if (distance < 1.5f)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
            Destroy();
        }
        if (hitDown)
        {
            Destroy();
        }
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - .15f, -2);
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
