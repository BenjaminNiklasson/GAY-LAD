using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    Globals globals;
    UIManager uiManager;
    int nextLevel;
    ScenePersist sp;

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
            NextLevel();
        }
    }

    public void NextLevel()
    {
        globals.currentPlayer.GetComponent<Rigidbody>().linearVelocity = new Vector3();
        globals.playerMovement.enabled = false;
        sp.levelsAccessed[SceneManager.GetActiveScene().buildIndex-1] = true;
        uiManager.FadeToBlack();
        globals.StartLevel(nextLevel);
    }
}
