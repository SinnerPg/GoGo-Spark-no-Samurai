using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnikiManager : MonoBehaviour
{
    public GameObject fadeOut, fadeOutText, exitButton;
    public AudioSource audio;
    public AudioClip shadowClip, shadowChargeClip, bulletChargeClip, chogathChargeClip, swordChargeClip;
    private Transform player;
    public GameObject[] spawner;
    private PlayerManager playerScript;
    private Animator animator;
    public int hp;
    private float canAttackTime, distance, attackTime = 0f;
    private bool charging = false, hit, dead = false, charge1 = false, charge2 = false, charge3 = false, charge4 = false, isSkilling = false, attacking = false, invincible = false;
    private int attack, shadowsNumber = 12;
    private float points;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Enshimon").transform;
        playerScript = GameObject.Find("Enshimon").GetComponent<PlayerManager>();
        hp = 55;
        points = player.GetComponent<PlayerManager>().anikiPoint;
        canAttackTime = Time.time + 3.5f;
    }
    void Update()
    {
        if (player.transform.position.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (!playerScript.isAmaterasu)
        {
            animator.enabled = true;
            hit = false;
            distance = Vector3.Distance(transform.position, player.position);

            if (hp <= 0)
            {
                animator.SetBool("death", true);
                dead = true;
            }

            if (Time.time > canAttackTime && !isSkilling)
            {
                isSkilling = true;
                invincible = true;
                attack = Random.Range(1, 5);
                switch (attack)
                {
                    case 1:
                        startAttack1();
                        break;
                    case 2:
                        startAttack2();
                        break;
                    case 3:
                        startAttack3();
                        break;
                    case 4:
                        startAttack4();
                        break;
                }
            }

            if (charge1)
            {
                if (shadowsNumber > 0 && !attacking)
                {
                    attacking = true;
                    GameObject obj = Instantiate(Resources.Load("Shadow Clone")) as GameObject;
                    obj.transform.position = transform.position;
                    audio.PlayOneShot(shadowClip);
                    shadowsNumber--;
                    Invoke("resetAttack", 1.5f);
                }
                else if (shadowsNumber == 0)
                {
                    charge1 = false;
                    animator.SetBool("charge1", false);
                    canAttackTime = Time.time + 3.5f;
                    isSkilling = false;
                    shadowsNumber = 10;
                }
            }

            if (charge2)
            {
                attackTime += Time.deltaTime;
                if (!attacking)
                {
                    attacking = true;
                    int spawn = Random.Range(0, 15);
                    GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                    bul.transform.position = spawner[spawn].transform.position;
                    bul.SetActive(true);
                    Invoke("resetAttack", 0.09f);
                }

                if (attackTime > 15f)
                {
                    charge2 = false;
                    Invoke("stopCharge2", 3f);
                }
            }

            if (charge3)
            {
                attackTime += Time.deltaTime;
                if (!attacking)
                {
                    attacking = true;
                    GameObject spine = SpinePool.spinePoolInstance.GetSpine();
                    spine.transform.position = new Vector3(player.transform.position.x + Random.Range(-4, 4), player.transform.position.y + Random.Range(-4, 4), -1);
                    spine.SetActive(true);
                    Invoke("resetAttack", 1.5f);
                }

                if (attackTime > 15f)
                {
                    charge3 = false;
                    animator.SetBool("charge3", false);
                    canAttackTime = Time.time + 3.5f;
                    isSkilling = false;
                    attackTime = 0f;
                }
            }

            if (charge4)
            {
                attackTime += Time.deltaTime;

                if (!attacking)
                {
                    attacking = true;
                    GameObject sword = Instantiate(Resources.Load("Spada rotante")) as GameObject;
                    if (Mathf.Round(attackTime) == 0)
                    {
                        sword.GetComponent<SwordManager>().setTime(15);
                    }
                    else if (Mathf.Round(attackTime) == 5)
                    {
                        sword.GetComponent<SwordManager>().setTime(10);
                    }
                    else if (Mathf.Round(attackTime) == 10)
                    {
                        sword.GetComponent<SwordManager>().setTime(5);
                    }
                    sword.transform.position = transform.position;
                    Invoke("resetAttack", 5f);
                }


                if (attackTime > 15f)
                {
                    charge4 = false;
                    animator.SetBool("charge4", false);
                    canAttackTime = Time.time + 3.5f;
                    isSkilling = false;
                    attackTime = 0f;
                }
            }
        }
        else
        {
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
        if (!invincible)
        {
            hp -= x;
        }
    }

    public void destroy()
    {
        Destroy(this.transform.parent.gameObject);
    }

    void resetAttack()
    {
        attacking = false;
    }

    public void startIdle()
    {
        animator.SetBool("idle", true);
        invincible = false;
    }

    void startAttack1()
    {
        animator.SetBool("atk1", true);
    }

    void startAttack2()
    {
        animator.SetBool("atk2", true);
    }

    void startAttack3()
    {
        animator.SetBool("atk3", true);
    }
    void startAttack4()
    {
        animator.SetBool("atk4", true);
    }

    void stopCharge2()
    {
        animator.SetBool("charge2", false);
        canAttackTime = Time.time + 3.5f;
        isSkilling = false;
        attackTime = 0f;
    }

    public void statusAttack1()
    {
        animator.SetBool("charge1", true);
        animator.SetBool("idle", false);
        animator.SetBool("atk1", false);
        charge1 = true;
    }

    public void statusAttack2()
    {
        animator.SetBool("charge2", true);
        animator.SetBool("idle", false);
        animator.SetBool("atk2", false);
        charge2 = true;
    }

    public void statusAttack3()
    {
        animator.SetBool("charge3", true);
        animator.SetBool("idle", false);
        animator.SetBool("atk3", false);
        charge3 = true;
    }

    public void statusAttack4()
    {
        animator.SetBool("charge4", true);
        animator.SetBool("idle", false);
        animator.SetBool("atk4", false);
        charge4 = true;
    }

    public void fadeOutEndgame()
    {
        fadeOut.SetActive(true);
        fadeOut.GetComponent<Animator>().enabled = true;
        Invoke("textEndgame", 3f);
        Invoke("exitFunction", 6f);
    }

    public void textEndgame()
    {
        fadeOutText.SetActive(true);
        fadeOut.GetComponent<Animator>().enabled = true;
    }

    public void exitFunction()
    {
        exitButton.SetActive(true);
    }

    public void charge1Sound()
    {
        audio.PlayOneShot(shadowChargeClip);
    }

    public void charge2Sound()
    {
        audio.PlayOneShot(bulletChargeClip);
    }

    public void charge3Sound()
    {
        audio.PlayOneShot(chogathChargeClip);
    }

    public void charge4Sound()
    {
        audio.PlayOneShot(swordChargeClip);
    }
}
