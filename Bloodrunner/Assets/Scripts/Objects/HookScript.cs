using UnityEngine;

public class HookScript : MonoBehaviour
{
    Globals globals;
    MeshRenderer renderer;
    MeshFilter mFilter;
    [SerializeField] Material baseMat;
    [SerializeField] Material glowMat;
    [SerializeField] Mesh standardMesh;
    [SerializeField] Mesh hookedMesh;
    public bool hooked { get; set; } = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mFilter = GetComponent<MeshFilter>();
        renderer = GetComponent<MeshRenderer>();
        globals = GameObject.FindGameObjectWithTag("Globals").GetComponent<Globals>();
    }

    private void Update()
    {
        if (hooked && mFilter.mesh != hookedMesh)
        {
            mFilter.mesh = hookedMesh;
        }
        else if(!hooked && mFilter.mesh != standardMesh)
        {
            mFilter.mesh = standardMesh;
        }
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
