using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Globals : MonoBehaviour
{
    public UIManager UIManager;

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
        Time.timeScale = 0f;
        isPaused = true;
        
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