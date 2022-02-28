using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TenguManager : MonoBehaviour
{
    private Transform player;
    private PlayerManager playerScript;
    private Animator animator;
    private AIPath aiPath;

    public int hp;
    private bool attacking = false, charging = false, hit, dead = false;
    public float atkCooldownTime = 2f;
    private float canAttackTime = 0, distance;
    Vector2 direction;
    public float atkSpeed = 20f;
    private float points;
    void Start()
    {
        animator = GetComponent<Animator>();
        aiPath = transform.parent.GetComponent<AIPath>();
        player = GameObject.Find("Enshimon").transform;
        playerScript = GameObject.Find("Enshimon").GetComponent<PlayerManager>();
        hp = 1;
    }
    void Update()
    {
        points = player.GetComponent<PlayerManager>().anikiPoint;
        if (!playerScript.isAmaterasu)
        {
            animator.enabled = true;
            if (hp > 0)
            {
                hit = false;
            }
            distance = Vector3.Distance(transform.position, player.position);
            if (distance < 6f)
            {
                aiPath.enabled = false;
                if (Time.time > canAttackTime)
                {
                    animator.SetBool("charging", true);
                    charging = true;
                }
            }
            else if (!charging)
            {
                aiPath.enabled = true;
            }

            if (distance < 1.5f && !dead)
            {
                player.GetComponent<PlayerManager>().changeHp(1);
            }

            if (hp <= 0)
            {
                animator.SetBool("death", true);
                aiPath.enabled = false;
                dead = true;
                attacking = false;
                charging = false;
            }

            if (attacking)
            {
                Vector2 position = new Vector3(transform.parent.position.x, transform.parent.position.y, -2f);
                Vector2 dir = new Vector2(direction.x + 0.15f, direction.y);
                position += dir * atkSpeed * Time.deltaTime;
                transform.parent.position = new Vector3(position.x, position.y, -2f);
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

    public void startAtk()
    {
        animator.SetBool("attacking", true);
        canAttackTime = Time.time + atkCooldownTime;
    }

    public void stopAtk()
    {
        animator.SetBool("attacking", false);
        attacking = false;
        aiPath.enabled = true;
        charging = false;
    }

    public void flyAttack()
    {
        direction = (player.transform.position - transform.parent.position).normalized;
        attacking = true;
        animator.SetBool("charging", false);
    }

    public void changeHp(int x)
    {
        hp -= x;
    }

    //1: Right knock; -1: Left knock, 3: Upper Knock; 4: Bottom knock;
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
}
