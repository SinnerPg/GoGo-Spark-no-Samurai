using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 5f, dashSpeed = 6f;
    Vector2 movement;
    public Animator animator;
    public UIManager uiManager;

    public GameObject heart1, heart2, heart3, heart4, heart5;
    private Rigidbody2D rb;
    private HitboxManager hm;
    public GameObject menu;
    private bool isDashing, isAttacking, invulnerable, canDash, canSkill1 = false, canSkill2 = false, canSkill3 = false, isSkilling, paralisi;
    private float dashCooldownTime = 1.5f, canDashTime = 0, skill1CooldownTime = 4, canSkill1Time = 0f, skill2CooldownTime = 6, canSkill2Time = 0f,
                  skill3CooldownTime = 10, canSkill3Time = 0f;
    public int hp;
    [HideInInspector]
    public float anikiPoint;
    [HideInInspector]
    public bool isAmaterasu;
    [HideInInspector]
    public int nKill;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hm = GetComponent<HitboxManager>();
        invulnerable = false;
        canDash = true;
        hp = 5;
        nKill = 0;
        anikiPoint = 0f;
    }

    void Update()
    {
        if (hp >= 5)
        {
            heart5.SetActive(true);
            heart4.SetActive(true);
            heart3.SetActive(true);
            heart2.SetActive(true);
            heart1.SetActive(true);
        }
        else if (hp == 4)
        {
            heart5.SetActive(false);
            heart4.SetActive(true);
            heart3.SetActive(true);
            heart2.SetActive(true);
            heart1.SetActive(true);
        }
        else if (hp == 3)
        {
            heart5.SetActive(false);
            heart4.SetActive(false);
            heart3.SetActive(true);
            heart2.SetActive(true);
            heart1.SetActive(true);
        }
        else if (hp == 2)
        {
            heart5.SetActive(false);
            heart4.SetActive(false);
            heart3.SetActive(false);
            heart2.SetActive(true);
            heart1.SetActive(true);
        }
        else if (hp == 1)
        {
            heart5.SetActive(false);
            heart4.SetActive(false);
            heart3.SetActive(false);
            heart2.SetActive(false);
            heart1.SetActive(true);
        }
        else if (hp == 0)
        {
            heart5.SetActive(false);
            heart4.SetActive(false);
            heart3.SetActive(false);
            heart2.SetActive(false);
            heart1.SetActive(false);
        }

        if (hp > 0)
        {
            move();

            if (Input.GetKey(KeyCode.LeftShift))
            {
                dash();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                attack();
            }
        }
    }

    void FixedUpdate()
    {
        if (!isDashing && !isAttacking && !isSkilling && !paralisi && hp > 0)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void move()
    {
        if (!isDashing && !isAttacking && !isSkilling && !paralisi && hp > 0)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (movement.x != 0)
            {
                movement.y = 0;
            }
            if (movement.y != 0)
            {
                movement.x = 0;
            }
            movement.Normalize();
            if (movement != Vector2.zero)
            {
                animator.SetBool("walking", true);
            }
            else
            {
                animator.SetBool("walking", false);
            }

            if (movement.x == -1)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (movement.x == 1)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

    }

    public void dash()
    {
        if (Time.time > canDashTime)
        {
            canDash = true;
            if (!isDashing && !isAttacking && !isSkilling && canDash && !paralisi)
            {
                isDashing = true;
                invulnerable = true;
                canDash = false;
                animator.SetBool("dashing", true);
                if (movement.x == 1)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
                else if (movement.x == -1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (movement.y == 1)
                {
                    rb.velocity = Vector2.up * dashSpeed;
                }
                else if (movement.y == -1)
                {
                    rb.velocity = Vector2.down * dashSpeed;
                }
                else if (movement.x == 0 && movement.y == 0)
                {
                    if (transform.localScale.x == -1)
                    {
                        rb.velocity = Vector2.left * dashSpeed;
                    }
                    else
                    {
                        rb.velocity = Vector2.right * dashSpeed;
                    }
                }
                canDashTime = Time.time + dashCooldownTime;
                uiManager.setDashCooldown();
            }
        }
    }

    public void skillOne()
    {
        if (Time.time > canSkill1Time)
        {
            canSkill1 = true;
            if (!isDashing && !isAttacking && !isSkilling && canSkill1 && !paralisi)
            {
                isSkilling = true;
                canSkill1 = false;
                if (movement.x == 1)
                {
                    rb.velocity = Vector2.zero;
                    animator.SetBool("skill1", true);
                }
                else if (movement.x == -1)
                {
                    rb.velocity = Vector2.zero;
                    animator.SetBool("skill1", true);
                }
                else if (movement.y == 1)
                {
                    rb.velocity = Vector2.zero;
                    animator.SetBool("skill1Up", true);
                }
                else if (movement.y == -1)
                {
                    rb.velocity = Vector2.zero;
                    animator.SetBool("skill1Down", true);
                }
                else if (movement.x == 0 && movement.y == 0)
                {
                    rb.velocity = Vector2.zero;
                    animator.SetBool("skill1", true);
                }
                canSkill1Time = Time.time + skill1CooldownTime;
                uiManager.setSkill1Cooldown();
            }
        }
    }

    public void skillTwo()
    {
        if (Time.time > canSkill2Time)
        {
            canSkill2 = true;
            if (!isDashing && !isAttacking && !isSkilling && canSkill2 && !paralisi)
            {
                isSkilling = true;
                canSkill2 = false;
                rb.velocity = Vector2.zero;
                animator.SetBool("skill2", true);
                canSkill2Time = Time.time + skill2CooldownTime;
                uiManager.setSkill2Cooldown();
            }
        }
    }

    public void skillThree()
    {
        if (Time.time > canSkill3Time)
        {
            canSkill3 = true;
            if (!isDashing && !isAttacking && !isSkilling && canSkill3 && !paralisi)
            {
                isSkilling = true;
                canSkill3 = false;
                if (movement.x == 1)
                {
                    rb.velocity = Vector2.zero;
                    animator.SetBool("skill3", true);
                }
                else if (movement.x == -1)
                {
                    rb.velocity = Vector2.zero;
                    animator.SetBool("skill3", true);
                }
                else if (movement.y == 1)
                {
                    rb.velocity = Vector2.zero;
                    animator.SetBool("skill3Up", true);
                }
                else if (movement.y == -1)
                {
                    rb.velocity = Vector2.zero;
                    animator.SetBool("skill3Down", true);
                }
                else if (movement.x == 0 && movement.y == 0)
                {
                    rb.velocity = Vector2.zero;
                    animator.SetBool("skill3", true);
                }
                canSkill3Time = Time.time + skill3CooldownTime;
                uiManager.setSkill3Cooldown();
            }
        }
    }

    public void skillFour()
    {
        if (!isDashing && !isAttacking && !isSkilling && !isAmaterasu && anikiPoint == 10 && !paralisi)
        {
            isSkilling = true;
            isAmaterasu = true;
            rb.velocity = Vector2.zero;
            animator.SetBool("skill4", true);
            anikiPoint = 0;
        }
    }

    public void stopDash()
    {
        animator.SetBool("dashing", false);
        isDashing = false;
        invulnerable = false;
    }

    public void attack()
    {
        if (!isDashing && !isSkilling && !paralisi)
        {
            if (movement.x == 1)
            {
                rb.velocity = Vector2.zero;
                isAttacking = true;
                animator.SetBool("attacking", true);
            }
            else if (movement.x == -1)
            {
                rb.velocity = Vector2.zero;
                isAttacking = true;
                animator.SetBool("attacking", true);
            }
            else if (movement.y == 1)
            {
                rb.velocity = Vector2.zero;
                isAttacking = true;
                animator.SetBool("attackingUp", true);
            }
            else if (movement.y == -1)
            {
                rb.velocity = Vector2.zero;
                isAttacking = true;
                animator.SetBool("attackingDown", true);
            }
            else if (movement.x == 0 && movement.y == 0)
            {
                rb.velocity = Vector2.zero;
                isAttacking = true;
                animator.SetBool("attacking", true);
            }
        }
    }

    public void changeHp(int x)
    {
        if (!invulnerable)
        {
            hp -= x;
            invulnerable = true;
            if (hp > 0)
            {
                foreach (AnimatorControllerParameter parameter in animator.parameters)
                {
                    animator.SetBool(parameter.name, false);
                }
                isSkilling = false;
                isAttacking = false;
                animator.SetBool("hit", true);
                StartCoroutine(ToggleRenderer());
            }
            else
            {
                animator.SetTrigger("death");
            }
        }
    }

    public void stopAttacking()
    {
        animator.SetBool("attacking", false);
        isAttacking = false;
    }

    public void stopAttackingUp()
    {
        animator.SetBool("attackingUp", false);
        isAttacking = false;
    }

    public void stopAttackingDown()
    {
        animator.SetBool("attackingDown", false);
        isAttacking = false;
    }

    public void stopSkill1()
    {
        animator.SetBool("skill1", false);
        isSkilling = false;
    }

    public void stopSkill1Up()
    {
        animator.SetBool("skill1Up", false);
        isSkilling = false;
    }

    public void stopSkill1Down()
    {
        animator.SetBool("skill1Down", false);
        isSkilling = false;
    }

    public void stopSkill2()
    {
        animator.SetBool("skill2", false);
        isSkilling = false;
    }

    public void stopSkill3()
    {
        animator.SetBool("skill3", false);
        isSkilling = false;
    }

    public void stopSkill3Up()
    {
        animator.SetBool("skill3Up", false);
        isSkilling = false;
    }

    public void stopSkill3Down()
    {
        animator.SetBool("skill3Down", false);
        isSkilling = false;
    }

    public void stopSkill4()
    {
        animator.SetBool("skill4", false);
        isSkilling = false;
        isAmaterasu = false;
    }

    public void enableParalisi()
    {
        paralisi = true;
    }

    public void disableParalisi()
    {
        animator.SetBool("paralisi", false);
        paralisi = false;
    }

    public void stopTime()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    IEnumerator ToggleRenderer()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("hit", false);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().enabled = true;
        invulnerable = false;
    }

    public void addPoint()
    {
        anikiPoint++;
    }
}
