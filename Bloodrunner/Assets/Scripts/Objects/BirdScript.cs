using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField] int birdID;
    ScenePersist sp;
    private void Start()
    {
        sp = GameObject.FindGameObjectWithTag("ScenePersist").GetComponent<ScenePersist>();
        if (sp.birdsFound[birdID] == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        sp.birdsFound[birdID] = true;
        Destroy(gameObject);
    }
}
