using Unity.Cinemachine;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public Vector3 respawnPoint { get; set; }
    [SerializeField] GameObject playerPrefab;
    public GameObject currentPlayer { get; set; }
    public void PlayerDeath()
    {
        currentPlayer.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        currentPlayer.transform.position = respawnPoint;
    }
}