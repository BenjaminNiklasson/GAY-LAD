using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    Globals globals;
    UIManager uiManager;
    ScenePersist sp;
    int nextLevel;

    private void Start()
    {
        sp = GameObject.FindGameObjectWithTag("ScenePersist").GetComponent<ScenePersist>();
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        globals = GameObject.FindGameObjectWithTag("Globals").GetComponent<Globals>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (nextLevel >= SceneManager.sceneCountInBuildSettings)
            {
                uiManager.FadeToBlack();
                Cursor.lockState = CursorLockMode.None;
                globals.BackToMainMenu();
            }
            else
            {
                NextLevel();
            }
        }
    }

    public void NextLevel()
    {
        globals.playerMovement.rb.linearVelocity = Vector3.zero;
        globals.playerMovement.enabled = false;
        sp.UnlockLevel(nextLevel);
        globals.StartLevel(nextLevel);
    }
}
