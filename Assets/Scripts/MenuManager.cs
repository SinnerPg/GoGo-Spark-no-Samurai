using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject popupCommands;
    public GameObject popupCredits;
    public GameObject menu;
    public Image fadeBG;
    public Animator fadeAnimator;
    public Animator popupCommandsAnimator;
    public Animator popupCreditsAnimator;
    public Animator popupGame;

    public void gamePopup()
    {
        popupGame.SetBool("Start", true);   
    }

    public void closeGamePopup()
    {
        popupGame.SetBool("Start", false); 
    }


    public void newGameEasy()
    {
        StartCoroutine(EasyCoroutine());
    }
                
    IEnumerator EasyCoroutine()
    {
        fadeAnimator.SetBool("Fade", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("IntroEasy");
    }

    public void newGameNormal()
    {
        StartCoroutine(NormalCoroutine());
    }
                
    IEnumerator NormalCoroutine()
    {
        fadeAnimator.SetBool("Fade", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("IntroNormal");
    }





    public void commands()
    {
        popupCommandsAnimator.SetBool("Start", true);
    }

    public void closeCommands()
    {
        popupCommandsAnimator.SetBool("Start", false);
    }

    public void credits()
    {
        popupCreditsAnimator.SetBool("Start", true);   
    }

    public void closeCredits()
    {
        popupCreditsAnimator.SetBool("Start", false); 
    }

    public void exit()
    {
        Application.Quit();
    }

}