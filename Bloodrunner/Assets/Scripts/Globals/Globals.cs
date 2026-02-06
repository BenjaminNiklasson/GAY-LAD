using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Globals : MonoBehaviour
{
    public UIManager UIManager;

    public string currentScene;

    
    [SerializeField] GameObject playerPrefab;
    [SerializeField] public GameObject currentPlayer;
    [SerializeField] GameObject playerLavaLight;
    public bool seeHook { get; set; } = false;
    public static bool isPaused { get; set; } = false;

    public GameObject hookSeen { get; set; }

    private GameObject scenePersist { get; set; }
    public Vector3 respawnPoint { get { return scenePersist.GetComponent<ScenePersist>().respawnPoint; } set { scenePersist.GetComponent<ScenePersist>().respawnPoint = value;  } }

    public void Start()
    {
        Physics.IgnoreLayerCollision(3, 0);

        currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Main Menu")
        {
            UIManager.FadeInUI();
        }

        scenePersist = GameObject.FindGameObjectWithTag("ScenePersist");
    }

    

    public void PlayerDeathGlobal()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    public void Update()
    {
       
    }

}