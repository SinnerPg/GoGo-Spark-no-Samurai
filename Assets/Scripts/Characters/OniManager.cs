using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class OniManager : MonoBehaviour
{
    private Transform player;
    private PlayerManager playerScript;
    private Animator animator;
    private AIPath aiPath;

    public int hp;
    public float atkCooldownTime = 1.5f;
    private float canAttackTime = 0, distance;
    private bool charging = false, hit, dead = false;
    private float points;
    void Start()
    {
        animator = GetComponent<Animator>();
        aiPath = transform.parent.GetComponent<AIPath>();
        player = GameObject.Find("Enshimon").transform;
        playerScript = GameObject.Find("Enshimon").GetComponent<PlayerManager>();
        hp = 3;
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
            if (distance < 3f)
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

            if (distance < 1.5f && !dead)
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

    public void stopAtk()
    {
        animator.SetBool("attacking", false);
        aiPath.enabled = true;
        canAttackTime = Time.time + atkCooldownTime;
        charging = false;
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

    public void checkFirstDamage()
    {
        RaycastHit2D hitBack = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, 0, -1), 4f, 1 << 9);
        RaycastHit2D hitBackSx = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, -1, -1), 3.5f, 1 << 9);
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, new Vector3(0, -1, -1), 3.5f, 1 << 9);
        if (hitBack)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (hitBackSx)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (hitDown)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
    }

    public void checkSecondDamage()
    {
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, new Vector3(0, -1, -1), 3.5f, 1 << 9);
        RaycastHit2D hitFrontDown = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, -1, -1), 3.5f, 1 << 9);
        RaycastHit2D hitFront = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, 0, -1), 4f, 1 << 9);
        RaycastHit2D hitFrontUp = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, 1, -1), 3f, 1 << 9);
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, new Vector3(0, 1, -1), 4f, 1 << 9);
        if (hitDown)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (hitFrontDown)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (hitFront)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (hitFrontUp)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (hitUp)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
    }

    public void checkThirdDamage()
    {
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, new Vector3(0, 1, -1), 4f, 1 << 9);
        RaycastHit2D hitBackUp = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, 1, -1), 3f, 1 << 9);
        RaycastHit2D hitBack = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, 0, -1), 4f, 1 << 9);
        if (hitUp)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (hitBackUp)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (hitBack)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
    }
}
