using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] GameObject boom;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("Player"))
        {
            Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
