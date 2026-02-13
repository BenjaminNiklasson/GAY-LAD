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
    void Awake()
    {
        Time.timeScale = 1f;
        Invoke("DelayedStart", 0.1f);
    }

    void DelayedStart()
    {
        Debug.Log("Delayed!!!!");
        Time.timeScale = 1f;
        globals = GameObject.FindGameObjectWithTag("Globals").GetComponent<Globals>();
        scenePersist = GameObject.FindGameObjectWithTag("ScenePersist").GetComponent<ScenePersist>();
        globals.deaths = scenePersist.deaths;
        if (globals.deaths == 0)
        {
            globals.respawnPoint = globals.currentPlayer.transform.position;
        }

        globals.currentPlayer.transform.position = globals.respawnPoint;
        
        globals.playerMovement = globals.currentPlayer.GetComponent<PlayerMovement>();
        globals.gun = GameObject.FindGameObjectWithTag("Gun");

        
        scenePersist.enabled = true;
        scenePersist.NewScene();

        globals.lr = globals.gameObject.GetComponent<LineRenderer>();
        globals.lr.enabled = false;

        globals.UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        globals.UIManager.fadeInBlackImage = GameObject.FindGameObjectWithTag("BlackCanvas").transform.GetChild(0).gameObject;
        globals.UIManager.fadeOutBlackImage = GameObject.FindGameObjectWithTag("BlackCanvas").transform.GetChild(1).gameObject;

        globals.currentPlayer.GetComponent<PlayerMovement>().playerControls.Enable();
    }
}
