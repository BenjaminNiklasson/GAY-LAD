using UnityEngine;

public class SlowDownLava : MonoBehaviour
{
    LavaRise lavaRise;
    [SerializeField] float lavaRiseSlowing = 3;
    bool lavaSlowed = false;
    private void Start()
    {
        lavaRise = GameObject.FindWithTag("Lava").GetComponent<LavaRise>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Lavahit!");
        if (other.transform.CompareTag("Lava") && lavaSlowed == false)
        {
            lavaRise.lavaRiseSpeed = lavaRise.lavaRiseSpeed/lavaRiseSlowing;
            lavaSlowed = true;
        }
    }
}
