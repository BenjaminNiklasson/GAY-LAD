using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    Globals globals;
    UIManager uiManager;
    [SerializeField] string nextLevel;

    private void Start()
    {
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
