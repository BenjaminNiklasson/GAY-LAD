using UnityEngine;

public class LavaRise : MonoBehaviour
{
    [SerializeField] public float lavaRiseSpeed = 1f;
    [SerializeField] float lavaRiseDelay = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("Rise", lavaRiseDelay);
        }
    }

    void Rise()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + lavaRiseSpeed, transform.position.z);
        Invoke("Rise", lavaRiseDelay);
    }
}
