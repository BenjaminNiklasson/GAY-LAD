using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public Vector3 respawnPoint { get; set; }
    [SerializeField] GameObject playerPrefab;
    [SerializeField] public GameObject currentPlayer;
    [SerializeField] GameObject playerLavaLight;
    public bool seeHook { get; set; } = false;
    public GameObject hookSeen { get; set; }

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