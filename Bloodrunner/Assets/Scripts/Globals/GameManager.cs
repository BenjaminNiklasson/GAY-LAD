using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //PlayerPrefs.SetInt("Name", (yourBool? 1 : 0));
    //yourBool = (PlayerPrefs.GetInt("Name") != 0);

    public float restartDelay = 1f;



    public void StartLevelOne()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void StartLevelTwo()
    {
        SceneManager.LoadScene("Level_2");
    }
    public void StartLevelThree()
    {
        SceneManager.LoadScene("Level_3");
    }
    public void StartLevelFour()
    {
        SceneManager.LoadScene("Level_4");
    }
    

    public void ExitGame () 
        {
        Application.Quit();
        Debug.Log("The application has been quit (Hopefully)");
        }


    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
