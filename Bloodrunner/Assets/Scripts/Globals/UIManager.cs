using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    public Globals globals;

    public GameObject fadeOutBlackImage;

    public GameObject fadeInBlackImage;

    public float fadeOutTime = 4f;

    public GameObject pauseSign;

    public void FadeToBlack()
    {
        fadeOutBlackImage.SetActive(true);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
    }
    public void PauseGameUIOff()
    {
        pauseSign.SetActive(false);
    }



}
