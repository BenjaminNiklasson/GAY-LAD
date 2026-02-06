using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Animations;
using NUnit.Framework.Internal.Filters;
public class UIManager : MonoBehaviour
{

   public Animator pauseSignLeave;
    public Animator pauseBgAnimator;
    
    [SerializeField] private string pauseSignSlideOut;
    [SerializeField] private string pauseBgSlideOut;
    [SerializeField] private string pauseBgSlideIn;
    public Globals globals;

    public GameObject fadeOutBlackImage;

    public GameObject fadeInBlackImage;

    public float fadeOutTime = 4f;

    public GameObject pauseSign;
    public GameObject pauseBG;

    

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
        pauseBgAnimator.Play(pauseBgSlideIn, 0, 0.0f);
        globals.PauseOrUnpauseGame();
        

    }
    public void PauseGameUIOff()
    {
        pauseSignLeave.Play(pauseSignSlideOut, 0, 0.0f);
        pauseBgAnimator.Play(pauseBgSlideOut, 0, 0.0f);

        StartCoroutine(PauseSignUIOff());
        
    }

    IEnumerator PauseSignUIOff()
    {
        yield return new WaitForSeconds(1f);
        pauseSign.SetActive(false);
        pauseBG.SetActive(false);
        globals.PauseOrUnpauseGame();
    }

   

}
