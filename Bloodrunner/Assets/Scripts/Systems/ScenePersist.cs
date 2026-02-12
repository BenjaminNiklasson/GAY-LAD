using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    static GameObject instance = null;
    public int deaths { get; set; }
    public AudioManager audioManager;
    public bool musicCheck = true;

    public bool bird1Found { get; set; } = false;
    public bool bird2Found { get; set; } = false;
    public bool bird3Found { get; set; } = false;
    public bool bird4Found { get; set; } = false;

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
