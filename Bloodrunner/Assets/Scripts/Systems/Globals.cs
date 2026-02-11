using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Globals : MonoBehaviour
{
    public UIManager UIManager;
    public GameObject globalsInstance { get; set; }
    public float startLevelDelay = 2f;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] public GameObject currentPlayer;
    
    public bool seeHook { get; set; } = false;
    public static bool isPaused { get; set; } = false;
    public GameObject hookSeen { get; set; }
    public Vector3 respawnPoint { get; set; }
    public int deaths { get; set; } = 0;

    public PlayerMovement playerMovement { get; set; }
    public GameObject gun { get; set; }
    bool swinging = false;
    SpringJoint joint;
    public GameObject hook;
    [SerializeField] float jointSpring = 4.5f;
    [SerializeField] float jointDamper = 7f;
    [SerializeField] float jointMassScale = 4.5f;
    [SerializeField] float swingPush = 3;
    [SerializeField] float swingSpeed = 3;
    public LineRenderer lr { get; set; }
    Transform[] lrPoints;

    
    //Game stuff
    public void Start()
    {

        Physics.IgnoreLayerCollision(3, 0);

    }

    private void Update()
    {
        if (swinging)
        {
            DrawRope(gun.transform.GetChild(0).GetChild(0).position, hook.transform.position);
        }
    }
    public void DrawRope(Vector3 start, Vector3 stop)
    {
        lr.SetPosition(0, start);
        lr.SetPosition(1, stop);
    }
    public void PlayerDeathGlobal()
    {
        UIManager.FadeToBlack();
        Time.timeScale = 0f;
        StartCoroutine(DeathRestart());
       
    }
    IEnumerator DeathRestart()
    {
        Debug.Log("Rat");
        yield return new WaitForSecondsRealtime(2f);
        deaths++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Swinging()
    {
        hook = hookSeen;
        hook.GetComponent<HookScript>().hooked = true;
        swinging = true;
        playerMovement.swinging = true;
        playerMovement.playerSpeed = playerMovement.playerSpeed * swingSpeed;
        joint = currentPlayer.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = hook.transform.position;

        float distanceFromPoint = Vector3.Distance(currentPlayer.transform.position, hook.transform.position);

        joint.maxDistance = distanceFromPoint * 0.25f;
        joint.minDistance = distanceFromPoint * 0.8f;

        joint.spring = jointSpring;
        joint.damper = jointDamper;
        joint.massScale = jointMassScale;

        playerMovement.rb.linearVelocity = playerMovement.rb.linearVelocity * swingPush;

        lr.enabled = true;
        lr.positionCount = 2;
        DrawRope(gun.transform.GetChild(0).GetChild(0).position, hook.transform.position);
    }
    public void StopSwing()
    {
        lr.enabled = false;
        hook.GetComponent<HookScript>().hooked = false;
        playerMovement.swinging = false;
        playerMovement.playerSpeed = playerMovement.playerSpeed / swingSpeed;
        Destroy(currentPlayer.GetComponent<SpringJoint>());
        gun.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    //UI stuff
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
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}