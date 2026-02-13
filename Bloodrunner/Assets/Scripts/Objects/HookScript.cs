using UnityEngine;

public class HookScript : MonoBehaviour
{
    Globals globals;
    MeshRenderer renderer;
    [SerializeField] Material baseMat;
    [SerializeField] Material glowMat;
    public bool hooked { get; set; } = false;

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
            globals.hookSeen = gameObject;
            renderer.material = glowMat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CrossHair"))
        {
            if (globals.hookSeen == gameObject)
            {
                globals.hookSeen = null;
            }
            renderer.material = baseMat;
        }
    }
}
