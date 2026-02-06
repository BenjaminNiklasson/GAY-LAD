using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Globals : MonoBehaviour
{
    public UIManager UIManager;

    public string currentScene;

    public Vector3 respawnPoint { get; set; }
    [SerializeField] GameObject playerPrefab;
    [SerializeField] public GameObject currentPlayer;
    [SerializeField] GameObject playerLavaLight;
    public bool seeHook { get; set; } = false;
    public static bool isPaused { get; set; } = false;

    public GameObject hookSeen { get; set; }

    public void Start()
    {
        Physics.IgnoreLayerCollision(3, 0);

        currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Main Menu")
        {
            UIManager.FadeInUI();
        }
       
        
    }

    

    public void PlayerDeathGlobal()
    {
        currentPlayer.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        currentPlayer.transform.position = respawnPoint;
    }



    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        UIManager.PauseGameUIOn();
        isPaused = true;
        Time.timeScale = 0f;

    }
    public void UnpauseGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        UIManager.PauseGameUIOff();
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Update()
    {
       
    }

}