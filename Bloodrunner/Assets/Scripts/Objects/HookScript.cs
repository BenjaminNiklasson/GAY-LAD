using UnityEngine;

public class HookScript : MonoBehaviour
{
    Globals globals;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globals = GameObject.FindGameObjectWithTag("Globals").GetComponent<Globals>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CrossHair"))
        {
            globals.seeHook = true;
            globals.hookSeen = gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CrossHair"))
        {
            globals.seeHook = false;
            globals.hookSeen = null;
        }
    }
}
