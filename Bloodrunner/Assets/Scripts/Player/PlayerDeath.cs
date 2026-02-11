using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    public UIManager UIManager;


    Globals globals;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globals = GameObject.FindWithTag("Globals").GetComponent<Globals>();
        globals.respawnPoint = transform.position;
        globals.currentPlayer = gameObject;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Lava"))
        {
            globals.PlayerDeathGlobal();
        }
    }
}
