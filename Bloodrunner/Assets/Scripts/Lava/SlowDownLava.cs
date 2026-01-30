using UnityEngine;

public class SlowDownLava : MonoBehaviour
{
    LavaRise lavaRise;
    float lavaRiseSpeedOriginal;
    bool lavaSlowed = false;
    private void Start()
    {
        lavaRise = GameObject.FindWithTag("Lava").GetComponent<LavaRise>();
        lavaRiseSpeedOriginal = lavaRise.lavaRiseSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Lavahit!");
        if (other.transform.CompareTag("Lava") && lavaSlowed == false)
        {
            lavaRise.lavaRiseSpeed = lavaRiseSpeedOriginal;
            lavaSlowed = true;
        }
    }
}
