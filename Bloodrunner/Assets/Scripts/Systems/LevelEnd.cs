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
        sp.levelsAccessed[SceneManager.GetActiveScene().buildIndex-1] = true;
        Time.timeScale = 0;
        uiManager.FadeToBlack();
        globals.StartLevel(nextLevel);
    }
}
