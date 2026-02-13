using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Animations;
using NUnit.Framework.Internal.Filters;
using TMPro;


public class UIManager : MonoBehaviour
{

    public Animator pauseSignLeaveAninmator;
    public Animator pauseBgAnimator;
    public Animator settingsSignAnimator;
    public Animator controlSignAnimator;

    [SerializeField] private string pauseSignSlideOut;
    [SerializeField] private string pauseBgSlideOut;
    [SerializeField] private string pauseBgSlideIn;
    [SerializeField] private string settingsSignSlideOut;
    [SerializeField] private string controlSignSlideOut;
    [SerializeField] private string controlSignSlideIn;
    public Globals globals;

    public GameObject fadeOutBlackImage;

    public GameObject fadeInBlackImage;

    [SerializeField] public float fadeOutTime = 4f;

    public TextMeshProUGUI birdSavedText;

    public GameObject xCheck;
    public GameObject pauseSign;
    public GameObject pauseBG;
    public GameObject settingsSign;
    public GameObject controlsSign;

    AudioManager audioManager;
    ScenePersist scenePersist;

    public void FadeToBlack()
    {
        fadeOutBlackImage.SetActive(true);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globals = GameObject.FindGameObjectWithTag("Globals").GetComponent<Globals>();

        scenePersist = GameObject.FindGameObjectWithTag("ScenePersist").GetComponent<ScenePersist>();

        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        fadeInBlackImage = GameObject.FindGameObjectWithTag("BlackCanvas").transform.GetChild(0).gameObject;
        fadeOutBlackImage = GameObject.FindGameObjectWithTag("BlackCanvas").transform.GetChild(1).gameObject;
        FadeInUI();

        birdSavedText.text = scenePersist.birdsSaved + "/5";

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
        pauseSignLeaveAninmator.Play(pauseSignSlideOut, 0, 0.0f);
        pauseBgAnimator.Play(pauseBgSlideOut, 0, 0.0f);
        globals.PauseOrUnpauseGame();
        StartCoroutine(PauseSignUIOff());

    }

    IEnumerator PauseSignUIOff()
    {
        yield return new WaitForSecondsRealtime(1.2f);
        pauseSign.SetActive(false);
        pauseBG.SetActive(false);
        
    }

    public void SettingsSignActivate()
    {
        settingsSign.SetActive(false);
        settingsSign.SetActive(true);
    }

    public void SettingsSignDeActivate()
    {
        settingsSignAnimator.Play(settingsSignSlideOut, 0, 0.0f);
        StartCoroutine(SettingsSignExit());
    }

    IEnumerator SettingsSignExit()
    {
        yield return new WaitForSeconds(1.2f);

        settingsSign.SetActive(false);

    }
    public void ControlSignActivate()
    {
        
        controlsSign.SetActive(false);
        controlsSign.SetActive(true);
    }

    public void ControlSignDeActivate()
    {
        controlSignAnimator.Play(controlSignSlideOut);
        StartCoroutine(ControlSignDeActivateDelay());
    }

    IEnumerator ControlSignDeActivateDelay()
    {
        yield return new WaitForSeconds(1.2f);
        controlsSign.SetActive(false);
    }

    public void MusicCheckBox()
    {
        Debug.Log("The Button has been diddled");

        if (scenePersist.musicCheck)
        {
            scenePersist.musicCheck = false;
            xCheck.SetActive(false);
            audioManager.StopMusic();
            Debug.Log("Music is TURNED OFF");
        }
        else
        {
            scenePersist.musicCheck = true;
            xCheck.SetActive(true);
            audioManager.PlayMusic();
            Debug.Log("MUSIC IS HOPEFULLY TURNED *on*");

        }


    }



}
