using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework.Internal.Filters;
public class UIManager : MonoBehaviour
{

    public Globals globals;

    public GameObject fadeOutBlackImage;

    public GameObject fadeInBlackImage;

    public float fadeOutTime = 4f;

    public GameObject pauseSign;
    public GameObject pauseBG;

    public Animator animator;

    public void FadeToBlack()
    {
        fadeOutBlackImage.SetActive(true);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        

    }

    public void FadeInUI()
    {
        fadeInBlackImage.SetActive(true);
        StartCoroutine(BlackScreenSetFalse());
    }

    IEnumerator BlackScreenSetFalse()
    {
        yield return new WaitForSeconds(fadeOutTime);
        fadeInBlackImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGameUIOn()
    {
        pauseSign.SetActive(true);
        pauseBG.SetActive(true);
        
    }
    public void PauseGameUIOff()
    {
        pauseSign.SetActive(false);
        pauseBG.SetActive(false);
    }



}
