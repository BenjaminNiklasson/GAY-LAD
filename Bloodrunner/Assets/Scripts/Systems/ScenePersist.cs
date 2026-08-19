using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    static GameObject instance = null;
    public int deaths { get; set; }
    public AudioManager audioManager;
    public bool musicCheck = true;

    public bool[] birdsFound { get; set; } = { false, false, false, false, false, };
    public int birdsSaved { get; set; } = 0;

    private bool[] levelsAccessed { get; set; } = { true, true, false, false };

    public int levels { get { return levelsAccessed.Count(); } }

    public void AddBirdFound()
    {
        birdsSaved += 1;
    }
    private void Awake()
    {
        gameObject.GetComponent<ScenePersist>().enabled = true;
        NewScene();
    }
    public void NewScene()
    {
        instance = Persist(instance, "ScenePersist");
    }

    public void UnlockLevel(int levelName)
    {
        levelsAccessed[levelName] = true;
    }

    public bool LevelUnlocked(int levelName)
    {
        return levelsAccessed[levelName];
    }

    private GameObject Persist(GameObject gO, string tag)
    {
        if (gO == null)
        {
            gO = gameObject;
            DontDestroyOnLoad(gO);
        }
        else
        {
            List<GameObject> toDestroy = GameObject.FindGameObjectsWithTag(tag).Where(x => x != gO).ToList();
            for (int i = 0; i < toDestroy.Count; i++)
            {
                Destroy(toDestroy[i]);
            }
        }

        return gO;
    }
}
