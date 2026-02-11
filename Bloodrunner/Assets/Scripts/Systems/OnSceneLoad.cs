using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Profiling;

public class OnSceneLoad : MonoBehaviour
{
    Globals globals;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globals = GameObject.FindGameObjectWithTag("Globals").GetComponent<Globals>();
        
        if (globals.deaths == 0)
        {
            globals.respawnPoint = globals.currentPlayer.transform.position;
        }

        globals.currentPlayer.transform.position = globals.respawnPoint;
        
        globals.playerMovement = globals.currentPlayer.GetComponent<PlayerMovement>();
        globals.lr = globals.currentPlayer.GetComponent<LineRenderer>();
        globals.gun = GameObject.FindGameObjectWithTag("Gun");
    }
}
