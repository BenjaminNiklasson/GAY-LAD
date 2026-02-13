using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField] int birdID;
    Globals globals;

    private void Start()
    {
        globals = GameObject.FindGameObjectWithTag("Globals").GetComponent<Globals>();
        if (globals.birdsFound[birdID] == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        globals.birdsFound[birdID] = true;
        Destroy(gameObject);
    }
}
