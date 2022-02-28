using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    private Transform player;
    private float playerSpeed;
    Vector2 direction;
    private float distance;
    private bool travel = true;
    private float speed = 0;
    private int time;
    private void Start()
    {
        player = GameObject.Find("Enshimon").transform;
        playerSpeed = player.GetComponent<PlayerManager>().moveSpeed;
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());
        Invoke("Destroy", time);
    }

    void Update()
    {
        direction = (player.transform.position - transform.position).normalized;
        distance = Vector3.Distance(transform.position, player.position);

        if (distance < playerSpeed - 1f)
        {
            speed = playerSpeed - .5f;
        }
        else
        {
            speed = 1 / distance * 10f + playerSpeed - .5f;
        }

        if (distance < 1.5f)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        Vector2 position = new Vector3(transform.position.x, transform.position.y, -1f);
        Vector2 dir = new Vector2(direction.x, direction.y);
        position += dir * speed * Time.deltaTime;
        transform.position = new Vector3(position.x, position.y, -1f);
    }
    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void setTime(int t)
    {
        time = t;
    }
}
