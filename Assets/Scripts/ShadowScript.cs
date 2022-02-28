using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour
{
    private Transform player;
    Vector2 direction;
    private float distance, arenaDistance;
    private bool travel = true;
    RaycastHit2D hitUp, hitDown, hitLeft, hitRight;

    private void Start()
    {
        player = GameObject.Find("Enshimon").transform;
        direction = (player.transform.position - transform.position).normalized;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        hitUp = Physics2D.Raycast(transform.position, new Vector3(0, 1, -2), 2f, 1 << 10);
        hitDown = Physics2D.Raycast(transform.position, new Vector3(0, -1, -2), 2f, 1 << 10);
        hitLeft = Physics2D.Raycast(transform.position, new Vector3(-1, 0, -2), 2f, 1 << 10);
        hitRight = Physics2D.Raycast(transform.position, new Vector3(1, 0, -2), 2f, 1 << 10);
        if (distance < 2f)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
            Destroy();
        }
        if (hitUp || hitDown || hitLeft || hitRight)
        {
            Destroy();
        }
        Vector2 position = new Vector3(transform.position.x, transform.position.y, -2f);
        Vector2 dir = new Vector2(direction.x, direction.y);
        position += dir * 30f * Time.deltaTime;
        transform.position = new Vector3(position.x, position.y, -2f);
    }


    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
