using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour
{
    public GameObject fadeOut;

    private EnshimonSoundManager soundManager;

    void Start()
    {
        soundManager = GetComponent<EnshimonSoundManager>();
    }
    public void fadeOutAmaterasu()
    {
        fadeOut.SetActive(true);
        fadeOut.GetComponent<Animator>().enabled = true;
    }

    public void fadeInAmaterasu()
    {
        fadeOut.SetActive(false);
        fadeOut.GetComponent<Animator>().enabled = false;
    }
    public void checkAttackSide()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, new Vector3(transform.localScale.x, 0, -2), 3.5f, 1 << 8);
        if (hit != null)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                switch (hit[i].transform.gameObject.name)
                {
                    case "Oni":
                        hit[i].transform.gameObject.GetComponent<OniManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hit[i].transform.gameObject.GetComponent<TenguManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hit[i].transform.gameObject.GetComponent<KappaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hit[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hit[i].transform.gameObject.GetComponent<KirinManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hit[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
    }

    public void checkAttackSideSkill1()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, new Vector3(transform.localScale.x, 0, -2), 3.5f, 1 << 8);
        if (hit != null)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                switch (hit[i].transform.gameObject.name)
                {
                    case "Oni":
                        hit[i].transform.gameObject.GetComponent<OniManager>().changeHpKnock(1, transform.localScale.x);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hit[i].transform.gameObject.GetComponent<TenguManager>().changeHpKnock(1, transform.localScale.x);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hit[i].transform.gameObject.GetComponent<KappaManager>().changeHpKnock(1, transform.localScale.x);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hit[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hit[i].transform.gameObject.GetComponent<KirinManager>().changeHpKnock(1, transform.localScale.x);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hit[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHpKnock(1, transform.localScale.x);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }

            }
        }
    }

    public void checkAttackUp()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, new Vector3(0, 1, -2), 4f, 1 << 8);
        RaycastHit2D[] hitSx = Physics2D.RaycastAll(transform.position, new Vector3(-1, 1, -2), 4f, 1 << 8);
        RaycastHit2D[] hitDx = Physics2D.RaycastAll(transform.position, new Vector3(1, 1, -2), 4f, 1 << 8);
        if (hit != null)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                switch (hit[i].transform.gameObject.name)
                {
                    case "Oni":
                        hit[i].transform.gameObject.GetComponent<OniManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hit[i].transform.gameObject.GetComponent<TenguManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hit[i].transform.gameObject.GetComponent<KappaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hit[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hit[i].transform.gameObject.GetComponent<KirinManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hit[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitSx != null)
        {
            for (int i = 0; i < hitSx.Length; i++)
            {
                switch (hitSx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitSx[i].transform.gameObject.GetComponent<OniManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitSx[i].transform.gameObject.GetComponent<TenguManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitSx[i].transform.gameObject.GetComponent<KappaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitSx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitSx[i].transform.gameObject.GetComponent<KirinManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitSx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitDx != null)
        {
            for (int i = 0; i < hitDx.Length; i++)
            {
                switch (hitDx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitDx[i].transform.gameObject.GetComponent<OniManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitDx[i].transform.gameObject.GetComponent<TenguManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitDx[i].transform.gameObject.GetComponent<KappaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitDx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitDx[i].transform.gameObject.GetComponent<KirinManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitDx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
    }

    public void checkAttackUpSkill1()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, new Vector3(0, 1, -2), 4.5f, 1 << 8);
        RaycastHit2D[] hitSx = Physics2D.RaycastAll(transform.position, new Vector3(-1, 1, -2), 4.5f, 1 << 8);
        RaycastHit2D[] hitDx = Physics2D.RaycastAll(transform.position, new Vector3(1, 1, -2), 4.5f, 1 << 8);
        if (hit != null)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                switch (hit[i].transform.gameObject.name)
                {
                    case "Oni":
                        hit[i].transform.gameObject.GetComponent<OniManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hit[i].transform.gameObject.GetComponent<TenguManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hit[i].transform.gameObject.GetComponent<KappaManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hit[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hit[i].transform.gameObject.GetComponent<KirinManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hit[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitSx != null)
        {
            for (int i = 0; i < hitSx.Length; i++)
            {
                switch (hitSx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitSx[i].transform.gameObject.GetComponent<OniManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitSx[i].transform.gameObject.GetComponent<TenguManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitSx[i].transform.gameObject.GetComponent<KappaManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitSx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitSx[i].transform.gameObject.GetComponent<KirinManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitSx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitDx != null)
        {
            for (int i = 0; i < hitDx.Length; i++)
            {
                switch (hitDx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitDx[i].transform.gameObject.GetComponent<OniManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitDx[i].transform.gameObject.GetComponent<TenguManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitDx[i].transform.gameObject.GetComponent<KappaManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitDx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitDx[i].transform.gameObject.GetComponent<KirinManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitDx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
    }

    public void checkAttackDown()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, new Vector3(0, -1, -2), 4.5f, 1 << 8);
        RaycastHit2D[] hitDx = Physics2D.RaycastAll(transform.position, new Vector3(1, -1, -2), 4f, 1 << 8);
        RaycastHit2D[] hitSx = Physics2D.RaycastAll(transform.position, new Vector3(-1, -1, -2), 4f, 1 << 8);
        if (hit != null)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                switch (hit[i].transform.gameObject.name)
                {
                    case "Oni":
                        hit[i].transform.gameObject.GetComponent<OniManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hit[i].transform.gameObject.GetComponent<TenguManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hit[i].transform.gameObject.GetComponent<KappaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hit[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hit[i].transform.gameObject.GetComponent<KirinManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hit[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitDx != null)
        {
            for (int i = 0; i < hitDx.Length; i++)
            {
                switch (hitDx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitDx[i].transform.gameObject.GetComponent<OniManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitDx[i].transform.gameObject.GetComponent<TenguManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitDx[i].transform.gameObject.GetComponent<KappaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitDx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitDx[i].transform.gameObject.GetComponent<KirinManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitDx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitSx != null)
        {
            for (int i = 0; i < hitSx.Length; i++)
            {
                switch (hitSx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitSx[i].transform.gameObject.GetComponent<OniManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitSx[i].transform.gameObject.GetComponent<TenguManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitSx[i].transform.gameObject.GetComponent<KappaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitSx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitSx[i].transform.gameObject.GetComponent<KirinManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitSx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
    }

    public void checkAttackDownSkill1()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, new Vector3(0, -1, -2), 4f, 1 << 8);
        RaycastHit2D[] hitDx = Physics2D.RaycastAll(transform.position, new Vector3(1, -1, -2), 3.5f, 1 << 8);
        RaycastHit2D[] hitSx = Physics2D.RaycastAll(transform.position, new Vector3(-1, -1, -2), 3.5f, 1 << 8);
        if (hit != null)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                switch (hit[i].transform.gameObject.name)
                {
                    case "Oni":
                        hit[i].transform.gameObject.GetComponent<OniManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hit[i].transform.gameObject.GetComponent<TenguManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hit[i].transform.gameObject.GetComponent<KappaManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hit[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hit[i].transform.gameObject.GetComponent<KirinManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hit[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitDx != null)
        {
            for (int i = 0; i < hitDx.Length; i++)
            {
                switch (hitDx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitDx[i].transform.gameObject.GetComponent<OniManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitDx[i].transform.gameObject.GetComponent<TenguManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitDx[i].transform.gameObject.GetComponent<KappaManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitDx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitDx[i].transform.gameObject.GetComponent<KirinManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitDx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitSx != null)
        {
            for (int i = 0; i < hitSx.Length; i++)
            {
                switch (hitSx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitSx[i].transform.gameObject.GetComponent<OniManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitSx[i].transform.gameObject.GetComponent<TenguManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitSx[i].transform.gameObject.GetComponent<KappaManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitSx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitSx[i].transform.gameObject.GetComponent<KirinManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitSx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
    }

    public void checkAttackDownSkill2()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, new Vector3(transform.localScale.x, 0, -2), 7f, 1 << 8);
        RaycastHit2D[] hitDx = Physics2D.RaycastAll(transform.position, new Vector3(transform.localScale.x, -1, -2), 6.5f, 1 << 8);
        RaycastHit2D[] hitDown = Physics2D.RaycastAll(transform.position, new Vector3(0, -1, -2), 7f, 1 << 8);
        RaycastHit2D[] hitSx = Physics2D.RaycastAll(transform.position, new Vector3(transform.localScale.x * -1, -1, -2), 6.5f, 1 << 8);
        if (hit != null)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                switch (hit[i].transform.gameObject.name)
                {
                    case "Oni":
                        hit[i].transform.gameObject.GetComponent<OniManager>().changeHpKnock(1, transform.localScale.x);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hit[i].transform.gameObject.GetComponent<TenguManager>().changeHpKnock(1, transform.localScale.x);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hit[i].transform.gameObject.GetComponent<KappaManager>().changeHpKnock(1, transform.localScale.x);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hit[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hit[i].transform.gameObject.GetComponent<KirinManager>().changeHpKnock(1, transform.localScale.x);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hit[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHpKnock(1, transform.localScale.x);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitDx != null)
        {
            for (int i = 0; i < hitDx.Length; i++)
            {
                switch (hitDx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitDx[i].transform.gameObject.GetComponent<OniManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitDx[i].transform.gameObject.GetComponent<TenguManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitDx[i].transform.gameObject.GetComponent<KappaManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitDx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitDx[i].transform.gameObject.GetComponent<KirinManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitDx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitDown != null)
        {
            for (int i = 0; i < hitDown.Length; i++)
            {
                switch (hitDown[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitDown[i].transform.gameObject.GetComponent<OniManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitDown[i].transform.gameObject.GetComponent<TenguManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitDown[i].transform.gameObject.GetComponent<KappaManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitDown[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitDown[i].transform.gameObject.GetComponent<KirinManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitDown[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitSx != null)
        {
            for (int i = 0; i < hitSx.Length; i++)
            {
                switch (hitSx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitSx[i].transform.gameObject.GetComponent<OniManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitSx[i].transform.gameObject.GetComponent<TenguManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitSx[i].transform.gameObject.GetComponent<KappaManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitSx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitSx[i].transform.gameObject.GetComponent<KirinManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitSx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHpKnock(1, 4);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
    }

    public void checkAttackBackSkill2()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, new Vector3(transform.localScale.x * -1, 0, -1), 7f, 1 << 8);
        RaycastHit2D[] hitSx = Physics2D.RaycastAll(transform.position, new Vector3(transform.localScale.x * -1, 1, -1), 6.5f, 1 << 8);
        RaycastHit2D[] hitUp = Physics2D.RaycastAll(transform.position, new Vector3(0, 1, -1), 7f, 1 << 8);
        RaycastHit2D[] hitDx = Physics2D.RaycastAll(transform.position, new Vector3(transform.localScale.x, 1, -1), 6.5f, 1 << 8);
        if (hit != null)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                switch (hit[i].transform.gameObject.name)
                {
                    case "Oni":
                        hit[i].transform.gameObject.GetComponent<OniManager>().changeHpKnock(1, transform.localScale.x * -1);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hit[i].transform.gameObject.GetComponent<TenguManager>().changeHpKnock(1, transform.localScale.x * -1);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hit[i].transform.gameObject.GetComponent<KappaManager>().changeHpKnock(1, transform.localScale.x * -1);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hit[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hit[i].transform.gameObject.GetComponent<KirinManager>().changeHpKnock(1, transform.localScale.x * -1);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hit[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHpKnock(1, transform.localScale.x * -1);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitSx != null)
        {
            for (int i = 0; i < hitSx.Length; i++)
            {
                switch (hitSx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitSx[i].transform.gameObject.GetComponent<OniManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitSx[i].transform.gameObject.GetComponent<TenguManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitSx[i].transform.gameObject.GetComponent<KappaManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitSx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitSx[i].transform.gameObject.GetComponent<KirinManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitSx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitUp != null)
        {
            for (int i = 0; i < hitUp.Length; i++)
            {
                switch (hitUp[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitUp[i].transform.gameObject.GetComponent<OniManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitUp[i].transform.gameObject.GetComponent<TenguManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitUp[i].transform.gameObject.GetComponent<KappaManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitUp[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitUp[i].transform.gameObject.GetComponent<KirinManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitUp[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitDx != null)
        {
            for (int i = 0; i < hitDx.Length; i++)
            {
                switch (hitDx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitDx[i].transform.gameObject.GetComponent<OniManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitDx[i].transform.gameObject.GetComponent<TenguManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitDx[i].transform.gameObject.GetComponent<KappaManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitDx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitDx[i].transform.gameObject.GetComponent<KirinManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitDx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHpKnock(1, 3);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(1);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
    }

    public void checkAttackSideSkill3()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, new Vector3(transform.localScale.x, 0, -2), 5f, 1 << 8);
        if (hit != null)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                switch (hit[i].transform.gameObject.name)
                {
                    case "Oni":
                        hit[i].transform.gameObject.GetComponent<OniManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hit[i].transform.gameObject.GetComponent<TenguManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hit[i].transform.gameObject.GetComponent<KappaManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hit[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hit[i].transform.gameObject.GetComponent<KirinManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hit[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
    }

    public void checkAttackUpSkill3()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, new Vector3(0, 1, -2), 5.5f, 1 << 8);
        RaycastHit2D[] hitSx = Physics2D.RaycastAll(transform.position, new Vector3(-1, 1, -2), 5.5f, 1 << 8);
        RaycastHit2D[] hitDx = Physics2D.RaycastAll(transform.position, new Vector3(1, 1, -2), 5.5f, 1 << 8);
        if (hit != null)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                switch (hit[i].transform.gameObject.name)
                {
                    case "Oni":
                        hit[i].transform.gameObject.GetComponent<OniManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hit[i].transform.gameObject.GetComponent<TenguManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hit[i].transform.gameObject.GetComponent<KappaManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hit[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hit[i].transform.gameObject.GetComponent<KirinManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hit[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitSx != null)
        {
            for (int i = 0; i < hitSx.Length; i++)
            {
                switch (hitSx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitSx[i].transform.gameObject.GetComponent<OniManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitSx[i].transform.gameObject.GetComponent<TenguManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitSx[i].transform.gameObject.GetComponent<KappaManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitSx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitSx[i].transform.gameObject.GetComponent<KirinManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitSx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitDx != null)
        {
            for (int i = 0; i < hitDx.Length; i++)
            {
                switch (hitDx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitDx[i].transform.gameObject.GetComponent<OniManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitDx[i].transform.gameObject.GetComponent<TenguManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitDx[i].transform.gameObject.GetComponent<KappaManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitDx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitDx[i].transform.gameObject.GetComponent<KirinManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitDx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
    }

    public void checkAttackDownSkill3()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, new Vector3(0, -1, -2), 5.5f, 1 << 8);
        RaycastHit2D[] hitDx = Physics2D.RaycastAll(transform.position, new Vector3(1, -1, -2), 4.5f, 1 << 8);
        RaycastHit2D[] hitSx = Physics2D.RaycastAll(transform.position, new Vector3(-1, -1, -2), 4.5f, 1 << 8);
        if (hit != null)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                switch (hit[i].transform.gameObject.name)
                {
                    case "Oni":
                        hit[i].transform.gameObject.GetComponent<OniManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hit[i].transform.gameObject.GetComponent<TenguManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hit[i].transform.gameObject.GetComponent<KappaManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hit[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hit[i].transform.gameObject.GetComponent<KirinManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hit[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitDx != null)
        {
            for (int i = 0; i < hitDx.Length; i++)
            {
                switch (hitDx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitDx[i].transform.gameObject.GetComponent<OniManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitDx[i].transform.gameObject.GetComponent<TenguManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitDx[i].transform.gameObject.GetComponent<KappaManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitDx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitDx[i].transform.gameObject.GetComponent<KirinManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitDx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
        else if (hitSx != null)
        {
            for (int i = 0; i < hitSx.Length; i++)
            {
                switch (hitSx[i].transform.gameObject.name)
                {
                    case "Oni":
                        hitSx[i].transform.gameObject.GetComponent<OniManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Tengu":
                        hitSx[i].transform.gameObject.GetComponent<TenguManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Kappa":
                        hitSx[i].transform.gameObject.GetComponent<KappaManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Yamauba":
                        hitSx[i].transform.gameObject.GetComponent<YamaubaManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Kirin":
                        hitSx[i].transform.gameObject.GetComponent<KirinManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Arahabaki":
                        hitSx[i].transform.gameObject.GetComponent<ArahabakiManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                    case "Aniki":
                        hit[i].transform.gameObject.GetComponent<AnikiManager>().changeHp(3);
                        soundManager.hitPlay();
                        break;
                }
            }
        }
    }
}
