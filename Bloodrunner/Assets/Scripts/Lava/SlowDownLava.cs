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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Lava") && lavaSlowed == false)
        {
            lavaRise.lavaRiseSpeed = lavaRiseSpeedOriginal;
            lavaSlowed = true;
        }
    }
}
