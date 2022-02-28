using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class KirinManager : MonoBehaviour
{
    private Transform player;
    private PlayerManager playerScript;
    private Animator animator;
    private AIPath aiPath;

    public int hp;
    private bool charging = false, hit, dead = false;
    public float atkCooldownTime = 2f;
    private float canAttackTime = 0, distance;
    private float points;
    void Start()
    {
        animator = GetComponent<Animator>();
        aiPath = transform.parent.GetComponent<AIPath>();
        player = GameObject.Find("Enshimon").transform;
        playerScript = GameObject.Find("Enshimon").GetComponent<PlayerManager>();
        hp = 2;
        points = player.GetComponent<PlayerManager>().anikiPoint;
    }
    void Update()
    {
        if (!playerScript.isAmaterasu)
        {
            animator.enabled = true;
            if (hp > 0)
            {
                hit = false;
            }
            distance = Vector3.Distance(transform.position, player.position);
            if (distance < 8f)
            {
                aiPath.enabled = false;
                if (Time.time > canAttackTime)
                {
                    animator.SetBool("attacking", true);
                    charging = true;
                }
            }
            else if (!charging)
            {
                aiPath.enabled = true;
            }

            if (distance < 2.5f && !dead)
            {
                player.GetComponent<PlayerManager>().changeHp(1);
            }

            if (hp <= 0)
            {
                animator.SetBool("death", true);
                aiPath.enabled = false;
                dead = true;
            }
        }
        else
        {
            aiPath.enabled = false;
            animator.enabled = false;
            if (!hit)
            {
                changeHp(2);
                hit = true;
            }
        }
    }
    public void changeHp(int x)
    {
        hp -= x;
    }

    public void changeHpKnock(int x, float direction)
    {
        hp -= x;
        if (direction == 1)
        {
            transform.parent.position = new Vector3(transform.parent.position.x + 2, transform.parent.position.y, transform.parent.position.z);
        }
        else if (direction == -1)
        {
            transform.parent.position = new Vector3(transform.parent.position.x - 2, transform.parent.position.y, transform.parent.position.z);
        }
        else if (direction == 3)
        {
            transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y + 2, transform.parent.position.z);
        }
        else if (direction == 4)
        {
            transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y - 2, transform.parent.position.z);
        }
    }


    public void destroy()
    {
        points = player.GetComponent<PlayerManager>().anikiPoint;
        if (points < 10)
        {
            player.GetComponent<PlayerManager>().addPoint();
        }
        int chance = Random.Range(1, 101);
        if (chance >= 0 && chance <= 7)
        {
            GameObject obj = Instantiate(Resources.Load("Cuore")) as GameObject;
            obj.transform.position = transform.position;
        }
        Destroy(this.transform.parent.gameObject);
        player.GetComponent<PlayerManager>().nKill++;
    }

    public void stopAtk()
    {
        charging = false;
        canAttackTime = Time.time + atkCooldownTime;
        GameObject obj = Instantiate(Resources.Load("Bolt")) as GameObject;
        animator.SetBool("attacking", false);
    }
}
