using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Profiling;

public class OnSceneLoad : MonoBehaviour
{
    Globals globals;
    ScenePersist scenePersist;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("DelayedStart", 0.1f);
    }

    void DelayedStart()
    {
        Time.timeScale = 1f;
        globals = GameObject.FindGameObjectWithTag("Globals").GetComponent<Globals>();
        
        if (globals.deaths == 0)
        {
            globals.respawnPoint = globals.currentPlayer.transform.position;
        }

        globals.currentPlayer.transform.position = globals.respawnPoint;
        
        globals.playerMovement = globals.currentPlayer.GetComponent<PlayerMovement>();
        globals.gun = GameObject.FindGameObjectWithTag("Gun");

        scenePersist = GameObject.FindGameObjectWithTag("ScenePersist").GetComponent<ScenePersist>();
        scenePersist.enabled = true;
        scenePersist.NewScene();

        globals.lr = globals.gameObject.GetComponent<LineRenderer>();
        globals.lr.enabled = false;
    }
}
