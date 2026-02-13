using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    Globals globals;
    UIManager uiManager;
    int nextLevel;

    private void Start()
    {
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
        uiManager.FadeToBlack();
        globals.StartLevel(nextLevel);
    }
}
