using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Globals : MonoBehaviour
{
    public UIManager UIManager;
    private GameObject globals;
    public float startLevelDelay = 2f;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] public GameObject currentPlayer;
    
    public bool seeHook { get; set; } = false;
    public static bool isPaused { get; set; } = false;
    public GameObject hookSeen { get; set; }
    public Vector3 respawnPoint { get; set; }
    public int deaths { get; set; } = 0;

    private void Awake()
    {
        if (globals == null)
        {
            globals = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        if(deaths == 0)
        {
            respawnPoint = currentPlayer.transform.position;
        }

        currentPlayer.transform.position = respawnPoint;

        Physics.IgnoreLayerCollision(3, 0);
    }

    public void PlayerDeathGlobal()
    {
        deaths++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            UIManager.PauseGameUIOn();
            isPaused = true;
            Time.timeScale = 0f;
        }

    }
    public void UnpauseGame()
    {
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            UIManager.PauseGameUIOff();
            Time.timeScale = 1f;
        }
    }

    public void PauseOrUnpauseGame()
    {
        if (isPaused)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }
    }

    public void StartLevel(string sceneName)
    {
        StartCoroutine(StartLevelRoutine(sceneName));
    }

    //Starts the StartLevelRoutine.
    IEnumerator StartLevelRoutine(string sceneName)
    {
        //Calls the ui Manager to trigger the fade to black effect.
        UIManager.FadeToBlack();

        //Waits the amount of time designated at the startLevelDelay float variable.
        yield return new WaitForSeconds(startLevelDelay);
        deaths = 0;
        SceneManager.LoadScene(sceneName);
    }

}