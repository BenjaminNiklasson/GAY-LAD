using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    static GameObject instance = null;
    //static GameObject globalsInstance = null;
    //static GameObject PMCanvasInstance = null;
    //static GameObject VProfile = null;
    public int deaths { get; set; }
    public AudioManager audioManager;
    public bool musicCheck;

    private void Awake()
    {
        gameObject.GetComponent<ScenePersist>().enabled = true;
        NewScene();
    }

    public void NewScene()
    {
        instance = Persist(instance, "ScenePersist");
        //globalsInstance = Persist(globalsInstance, "Globals");
        //PMCanvasInstance = Persist(PMCanvasInstance, "PMCanvas");
        //VProfile = Persist(VProfile, "VProfile");
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
