using UnityEngine;

public class LavaRise : MonoBehaviour
{
    [SerializeField] public float lavaRiseSpeed = 1f;
    [SerializeField] float lavaRiseDelay = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Rise", lavaRiseDelay);
    }


    void Rise()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + lavaRiseSpeed, transform.position.z);
        Invoke("Rise", lavaRiseDelay);
    }
}
