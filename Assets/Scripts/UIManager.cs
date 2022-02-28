using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public ResetCooldown dashCooldown, skill1Cooldown, skill2Cooldown, skill3Cooldown;
    public PlayerManager points;
    public Image anikiBar;

    void Update() {
        anikiBar.fillAmount = points.anikiPoint/10f;
    }

    public void setDashCooldown()
    {
        dashCooldown.setCooldown();
    }

    public void setSkill1Cooldown()
    {
        skill1Cooldown.setCooldown();
    }

    public void setSkill2Cooldown()
    {
        skill2Cooldown.setCooldown();
    }

    public void setSkill3Cooldown()
    {
        skill3Cooldown.setCooldown();
    }
}
