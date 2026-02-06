using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    GameObject scenePersist;
    public Transform respawnPoint { get; set; }

    private void Awake()
    {
        if (scenePersist == null)
        {
            scenePersist = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
