using UnityEngine;

public class HookScript : MonoBehaviour
{
    Globals globals;
    MeshRenderer renderer;
    [SerializeField] Material baseMat;
    [SerializeField] Material glowMat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        globals = GameObject.FindGameObjectWithTag("Globals").GetComponent<Globals>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CrossHair"))
        {
            globals.seeHook = true;
            globals.hookSeen = gameObject;
            renderer.material = glowMat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CrossHair"))
        {
            globals.seeHook = false;
            globals.hookSeen = null;
            renderer.material = baseMat;
        }
    }
}
