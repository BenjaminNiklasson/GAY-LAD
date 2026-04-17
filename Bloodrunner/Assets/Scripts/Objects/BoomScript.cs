using UnityEngine;
using UnityEngine.Rendering;

public class BoomScript : MonoBehaviour
{
    [SerializeField] float destroyDelay = 1.5f;
    [SerializeField] float force = 20f;
    void Start()
    {
        Invoke("DestroySelf", destroyDelay);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody rb = player.GetComponent<Rigidbody>();
        Vector3 direction = (player.transform.position - transform.position).normalized;
        float distance = Vector3.Distance(player.transform.position, transform.position);
        float multi = force - distance;
        if (multi < 0)
        {
            multi = 0;
        }
        rb.linearVelocity = direction * multi;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
