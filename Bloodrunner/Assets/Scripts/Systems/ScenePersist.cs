using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    static GameObject instance = null;
    public int deaths { get; set; }
    public AudioManager audioManager;
    public bool musicCheck = true;

    public bool[] birdsFound { get; set; } = { false, false, false, false, false, };

    public int birdsSaved { get; set; } = 0;
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

    private GameObject Persist(GameObject gO, string tag)
    {
        if (gO == null)
        {
            gO = GameObject.FindGameObjectWithTag(tag);
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
