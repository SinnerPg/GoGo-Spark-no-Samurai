using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetCooldown : MonoBehaviour
{

    public void setCooldown()
    {
        GetComponent<Image>().fillAmount = 0;
        GetComponent<Animator>().SetBool("cooldown", true);
    }
    void resetCooldown()
    {
        GetComponent<Animator>().SetBool("cooldown", false);
    }
}
