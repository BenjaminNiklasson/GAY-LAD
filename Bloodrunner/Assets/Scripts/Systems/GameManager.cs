using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //PlayerPrefs.SetInt("Name", (yourBool? 1 : 0));
    //yourBool = (PlayerPrefs.GetInt("Name") != 0);


    public UIManager uiManager;

    public float startLevelDelay = 2f;

   


    //Starts a coroutine for timing.
    public void StartLevel(string sceneName)
    {

        StartCoroutine(StartLevelRoutine(sceneName));
    }

    //Starts the StartLevelRoutine.
    IEnumerator StartLevelRoutine(string sceneName)
    {
        //Calls the ui Manager to trigger the fade to black effect.
        uiManager.FadeToBlack();


        //Waits the amount of time designated at the startLevelDelay float variable.
        yield return new WaitForSeconds(startLevelDelay);

        SceneManager.LoadScene(sceneName);
    }




    public void ExitGame () 
        {
        Application.Quit();
        Debug.Log("The application has been quit (Hopefully)");
        }


  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
      

    }
}
