using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    static GameObject instance;
    static GameObject globalsInstance;
    static GameObject UIManagerInstance;
    static GameObject PMCanvasInstance;
    static GameObject VProfile;
    static GameObject BlackCanvas;
    static GameObject EventSystem;

    private void Awake()
    {
        if (instance == null)
        {
            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (globalsInstance == null)
        {
            globalsInstance = GameObject.FindGameObjectWithTag("Globals"); ;
            DontDestroyOnLoad(globalsInstance);
        }
        else
        {
            List<GameObject> toDestroy = GameObject.FindGameObjectsWithTag("Globals").Where(x => x != globalsInstance).ToList();
            for (int i = 0; i < toDestroy.Count; i++)
            {
                Destroy(toDestroy[i]);
            }
        }

        if (UIManagerInstance == null)
        {
            UIManagerInstance = GameObject.FindGameObjectWithTag("UIManager");
            DontDestroyOnLoad(UIManagerInstance);
        }
        else
        {
            List<GameObject> toDestroy = GameObject.FindGameObjectsWithTag("UIManager").Where(x => x != UIManagerInstance).ToList();
            for (int i = 0; i < toDestroy.Count; i++)
            {
                Destroy(toDestroy[i]);
            }
        }

        if (PMCanvasInstance == null)
        {
            PMCanvasInstance = GameObject.FindGameObjectWithTag("PMCanvas");
            DontDestroyOnLoad(PMCanvasInstance);
        }
        else
        {
            List<GameObject> toDestroy = GameObject.FindGameObjectsWithTag("PMCanvas").Where(x => x != PMCanvasInstance).ToList();
            for (int i = 0; i < toDestroy.Count; i++)
            {
                Destroy(toDestroy[i]);
            }
        }

        if (VProfile == null)
        {
            VProfile = GameObject.FindGameObjectWithTag("VProfile");
            DontDestroyOnLoad(VProfile);
        }
        else
        {
            List<GameObject> toDestroy = GameObject.FindGameObjectsWithTag("VProfile").Where(x => x != VProfile).ToList();
            for (int i = 0; i < toDestroy.Count; i++)
            {
                Destroy(toDestroy[i]);
            }
        }

        if (BlackCanvas == null)
        {
            BlackCanvas = GameObject.FindGameObjectWithTag("BlackCanvas");
            DontDestroyOnLoad(BlackCanvas);
        }
        else
        {
            List<GameObject> toDestroy = GameObject.FindGameObjectsWithTag("BlackCanvas").Where(x => x != BlackCanvas).ToList();
            for (int i = 0; i < toDestroy.Count; i++)
            {
                Destroy(toDestroy[i]);
            }
        }

        if (EventSystem == null)
        {
            EventSystem = GameObject.FindGameObjectWithTag("EventSystem");
            DontDestroyOnLoad(EventSystem);
        }
        else
        {
            List<GameObject> toDestroy = GameObject.FindGameObjectsWithTag("EventSystem").Where(x => x != EventSystem).ToList();
            for (int i = 0; i < toDestroy.Count; i++)
            {
                Destroy(toDestroy[i]);
            }
        }
    }
}
