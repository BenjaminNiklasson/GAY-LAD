using UnityEngine;

public class SpeedUpLava : MonoBehaviour
{
    LavaRise lavaRise;
    float lavaRiseSpeedOriginal;
    [SerializeField] float lavaAcceleration = 3f;
    bool spedUp = false;
    private void Start()
    {
        lavaRise = GameObject.FindWithTag("Lava").GetComponent<LavaRise>();
        lavaRiseSpeedOriginal = lavaRise.lavaRiseSpeed;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player") && spedUp == false)
        {
            lavaRise.lavaRiseSpeed = lavaRiseSpeedOriginal * lavaAcceleration;
            spedUp = true;
        }
    }
}
