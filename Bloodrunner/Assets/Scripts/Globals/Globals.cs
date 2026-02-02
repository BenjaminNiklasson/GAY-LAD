using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public Vector3 respawnPoint { get; set; }
    [SerializeField] GameObject playerPrefab;
    public GameObject currentPlayer { get; set; }

    public void Start()
    {
        Physics.IgnoreLayerCollision(3, 0);
    }

    public void PlayerDeathGlobal()
    {
        currentPlayer.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        currentPlayer.transform.position = respawnPoint;
    }
}