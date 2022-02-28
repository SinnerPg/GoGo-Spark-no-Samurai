using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class ArahabakiManager : MonoBehaviour
{
    private Transform player;
    private PlayerManager playerScript;
    private Animator animator;
    private AIPath aiPath;

    public int hp;
    public float atkCooldownTime = 3f;
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
        if (points < 10 && !hit)
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
        RaycastHit2D firstHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, 0, -2), 9f, 1 << 9);
        RaycastHit2D secondHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, -2, -2), 4f, 1 << 9);
        RaycastHit2D thirdHit = Physics2D.Raycast(transform.position, new Vector3(0, -1, -2), 9f, 1 << 9);
        RaycastHit2D foruthHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, -4f, -2), 2.6f, 1 << 9);
        RaycastHit2D fifthHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, -1, -2), 6.5f, 1 << 9);
        RaycastHit2D sixthHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, -.5f, -2), 7.5f, 1 << 9);
        RaycastHit2D seventhHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, -.2f, -2), 8f, 1 << 9);
        if (firstHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (secondHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (thirdHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (foruthHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (fifthHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (sixthHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (seventhHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
    }

    public void checkSecondDamage()
    {
        RaycastHit2D firstHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, 0, -2), 9f, 1 << 9);
        RaycastHit2D secondHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, 0.5f, -2), 8f, 1 << 9);
        RaycastHit2D thirdHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, 1f, -2), 6.5f, 1 << 9);
        RaycastHit2D fourthHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, 0.25f, -2), 9f, 1 << 9);
        RaycastHit2D fifthHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, -.5f, -2), 7.5f, 1 << 9);
        RaycastHit2D sixthHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, -.2f, -2), 8f, 1 << 9);
        if (firstHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (secondHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (thirdHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (fourthHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (fifthHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (sixthHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
    }

    public void checkThirdDamage()
    {
        RaycastHit2D firstHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, 0.25f, -2), 9f, 1 << 9);
        RaycastHit2D secondHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, 0.5f, -2), 8f, 1 << 9);
        RaycastHit2D thirdHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, 1f, -2), 6.5f, 1 << 9);
        RaycastHit2D fourthHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, 2f, -2), 4f, 1 << 9);
        RaycastHit2D fifthHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x * -1, 4f, -2), 2f, 1 << 9);
        RaycastHit2D sixthHit = Physics2D.Raycast(transform.position, new Vector3(0, 1, -2), 8f, 1 << 9);
        if (firstHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (secondHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (thirdHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (fourthHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (fifthHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (sixthHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
    }

    public void checkFourthDamage()
    {
        RaycastHit2D firstHit = Physics2D.Raycast(transform.position, new Vector3(0, 1, -2), 8f, 1 << 9);
        RaycastHit2D secondHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, 0.5f, -2), 7.5f, 1 << 9);
        RaycastHit2D thirdHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, 1f, -2), 6f, 1 << 9);
        RaycastHit2D fourthHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, 2f, -2), 3.5f, 1 << 9);
        RaycastHit2D fifthHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, 4f, -2), 2f, 1 << 9);
        RaycastHit2D sixthHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, 0, -2), 8f, 1 << 9);
        if (firstHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (secondHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (thirdHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (fourthHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (fifthHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (sixthHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
    }

    public void checkFifthDamage()
    {
        RaycastHit2D firstHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, 0, -2), 8f, 1 << 9);
        RaycastHit2D secondHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, 0.5f, -2), 7.5f, 1 << 9);
        RaycastHit2D thirdHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, 1f, -2), 6f, 1 << 9);
        RaycastHit2D fourthHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, -0.5f, -2), 7f, 1 << 9);
        if (firstHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (secondHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (thirdHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (fourthHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
    }

    public void checkSixthDamage()
    {
        RaycastHit2D firstHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, 0, -2), 8f, 1 << 9);
        RaycastHit2D secondHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, -0.5f, -2), 7f, 1 << 9);
        RaycastHit2D thirdHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, -1f, -2), 5.5f, 1 << 9);
        RaycastHit2D fourthHit = Physics2D.Raycast(transform.position, new Vector3(transform.localScale.x, -2f, -2), 5f, 1 << 9);
        RaycastHit2D fifthHit = Physics2D.Raycast(transform.position, new Vector3(0, -1f, -2), 8f, 1 << 9);
        if (firstHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (secondHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (thirdHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (fourthHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
        else if (fifthHit)
        {
            player.GetComponent<PlayerManager>().changeHp(1);
        }
    }
}
