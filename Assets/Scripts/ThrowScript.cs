using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowScript : MonoBehaviour
{
    private Transform player;
    Vector2 direction;
    private float distance, arenaDistance;
    private bool travel = true;
    RaycastHit2D hitUp, hitDown, hitLeft, hitRight;

    private void Start()
    {
        if (transform.parent != null)
        {
            transform.position = transform.parent.position;
            transform.parent = null;
        }
        player = GameObject.Find("Enshimon").transform;
        direction = (player.transform.position - transform.position).normalized;
        Invoke("Trap", 1.5f);
        Invoke("Destroy", 9f);
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        hitUp = Physics2D.Raycast(transform.position, new Vector3(0, 1, -2), 2f, 1 << 11);
        hitDown = Physics2D.Raycast(transform.position, new Vector3(0, -1, -2), 2f, 1 << 11);
        hitLeft = Physics2D.Raycast(transform.position, new Vector3(-1, 0, -2), 2f, 1 << 11);
        hitRight = Physics2D.Raycast(transform.position, new Vector3(1, 0, -2), 2f, 1 << 11);
        if (distance < 1.5f)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
            if (travel)
            {
                Destroy();
            }
        }
        if (hitUp || hitDown || hitLeft || hitRight)
        {
            Trap();
        }
        if (travel)
        {
            Vector2 position = new Vector3(transform.position.x, transform.position.y, -1);
            Vector2 dir = new Vector2(direction.x, direction.y);
            position += dir * 9f * Time.deltaTime;
            transform.position = new Vector3(position.x, position.y, -1);
        }
    }

    private void Trap()
    {
        GetComponent<Animator>().SetBool("drop", true);
        travel = false;
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
