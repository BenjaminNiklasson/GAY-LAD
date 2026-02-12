using UnityEngine;

public class BirdManager : MonoBehaviour
{
    public ScenePersist scenePersist;

    public GameObject bird1;
    public GameObject bird2;
    public GameObject bird3;
    public GameObject bird4;
    public GameObject bird5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (scenePersist.bird1Found)
        {
            bird1.SetActive(true);
        }
        if (scenePersist.bird2Found)
        {
            bird2.SetActive(true);
        }
        if (scenePersist.bird3Found)
        {
            bird3.SetActive(true);
        }
        if (scenePersist.bird4Found)
        {
            bird4.SetActive(true);
        }
        if (scenePersist.bird1Found && scenePersist.bird2Found && scenePersist.bird3Found && scenePersist.bird4Found)
        {
            bird5.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
