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
        if (scenePersist.birdsFound[0])
        {
            bird1.SetActive(true);
        }
        if (scenePersist.birdsFound[1])
        {
            bird2.SetActive(true);
        }
        if (scenePersist.birdsFound[2])
        {
            bird3.SetActive(true);
        }
        if (scenePersist.birdsFound[3])
        {
            bird4.SetActive(true);
        }
        if (scenePersist.birdsFound[4])
        {
            bird5.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
